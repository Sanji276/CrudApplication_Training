using CrudApplication.Models.Auth;
using Microsoft.AspNetCore.Identity;

namespace CrudApplication.Repository.Auth
{
    public interface IAuthenticationRepository
    {
        Task<int> AddUser(UserSignupModel model);
        Task<UserSignupModel> UpdateUser(UserSignupModel model);
        Task DeleteUser(UserSignupModel model);
    }
}
