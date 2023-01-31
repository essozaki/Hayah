using Pharmacy_Project.Data.Entities;

namespace Pharmacy_Project.Models
{
    public class XraysVM: Xrays
    {
        public IFormFile Photo { get; set; }
    }
}
