using Microsoft.EntityFrameworkCore;
using StoreTestTask.Data.Interfaces;
using StoreTestTask.Data.Models;


namespace StoreTestTask.Data.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetClientsByBirthdayAsync(DateTime date)
        {
            return await _context.Clients
                .Where(c => c.BirthDate.Month == date.Month && c.BirthDate.Day == date.Day)
                .ToListAsync();
        }

        public async Task<IEnumerable<ClientPurchaseInfo>> GetRecentBuyersAsync(DateTime cutoffDate)
        {
            return await _context.Purchases
                .Where(p => p.Date >= cutoffDate)
                .GroupBy(p => p.ClientId)
                .Select(g => new ClientPurchaseInfo
                {
                    Client = g.First().Client,
                    LastPurchaseDate = g.Max(p => p.Date)
                })
                .ToListAsync();
        }

        public async Task<Dictionary<string, int>> GetPopularCategoriesAsync(int clientId)
        {
            return await _context.PurchaseDetails
                .Where(pi => pi.Purchase.ClientId == clientId)
                .GroupBy(pi => pi.Product.Category)
                .Select(g => new { Category = g.Key, Quantity = g.Sum(pi => pi.Quantity) })
                .ToDictionaryAsync(x => x.Category, x => x.Quantity);
        }
    }
}
