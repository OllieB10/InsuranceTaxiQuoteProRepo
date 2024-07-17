using DataAccess.Interfaces;
using DataAccess.Enums;

namespace DataAccess.RatingTable
{
    public class SeatsTable : ISeatsTable
    {
        #region Seats Table

        public Dictionary<VehicleSeats, decimal> GetSeatsTable()
        {
            Dictionary<VehicleSeats,decimal> seatsTable = new()
            {
                {VehicleSeats.Five, 1.08M},
                {VehicleSeats.Six, 1.12M},
                {VehicleSeats.Seven, 1.14M},
                {VehicleSeats.Eight, 1.16M},
                {VehicleSeats.Nine, 1.18M},
            };

            return seatsTable;
        }

        #endregion

    }
}
