using Pharmacy_Project.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy_Project.Data.Entities
{
    public class PharmaciesAppointments:Appointments
    {
        public int Phar_Id { get; set; }
        [ForeignKey("Phar_Id")]
        public Pharmacies Pharmacies { get; set; }
    }
}
