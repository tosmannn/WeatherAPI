// See https://aka.ms/new-console-template for more information

using WeatherAPI.Service.Implementations;
using WeatherAPI.Service.Interface;
using WeatherAPI.Utilities;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using WeatherAPI.Models.WeatherModels;

var builder = new ConfigurationBuilder();
BuildConfig(builder);

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Build())
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

logger.Information("Application Starting");

var host = Host.CreateDefaultBuilder()
.ConfigureServices((_, services) =>
services.AddScoped<IWeatherService, WeatherService>())
.UseSerilog()
.Build();


var weatherService = ActivatorUtilities.CreateInstance<WeatherService>(host.Services);

Run();

#region BuildConfig
static void BuildConfig(IConfigurationBuilder builder)
{
    builder.SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
        .AddEnvironmentVariables();
}
#endregion

#region Run App

void Run()
{
    string userInput;
    bool isZipcodeValid = false;
    bool isWeatherAvailable = false;
    var weatherData = new WeatherRootModel();

    do
    {
        Console.Write("Please Input US Zipcode: ");

        userInput = Console.ReadLine().Trim();

        if (!string.IsNullOrWhiteSpace(userInput))
        {
            isZipcodeValid = ZipcodeHelper.IsZipcodeValid(userInput);

            if (isZipcodeValid)
            {
                weatherData = weatherService.GetWeather(userInput);

                isWeatherAvailable = weatherData.Success;

                if (!isWeatherAvailable)
                {
                    Console.WriteLine("You may try again later or make sure you entered US zipcode");
                }
            }
            else
            {
                Console.WriteLine("Zipcode invalid.");
            }
        }

    } while (!isZipcodeValid || string.IsNullOrWhiteSpace(userInput) || !isWeatherAvailable);

    Console.WriteLine();

    var questions = new List<string>
    {
        "Should I go outside?",
        "Should I wear sunscreen?",
        "Can I fly my kite?"
    };

    var i = 0;

    Console.WriteLine("You may ask these questions below: ");

    foreach (var question in questions)
    {
        var numberKeyPress = ++i;

        Console.WriteLine($"Type {numberKeyPress}: {question}");

    }

    Console.WriteLine("Type 'Okay' When finsihed asking");
    Console.WriteLine();
    Console.WriteLine("Please choose your question.");

    do
    {
        Console.Write("Enter keyword: ");
        userInput = Console.ReadLine().Trim();

        var isNumber = int.TryParse(userInput, out var number);

        var questionIndex = number - 1;

        switch (userInput)
        {
            case "1":
                Console.Write($"{questions[questionIndex]}: ");

                var canGoOutside = weatherService.CanGoOutside(weatherData);

                if (!canGoOutside)
                    Console.WriteLine("Yes");
                else
                    Console.WriteLine("No");

                break;
            case "2":
                Console.Write($"{questions[questionIndex]}: ");

                var isSunscreenNeeded = weatherService.IsSunscreenNeeded(weatherData);

                if (isSunscreenNeeded)
                    Console.WriteLine("Yes");
                else
                    Console.WriteLine("No");

                break;

            case "3":
                Console.Write($"{questions[questionIndex]}: ");

                var canFlyKite = weatherService.CanFlyKite(weatherData);

                if (canFlyKite)
                    Console.WriteLine("Yes");
                else
                    Console.WriteLine("No");

                break;

            default:
                if (userInput.ToLower() != "okay")
                    Console.WriteLine("Please Choose from the question list or type 'Okay' when finished asking.");
                break;
        }

        Console.WriteLine();

    } while (userInput.ToLower() != "okay");

    Console.WriteLine("Thank you for using the application");

}
#endregion
