using DataAccess.Enums;

namespace DataAccess.Interfaces
{
    public interface IVehicleTransmissionTable
    {
        Dictionary<VehicleTransmission, decimal> GetVehicleTransmissionsTable();
    }
}