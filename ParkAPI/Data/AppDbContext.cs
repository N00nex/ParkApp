using Microsoft.EntityFrameworkCore;
using ParkAPI.Models;
using System.Collections.Generic;

namespace ParkAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ParkHaus> ParkHaus { get; set; } = null!;
        public DbSet<PreisKlasse> PreisKlasse { get; set; } = null!;
        public DbSet<BetriebsZeit> BetriebsZeit { get; set; } = null!;
        public DbSet<Address> Address { get; set; } = null!;


    }
}