using Microsoft.AspNetCore.Identity;

namespace Ceng382.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public byte[]? ProfilePhoto { get; set; }
        public string? ProfilePhotoType { get; set; }
    }
}
