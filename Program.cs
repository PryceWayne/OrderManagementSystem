using OrderManagementSystem.Models;
using Microsoft.Extensions.Logging; // Add this for logging

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Load the FedEx settings from appsettings.json
builder.Services.Configure<FedExSettings>(builder.Configuration.GetSection("FedExApi"));

// Register HttpClient and the FedEx services
builder.Services.AddHttpClient<FedExAuthService>();  // For OAuth authentication
builder.Services.AddHttpClient<FedExShippingService>();  // For creating shipments

// Configure logging
builder.Logging.ClearProviders();  // Clear default providers if you want a clean setup
builder.Logging.AddConsole();      // Log to the console
builder.Logging.AddDebug();        // Log to the debug output (useful for development)
builder.Logging.AddEventSourceLogger();  // You can add more providers (e.g., EventSource)

// Optionally, you can add logging to a file
builder.Logging.AddFile("Logs/app-{Date}.txt"); // Requires a package like Serilog or NLog for file logging

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Define routing for general views and FedEx API integration
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Add a route for handling the FedEx API calls via ShippingController
app.MapControllerRoute(
    name: "shipping",
    pattern: "{controller=Shipping}/{action=CreateShipment}/{id?}");

// You can add more routes for additional FedEx actions as needed, like tracking or canceling shipments
app.MapControllerRoute(
    name: "tracking",
    pattern: "{controller=Shipping}/{action=TrackShipment}/{id?}");

app.Run();