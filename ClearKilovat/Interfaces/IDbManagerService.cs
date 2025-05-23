using ClearKilovat.Models.Entity;

namespace ClearKilovat.Interfaces
{
    public interface IDbManagerService
    {
        public List<Account> GetAccounts();
    }
}
