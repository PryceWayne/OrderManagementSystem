using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

public class FedExShippingService
{
    private readonly HttpClient _httpClient;
    private readonly FedExAuthService _authService;
    private readonly IConfiguration _configuration;

    public FedExShippingService(HttpClient httpClient, FedExAuthService authService, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _authService = authService;
        _configuration = configuration;
    }

    // Method to create a shipment using FedEx API
    public async Task<string> CreateShipmentAsync(FedExShipmentData shipmentData)
    {
        // Get OAuth token
        var token = await _authService.GetOAuthTokenAsync();
        if (token == null)
        {
            return "Failed to authenticate with FedEx.";
        }

        // Fetch the shipment creation URL from appsettings.json
        var apiUrl = _configuration["FedExApi:BaseUrl"] + _configuration["FedExApi:ShipmentUrl"];

        // Add the OAuth token to the request headers
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

        // Serialize shipment data to JSON
        var jsonData = JsonConvert.SerializeObject(shipmentData);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        // Send the shipment creation request
        var response = await _httpClient.PostAsync(apiUrl, content);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync(); // Return shipment details
        }

        return "Shipment creation failed"; // Handle errors
    }
}