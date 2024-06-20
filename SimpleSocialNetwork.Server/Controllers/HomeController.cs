using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace SimpleSocialNetwork.Server.Controllers
{
    [ApiController]
    [Route("/api/{action}")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "version")]
        [ResponseCache(Duration = 86400, Location = ResponseCacheLocation.Any, NoStore = false)]
        public string Version()
        {
            return FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion?.ToString() ?? throw new Exception("Неизвестная версия API");
        }
    }
}
