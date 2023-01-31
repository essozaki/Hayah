

using Pharmacy_Project.API.Models;
using Pharmacy_Project.Models;

namespace Pharmacy_Project.Api.Models
{
    public class ClincsCustomResponse : CustomResponse
    {
        public IEnumerable<ClincsVM> Records { get; set; }
        public ClincsVM Record { get; set; }
    }
}