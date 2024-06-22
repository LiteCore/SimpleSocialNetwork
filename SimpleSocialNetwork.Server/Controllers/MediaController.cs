using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleSocialNetwork.Server.Services.DB;
using System.Net.Mime;

namespace SimpleSocialNetwork.Server.Controllers
{
    [Produces(MediaTypeNames.Image.Png)]
    [ApiController]
    public class MediaController : Controller
    {
        private readonly ILogger<MediaController> _logger;
        private readonly SocialNetworkDBContext _dbContext;

        public MediaController(ILogger<MediaController> logger, SocialNetworkDBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("/api/v1/profilePic")]
        [ResponseCache(Duration = 86400, Location = ResponseCacheLocation.Any, NoStore = false)]
        public IActionResult GetProfilePic(string userName)
        {
            var picture = _dbContext.Users
                .Select(x => new { UserName = x.UserName, ProfilePic = x.ProfilePic })
                .Include(x => x.ProfilePic)
                .FirstOrDefault(x => x.UserName == userName)?
                .ProfilePic.Picture;
            if (picture == null)
            {
                return NotFound();
            }
            return File(picture, "image/png");
        }
    }
}
