using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ceng382.Models.Northwind
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [MaxLength(40)]
        public string ProductName { get; set; } = string.Empty;

        public int? SupplierID { get; set; }

        public int? CategoryID { get; set; }

        [MaxLength(20)]
        public string? QuantityPerUnit { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }

        [ForeignKey(nameof(CategoryID))]
        public Category? Category { get; set; }

        [ForeignKey(nameof(SupplierID))]
        public Supplier? Supplier { get; set; }
    }
}
