using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
  public  class Plane
    {
        [Range(1, int.MaxValue, ErrorMessage = "La capacité doit être un entier positif.")]
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int  PlaneId{ get; set; }

        public PlaneType PlaneType { get; set; }
        ICollection<Flight> Flights { get; set;}
        public string  Airlinelogo { get; set; }
    }
}
