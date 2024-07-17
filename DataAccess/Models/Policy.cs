namespace DataAccess.Models
{
    public class Policy
    {
        public IList<Vehicle> Vehicles { get; set; }
        public IList<Driver> Drivers { get; set; }
        public Proposer Proposer { get; set; }
        public string Cover { get; set; }
        public decimal NetPremium { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
