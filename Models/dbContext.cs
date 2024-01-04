using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace GrowFurthers.Models
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Hotels> Hotels { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<City> City { get; set; }
        private readonly IConfiguration config;

        public IEnumerable<Hotels> GetHotelList(string location, string roomType, string[] selectedAmenities)
        {

            var amenity = string.Join(",", selectedAmenities); // Convert string[] to comma-separated string
            return Hotels.FromSqlRaw("EXEC SP_GetHotelList {0}, {1}, {2}", location, roomType, amenity);
        }
        public IEnumerable<Rooms> GetRoomsDetails(int HotelId)
        {
            return Rooms.FromSqlRaw("EXEC SP_GetRoomDetails {0}",HotelId);
        }
    }
}
