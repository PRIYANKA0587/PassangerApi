using Microsoft.EntityFrameworkCore;
using PassangerApi.Models;

namespace PassangerApi.DataContext
{
    public class PassangerDbContext : DbContext
    {
        public PassangerDbContext(DbContextOptions<PassangerDbContext> options) : base(options)
        {

        }
        public DbSet<Passanger> Passangers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Passanger>().HasData(
                new Passanger()
                {
                    Id = 1,
                    Name = "Priyanka",
                    MobileNumber = "656095445",
                    Age = 30,
                    Email = "sobarp@gmail.com",
                    Adhar = "433454657612"

                });
        }
    }
}

