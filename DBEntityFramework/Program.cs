using Microsoft.EntityFrameworkCore;


namespace DBEntityFramework;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Host=localhost;Database=films_db;Username=postgres;Password=1231";
        var optionsBuilder =  new DbContextOptionsBuilder<FilmsManagerDBContext>();
        optionsBuilder.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        var options = optionsBuilder.Options;
        using var context = new FilmsManagerDBContext(options);
        
        var movie = context.Movies
            .Include(m => m.Director)
            .Include(m => m.Genre)
            .FirstOrDefault();
        
        Console.WriteLine($"Name   : {movie.Title}");
        Console.WriteLine($"Year         : {movie.Year}");
        Console.WriteLine($"Rating     : {movie.Rating}");
        Console.WriteLine($"Time: {movie.DurationMinutes} minutes.");
        Console.WriteLine($"Directors   : {movie.Director.Name}");
        Console.WriteLine($"Genres       : {movie.Genre.Name}");
    }
}