using Pharmacy_Project.Data.Entities;

namespace Pharmacy_Project.Models
{
    public class Medical_InformationVM: Medical_Information
    {
        public IFormFile Photo { get; set; }
    }
}
