using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ceng382.Data;
using Ceng382.Models.Northwind;

namespace Ceng382.Pages.Northwind
{
    public class EmployeesModel : PageModel
    {
        private readonly NorthwindDbContext _db;

        public EmployeesModel(NorthwindDbContext db)
        {
            _db = db;
        }

        public List<Employee> Employees { get; set; } = new();

        public void OnGet()
        {
            Employees = _db.Employees
                .Include(e => e.Manager)
                .OrderBy(e => e.LastName)
                .ToList();
        }
    }
}
