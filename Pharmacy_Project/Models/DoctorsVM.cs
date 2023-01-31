using Pharmacy_Project.Data.Entities;

namespace Pharmacy_Project.Models
{
    public class DoctorsVM: Doctors
    {
        public IFormFile Photo { get; set; }
    }
}
