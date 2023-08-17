using _1financeMVC.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _1financeMVC.ProductDto
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Name is required.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive value.")]
        public int quantity { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public double price { get; set; }

        [DisplayName("Category")]
        public Category CatId { get; set; }
    }
}
