using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class ShippingController : Controller
{
    private readonly FedExShippingService _fedExShippingService;

    public ShippingController(FedExShippingService fedExShippingService)
    {
        _fedExShippingService = fedExShippingService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateShipment()
    {
        var shipmentData = new FedExShipmentData
        {
            ShipFrom = "123 Sender St, City, State, ZIP",
            ShipTo = "456 Recipient St, City, State, ZIP",
            PackagingType = "YOUR_PACKAGING",
            Weight = 5.0m, // Weight in lbs
            ServiceType = "FEDEX_GROUND", // FedEx service type
            Dimensions = new Dimensions
            {
                Length = 10,
                Width = 10,
                Height = 10,
                Units = "IN"
            }
        };

        var result = await _fedExShippingService.CreateShipmentAsync(shipmentData);

        if (!string.IsNullOrEmpty(result))
        {
            return Ok(result); // Display shipment result (e.g., tracking number or shipping label)
        }

        return BadRequest("Shipment creation failed");
    }
}