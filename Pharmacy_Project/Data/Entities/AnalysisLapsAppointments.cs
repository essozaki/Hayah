using Pharmacy_Project.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy_Project.Data.Entities
{
    public class AnalysisLapsAppointments: Appointments
    {
        public int Lap_Id { get; set; }
        [ForeignKey("Lap_Id")]
        public AnalysisLaps AnalysisLaps { get; set; }
    }
}
