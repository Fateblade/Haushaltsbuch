using System.Linq;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;
using Fateblade.Haushaltsbuch.Logic.ItemManagement.Contract.Exceptions;

namespace Fateblade.Haushaltsbuch.Logic.ItemManagement.Contract
{
    [MapException(typeof(ItemManagementException), "Unbekannter Fehler beim Zugriff auf Gegenstände")]
    public interface IItemManager
    {
        [ExceptionMessage("Fehler beim Zugriff auf alle Gegenstände")]
        IQueryable<Item> GetItems();

        [ExceptionMessage("Fehler beim Zugriff auf einen bestimmten Gegenstand")]
        Item Get(int id);

        [ExceptionMessage("Fehler beim Hinzufügen eines Gegenstandes")]
        void Add(Item item);

        [ExceptionMessage("Fehler beim Löschen eines Gegenstandes")]
        void Delete(int id);

        [ExceptionMessage("Fehler beim Aktualisieren eines Gegenstandes")]
        void Update(Item item);
    }
}
