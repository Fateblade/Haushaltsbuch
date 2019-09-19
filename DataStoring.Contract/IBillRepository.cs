using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;
using Fateblade.Haushaltsbuch.Data.DataStoring.Contract.Exceptions;
using System.Linq;

namespace Fateblade.Haushaltsbuch.Data.DataStoring.Contract
{
    [MapException(typeof(DataStoringException), "Unbekannter Fehler beim Datenzugriff auf Rechnungen")]
    public interface IBillRepository
    {
        [ExceptionMessage("Fehler bei der Rechnungsabfrage")]
        IQueryable<Bill> Query { get; }

        [ExceptionMessage("Fehler beim Hinzufügen einer Rechnung")]
        void Add(Bill bill);

        [ExceptionMessage("Fehler beim Aktualisieren einer Rechnung")]
        void Update(Bill bill);

        [ExceptionMessage("Fehler beim Löschen einer Rechnung")]
        void Delete(int id);
    }
}
