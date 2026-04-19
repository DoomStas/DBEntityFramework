using Microsoft.EntityFrameworkCore;

namespace DBEntityFramework;

public class FilmsManagerDBContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Genre> Genres { get; set; }

    public FilmsManagerDBContext(DbContextOptions<FilmsManagerDBContext> options) : base(options)
    {
        
    }
}