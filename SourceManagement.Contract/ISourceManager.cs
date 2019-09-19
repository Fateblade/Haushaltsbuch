using System.Linq;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;
using Fateblade.Haushaltsbuch.Logic.SourceManagement.Contract.Exceptions;

namespace Fateblade.Haushaltsbuch.Logic.SourceManagement.Contract
{
    [MapException(typeof(SourceManagementException),"Unbekannter Fehler beim Zugriff auf die Quellen")]
    public interface ISourceManager
    {
        [ExceptionMessage("Fehler beim Zugriff auf alle Quellen")]
        IQueryable<Source> GetSources();

        [ExceptionMessage("Fehler beim Zugriff auf eine bestimmte Quelle")]
        Source Get(int id);

        [ExceptionMessage("Fehler beim Hinzufügen einer Quelle")]
        void Add(Source source);

        [ExceptionMessage("Fehler beim Löschen einer Quelle")]
        void Delete(int id);

        [ExceptionMessage("Fehler beim Aktualisieren einer Quelle")]
        void Update(Source source);
    }
}
