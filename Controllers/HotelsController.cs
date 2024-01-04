using GrowFurthers.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Globalization;

namespace GrowFurthers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IConfiguration _config;
        public readonly dbContext _context;
        public HotelsController(IConfiguration config, dbContext context)
        {
            _config = config;
            _context = context;
        }
        [HttpGet("SearchHotel")]
        public IActionResult Get(string hotelName)
        {
            //For All Users
            //var users = _context.Users.Select(u => new { Id = u.UserID, FirstName = u.Firstname, LastName = u.Lastname });
            //For single Users
            var hotels = _context.Hotels.Where(h => h.hotelName == hotelName).ToList();
            return Ok(hotels);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        [HttpPost("AddHotel")]
        public IActionResult Create(Hotels hotels)
        {
            //thinking of adding hotelcode for unique identification
            if (_context.Hotels.Where(h => h.phoneNo == hotels.phoneNo).FirstOrDefault() != null)
            {
                return Ok("Already Exists!");
            }
            _context.Hotels.Add(hotels);
            _context.SaveChanges();
            return Ok("Success");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        [HttpPost("AddHotelRoom")]
        public IActionResult Create(Rooms rooms)
        {
            _context.Rooms.Add(rooms);
            _context.SaveChanges();
            return Ok("Success");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        [HttpPost("UpdateHotelDetails")]
        public IActionResult Update(Hotels hotels)
        {
            
            var hotel = _context.Hotels.FirstOrDefault(h => h.phoneNo == hotels.phoneNo);
            if (hotel != null)
            {
                hotel.hotelName = hotels.hotelName;
                hotel.email = hotels.email;
                hotel.address = hotels.address;
                hotel.phoneNo = hotels.phoneNo;
                hotel.checkInTime = hotels.checkInTime;
                hotel.checkOutTime = hotels.checkOutTime;
                hotel.city = hotels.city;
                hotel.rating = hotels.rating;
                _context.SaveChanges();
                return Ok("Hotel Updated");
            }
            _context.Hotels.Add(hotels);
            _context.SaveChanges();
            return Ok("Hotel Inserted");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var hotel = _context.Hotels.FirstOrDefault(h => h.hotelId == id);
            if (hotel != null)
            {
                hotel.active = "N";
                _context.SaveChanges();
                return Ok("Record Deleted");
            }
            return Ok("Record Does not exist");
        }
        [HttpGet("GetCity")]
        public IActionResult Get()
        {
            var city = _context.City.ToList();
            
            return Ok(city);
        }

        [HttpGet("GetRooms")]
        public IActionResult GetRooms()
        {
            var roomType = _context.Rooms.Select(room => room.roomType).Distinct().ToList();

            return Ok(roomType);
        }
        [HttpGet("GetAmenities")]
        public IActionResult GetAmenities()
        {
            var Amenities = _context.Amenities.Select(Amenities => Amenities.amenityName).Distinct().ToList();

            return Ok(Amenities);
        }
        [HttpGet("GetHotels")]
        public IActionResult GetHotels([FromQuery] string location, [FromQuery] string roomType, 
            [FromQuery] string[] selectedAmenities)
        {
            
            var hotels = _context.GetHotelList(location, roomType, selectedAmenities);
            return Ok(hotels);
        }

        //public IActionResult GetHotels([FromQuery] string location, [FromQuery] string checkInDate,
        //   [FromQuery] string checkOutDate, [FromQuery] int noofAdults, [FromQuery] int noofChildren,
        //   [FromQuery] string roomType, [FromQuery] string[] selectedAmenities)
        //{

        //    var hotels = _context.GetHotelList(location, roomType, selectedAmenities);
        //    return Ok(hotels);
        //}
    }
}
