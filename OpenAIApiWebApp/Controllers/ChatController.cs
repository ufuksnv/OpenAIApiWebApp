using Azure.AI.OpenAI;
using Azure;
using Microsoft.AspNetCore.Mvc;
using OpenAIApiWebApp.Services;
using System.Threading.Tasks;

namespace OpenAIApiWebApp.Controllers
{
    public class ChatController : Controller
    {
        private readonly ApiService _apiService;

        public ChatController(ApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string prompt)
        {
            if (string.IsNullOrEmpty(prompt) || prompt.Length > 50)
            {
                ViewBag.ErrorMessage = "Hata: Mesaj boş olamaz veya en fazla 50 karakter içerebilir.";
                return View();
            }

            string responseMessage = await _apiService.SendApiMessage(prompt);
            ViewBag.ResponseMessage = responseMessage;

            return View();
        }

        
    }
}
