// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;

Console.WriteLine("Hello, World!");
#region exemple avec constructor
//Flight F1 = new ();
//F1.FlightId = 1;
//F1.Destination = "Paris";
//Flight F2 = new (2,DateTime.Now,5);
#endregion
Flight F3 = new()
{
    FlightDate = DateTime.Now,
    Departure = "Tunis",
    EstimateDuration = 6
};