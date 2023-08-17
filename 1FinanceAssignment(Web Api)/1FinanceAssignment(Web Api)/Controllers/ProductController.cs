using _1FinanceAssignment_Web_Api_.Models;
using _1FinanceAssignment_Web_Api_.ProductDto;
using _1FinanceAssignment_Web_Api_.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace _1FinanceAssignment_Web_Api_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IProductRepository _productRepository;
        readonly IMapper _mapper;
        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper= mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
           
            IEnumerable<Product> allproducts = _productRepository.GetAllProducts();
            IEnumerable<GetProductDto> dto= _mapper.Map<List<GetProductDto>>(allproducts);


            return Ok(dto);
        }


       

        [HttpPost]

        //argumets call model binding
        public IActionResult AddProduct(AddProductDto dto)
        {
            Product product=_mapper.Map<Product>(dto);
            bool addProductStatus = _productRepository.AddProduct(product);

            if(addProductStatus)
                return Ok();
            return BadRequest(addProductStatus);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            bool result = _productRepository.deleteById(id);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(new { message = "Failed to delete the product." });
        }





        [HttpPut]
        public ActionResult Edit(GetProductDto dto)
        {
            Product product = _mapper.Map<Product>(dto);
            bool result=  _productRepository.Update(product);
            if(result)
            {
                return Ok(result); 
            }
            return BadRequest();
        }


        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var pro = _productRepository.GetByID(id);
            if (pro != null)
            {
                return Ok(pro);
            }
            return BadRequest();
        }
    }
}
