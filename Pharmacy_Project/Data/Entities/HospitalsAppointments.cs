using Pharmacy_Project.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy_Project.Data.Entities
{
    public class HospitalsAppointments:Appointments
    {
        public int Hosp_Id { get; set; }
        [ForeignKey("Hosp_Id")]
        public Hospitals Hospitals { get; set; }
    }
}
