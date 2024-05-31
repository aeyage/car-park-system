//using CarParkSystem.Data;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.Extensions.Configuration;
//using System.IO;

//public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ParkingDbContext>
//{
//    public ParkingDbContext CreateDbContext(string[] args)
//    {
//        var configuration = new ConfigurationBuilder()
//            .SetBasePath(Directory.GetCurrentDirectory())
//            .AddJsonFile("appsettings.json")
//            .Build();

//        var optionsBuilder = new DbContextOptionsBuilder<ParkingDbContext>();
//        var connectionString = configuration.GetConnectionString("DefaultConnection");

//        optionsBuilder.UseSqlServer(connectionString);

//        return new ParkingDbContext(optionsBuilder.Options);
//    }
//}

using CarParkSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ParkingDbContext>
{
    public ParkingDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<ParkingDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        optionsBuilder.UseSqlServer(connectionString);

        return new ParkingDbContext(optionsBuilder.Options);
    }
}

