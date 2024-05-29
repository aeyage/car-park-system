using Microsoft.EntityFrameworkCore;
using CarParkSystem.Models;

namespace CarParkSystem.Data
{
    public class ParkingDbContext : DbContext
    {
        public ParkingDbContext(DbContextOptions<ParkingDbContext> options) 
            :base(options) { }

        public DbSet<Parking> Parkings { get; set; }    
    }
}
