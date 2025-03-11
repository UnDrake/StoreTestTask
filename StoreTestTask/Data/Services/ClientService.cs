using StoreTestTask.Data.Interfaces;
using StoreTestTask.ViewModels;


namespace StoreTestTask.Data.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IEnumerable<BirthdayClientViewModel>> GetBirthdayPeopleAsync(DateTime date)
        {
            var clients = await _clientRepository.GetClientsByBirthdayAsync(date);
            return clients.Select(c => new BirthdayClientViewModel { Id = c.Id, FullName = c.FullName });
        }

        public async Task<IEnumerable<RecentBuyerViewModel>> GetRecentBuyersAsync(int days)
        {
            var cutoffDate = DateTime.UtcNow.AddDays(-days);
            var clients = await _clientRepository.GetRecentBuyersAsync(cutoffDate);

            return clients.Select(c => new RecentBuyerViewModel
            {
                Id = c.Client.Id,
                FullName = c.Client.FullName,
                LastPurchaseDate = c.LastPurchaseDate
            });
        }

        public async Task<IEnumerable<PopularClientCategoryViewModel>> GetPopularCategoriesAsync(int clientId)
        {
            var categories = await _clientRepository.GetPopularCategoriesAsync(clientId);
            return categories.Select(c => new PopularClientCategoryViewModel { Category = c.Key, Quantity = c.Value });
        }
    }
}
