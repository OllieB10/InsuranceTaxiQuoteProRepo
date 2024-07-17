using DataAccess.Enums;

namespace DataAccess.Interfaces
{
    public interface ISeatsTable
    {
        Dictionary<VehicleSeats, decimal> GetSeatsTable();
    }
}