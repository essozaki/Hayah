using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy_Project.Api.Bll;
using Pharmacy_Project.Api.Models;
using Pharmacy_Project.API.Models;

namespace Pharmacy_Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsApiController : ControllerBase
    {
        private readonly IQuestionsApiRep _term;

        public QuestionsApiController(IQuestionsApiRep term)
        {
            this._term = term;
        }



        [HttpGet]
        [Route("/api/GetAllQuestions")]
        public IActionResult Get()
        {
            try
            {
                var data = _term.GetAll();

                QuestionsCustomResponse Cusotm = new QuestionsCustomResponse
                {

                    Records = data,
                    Code = "200",
                    Message = "Data Returned",
                    Status = "Done"

                };
                return Ok(Cusotm);
            }
            catch (Exception ex)
            {
                return NotFound(new CustomResponse
                {
                    Code = "400",
                    Message = ex.Message,
                    Status = "Faild"
                });

            }
        }

    }
}
