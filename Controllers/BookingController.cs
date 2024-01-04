using GrowFurthers.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrowFurthers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BookingController : ControllerBase
    {
        private readonly IConfiguration _config;
        public readonly dbContext _context;
        public BookingController(IConfiguration config, dbContext context)
        {
            _config = config;
            _context = context;
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles ="Standard")]
        [HttpPost("BookHotel")]
        public IActionResult Create(Bookings bookings)
        {
            if (User.Identity.IsAuthenticated)
            {
                _context.Bookings.Add(bookings);
                _context.SaveChanges();
                return Ok("Success");
            }
            else
            {
                return Ok("Failure");
            }
        }

    }
}
