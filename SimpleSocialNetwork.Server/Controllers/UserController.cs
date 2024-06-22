using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleSocialNetwork.Server.Services.DB;
using SimpleSocialNetwork.Server.Services.UserManager;
using System.Diagnostics;
using System.Reflection;

namespace SimpleSocialNetwork.Server.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly SocialNetworkDBContext _dbContext;
        private readonly UserManager _userManager;

        public UserController(ILogger<UserController> logger, SocialNetworkDBContext dbContext, UserManager userManager)
        {
            _logger = logger;
            _dbContext = dbContext;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("/api/v1/user")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult GetUsers(int count = 10, int offset = 0)
        {
            return Ok(_dbContext.Users
                .Skip(offset)
                .Take(count)
                .Select(x => new Models.DTO.User(x))
                .ToList());
        }

        [HttpGet]
        [Route("/api/v1/user/{userName}")]
        public IActionResult GetUser(string userName)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.UserName == userName);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(new Models.DTO.User(user));
        }
        [HttpDelete]
        [Route("/api/v1/user/{userName}")]
        public IActionResult DeleteUser(string userName)
        {
            var user = new Services.DB.User() { UserName = userName };
            _dbContext.Users.Attach(user);
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
            return Ok();
        }
        [HttpPost]
        [Route("/api/v1/user/{userName}")]
        public async Task<IActionResult> PostUser(string userName, [FromBody] Models.DTO.User user)
        {
            if (user == null || user.UserName == null || user.Password == null)
                return Forbid();
            user = new Models.DTO.User(await _userManager.AddUser(user.UserName, user.Password));
            return Ok(user);
        }

    }
}
