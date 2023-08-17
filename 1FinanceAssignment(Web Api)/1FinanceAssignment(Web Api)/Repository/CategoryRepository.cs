using _1FinanceAssignment_Web_Api_.ContextLayered;
using _1FinanceAssignment_Web_Api_.Models;
using Microsoft.EntityFrameworkCore;

namespace _1FinanceAssignment_Web_Api_.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        readonly ProductDbContext _context;


        public CategoryRepository(ProductDbContext context)
        {
            _context = context;
        }

        public bool AddCategory(Category category)
        {
            if (_context.categories.Any(p => p.Category_name == category.Category_name) == false)
            {
                _context.categories.Add(category);
            }

            bool b = _context.SaveChanges() > 0 ? true : false;

            return b;
        }

        public bool deleteById(int id)
        {
            int result;
            var category = _context.categories.FirstOrDefault(u => u.Id == id);
            if (category != null)
            {
                _context.categories.Remove(category);
                result = _context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Category> GetAllCategories()
        {
            List<Category> Category = _context.categories.ToList();

            return Category;
        }

        public Category GetByID(int id)
        {
            Category? category = _context.categories.FirstOrDefault(u => u.Id == id);

            return category;
        }

        public bool Update(Category category)
        {
            int result;
            var category1 = _context.categories.FirstOrDefault(u => u.Id == category.Id);
            if (category1 != null)
            {
                category1.Category_name = category.Category_name;
                category1.description = category.description;
                _context.categories.Update(category1);
                result = _context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
