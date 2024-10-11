using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Models;
using System;
using System.Collections.Generic;

namespace OrderManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShippingController : ControllerBase
    {
        // Endpoint to create a shipping label
        [HttpPost("CreateShippingLabel")]
        public IActionResult CreateShippingLabel([FromBody] FedExLabelRequest request)
        {
            // Validate the incoming request
            if (request == null || request.OriginAddress == null || request.DestinationAddress == null || request.PackageDetails == null)
            {
                return BadRequest("Invalid request data.");
            }

            // Map the request data to the FedEx shipment data model
            var shipmentData = MapToShipmentData(request);

            // Here you would send shipmentData to FedEx API and handle the response
            // For now, we're just returning the mapped data for testing
            return Ok(shipmentData);
        }

        // Maps FedExLabelRequest to FedExShipmentData
        private FedExShipmentData MapToShipmentData(FedExLabelRequest request)
        {
            return new FedExShipmentData
            {
                Shipper = new Shipper
                {
                    Contact = new FedExContact
                    {
                        PersonName = "John Doe",
                        PhoneNumber = "1234567890", // PhoneNumber as string
                        CompanyName = "Acme Corporation"
                    },
                    Address = new FedExAddress
                    {
                        StreetLines = new List<string> { "123 Main St" },
                        City = "Springfield",
                        StateOrProvinceCode = "IL",
                        PostalCode = "62701",
                        CountryCode = "US"
                    }
                },
                Recipients = new List<Recipient>
                {
                    new Recipient
                    {
                        Contact = new FedExContact
                        {
                            PersonName = "Jane Smith",
                            PhoneNumber = "9876543210", // PhoneNumber as string
                            CompanyName = "Widgets Inc."
                        },
                        Address = new FedExAddress
                        {
                            StreetLines = new List<string> { "456 Elm St" },
                            City = "Chicago",
                            StateOrProvinceCode = "IL",
                            PostalCode = "60601",
                            CountryCode = "US"
                        }
                    }
                },
                ShipDatestamp = DateTime.Now.ToString("yyyy-MM-dd"),
                ServiceType = "FEDEX_GROUND",
                PackagingType = "YOUR_PACKAGING_TYPE",
                PickupType = "USE_SCHEDULED_PICKUP",
                ShippingChargesPayment = new ShippingChargesPayment
                {
                    PaymentType = "SENDER"
                },
                ShipmentSpecialServices = new ShipmentSpecialServices
                {
                    SpecialServiceTypes = new List<string> { "FEDEX_ONE_RATE" }
                },
                LabelSpecification = new LabelSpecification
                {
                    ImageType = "PDF",
                    LabelStockType = "PAPER_85X11_TOP_HALF_LABEL"
                },
                RequestedPackageLineItems = new List<RequestedPackageLineItem>
                {
                    new RequestedPackageLineItem
                    {
                        Weight = new FedExWeight
                        {
                            Units = "LB",
                            Value = (decimal)request.PackageDetails.Weight
                        },
                        Dimensions = new FedExDimensions
                        {
                            Length = request.PackageDetails.Dimensions.Length,
                            Width = request.PackageDetails.Dimensions.Width,
                            Height = request.PackageDetails.Dimensions.Height,
                            
                        }
                    }
                }
            };
        }
    }
}