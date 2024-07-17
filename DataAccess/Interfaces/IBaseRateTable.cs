using DataAccess.Enums;

namespace DataAccess.Interfaces
{
    public interface IBaseRateTable
    {
        Dictionary<NCB, decimal> GetBaseRateTable();
    }
}