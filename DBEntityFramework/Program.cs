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
        
        IRepository<Movie> movieRepository = new FilmsRepository<Movie>(context);
        IRepository<Genre> genreRepository = new FilmsRepository<Genre>(context);
        
        var newGenre = new Genre { Name = "Horror" };
        genreRepository.Add(newGenre);
        genreRepository.Save();

        var newMovie = new Movie 
        { 
            Title = "Insidious",
            Year = 2010,
            Rating = 6.8,
            DurationMinutes = 103,
            GenreId = newGenre.Id,
            DirectorId = 1
        };
        movieRepository.Add(newMovie);
        movieRepository.Save();
        Console.WriteLine("Film added");

        // GetAll
        Console.WriteLine("\nAll films:");
        var allMovies = movieRepository.GetAll();
        foreach (var m in allMovies)
        {
            Console.WriteLine($"- {m.Title} ({m.Year})");
        }

        // GetById
        int searchId = newMovie.Id;
        var movieFromDb = movieRepository.GetById(searchId);
        if (movieFromDb != null)
        {
            Console.WriteLine($"\nFind film to ID {searchId}: {movieFromDb.Title}");

            // Update
            movieFromDb.Rating = 9.0;
            movieRepository.Update(movieFromDb);
            movieRepository.Save();
            Console.WriteLine("Rating updated");
        }

        // Delete
        if (movieFromDb != null)
        {
            movieRepository.Delete(movieFromDb);
            movieRepository.Save();
            Console.WriteLine($"Film '{movieFromDb.Title}' deleted.");
        }
    }
}