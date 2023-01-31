using Pharmacy_Project.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy_Project.Data.Entities
{
    public class MedicalCentresAppointments:Appointments
    {
        public int center_Id { get; set; }
        [ForeignKey("center_Id")]
        public MedicalCentres MedicalCentres { get; set; }
    }
}
