using StoreTestTask.ViewModels;


namespace StoreTestTask.Data.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<BirthdayClientViewModel>> GetBirthdayPeopleAsync(DateTime date);
        Task<IEnumerable<RecentBuyerViewModel>> GetRecentBuyersAsync(int days);
        Task<IEnumerable<PopularClientCategoryViewModel>> GetPopularCategoriesAsync(int clientId);
    }
}
