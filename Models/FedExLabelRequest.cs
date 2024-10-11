namespace OrderManagementSystem.Models
{
    public class FedExLabelRequest
    {
        public FedExAddress OriginAddress { get; set; }
        public FedExAddress DestinationAddress { get; set; }
        public FedExPackageDetails PackageDetails { get; set; }
    }
}
