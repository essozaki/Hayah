//using Pharmacy_Project.Api.Interfaces;
using Pharmacy_Project.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Pharmacy_Project.Models;
using Pharmacy_Project.Api.Services.BLL;

namespace Pharmacy_Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        //private readonly IMailService _mailService;
        private IConfiguration _configuration;

        public AuthController(IUserService userService , /*IMailService mailService,*/ IConfiguration configuration)
        {
 
            _userService = userService;
            //_mailService = mailService;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody]registerationVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUserAsync(model);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest("Some Inputs are not valid !"); // status code 400
        }


        // /api/auth/login
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginUserAsync(model);

                if (result.IsSuccess)
                {
                    //await _mailService.SendEmailAsync(model.Email, "New login", "<h1>Hey!, new login to your account noticed</h1><p>New login to your account at " + DateTime.Now + "</p>");
                    return Ok(result);
                }

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
        }


      

        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(string email, IFormFileCollection attachments)
        {
            if (string.IsNullOrEmpty(email))
                return NotFound();

            var result = await _userService.ForgetPasswordAsync(email,  attachments);

            if (result.IsSuccess)
                return Ok(result); // 200

            return BadRequest(result); // 400
        }

        // api/auth/resetpassword
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.ResetPasswordAsync(model);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
        }


    }
}
