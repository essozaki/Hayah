using Pharmacy_Project.Extend;

//using Pharmacy_Project.Api.Interfaces;
using Pharmacy_Project.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using static Pharmacy_Project.Api.Models.ResetPasswordModel;
using Pharmacy_Project.Models;
using EmailService;
using Pharmacy_Project.Api.Services.BLL;

namespace Pharmacy_Project.Api.Services
{
    public class UserService : IUserService
    {
        private UserManager<ApplicationUser> _userManger;
        private IConfiguration _configuration;
        //private IMailService _mailService;
        IEmailSender _emailSender;


        public UserService(IEmailSender emailSender, UserManager<ApplicationUser> userManager, IConfiguration configuration /*IMailService mailService*/)
        {
            _userManger = userManager;
            _configuration = configuration;
            _emailSender = emailSender;
            //_mailService = mailService;


        }



        public async Task<UserManagerResponse> RegisterUserAsync(registerationVM model)
        {
            if (model == null)
                throw new NullReferenceException("Reigster Model is null");

            //if (model.Password != model.ConfirmPassword)
            //    return new UserManagerResponse
            //    {
            //        Message = "Confirm password doesn't match the password",
            //        IsSuccess = false,

            //    };

            //var user = new ApplicationUser
               var user = new ApplicationUser

               {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName,

               Gender = model.Gender,

               };

            var result = await _userManger.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var confirmEmailToken = await _userManger.GenerateEmailConfirmationTokenAsync(user);

                var encodedEmailToken = Encoding.UTF8.GetBytes(confirmEmailToken);
                var validEmailToken = WebEncoders.Base64UrlEncode(encodedEmailToken);
                string url = $"{_configuration["AppUrl"]}/api/auth/confirmemail?userid={user.Id}&token={validEmailToken}";
                //await _mailService.SendEmailAsync(user.UserName, "Email created successfully!", $"<h1>Welcome to Auth 'Carea' Project</h1>");

                return new UserManagerResponse
                {
                    Message = "User created successfully!",
                    IsSuccess = true,
                };
            }

            return new UserManagerResponse
            {
                Message = "User did not create",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }



        public async Task<UserManagerResponse> LoginUserAsync(LoginModel model)
        {
            var user = await _userManger.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return new UserManagerResponse
                {
                    Message = "There is no user with that Email address",
                    IsSuccess = false,
                };
            }

            var result = await _userManger.CheckPasswordAsync(user, model.Password);

            if (!result)
                return new UserManagerResponse
                {
                    Message = "Invalid password",
                    IsSuccess = false,
                };

            var claims = new[]
            {
                new Claim("Email", model.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserManagerResponse
            {
                Message = "User Login successfully!",
                IsSuccess = true,
                ExpireDate = token.ValidTo,
                Token = tokenAsString
            };
        }

        public async Task<UserManagerResponse> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManger.FindByIdAsync(userId);
            if (user == null)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "User not found"
                };

            var decodedToken = WebEncoders.Base64UrlDecode(token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManger.ConfirmEmailAsync(user, normalToken);

            if (result.Succeeded)
                return new UserManagerResponse
                {
                    Message = "Email confirmed successfully!",
                    IsSuccess = true,
                };

            return new UserManagerResponse
            {
                IsSuccess = false,
                Message = "Email did not confirm",
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        public async Task<UserManagerResponse> ForgetPasswordAsync(string Email, IFormFileCollection attachments)
        {
            var user = await _userManger.FindByEmailAsync(Email);
            if (user == null)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "No user associated with email",
                };

            var token = await _userManger.GeneratePasswordResetTokenAsync(user);
            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);

            string url = $"{_configuration["AppUrl"]}/ResetPassword?email={Email}&token={validToken}";

            var messages = new EmailService.Message(new string[] { Email }, "There is some one need to reset password , Is that you !? ", null, attachments, token);
            await _emailSender.SendEmailAsync2(messages, Email, "", null);
          

            return new UserManagerResponse
            {
                IsSuccess = true,
                Message = "Reset password URL has been sent to the email successfully!",
                Token = validToken,
            };
        }

        public async Task<UserManagerResponse> ResetPasswordAsync(ResetPasswordModel model)
        {
            var user = await _userManger.FindByEmailAsync(model.Email);
            if (user == null)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "No user associated with email",
                };

            if (model.NewPassword != model.ConfirmPassword)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "Password doesn't match its confirmation",
                };

            var decodedToken = WebEncoders.Base64UrlDecode(model.Token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManger.ResetPasswordAsync(user, normalToken, model.NewPassword);

            if (result.Succeeded)
                return new UserManagerResponse
                {
                    Message = "Password has been reset successfully!",
                    IsSuccess = true,
                };

            return new UserManagerResponse
            {
                Message = "Something went wrong",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description),
            };
        }
    }
}
