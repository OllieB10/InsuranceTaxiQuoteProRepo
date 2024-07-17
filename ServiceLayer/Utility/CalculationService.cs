using DataAccess.Enums;
using DataAccess.Models;
using ServiceLayer.Interfaces;
using DataAccess.Interfaces;

namespace ServiceLayer.Utility
{
    public class CalculationService : ICalculationService
    {
        private readonly ICalculation _calculation;

        public CalculationService(ICalculation calculation)
        {
           _calculation = calculation;
        }
        public decimal CalculateBaseRateService(NCB ncb)
        {
            return _calculation.CalculateBaseRate(ncb);
        }

        public decimal CalculateClaimsRateService(List<MotorClaim> motorClaims, NCB ncb)
        {
            return _calculation.CalculateClaimsRate(motorClaims, ncb);
        }

        public decimal CalculateDriversAgeService(NCB ncb, DriverAges driverAge)
        {
            return _calculation.CalculateDriversAge(ncb, driverAge);
        }

        public decimal CalculateMinimumPremiumService(NCB ncb)
        {
            return _calculation.CalculateMinimumPremium(ncb);
        }

        public decimal CalculateMotorConvictionsService(int motorConvictions)
        {
            return _calculation.CalculateMotorConvictions(motorConvictions);
        }

        public decimal CalculateVehicleSeatsRateService(Vehicle vehicle)
        {
            return _calculation.CalculateVehicleSeatsRate(vehicle);
        }

        public decimal CalculateVehicleTransmissionRateService(VehicleTransmission vehicleTransmission)
        {
            return _calculation.CalculateVehicleTransmissionRate(vehicleTransmission);
        }

        public decimal CalculateVehicleUseService(VehicleUse vehicleUse)
        {
            return _calculation.CalculateVehicleUse(vehicleUse);
        }

        public decimal CalculateVehicleValueService(Vehicle vehicle)
        {
            return _calculation.CalculateVehicleValue(vehicle);
        }
    }
}
