using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EmailService;
using Microsoft.AspNetCore.Authorization;
using Pharmacy_Project.Models;
using Pharmacy_Project.Migrations;
using Pharmacy_Project.Extend;
using Pharmacy_Project.Api.Models;
using Pharmacy_Project.Api.Services.BLL;

namespace Pharmacy_Project.Controllers
{
    public class AccountController : Controller
    {
        #region fields
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<AccountController> logger;
        private readonly IUserService _userService;
        IEmailSender _emailSender;

        #endregion

        #region obj
      

        public AccountController(IEmailSender emailSender, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<AccountController> logger,IUserService userService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this._emailSender = emailSender;
            this._userService = userService;

        }

        #endregion

        #region Actions

        //[Authorize]
        [HttpGet]
        public IActionResult Registrtion()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Registrtion(registerationVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FullName = model.FullName, PhoneNumber = model.PhoneNumber };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("LogIn");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(model);
        }


        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                //var result = await _userService.LoginUserAsync(model);
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, true, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home", model.Email);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User name or password");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("LogIn");
        }
        public IActionResult ForgetPassword(/*string id*/)
        {
            //ViewBag.email = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(forgetpasswordVM model, IFormFileCollection attachments)
        {

            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);
                    var email = user.Email;
                    var passwordResetLink = Url.Action("ResetPassword", "Account", new { Email = model.Email, Token = token }, Request.Scheme);
                    var messages = new EmailService.Message(new string[] { email }, "Reset Password url ", passwordResetLink, attachments, token);
                    await _emailSender.SendEmailAsync2(messages, email, "", passwordResetLink);

                    return RedirectToAction("ConfirmForgetPassword");
                }

                return View(model);

            }

            return View(model);
        }









        public IActionResult ResetPassword(string Email, string Token)
        {
            if (Email == null || Token == null)
            {
                ModelState.AddModelError("", "Invalid data");

            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(resetpasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ConfirmResetPassword");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                        return View(model);
                    }

                    return RedirectToAction("ConfirmResetPassword");

                }

            }

            return View(model);
        }
        public IActionResult ConfirmforgetPassword()
        {
            return View();
        }
        public IActionResult ConfirmresetPassword()
        {
            return View();
        }




        [HttpGet]
        public async Task<IActionResult> ProffileAsync(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            return View(user);
        }


    }
}
#endregion

