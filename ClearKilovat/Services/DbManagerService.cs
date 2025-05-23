using ClearKilovat.DB;
using ClearKilovat.Interfaces;
using ClearKilovat.Models.DTO;
using ClearKilovat.Models.Entity;

namespace ClearKilovat.Services
{
    public class DbManagerService : IDbManagerService
    {
        private readonly PostgreDBContext _context;

        public DbManagerService(PostgreDBContext context)
        {
            _context = context;
        }

        public List<Account> GetAccounts()
        {
            
            return _context.Accounts.ToList();
        }
    }
}
