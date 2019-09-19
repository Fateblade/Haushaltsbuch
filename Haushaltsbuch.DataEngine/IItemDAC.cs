using ACI.Base.DB;
using Haushaltsbuch.Models;

namespace Haushaltsbuch.DataEngine
{
    public interface IItemDAC : IGenericDAC<Item>, IGenericEditableDAC<Item>, IGenericListDAC<Item>
    {
    }
}
