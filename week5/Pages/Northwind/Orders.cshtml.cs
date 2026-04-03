using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ceng382.Data;
using Ceng382.Models.Northwind;

namespace Ceng382.Pages.Northwind
{
    public class OrdersModel : PageModel
    {
        private readonly NorthwindDbContext _db;

        public OrdersModel(NorthwindDbContext db)
        {
            _db = db;
        }

        public List<Order> Orders { get; set; } = new();

        public void OnGet()
        {
            Orders = _db.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.Shipper)
                .OrderByDescending(o => o.OrderDate)
                .ToList();
        }
    }
}
