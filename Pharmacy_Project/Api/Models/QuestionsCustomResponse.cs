

using Pharmacy_Project.API.Models;
using Pharmacy_Project.Models;

namespace Pharmacy_Project.Api.Models
{
    public class QuestionsCustomResponse : CustomResponse
    {
        public IEnumerable<QuestionsVM> Records { get; set; }
        public QuestionsVM Record { get; set; }
    }
}
