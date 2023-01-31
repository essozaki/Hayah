using Pharmacy_Project.Data.Entities;

namespace Pharmacy_Project.Models
{
    public class AnalysisLapsVM: AnalysisLaps
    {
        public IFormFile Photo { get; set; }
    }
}
