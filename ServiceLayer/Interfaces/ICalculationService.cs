using DataAccess.Enums;
using DataAccess.Models;

namespace ServiceLayer.Interfaces
{
    public interface ICalculationService
    {
        decimal CalculateBaseRateService(NCB ncb);
        decimal CalculateClaimsRateService(List<MotorClaim> motorClaims, NCB ncb);
        decimal CalculateDriversAgeService(NCB ncb, DriverAges driverAge);
        decimal CalculateMinimumPremiumService(NCB ncb);
        decimal CalculateMotorConvictionsService(int motorConvictions);
        decimal CalculateVehicleSeatsRateService(Vehicle vehicle);
        decimal CalculateVehicleTransmissionRateService(VehicleTransmission vehicleTransmission);
        decimal CalculateVehicleUseService(VehicleUse vehicleUse);
        decimal CalculateVehicleValueService(Vehicle vehicle);
    }
}
