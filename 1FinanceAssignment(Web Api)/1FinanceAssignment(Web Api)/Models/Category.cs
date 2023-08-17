using System.ComponentModel.DataAnnotations;

namespace _1FinanceAssignment_Web_Api_.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? Category_name { get; set; }
        public string? description { get; set; }

        public List<Product>? products { get; set; }
    }
}
