using ACI.Base.DB;
using ACI.Base.Reflection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Haushaltsbuch.DataEngine
{
    public abstract class DataExecutionEngine<T> where T : IDataEntity
    {
        //members
        private static ConcurrentDictionary<Type, List<DBReflectionInfo>> _reflectionCache = new ConcurrentDictionary<Type, List<DBReflectionInfo>>();



        //properties
        public string ConnectionString { get; }




        //constructors
        public DataExecutionEngine()
        {
            ConnectionString = "Data Source=:memory:";
        }
        public DataExecutionEngine(string dbFilePath)
        {
            ConnectionString = $"URI=file: {dbFilePath}";
        }



        //public methods
        public void ExecuteStatementNonQuery(string statement, params SQLiteParameter[] parameters)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = statement;

                    addParamsToCommand(command, parameters);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
        public TScalar ExecuteScalarStatement<TScalar>(string statement, params SQLiteParameter[] parameters) 
            where TScalar : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T> //trying to limit it to primitive types
        {
            TScalar retVal;

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = statement;

                    addParamsToCommand(command, parameters);

                    retVal = (TScalar)command.ExecuteScalar();
                }

                connection.Close();
            }
            
            return retVal;
        }

        public T ExecuteStatementGetFirstRow(string statement, params SQLiteParameter[] parameters)
        {
            T retVal = default(T);

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = statement;

                    addParamsToCommand(command, parameters);

                    SQLiteDataReader reader = command.ExecuteReader();

                    reader.Read();
                    retVal = readRow(reader);
                }

                if (connection.State != System.Data.ConnectionState.Closed) { connection.Close(); }
            }

            return retVal;
        }


        public IEnumerable<T> ExecuteStatementGetList(string statement, params SQLiteParameter[] parameters)
        {
            List<T> retVal = new List<T>();

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = statement;

                    addParamsToCommand(command, parameters);

                    SQLiteDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        retVal.Add(readRow(reader));
                    }
                }

                if (connection.State != System.Data.ConnectionState.Closed) { connection.Close(); }
            }

            return retVal;
        }




        //private methods
        private void addParamsToCommand(SQLiteCommand command, params SQLiteParameter[] parameters)
        {
            if (parameters == null || command == null) { return; }
            
            foreach (SQLiteParameter param in parameters)
            {
                if (param.Direction == System.Data.ParameterDirection.Input)
                {
                    command.Parameters.Add(
                        new SQLiteParameter(
                            param.ParameterName,
                            param.DbType,
                            param.Size,
                            param.Direction,
                            param.Precision,
                            param.Scale,
                            param.SourceColumn,
                            param.SourceVersion,
                            param.SourceColumnNullMapping,
                            param.Value
                            )
                        );
                }
                else
                {
                    command.Parameters.Add(param);
                }
            }
        }

        private T readRow(SQLiteDataReader reader)
        {

            if (!_reflectionCache.ContainsKey(typeof(T)))
            {
                PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public);
                List<DBReflectionInfo> props = new List<DBReflectionInfo>();

                foreach (PropertyInfo property in properties)
                {
                    DBAttribute dbAttribute = property.GetCustomAttribute<DBAttribute>();
                    if (dbAttribute != null)
                    {
                        if (property.GetSetMethod() == null)
                        {
                            props.Add(new DBReflectionInfo(dbAttribute, ReflectionHelper.GetBackingField(property)));
                        }
                        else
                        {
                            props.Add(new DBReflectionInfo(dbAttribute, property));
                        }
                    }
                }

                _reflectionCache.TryAdd(typeof(T), props);
            }

            T retVal = default;
            if (_reflectionCache.TryGetValue(typeof(T), out List<DBReflectionInfo> informations))
            {
                retVal = Activator.CreateInstance<T>();
                foreach (DBReflectionInfo information in informations)
                {
                    object value = default;

                    try
                    {
                        value = Convert.ChangeType(reader[information.DBAttribute.QueryName], information.Property?.PropertyType ?? information.BackingField?.FieldType);
                    }
                    catch { }

                    if (value != default)
                    {
                        if (information.Property != null)
                        {
                            information.Property.SetValue(retVal, value);
                        }
                        else
                        {
                            information.BackingField.SetValue(retVal, value);
                        }
                    }
                }
            }

            return retVal;
        }
    }
}
