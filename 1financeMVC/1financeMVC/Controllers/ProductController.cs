using _1financeMVC.ProductDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace _1financeMVC.Controllers
{
    public class ProductController : Controller
    {
        // public static List<SearchProductVm> products = GlobalValues.products;
        private readonly HttpClient _httpClient;
       

        public ProductController()
        {
            _httpClient = new HttpClient();
            

        }

        [HttpGet]
        public async Task<ActionResult> GetAllProducts()
        {
            List<Product> allProducts = new List<Product>(); // Change the type to a List<Product>

            using (var response = await _httpClient.GetAsync("https://localhost:7094/api/Product"))
            {
                string data = await response.Content.ReadAsStringAsync();
                allProducts = JsonConvert.DeserializeObject<List<Product>>(data); // Deserialize into a List<Product>
            }

            return View(allProducts); // Pass the list of products to the view
        }





        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductDto dto)
        {
            if (ModelState.IsValid)
            {
                string dtoJson = JsonConvert.SerializeObject(dto);
                var content = new StringContent(dtoJson, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync("https://localhost:7094/api/Product", content);
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Product Added successfully!";
                    return RedirectToAction("GetAllProducts");
                }
                else
                {
                    TempData["SuccessMessage"] = "Product Already Exists";
                    return RedirectToAction("AddProduct");
                }
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://localhost:7094/api/Product/{id}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(content);
                return View(product);
            }
            return View(); // Handle error case
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://localhost:7094/api/Product/{id}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(content);
                return View(product);
            }
            return View(); // Handle error case
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(Product dto)
        {
            if (ModelState.IsValid)
            {
                string dtoJson = JsonConvert.SerializeObject(dto);
                var content = new StringContent(dtoJson, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PutAsync($"https://localhost:7094/api/Product", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetAllProducts");
                }
            }
            return View(dto);
        }



        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://localhost:7094/api/Product/{id}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(content);
                return View(product);
            }
            return View(); // Handle error case
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"https://localhost:7094/api/Product/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllProducts");
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError(string.Empty, "Failed to delete the product.");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "An error occurred while processing your request.");
            }

            return View("GetAllProducts");
        }


    }
}
