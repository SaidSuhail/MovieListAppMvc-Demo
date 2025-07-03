using Microsoft.EntityFrameworkCore;
using MovieListApp.Models;

namespace MovieListApp.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Movie> Movie { get; set; }
    }
}
