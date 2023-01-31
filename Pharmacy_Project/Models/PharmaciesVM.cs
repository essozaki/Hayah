using Pharmacy_Project.Data.Entities;

namespace Pharmacy_Project.Models
{
    public class PharmaciesVM: Pharmacies
    {
        public IFormFile Photo { get; set; }   
    }
}
