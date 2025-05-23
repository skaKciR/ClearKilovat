using ClearKilovat.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace ClearKilovat.DB
{
    public class PostgreDBContext :DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Consumption> Consumptions { get; set; }
        public PostgreDBContext(DbContextOptions<PostgreDBContext> options) : base(options)
        {
            
        }
    }
}
