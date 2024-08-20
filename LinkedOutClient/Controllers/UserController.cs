using Microsoft.AspNetCore.Mvc;

namespace LinkedOutClient.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:5258";
        public IActionResult Index()
        {
            return View();
        }
    }
}
