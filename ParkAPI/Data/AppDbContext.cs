using Microsoft.EntityFrameworkCore;
using ParkAPI.Models;


namespace ParkAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ParkingGarage> ParkingGarage { get; set; } = null!;
        public DbSet<Price> Price { get; set; } = null!;
        public DbSet<OpeningHours> OpeningHours { get; set; } = null!;
        public DbSet<Address> Address { get; set; } = null!;


    }
}