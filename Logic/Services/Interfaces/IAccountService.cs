using Logic.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services.Interfaces
{
    public interface IAccountService
    {
        Task<ClaimsPrincipal> LoginAsync(UserLoginViewModel model);
        Task<bool> RegisterAsync(UserRegisterViewModel model);
        Task<EditProfileViewModel> EditProfileAsync(string login);
        Task<EditProfileViewModel> EditProfileAsync(EditProfileViewModel model, string login);
        Task<ChangePasswordViewModel> ChangePasswordAsync(ChangePasswordViewModel model, string login);
    }
}
