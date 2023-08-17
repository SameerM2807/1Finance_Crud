using _1FinanceAssignment_Web_Api_.Models;

namespace _1FinanceAssignment_Web_Api_.Repository
{
    public interface ICategoryRepository
    {
        bool AddCategory(Category category);
        bool deleteById(int id);
        List<Category> GetAllCategories();
        Category GetByID(int id);
        bool Update(Category category);
    }
}
