using LinkedOutClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LinkedOutClient.Controllers
{
    public class PostController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "http://localhost:5258";
        public PostController() 
        { 
            _httpClient = new HttpClient();
        }
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/post");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var posts = JsonConvert.DeserializeObject<List<PostModel>>(content);
                return View(posts);
            }
            return View("Error");
        }
    }
}
