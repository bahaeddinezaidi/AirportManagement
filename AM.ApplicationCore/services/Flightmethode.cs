using AM.ApplicationCore.Domain;
using AM.ApplicationCore.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.services
{
    public class Flightmethode : Iflight
    {
        public  IList<Flight> Flights = new List<Flight>();
        public IList<DateTime> GetFlightDates(string destination)
        {
            //IList<DateTime> flightDates = new List<DateTime>();
            #region avec boucle for

            // for (int i = 0; i < Flights.Count; i++)
            //{

            //    if (Flights[i].Destination == destination)
            //     {

            //        flightDates.Add(Flights[i].FlightDate);
            //        }
            //  }
            #endregion
            #region  avec foreach
            //foreach (Flight flight in Flights)
            //{
            //    if (flight.Destination == destination)
            //    {
            //        flightDates.Add(flight.FlightDate);
            //    }
            //}



            //    return flightDates;
            //}
            #endregion
            var flightDates = (from flight in Flights
                               where flight.Destination == destination
                               select flight.FlightDate).ToList();

            return flightDates;

        }
        public void ShowFlightDetails(Plane plane)
        {
            var query = from f in Flights where f.Plane.Equals(plane) select new { f.Destination, f.FlightDate };

            foreach (var flightDetail in query)
            {
                Console.WriteLine($"Destination: {flightDetail.Destination}, Flight Date: {flightDetail.FlightDate}");
            }
        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (Flight f in Flights)
                    {
                        if (f.Destination.Equals(filterValue))
                            Console.WriteLine($"Flight ID: {f.FlightId}, Destination: {f.Destination}, Flight Date: {f.FlightDate}, Estimated Duration: {f.EstimatedDuration} minutes");
                    }
                    break;
                case "FlightDate":
                    foreach (Flight f in Flights)
                    {
                        if (f.FlightDate == DateTime.Parse(filterValue))
                            Console.WriteLine($"Flight ID: {f.FlightId}, Destination: {f.Destination}, Flight Date: {f.FlightDate}, Estimated Duration: {f.EstimatedDuration} minutes");
                    }
                    break;
                case "EffectiveArrival":
                    foreach (Flight f in Flights)
                    {
                        if (f.EffectiveArrival == DateTime.Parse(filterValue))
                            Console.WriteLine($"Flight ID: {f.FlightId}, Destination: {f.Destination}, Flight Date: {f.FlightDate}, Estimated Duration: {f.EstimatedDuration} minutes");
                    }
                    break;
            }
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var query = from f in Flights
                        where (f.FlightDate - startDate).TotalDays >= 0 && (f.FlightDate - startDate).TotalDays < 7
                        select f;
            return query.Count();
            #region avec Lambda

            //return Flights.Where(f=>(f.FlightDate-startDate).TotalDays < 7).Count();
            #endregion

        }

        public double DurationAverage(string destination)
        {
            return (from f in Flights
                  where f.Destination.Equals(destination)    
               select f.EstimatedDuration).Average();

            #region avec Lambda

           //return Flights.Where(f=>f.Destination.Equals(destination)).Average(f=> f.EstimatedDuration);
            #endregion
        }


        public IEnumerable<Flight> OrderedDurationFlights()
        {
            var query = from f in Flights
                     orderby f.EstimatedDuration descending
                     select f;

            return query;


        }

        public IEnumerable<Traveller> SeniorTravellers(Flight f)
        {

            var oldTravellers = from p in f.Passengers.OfType<Traveller>()
                                orderby p.BirthDate
                                select p;
            return oldTravellers.Take(3);

            #region avec lambda 
            // var reqLambda = f.Passengers.OfType<Traveller>().OrderBy(p => p.BirthDate).Take(3);
            #endregion
        }



       public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            var req = from f in Flights
                      group f by f.Destination;
            foreach (var g in req)
            {
                Console.WriteLine("Destination: " + g.Key);
                foreach (var f in g)
                    Console.WriteLine("Décollage: " + f.FlightDate);
            }
            return req;
        }

    }
}



