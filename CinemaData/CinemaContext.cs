using CinemaData.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaData
{
    public class CinemaContext:DbContext
    {
        public CinemaContext(DbContextOptions options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Order> Order { get; set; }       
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Showing> Showings { get; set; }
        public DbSet<ShowingSeat> ShowingSeats { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
