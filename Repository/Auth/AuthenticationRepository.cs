using CrudApplication.Database;
using CrudApplication.Models.Auth;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> UserExist(string email, string password)
        {
            try
            {
                var response = await _dbContext.UsersDetail.Where(x => x.Email == email && x.Password == password).FirstOrDefaultAsync();
                if (response != null)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<UserSignupModel>> UserList()
        {
            try
            {
                var result = await _dbContext.UsersDetail.ToListAsync();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserSignupModel> GetUserDetailById(int id)
        {
            try
            {
                var result = await _dbContext.UsersDetail.Where(x => x.Id == id).FirstOrDefaultAsync();
                return result!;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Task DeleteUser(UserSignupModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<UserSignupModel> UpdateUser(UserSignupModel model,int id)
        {
            try
            {
                var userModel =await _dbContext.UsersDetail.Where(x=>x.Id == id).FirstOrDefaultAsync();
                userModel.FirstName = model.FirstName;
                userModel.LastName = model.LastName;
                userModel.Email = model.Email;
                userModel.ContactNumber = model.ContactNumber;                 
                await _dbContext.SaveChangesAsync();
                return userModel;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
