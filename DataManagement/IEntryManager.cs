using System.Linq;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;
using Fateblade.Haushaltsbuch.Logic.EntryManagement.Contract.Exceptions;

namespace Fateblade.Haushaltsbuch.Logic.EntryManagement.Contract
{
    [MapException(typeof(EntryManagementException), "Unbekannter Fehler beim Zugriff auf Einträge")]
    public interface IEntryManager
    {
        [ExceptionMessage("Fehler beim Zugriff auf alle Einträge")]
        IQueryable<Entry> GetEntries();

        [ExceptionMessage("Fehler beim Zugriff auf einen bestimmten Eintrag")]
        Entry Get(int id);

        [ExceptionMessage("Fehler beim Hinzufügen eines Eintrags")]
        void Add(Entry entry);

        [ExceptionMessage("Fehler beim Löschen eines Eintrags")]
        void Delete(int id);

        [ExceptionMessage("Fehler beim Aktualisieren eines Eintrags")]
        void Update(Entry entry);
    }
}
