using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1FinanceAssignment_Web_Api_.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }

        [ForeignKey("Category")]
        public int CatId { get; set; }

        public Category? Category { get; set; }
    }
}
