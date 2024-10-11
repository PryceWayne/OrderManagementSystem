namespace OrderManagementSystem.Models
{
    public class FedExAddress
    {
        public List<string> StreetLines { get; set; }
        public string City { get; set; }
        public string StateOrProvinceCode { get; set; }
        public string PostalCode { get; set; }
        public string CountryCode { get; set; }
    }
}

