using ClearKilovat.Models.Entity;

namespace ClearKilovat.Interfaces
{
    public interface IJsonToPostgreLoader
    {
        public Task ImportFromFileAsync();
        public List<Account> GetAccounts();
    }
}
