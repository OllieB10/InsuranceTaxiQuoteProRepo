namespace DataAccess.Models
{
    /// <summary>
    /// Contains data members relating to the driver object.
    /// </summary>
    public class Driver
    {
        public IList<MotorClaim> Claims { get; set; }
        public bool InsurancePreviouslyRefused { get; set; }
        public bool HasCriminalConvictions { get; set; }
        public bool PreviouslyHadTermsApplied { get; set; }
        public bool DisqualifiedFromDriving { get; set; }
    }
}
