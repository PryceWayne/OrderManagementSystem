public class FedExShipmentData
{
    public string ShipFrom { get; set; }   // Sender's address
    public string ShipTo { get; set; }     // Recipient's address
    public string PackagingType { get; set; } // Packaging type, e.g., YOUR_PACKAGING
    public decimal Weight { get; set; }    // Weight in lbs
    public string ServiceType { get; set; } // FedEx service type, e.g., FEDEX_GROUND
    public Dimensions Dimensions { get; set; } // Dimensions of the package

}