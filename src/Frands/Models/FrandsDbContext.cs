using Microsoft.EntityFrameworkCore;

namespace Frands.Models
{   public class FrandsDbContext : DbContext
    {
        public FrandsDbContext(DbContextOptions<FrandsDbContext> options)
               : base(options)
        { }

        public DbSet<Album> Album { get; set; }
        public DbSet<Track> Track { get; set; }
       
    }

}