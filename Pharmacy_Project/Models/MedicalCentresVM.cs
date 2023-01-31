using Pharmacy_Project.Data.Entities;

namespace Pharmacy_Project.Models
{
    public class MedicalCentresVM: MedicalCentres
    {
        public IFormFile Photo { get; set; }
    }
}
