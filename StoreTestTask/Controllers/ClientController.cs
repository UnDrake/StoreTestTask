using Microsoft.AspNetCore.Mvc;
using StoreTestTask.Data.Interfaces;
using StoreTestTask.ViewModels;


[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet("birthday")]
    public async Task<ActionResult<IEnumerable<BirthdayClientViewModel>>> GetBirthdayPeople([FromQuery] DateTime date)
    {
        var clients = await _clientService.GetBirthdayPeopleAsync(date);
        return Ok(clients);
    }

    [HttpGet("recent-purchases")]
    public async Task<ActionResult<IEnumerable<RecentBuyerViewModel>>> GetRecentBuyers([FromQuery] int days)
    {
        var customers = await _clientService.GetRecentBuyersAsync(days);
        return Ok(customers);
    }

    [HttpGet("{id}/popular-categories")]
    public async Task<ActionResult<IEnumerable<PopularClientCategoryViewModel>>> GetPopularCategories(int id)
    {
        var categories = await _clientService.GetPopularCategoriesAsync(id);
        return Ok(categories);
    }
}