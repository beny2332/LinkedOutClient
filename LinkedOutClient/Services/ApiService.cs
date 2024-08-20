using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LinkedOutClient.Models;
using LinkedOutClient.DTO;
namespace LinkedOutClient.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:5258";
        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> LoginAsync(string username, string password)
        {
            var response = await _httpClient.PostAsync($"{_baseUrl}api/User/login",new StringContent(JsonConvert.SerializeObject(new { username, password })
                ,System.Text.Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return null;
        }

        public async Task<bool> CreatePostAsync(string token, NewPostDTO postDto)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.PostAsync($"{_baseUrl}api/post",
                new StringContent(JsonConvert.SerializeObject(postDto),
                System.Text.Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }
    }
}
