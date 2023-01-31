using Pharmacy_Project.Data.Entities;

namespace Pharmacy_Project.Models
{
    public class HospitalsVM: Hospitals

    {
        public IFormFile Photo { get; set; }
    }
}
