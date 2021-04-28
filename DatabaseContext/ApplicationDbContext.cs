using  Microsoft.EntityFrameworkCore;
using TranferAPI.Models;

namespace TranferAPI.DatabaseContext
{
    
    public class ApplicationDbContext  : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        
        
    }


}