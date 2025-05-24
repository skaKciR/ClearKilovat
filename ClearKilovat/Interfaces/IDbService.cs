using ClearKilovat.Models.Entity;

namespace ClearKilovat.Interfaces
{
    public interface IDbService
    {
        public Task ImportFromFileAsync();
        public List<Account> GetAccounts();
    }
}
