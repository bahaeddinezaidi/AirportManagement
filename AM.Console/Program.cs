// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.services;

Console.WriteLine("Hello, World!");
#region exemple avec constructor
//Flight F1 = new ();
//F1.FlightId = 1;
//F1.Destination = "Paris";
//Flight F2 = new (2,DateTime.Now,5);
#endregion
//Flight F3 = new()
//{
//    FlightDate = DateTime.Now,
//    Departure = "Tunis",
//    EstimateDuration = 6
//};

Flightmethode flightmethode = new();
flightmethode.Flights = TestData.listFlights;
Console.WriteLine("####la methode showFlight ###");
flightmethode.ShowFlightDetails(TestData.BoingPlane);
flightmethode.DestinationGroupedFlights();
Console.WriteLine("************************************ GetFlightDates (string destination)  ****************************** ");
Console.WriteLine("Flight dates to Madrid");
foreach (var item in flightmethode.GetFlightDates("Madrid"))
    Console.WriteLine(item);
Console.WriteLine("************************************ GetFlights(string filterType, string filterValue)  ****************************** ");
flightmethode.GetFlights("Destination", "Paris");
Console.WriteLine("************************************ ShowFlightDetails(Plane plane)  ****************************** ");
flightmethode.ShowFlightDetails(TestData.Airbusplane);
Console.WriteLine("************************************ ProgrammedFlightNumber(DateTime startDate)  ****************************** ");
Console.WriteLine("Number of programmed flights in 01/01/2022 week: ");
//flightmethode.ProgrammedFlightNumber(new DateTime(2022, 01, 01));
DateTime startDate = new DateTime(2022, 01, 01);
int numberOfFlights = flightmethode.ProgrammedFlightNumber(startDate);
Console.WriteLine(numberOfFlights);

Console.WriteLine("************************************ DurationAverage(string destination) ****************************** ");
Console.WriteLine("Duration average of flights to Madrid: " + flightmethode.DurationAverage("Madrid"));
Console.WriteLine("************************************ OrderedDurationFlights()  ****************************** ");
foreach (var item in flightmethode.OrderedDurationFlights())
    Console.WriteLine(item.Destination);