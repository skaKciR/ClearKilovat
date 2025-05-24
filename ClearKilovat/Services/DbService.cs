using System.Text.Json;
using ClearKilovat.DB;
using ClearKilovat.Interfaces;
using ClearKilovat.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace ClearKilovat.Services
{
    public class DbService : IDbService
    {
        private readonly PostgreDBContext _context;

        public DbService(PostgreDBContext context)
        {
            _context = context;
        }

        public List<Account> GetAccounts() => _context.Accounts.ToList();

        public async Task ImportFromFileAsync()
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, "JsonDataSet", "dataset_test.json");

            var json = await File.ReadAllTextAsync(filePath);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var rawAccounts = JsonSerializer.Deserialize<List<AccountRaw>>(json, options);

            foreach (var raw in rawAccounts)
            {
                if (await _context.Set<Account>().AnyAsync(a => a.Id == raw.accountId))
                    continue;

                var account = new Account
                {
                    Id = raw.accountId,
                    IsCommercial = raw.isCommercial,
                    Address = raw.address,
                    BuildingType = raw.buildingType,
                    RoomsCount = raw.roomsCount,
                    ResidentsCount = raw.residentsCount,
                    TotalArea = raw.totalArea,
                    Consumptions = new List<Consumption>()
                };

                if (raw.consumption != null)
                {
                    foreach (var kvp in raw.consumption)
                    {
                        if (int.TryParse(kvp.Key, out int month))
                        {
                            account.Consumptions.Add(new Consumption
                            {
                                Month = month,
                                Value = kvp.Value
                            });
                        }
                    }
                }

                _context.Set<Account>().Add(account);
            }

            await _context.SaveChangesAsync();
        }

    private class AccountRaw
    {
        public int accountId { get; set; }
        public bool isCommercial { get; set; }
        public string address { get; set; }
        public string buildingType { get; set; }
        public int? roomsCount { get; set; }
        public int? residentsCount { get; set; }
        public decimal? totalArea { get; set; }
        public Dictionary<string, int> consumption { get; set; }
    }
    }
}
