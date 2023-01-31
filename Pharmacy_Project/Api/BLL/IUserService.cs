using Pharmacy_Project.Api.Models;
using Pharmacy_Project.Models;


namespace Pharmacy_Project.Api.Services.BLL
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(registerationVM model);
        Task<UserManagerResponse> LoginUserAsync(LoginModel model);
        Task<UserManagerResponse> ConfirmEmailAsync(string userId , string token);
        Task<UserManagerResponse> ForgetPasswordAsync(string Email, IFormFileCollection attachments);
        Task<UserManagerResponse> ResetPasswordAsync(ResetPasswordModel model);

    }
}
