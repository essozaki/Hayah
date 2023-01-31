

using Pharmacy_Project.API.Models;
using Pharmacy_Project.Models;

namespace Pharmacy_Project.Api.Models
{
    public class Terms_ConditionsCustomResponse : CustomResponse
    {
        public IEnumerable<Terms_ConditionsVM> Records { get; set; }
        public Terms_ConditionsVM Record { get; set; }
    }
}