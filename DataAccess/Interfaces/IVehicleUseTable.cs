using DataAccess.Enums;

namespace DataAccess.Interfaces
{
    public interface IVehicleUseTable
    {
        Dictionary<VehicleUse, decimal> GetVehicleUseTable();
    }
}