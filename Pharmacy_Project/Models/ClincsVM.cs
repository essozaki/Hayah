using Pharmacy_Project.Data.Entities;

namespace Pharmacy_Project.Models
{
    public class ClincsVM: Clincs
    {
        public IFormFile Photo { get; set; }
    }
}
