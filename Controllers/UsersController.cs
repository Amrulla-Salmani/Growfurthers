using GrowFurthers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Models;

namespace GrowFurthers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _config;
        public readonly dbContext _context;
        public UsersController(IConfiguration config, dbContext context)
        {

            _config = config;
            _context = context;

        }

        [HttpGet("GetUser")]
        public IActionResult Get(int userId)
        {
            //For All Users
            //var users = _context.Users.Select(u => new { Id = u.UserID, FirstName = u.Firstname, LastName = u.Lastname });
            //For single Users
            var users = _context.Users.Where(u => u.UserId == userId).ToList();
            return Ok(users);
        }

        [HttpPost("SignupUser")]
        public IActionResult Create(Users user)
        {
            if (_context.Users.Where(u => u.phoneNo == user.phoneNo).FirstOrDefault() != null)
            {
                return Ok("Already Exists!");
            }
            user.memberSince = DateTime.Now;
            user.membership = "N";
            user.userRole = "Standard";
            user.active = "Y";
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok("Success");
        }
        [HttpPost("LoginUser")]
        public IActionResult login(Login login)
        {
            //var usermail = _context.Users.Select(u => u.Mail);
            var useravailable = _context.Users.Where(u => u.email == login.UserName && u.Password == login.Password).FirstOrDefault();

            if (useravailable != null)
            {
                return Ok(new JwtService(_config).GenerateToken(
                     useravailable.UserId.ToString(),
                     useravailable.FirstName,
                     useravailable.LastName,
                     useravailable.email,
                     useravailable.phoneNo,
                     useravailable.membership,
                     useravailable.userRole));
            }
            return Ok("Failure");
        }
    }

}
