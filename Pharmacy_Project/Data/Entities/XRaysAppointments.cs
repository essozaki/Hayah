using Pharmacy_Project.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy_Project.Data.Entities
{
    public class XRaysAppointments : Appointments
    {
        public int xray_Id { get; set; }
        [ForeignKey("xray_Id")]
        public Xrays Xrays { get; set; }
    }
}
