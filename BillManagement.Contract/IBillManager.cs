using BillManagement.Contract.Exceptions;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;
using System.Linq;

namespace BillManagement.Contract
{
    [MapException(typeof(BillManagementException), "Unbekannter Fehler beim Zugriff auf die Rechnungen")]
    public interface IBillManager
    {
        [ExceptionMessage("Fehler beim Zugriff auf alle Rechnungen")]
        IQueryable<Bill> GetItems();

        [ExceptionMessage("Fehler beim Zugriff auf eine bestimmte Rechnung")]
        Bill Get(int id);

        [ExceptionMessage("Fehler beim Hinzufügen einer Rechnung")]
        void Add(Bill item);

        [ExceptionMessage("Fehler beim Löschen einer Rechnung")]
        void Delete(int id);

        [ExceptionMessage("Fehler beim Aktualisieren einer Rechnung")]
        void Update(Bill item);
    }
}
