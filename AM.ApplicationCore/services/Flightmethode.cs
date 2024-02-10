using AM.ApplicationCore.Domain;
using AM.ApplicationCore.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.services
{
    internal class Flightmethode : Iflight
    {
        IList<Flight> Flights = new List<Flight>();
        IList<DateTime> Iflight.GetFlightDates(string destination)
        {
            IList<DateTime> flightDates = new List<DateTime>();
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
            var query = from a in Flights where a.Destination == destination select a.Destination;
            return (IList<DateTime>)query.ToList();

        }
        public void ShowFlightDetails(Plane plane)
        {
            var query = from f in Flights where f.Plane.Equals(plane) select new { f.Destination, f.FlightDate };
        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (Flight f in Flights)
                    {
                        if (f.Destination.Equals(filterValue))
                            Console.WriteLine(f);
                    }
                    break;
                case "FlightDate":
                    foreach (Flight f in Flights)
                    {
                        if (f.FlightDate == DateTime.Parse(filterValue))

                            Console.WriteLine(f);

                    }
                    break;
                case "EffectiveArrival":
                    foreach (Flight f in Flights)
                    {
                        if (f.EffectiveArrival == DateTime.Parse(filterValue))
                            Console.WriteLine(f);
                    }
                    break;
            }

        }
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var query = from f in Flights
                        where (f.FlightDate).CompareTo(startDate) > 0 && (f.FlightDate - startDate).TotalDays < 7
                        select f;
            return query.Count();

        }

        public double DurationAverage(string destination)
        {
            return (from f in Flights
                    where f.Destination.Equals(destination)
                    select f.EstimatedDuration).Average();
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
            throw new NotImplementedException();
        }
    }
}


