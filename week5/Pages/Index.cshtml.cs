using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ceng382.Data;
using Ceng382.Models.Identity;
using Ceng382.Models.Media;

namespace Ceng382.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly NorthwindDbContext _nwDb;

        public IndexModel(ApplicationDbContext db, NorthwindDbContext nwDb)
        {
            _db = db;
            _nwDb = nwDb;
        }

        public List<ImageModel> Images { get; set; } = new();
        public List<ApplicationUser> Users { get; set; } = new();
        public int ProductCount { get; set; }
        public int CustomerCount { get; set; }
        public int OrderCount { get; set; }

        public void OnGet()
        {
            Images = _db.Images.OrderByDescending(x => x.UploadedAt).ToList();
            Users = _db.Users.ToList();
            ProductCount = _nwDb.Products.Count();
            CustomerCount = _nwDb.Customers.Count();
            OrderCount = _nwDb.Orders.Count();
        }

        public async Task<IActionResult> OnPostUploadGalleryAsync(IList<IFormFile> galleryFiles)
        {
            foreach (var file in galleryFiles)
            {
                if (file == null || file.Length == 0) continue;

                using var ms = new MemoryStream();
                await file.CopyToAsync(ms);

                _db.Images.Add(new ImageModel
                {
                    FileName = file.FileName,
                    ContentType = file.ContentType,
                    Size = file.Length,
                    Data = ms.ToArray(),
                    UploadedBy = User.Identity?.Name
                });
            }

            await _db.SaveChangesAsync();
            return RedirectToPage();
        }
    }
}
