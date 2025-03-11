using StoreTestTask.Data.Models;


namespace StoreTestTask.Data.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClientsByBirthdayAsync(DateTime date);
        Task<IEnumerable<ClientPurchaseInfo>> GetRecentBuyersAsync(DateTime cutoffDate);
        Task<Dictionary<string, int>> GetPopularCategoriesAsync(int clientId);
    }
}
