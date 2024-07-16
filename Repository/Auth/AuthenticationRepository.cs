using CrudApplication.Database;
using CrudApplication.Models.Auth;

namespace CrudApplication.Repository.Auth
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly CrudApplicationDbContext _dbContext;

        public AuthenticationRepository(CrudApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddUser(UserSignupModel model)
        {
            try
            {                
                var result = await _dbContext.UsersDetail.AddAsync(model);
                await _dbContext.SaveChangesAsync();
                return result.Entity.Id;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public Task DeleteUser(UserSignupModel model)
        {
            throw new NotImplementedException();
        }

        public Task<UserSignupModel> UpdateUser(UserSignupModel model)
        {
            throw new NotImplementedException();
        }
    }
}
