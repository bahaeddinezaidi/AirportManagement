﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public Flight() { }
        public Flight(int flightId, DateTime flightDate, int estimateDuration)
        {
            FlightId = flightId;
            FlightDate = flightDate;
            EstimateDuration = estimateDuration;
        }

        public int FlightId { get; set; }
        public DateTime FlightDate { get; set; }

        public int EstimateDuration { get; set; }

        public int  EstimatedDuration { get; set; }

        public DateTime EffectiveArrival { get; set; }
        public string Departure { get; set; }

        public string Destination { get; set; }

        public Plane Plane { get; set; }

        ICollection<Passenger> Passengers { get; set; }


    }
}
