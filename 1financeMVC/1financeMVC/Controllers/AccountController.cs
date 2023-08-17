using _1financeMVC.AccountDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace _1financeMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient _httpClient;

        public AccountController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

       
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            using (var response = await _httpClient.PostAsync($"https://localhost:7094/api/Account/api/Register", content))
            {
                var data = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Register  successfully!";
                    return RedirectToAction("Login");
                }
                else
                {
                    TempData["SuccessMessage"] = "Registeration failed!";
                    return RedirectToAction("Register");
                }
            }

            return View();
        }







        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            using (var response = await _httpClient.PostAsync($"https://localhost:7094/api/Account/api/Login", content))
            {
                var data = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    HttpContext.Session.SetString("_layout","true");
                    TempData["SuccessMessage"] = "Login successfully!";
                    return RedirectToAction("GetAllProducts","Product");
                }
                else
                {
                    TempData["SuccessMessage2"] = "Login failed!";
                    return RedirectToAction("Login");
                }
            }

            return View();
        }


       
        public async Task<IActionResult> LogOut()
        {
            return RedirectToAction("Login");
        }

    }
}
