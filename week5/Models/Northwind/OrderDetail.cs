using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ceng382.Models.Northwind
{
    [Table("Order Details")]
    [PrimaryKey(nameof(OrderID), nameof(ProductID))]
    public class OrderDetail
    {
        public int OrderID { get; set; }

        public int ProductID { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        public short Quantity { get; set; }

        public float Discount { get; set; }

        [ForeignKey(nameof(OrderID))]
        public Order? Order { get; set; }

        [ForeignKey(nameof(ProductID))]
        public Product? Product { get; set; }
    }
}
