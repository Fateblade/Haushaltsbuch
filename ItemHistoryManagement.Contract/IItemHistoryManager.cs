using System.Linq;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;
using Fateblade.Haushaltsbuch.Logic.Domain.ItemHistoryManagement.Contract.Exceptions;

namespace Fateblade.Haushaltsbuch.Logic.Domain.ItemHistoryManagement.Contract
{
    [MapException(typeof(ItemHistoryManagementException), "Unbekannter Fehler beim Zugriff auf die Gegenstandshistorie")]
    public interface IItemHistoryManager
    {
        [ExceptionMessage("Fehler beim Abruf aller Gegenstandshistorien")]
        IQueryable<ItemHistory> GetItemHistories();

        [ExceptionMessage("Fehler beim Abruf der Historie eines Gegenstands")]
        IQueryable<ItemHistory> GetHistoryOfItem(int itemId);

        [ExceptionMessage("Fehler beim Abruf einer einzelnen Gegenstandshistorie")]
        ItemHistory Get(int historyId);

        [ExceptionMessage("Fehler beim Hinzufügen einer Gegenstandshistorie")]
        void Add(ItemHistory item);

        [ExceptionMessage("Fehler beim Löschen einer Gegenstandshistorie")]
        void Delete(int id);
    }
}
