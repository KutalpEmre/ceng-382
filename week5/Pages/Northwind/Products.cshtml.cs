using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ceng382.Data;
using Ceng382.Models.Northwind;

namespace Ceng382.Pages.Northwind
{
    public class ProductsModel : PageModel
    {
        private readonly NorthwindDbContext _db;

        public ProductsModel(NorthwindDbContext db)
        {
            _db = db;
        }

        public List<Product> Products { get; set; } = new();

        public void OnGet()
        {
            Products = _db.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .OrderBy(p => p.ProductName)
                .ToList();
        }
    }
}
