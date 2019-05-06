using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server
{
    public class dbContext : DbContext 
    {
        public DbSet<UserEntity> user {get;set;}

        public dbContext(DbContextOptions<dbContext> options)
            :base(options)
            {
                Database.EnsureCreated();
            }
    }
}