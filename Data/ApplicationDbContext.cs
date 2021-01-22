using Microsoft.EntityFrameworkCore;
using CarPro.Models;


namespace CarPro.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Lot> Lots { get; set; }

    }
}