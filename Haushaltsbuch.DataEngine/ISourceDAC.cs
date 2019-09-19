using ACI.Base.DB;
using Haushaltsbuch.Models;

namespace Haushaltsbuch.DataEngine
{
    public interface ISourceDAC : IGenericDAC<Source>, IGenericEditableDAC<Source>, IGenericListDAC<Source>
    {
    }
}
