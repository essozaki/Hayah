using Microsoft.AspNetCore.Mvc;
using Pharmacy_Project.Api.Bll;
using Pharmacy_Project.Api.Models;
using Pharmacy_Project.API.Models;


namespace Pharmacy_Project.Api.Controllers
{
  [Route("api/[controller]")]
        [ApiController]
        public class TermsConditionsApiController : ControllerBase
        {
            private readonly ITerms_ConditionsApiRep _term;

            public TermsConditionsApiController(ITerms_ConditionsApiRep term)
            {
                this._term = term;
            }



            [HttpGet]
            [Route("/api/GetAllTerms")]
            public IActionResult Get()
            {
                try
                {
                    var data = _term.GetAll();

                    Terms_ConditionsCustomResponse Cusotm = new Terms_ConditionsCustomResponse
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
