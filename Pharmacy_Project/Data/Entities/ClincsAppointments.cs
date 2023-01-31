using Pharmacy_Project.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy_Project.Data.Entities
{
    public class ClincsAppointments : Appointments
    {
        public int Clinc_Id { get; set; }
        [ForeignKey("Clinc_Id")]
        public Clincs Clincs { get; set; }
    }
}
