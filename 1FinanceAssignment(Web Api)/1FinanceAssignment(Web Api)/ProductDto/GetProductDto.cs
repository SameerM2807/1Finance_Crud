using System.ComponentModel.DataAnnotations.Schema;

namespace _1FinanceAssignment_Web_Api_.ProductDto
{
    public class GetProductDto
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }

       
        public int CatId { get; set; }
    }
}
