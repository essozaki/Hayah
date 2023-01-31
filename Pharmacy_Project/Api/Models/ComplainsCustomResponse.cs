using Pharmacy_Project.API.Models;
using Pharmacy_Project.Data.Entities;
using Pharmacy_Project.Models;

namespace Pharmacy_Project.Api.Models
{
    public class ComplainsCustomResponse : CustomResponse
    {
        public IEnumerable<ComplainsVM> Records { get; set; }
        public Complains Record { get; set; }
    }
}