using System.Text.Json;
using Assignment01Solution_QE170124.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment01Solution_QE170124;

public class SearchModel : PageModel
{
    public List<Product> Products { get; set; } = new List<Product>();

    public async Task OnGet(string ProductName)
    {
        using var client = new HttpClient();
        var response = await client.GetAsync("https://localhost:5001/api/product");
        var content = await response.Content.ReadAsStringAsync();
        Products = JsonSerializer.Deserialize<List<Product>>(content);
    }
}