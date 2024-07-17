using DataAccess.Enums;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface ICalculation
    {
        decimal CalculateBaseRate(NCB ncb);
        decimal CalculateClaimsRate(List<MotorClaim> motorClaims, NCB ncb);
        decimal CalculateDriversAge(NCB ncb, DriverAges driverAge);
        decimal CalculateMinimumPremium(NCB ncb);
        decimal CalculateMotorConvictions(int motorConvictions);
        decimal CalculateVehicleSeatsRate(Vehicle vehicle);
        decimal CalculateVehicleTransmissionRate(VehicleTransmission vehicleTransmission);
        decimal CalculateVehicleUse(VehicleUse vehicleUse);
        decimal CalculateVehicleValue(Vehicle vehicle);
    }
}