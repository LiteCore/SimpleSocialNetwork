using Microsoft.AspNetCore.Mvc;

namespace SimpleSocialNetwork.Server.Controllers
{
    [ApiController]
    [Route("/auth/{action}")]
    public class AuthController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public AuthController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
    }
}
