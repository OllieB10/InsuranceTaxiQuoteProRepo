using DataAccess.Enums;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace ServiceLayer.Utility
{
    public class Calculation : ICalculation
    {
        private readonly IBaseRateTable _baseRateTable;
        private readonly IClaimsTable _claimsTable;
        private readonly IDriverAgeTable _driverAgeTable;
        private readonly IVehicleValueTable _vehicleValueTable;
        private readonly IVehicleUseTable _vehicleUseTable;
        private readonly IVehicleTransmissionTable _vehicleTransmissionTable;
        private readonly ISeatsTable _seatsTable;
        private readonly IMotorConvictionsTable _motorConvictionsTable;
        private readonly IMinimumPremiumTable _minimumPremiumTable;

        public Calculation(IBaseRateTable baseRateTable, IClaimsTable claimsTable,
                                IDriverAgeTable driverAgeTable, IVehicleValueTable vehicleValueTable, IVehicleUseTable vehicleUseTable, IVehicleTransmissionTable vehicleTransmissionTable,
                                    ISeatsTable seatsTable, IMotorConvictionsTable motorConvictionsTable,
                                          IMinimumPremiumTable minimumPremiumTable
                                   )
        {
            _baseRateTable = baseRateTable;
            _claimsTable = claimsTable;
            _driverAgeTable = driverAgeTable;
            _vehicleValueTable = vehicleValueTable;
            _vehicleUseTable = vehicleUseTable;
            _vehicleTransmissionTable = vehicleTransmissionTable;
            _seatsTable = seatsTable;
            _motorConvictionsTable = motorConvictionsTable;
            _minimumPremiumTable = minimumPremiumTable;
        }

        public decimal CalculateBaseRate(NCB ncb)
        {
            // Get the base rate table.
            Dictionary<NCB, decimal> baseRates = _baseRateTable.GetBaseRateTable();

            decimal baseRate = 0;

            if (ncb == NCB.NewBadge)
            {
                baseRates.TryGetValue(NCB.NewBadge, out baseRate);
            }
            else if (ncb == NCB.Zero)
            {
                baseRates.TryGetValue(NCB.Zero, out baseRate);
            }
            else if (ncb == NCB.One)
            {
                baseRates.TryGetValue(NCB.One, out baseRate);
            }
            else if (ncb == NCB.Two)
            {
                baseRates.TryGetValue(NCB.Two, out baseRate);
            }
            else if (ncb == NCB.Three)
            {
                baseRates.TryGetValue(NCB.Three, out baseRate);
            }
            else if (ncb == NCB.Four)
            {
                baseRates.TryGetValue(NCB.Four, out baseRate);
            }
            else if (ncb == NCB.Five)
            {
               baseRates.TryGetValue(NCB.Five, out baseRate);
            }
            else if (ncb == NCB.SixPlus)
            {
                baseRates.TryGetValue(NCB.SixPlus, out baseRate);
            }

            return baseRate;
        }
        public decimal CalculateDriversAge(NCB ncb, DriverAges driverAge)
        {
            decimal driversAgeRate = 0.0M;

            Dictionary<string, decimal> driverAgeTab = _driverAgeTable.GetDriverAge();

            if (ncb == NCB.Zero)
            {
                driverAgeTab.TryGetValue($"{NCB.Zero}{driverAge}", out driversAgeRate);
            }
            else if (ncb == NCB.One)
            {
                driverAgeTab.TryGetValue($"{NCB.One}{driverAge}", out driversAgeRate);
            }
            else if (ncb == NCB.Two)
            {
                driverAgeTab.TryGetValue($"{NCB.Two}{driverAge}", out driversAgeRate);
            }
            else if (ncb == NCB.Three)
            {
                driverAgeTab.TryGetValue($"{NCB.Three}{driverAge}", out driversAgeRate);
            }
            else if (ncb == NCB.Four)
            {
                driverAgeTab.TryGetValue($"{NCB.Four}{driverAge}", out driversAgeRate);
            }
            else if (ncb == NCB.Five)
            {
                driverAgeTab.TryGetValue($"{NCB.Five}{driverAge}", out driversAgeRate);
            }
            else if (ncb == NCB.SixPlus)
            {
                driverAgeTab.TryGetValue($"{NCB.SixPlus}{driverAge}", out driversAgeRate);
            }
            else if (ncb == NCB.NewBadge)
            {
                driverAgeTab.TryGetValue($"{NCB.NewBadge}{driverAge}", out driversAgeRate);
            }

            return driversAgeRate;
        }
        public decimal CalculateVehicleValue(Vehicle vehicle)
        {
            Dictionary<string, decimal> vehiclevalue = _vehicleValueTable.GetVehicleValueTable();

            // This needs to be placed in our Factory class to adhere to the Dependency Inversion principle.
            VehicleValue vehValue = new();

            decimal estimatedVehiclevalue = 0.0M;

            if (vehicle.EstimatedValue >= 0M && vehicle.EstimatedValue < 10000M)
            {
                vehValue = VehicleValue.ZeroToNineThousandNineHundredNinetyNine;
            }
            else if (vehicle.EstimatedValue >= 10000M && vehicle.EstimatedValue < 19999M)
            {
                vehValue = VehicleValue.TenThousandToNineteenThousandNineHundredNinetyNine;
            }
            else if (vehicle.EstimatedValue >= 20000)
            {
                vehValue = VehicleValue.TwentyThousandPlus;
            }

            if (vehValue == VehicleValue.ZeroToNineThousandNineHundredNinetyNine)
            {
                vehiclevalue.TryGetValue($"{VehicleValue.ZeroToNineThousandNineHundredNinetyNine}", out estimatedVehiclevalue);
            }
            else if (vehValue == VehicleValue.TenThousandToNineteenThousandNineHundredNinetyNine)
            {
                vehiclevalue.TryGetValue($"{VehicleValue.TenThousandToNineteenThousandNineHundredNinetyNine}", out estimatedVehiclevalue);
            }
            else if (vehValue == VehicleValue.TwentyThousandPlus)
            {
                vehiclevalue.TryGetValue($"{VehicleValue.TwentyThousandPlus}", out estimatedVehiclevalue);
            }

            return estimatedVehiclevalue;

        }
        public decimal CalculateVehicleUse(VehicleUse vehicleUse)
        {
            // Get out Vehicle Use table.
            Dictionary<VehicleUse, decimal> vehicleUseTab = _vehicleUseTable.GetVehicleUseTable();

            // Set a default starting value 
            decimal vehicleUseRate = 0.0M;

            if (vehicleUse == VehicleUse.PrivateHire)
            {
                vehicleUseTab.TryGetValue(VehicleUse.PrivateHire, out vehicleUseRate);
            }
            else if (vehicleUse == VehicleUse.PublicHire)
            {
                vehicleUseTab.TryGetValue(VehicleUse.PublicHire, out vehicleUseRate);
            }
            else if (vehicleUse == VehicleUse.Other)
            {
                vehicleUseTab.TryGetValue(VehicleUse.Other, out vehicleUseRate);
            }

            return vehicleUseRate;
        }
        public decimal CalculateVehicleSeatsRate(Vehicle vehicle)
        {
            Dictionary<VehicleSeats, decimal> seatsTable = _seatsTable.GetSeatsTable();

            VehicleSeats vehicleSeats = new();

            if (vehicle.NoOfSeats == 5)
            {
                vehicleSeats = VehicleSeats.Five;
            }
            else if (vehicle.NoOfSeats == 6)
            {
                vehicleSeats = VehicleSeats.Six;
            }
            else if (vehicle.NoOfSeats == 7)
            {
                vehicleSeats = VehicleSeats.Seven;
            }
            else if (vehicle.NoOfSeats == 8)
            {
                vehicleSeats = VehicleSeats.Eight;
            }
            else if (vehicle.NoOfSeats == 9)
            {
                vehicleSeats = VehicleSeats.Nine;
            }

            seatsTable.TryGetValue(vehicleSeats, out decimal seatsRate);

            return seatsRate;
        }
        public decimal CalculateVehicleTransmissionRate(VehicleTransmission vehicleTransmission)
        {
            Dictionary<VehicleTransmission, decimal> vehicleTransTable = _vehicleTransmissionTable.GetVehicleTransmissionsTable();

            decimal vehicleTransmissionRate = 0;

            if (vehicleTransmission == VehicleTransmission.Manual)
            {
                vehicleTransTable.TryGetValue(VehicleTransmission.Manual, out vehicleTransmissionRate);
            }
            else if (vehicleTransmission == VehicleTransmission.Automatic)
            {
                vehicleTransTable.TryGetValue(VehicleTransmission.Automatic, out vehicleTransmissionRate);
            }

            return vehicleTransmissionRate;
        }
        public decimal CalculateMinimumPremium(NCB ncb)
        {
            Dictionary<NCB, decimal> minPremTable = _minimumPremiumTable.GetMinimumPremiumTable();

            decimal minPremValue = 0.0M;

            if (ncb == NCB.NewBadge)
            {
                minPremTable.TryGetValue(NCB.NewBadge, out minPremValue);
            }
            else if (ncb == NCB.Zero)
            {
                minPremTable.TryGetValue(NCB.Zero, out minPremValue);
            }
            else if (ncb == NCB.One)
            {
                minPremTable.TryGetValue(NCB.One, out minPremValue);
            }
            else if (ncb == NCB.Two)
            {
                minPremTable.TryGetValue(NCB.Two, out minPremValue);
            }
            else if (ncb == NCB.Three)
            {
                minPremTable.TryGetValue(NCB.Three, out minPremValue);
            }
            else if (ncb == NCB.Four)
            {
                minPremTable.TryGetValue(NCB.Four, out minPremValue);
            }
            else if (ncb == NCB.Five)
            {
                minPremTable.TryGetValue(NCB.Five, out minPremValue);
            }
            else if (ncb == NCB.SixPlus)
            {
                minPremTable.TryGetValue(NCB.SixPlus, out minPremValue);
            }

            return minPremValue;
        }
        public decimal CalculateClaimsRate(List<MotorClaim> motorClaims, NCB ncb)
        {
            // Get the claims Table key.
            string claimsTableKey = GetClaimsKey(motorClaims, ncb);

            // Get the table contents.
            Dictionary<string, decimal> claims = _claimsTable.GetClaimsTable();

            // Get the rate or the default.
            claims.TryGetValue(claimsTableKey, out  decimal claimsRate);

            // Return the Rate e.g 1.04
            return claimsRate;
        }
        private string GetClaimsKey(List<MotorClaim> motorClaims, NCB ncb)
        {
            int nonFaultClaims = 0;
            int faultClaims = 0;

            if (motorClaims.Count != 0)
            {
                foreach (MotorClaim claim in motorClaims)
                {
                    if (claim.AtFault)
                    {
                        faultClaims++;
                    }
                    else if (!claim.AtFault)
                    {
                        nonFaultClaims++;
                    }
                }

                if (faultClaims == 0 && nonFaultClaims == 1)
                {
                    return $"{ncb}{ClaimsFault.Zero}{ClaimsNonFault.One}";
                }
                else if (faultClaims == 1 && nonFaultClaims == 0)
                {
                    return $"{ncb}{ClaimsFault.One}{ClaimsNonFault.Zero}";
                }
                else if (faultClaims == 1 && nonFaultClaims == 1)
                {
                    return $"{ncb}{ClaimsFault.One}{ClaimsNonFault.One}";
                }
                else if (faultClaims == 0 && nonFaultClaims >= 2)
                {
                    return $"{ncb}{ClaimsFault.Zero}{ClaimsNonFault.TwoPlus}";
                }
                else if (faultClaims >= 2 && nonFaultClaims >= 0)
                {
                    return $"{ncb}{ClaimsFault.TwoPlus}{ClaimsNonFault.Zero}";
                }
                else if (faultClaims == 1 && nonFaultClaims >= 2)
                {
                    return $"{ncb}{ClaimsFault.One}{ClaimsNonFault.TwoPlus}";
                }
                else if (faultClaims >= 2 && nonFaultClaims == 1)
                {
                    return $"{ncb}{ClaimsFault.TwoPlus}{ClaimsNonFault.One}";
                }
                else if (faultClaims >= 2 && nonFaultClaims >= 2)
                {
                    return $"{ncb}{ClaimsFault.TwoPlus}{ClaimsNonFault.One}";
                }
            }
            else
            {
                return $"{ncb}{ClaimsFault.Zero}{ClaimsNonFault.Zero}";
            }

            return "DEFAULT";
        }
        public decimal CalculateMotorConvictions(int motorConvictions)
        {
            string motorConTableKey = GetMotorConvictionsKey(motorConvictions);

            decimal motConRate = 0.0M;

            Dictionary<string, decimal> motorConTable = _motorConvictionsTable.GetMotorConvictionsTable();

            motorConTable.TryGetValue(motorConTableKey, out motConRate);

            return motConRate;
        }
        private string GetMotorConvictionsKey(int motorConvictions)
        {
            if (motorConvictions == 0)
            {
                return "0";
            }
            else if (motorConvictions == 1)
            {
                return "1";
            }
            else if (motorConvictions >= 2)
            {
                return "2+";
            }
            else
            {
                return "DEFAULT";
            }
        }
    }
}
