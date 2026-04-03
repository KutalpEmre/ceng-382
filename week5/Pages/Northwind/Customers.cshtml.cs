using Microsoft.AspNetCore.Mvc.RazorPages;
using Ceng382.Data;
using Ceng382.Models.Northwind;

namespace Ceng382.Pages.Northwind
{
    public class CustomersModel : PageModel
    {
        private readonly NorthwindDbContext _db;

        public CustomersModel(NorthwindDbContext db)
        {
            _db = db;
        }

        public List<Customer> Customers { get; set; } = new();

        public void OnGet()
        {
            Customers = _db.Customers
                .OrderBy(c => c.CompanyName)
                .ToList();
        }
    }
}
