using CrudApplication.Models.Auth;
using Microsoft.AspNetCore.Identity;

namespace CrudApplication.Repository.Auth
{
    public interface IAuthenticationRepository
    {
        Task<int> AddUser(UserSignupModel model);
        Task<UserSignupModel> UpdateUser(UserSignupModel model, int id);
        Task DeleteUser(UserSignupModel model);
        Task<bool> UserExist(string email, string password);
        Task<IEnumerable<UserSignupModel>> UserList();
        Task<UserSignupModel> GetUserDetailById(int id);
    }
}
