using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy_Project.Api.Bll;
using Pharmacy_Project.Api.Models;
using Pharmacy_Project.API.Models;

namespace Pharmacy_Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClincsApiController : ControllerBase
    {
        private readonly IClincsApiRep _term;

        public ClincsApiController(IClincsApiRep term)
        {
            this._term = term;
        }



        [HttpGet]
        [Route("/api/GetAllClincs")]
        public IActionResult Get()
        {
            try
            {
                var data = _term.GetAll();

                ClincsCustomResponse Cusotm = new ClincsCustomResponse
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
