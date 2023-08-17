using _1FinanceAssignment_Web_Api_.ContextLayered;
using _1FinanceAssignment_Web_Api_.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace _1FinanceAssignment_Web_Api_.Repository
{
    public class ProductRepository : IProductRepository
    {

        ProductDbContext _context;
        public ProductRepository(ProductDbContext appDbContext)
        {
            _context = appDbContext;
        }

       
        public bool AddProduct(Product product)
        {
            if (_context.products.Any(p => p.ProductName == product.ProductName) == false)
            {
                _context.products.Add(product);
            }

            bool b = _context.SaveChanges() > 0 ? true : false;

            return b;

        }

       
        public bool deleteById(int id)
        {
            int result;
            var product = _context.products.FirstOrDefault(u => u.ProductId == id);
            if (product != null)
            {
                _context.products.Remove(product);
              result=  _context.SaveChanges();
                if(result > 0)
                {
                    return true;
                }
            }
            return false;
            
        }
       
        public List<Product> GetAllProducts()
        {
            List<Product> products = _context.products.ToList();

            return products;
        }

        
        public Product GetByID(int id)
        {
            Product? product = _context.products.FirstOrDefault(u => u.ProductId == id);

            return product;
        }

        
        public bool Update(Product product)
        {
            int result;
            var products1 = _context.products.FirstOrDefault(u => u.ProductId == product.ProductId);
            if (products1 != null)
            {
                _context.products.Remove(products1);
                _context.products.Add(product);
               result= _context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
