using CrudApplication.Models.Auth;
using Microsoft.EntityFrameworkCore;

namespace CrudApplication.Database
{
    public class CrudApplicationDbContext : DbContext
    {
        public CrudApplicationDbContext(DbContextOptions<CrudApplicationDbContext> dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<UserSignupModel> UsersDetail { get; set; }
    }
}
