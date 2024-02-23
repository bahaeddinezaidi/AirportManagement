using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
   public class Passenger
    {
        //public int Id { get; set; }
        [StringLength(7),Key]
        public string PassportNumber { get; set; }
        [MinLength(3),MaxLength(25,ErrorMessage ="First name ne depasse pas 25 ")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Date of Birth")]
        public DateTime  BirthDate{ get; set; }
        [RegularExpression(@"^\d{8}$", ErrorMessage = "Le numéro de téléphone doit contenir 8 chiffres.")]
        public int TellNumber{ get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        ICollection<Flight> Flights { get; set; }
        public bool checkprofile(string nom ,string prenom)
        {
            return FirstName.Equals(nom) && LastName.Equals(prenom);
        }
        public bool checkprofile(string nom ,string prenom ,string email)
        {
            return FirstName.Equals(nom) && LastName.Equals(prenom) && EmailAddress.Equals(email);
        }
        public virtual void PassengerType()
        {
            Console.WriteLine("i am passenger");
        }


    }
}
