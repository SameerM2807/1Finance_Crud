using _1FinanceAssignment_Web_Api_.CategoryDto;
using _1FinanceAssignment_Web_Api_.Models;
using _1FinanceAssignment_Web_Api_.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace _1FinanceAssignment_Web_Api_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        readonly ICategoryRepository _categoryRepository;
        readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper= mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {

            IEnumerable<Category> AllCategories = _categoryRepository.GetAllCategories();
            IEnumerable<GetCategoryDto> getCategoryDtos=_mapper.Map<List<GetCategoryDto>>(AllCategories);

            return Ok(getCategoryDtos);
        }




        [HttpPost]

        //argumets call model binding
        public IActionResult AddProduct(AddCategoryDto dto)
        {
            Category category=_mapper.Map<Category>(dto);

            bool AddCategory = _categoryRepository.AddCategory(category);

            if (AddCategory)
                return Ok();
            return BadRequest(AddCategory);

        }


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            bool result = _categoryRepository.deleteById(id);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }



        [HttpPut]
        public ActionResult Edit(GetCategoryDto dto)
        {
            Category category = _mapper.Map<Category>(dto);
            bool result = _categoryRepository.Update(category);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
