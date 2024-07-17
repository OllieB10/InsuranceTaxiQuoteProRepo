using DataAccess.Enums;

namespace DataAccess.Models
{
    /// <summary>
    /// Motor claim object.
    /// </summary>
    public class MotorClaim
    {
        public bool AtFault { get; set; }
        public IncidentType IncidentType { get; set; }
    }
}
