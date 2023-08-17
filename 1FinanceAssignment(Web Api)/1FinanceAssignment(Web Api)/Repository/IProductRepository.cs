using _1FinanceAssignment_Web_Api_.Models;

namespace _1FinanceAssignment_Web_Api_.Repository
{
    public interface IProductRepository
    {

        bool AddProduct(Product product);
        bool deleteById(int id);
        List<Product> GetAllProducts();
        Product GetByID(int id);
        bool Update(Product product);

    }
}
