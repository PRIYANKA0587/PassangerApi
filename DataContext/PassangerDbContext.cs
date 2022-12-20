using Microsoft.EntityFrameworkCore;
using PassengerApi.Models;

namespace PassengerApi.DataContext
{
    public class PassengerDbContext : DbContext
    {
        public PassengerDbContext(DbContextOptions<PassengerDbContext> options) : base(options)
        {

        }
        public DbSet<Passenger> Passengers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Passenger>().HasData(
                new Passenger()
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

