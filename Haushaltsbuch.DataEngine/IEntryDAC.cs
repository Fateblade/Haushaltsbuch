using ACI.Base.DB;
using Haushaltsbuch.Models;

namespace Haushaltsbuch.DataEngine
{
    public interface IEntryDAC : IGenericDAC<Entry>, IGenericEditableDAC<Entry>, IGenericListDAC<Entry>
    {
    }
}
