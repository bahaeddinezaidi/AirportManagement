﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
   public class Staff :Passenger
    {
        public DateTime EmployementDate { get; set; }

        [DataType(DataType.Currency)]
        public double Salary { get; set; }
        public  string Function { get; set; }

        public override void PassengerType()
        {
            Console.WriteLine("i am staff");
            
        }
    }
}
