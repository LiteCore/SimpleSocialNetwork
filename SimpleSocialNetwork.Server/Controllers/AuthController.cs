using Microsoft.AspNetCore.Mvc;

namespace SimpleSocialNetwork.Server.Controllers
{
    [ApiController]
    [Route("/auth/{action}")]
    public class AuthController : Controller
    {
        private readonly ILogger<UserController> _logger;
        public AuthController(ILogger<UserController> logger)
        {
            _logger = logger;
        }
    }
}
