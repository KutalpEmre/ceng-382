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

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<ImageModel> Images { get; set; } = new();
        public List<ApplicationUser> Users { get; set; } = new();

        public void OnGet()
        {
            Images = _db.Images.OrderByDescending(x => x.UploadedAt).ToList();
            Users = _db.Users.ToList();
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
