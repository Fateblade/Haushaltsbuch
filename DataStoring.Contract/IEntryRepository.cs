using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;
using Fateblade.Haushaltsbuch.Data.DataStoring.Contract.Exceptions;
using System.Linq;

namespace Fateblade.Haushaltsbuch.Data.DataStoring.Contract
{
    [MapException(typeof(DataStoringException), "Unbekannter Fehler beim Datenzugriff auf Rechnungseinträge")]
    public interface IEntryRepository
    {
        [ExceptionMessage("Fehler bei der Abfrage der Rechnungseinträge")]
        IQueryable<Entry> Query { get; }

        [ExceptionMessage("Fehler beim Hinzufügen von Rechnungseinträgen")]
        void Add(Entry entry);

        [ExceptionMessage("Fehler beim Aktualisieren von Rechnungseinträgen")]
        void Update(Entry entry);

        [ExceptionMessage("Fehler beim Löschen von Rechnungseinträgen")]
        void Delete(int id);
    }
}
