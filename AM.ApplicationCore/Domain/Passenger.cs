﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
   public class Passenger
    {
        public string PassportNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime  BirthDate{ get; set; }
        public int TellNumber{ get; set; }
        public string EmailAdress { get; set; }
        ICollection<Flight> Flights { get; set; }
        public bool checkprofile(string nom ,string prenom)
        {
            return FirstName.Equals(nom) && LastName.Equals(prenom);
        }
        public bool checkprofile(string nom ,string prenom ,string email)
        {
            return FirstName.Equals(nom) && LastName.Equals(prenom) && EmailAdress.Equals(email);
        }
        public virtual void PassengerType()
        {
            Console.WriteLine("i am passenger");
        }


    }
}
