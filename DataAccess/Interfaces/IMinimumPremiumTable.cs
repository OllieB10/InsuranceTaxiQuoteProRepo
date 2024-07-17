using DataAccess.Enums;

namespace DataAccess.Interfaces
{
    public interface IMinimumPremiumTable
    {
        Dictionary<NCB, decimal> GetMinimumPremiumTable();
    }
}