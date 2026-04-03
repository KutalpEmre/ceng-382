using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ceng382.Data;
using Ceng382.Models.Northwind;

namespace Ceng382.Pages.Northwind
{
    public class ContactInfosModel : PageModel
    {
        private readonly NorthwindDbContext _db;

        public ContactInfosModel(NorthwindDbContext db)
        {
            _db = db;
        }

        public List<Customer> Customers { get; set; } = new();
        public List<Supplier> Suppliers { get; set; } = new();
        public List<Shipper> Shippers { get; set; } = new();

        public void OnGet()
        {
            Customers = _db.Customers.OrderBy(c => c.CompanyName).ToList();
            Suppliers = _db.Suppliers.OrderBy(s => s.CompanyName).ToList();
            Shippers = _db.Shippers.OrderBy(s => s.CompanyName).ToList();
        }
    }
}
