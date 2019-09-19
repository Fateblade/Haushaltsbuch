using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;
using Fateblade.Haushaltsbuch.Data.DataStoring.Contract.Exceptions;
using System.Linq;

namespace Fateblade.Haushaltsbuch.Data.DataStoring.Contract
{
    [MapException(typeof(DataStoringException), "Unbekannter Fehler beim Datenzugriff auf Gegenstände")]
    public interface IItemRepository
    {
        [ExceptionMessage("Fehler bei der Gegenstandsabfrages")]
        IQueryable<Item> Query { get; }

        [ExceptionMessage("Fehler beim Hinzufügen eines Gegenstandes")]
        void Add(Item item);

        [ExceptionMessage("Fehler beim Aktualisieren eines Gegenstandes")]
        void Update(Item item);

        [ExceptionMessage("Fehler beim Löschen eines Gegenstandes")]
        void Delete(int id);
    }
}
