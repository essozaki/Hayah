using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy_Project.Api.Bll;
using Pharmacy_Project.Api.Models;
using Pharmacy_Project.API.Models;
using Pharmacy_Project.Bll;
using Pharmacy_Project.Data.Entities;
using Pharmacy_Project.Models;

namespace Pharmacy_Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplainsApiController : ControllerBase
    {

        private readonly IComplainsApiRep _comp;

        public ComplainsApiController(IComplainsApiRep comp)
        {
            this._comp = comp;
        }
       
        [HttpPost]
        [Route("/api/PostComplains")]
        public IActionResult PostService(ComplainsVM obj)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var data = _comp.Creat(obj);

                    ComplainsCustomResponse Cusotm = new ComplainsCustomResponse
                    {

                        Record = data,
                        Code = "200",
                        Message = "Data Returned",
                        Status = "Done"

                    };
                    return Ok(Cusotm);
                }
                return StatusCode(400, new CustomResponse { Code = "400", Message = "Invalid Data Annotation" });

            }
            catch (Exception)
            {

                return StatusCode(400, new CustomResponse { Code = "400", Message = "Invalid Data Annotation" });
            }

        }
    }
}
