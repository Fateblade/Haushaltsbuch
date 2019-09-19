using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;
using Fateblade.Haushaltsbuch.Data.DataStoring.Contract.Exceptions;
using System.Linq;

namespace Fateblade.Haushaltsbuch.Data.DataStoring.Contract
{
    [MapException(typeof(DataStoringException), "Unbekannter Fehler beim Datenzugriff auf Quellen")]
    public interface ISourceRepository
    {
        [ExceptionMessage("Fehler bei der Quellenabfrage")]
        IQueryable<Source> Query { get; }

        [ExceptionMessage("Fehler beim Hinzufügen einer Quelle")]
        void Add(Source source);

        [ExceptionMessage("Fehler beim Aktualisieren einer Quelle")]
        void Update(Source source);

        [ExceptionMessage("Fehler beim Löschen einer Quelle")]
        void Delete(int id);
        
    }
}
