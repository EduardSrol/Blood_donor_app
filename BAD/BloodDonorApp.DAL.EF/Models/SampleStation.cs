namespace BloodDonorApp.DAL.EF.Models
{
    public class SampleStation : Institution
    {

        public string WebLink { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}