using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ceng382.Models.Northwind
{
    [Table("Shippers")]
    public class Shipper
    {
        [Key]
        public int ShipperID { get; set; }

        [Required]
        [MaxLength(40)]
        public string CompanyName { get; set; } = string.Empty;

        [MaxLength(24)]
        public string? Phone { get; set; }
    }
}
