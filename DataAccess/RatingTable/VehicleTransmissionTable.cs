using DataAccess.Interfaces;
using DataAccess.Enums;

namespace DataAccess.RatingTable
{
    public class VehicleTransmissionTable : IVehicleTransmissionTable
    {
        #region Vehicle Transmission Table
        public Dictionary<VehicleTransmission, decimal> GetVehicleTransmissionsTable()
        {
            Dictionary<VehicleTransmission, decimal> vehTransmissionsTable = new()
            {
                { VehicleTransmission.Automatic, 1.02M },
                { VehicleTransmission.Manual, 1.05M}
            };

            return vehTransmissionsTable;
        }

        #endregion
    }
}
