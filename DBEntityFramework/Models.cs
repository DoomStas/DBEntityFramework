

namespace DBEntityFramework;



public class Director
{
    public int Id { get; set; }
    public string Name { get; set; }
    
}

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }
    
}

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public double Rating { get; set; }
    public int DurationMinutes { get; set; }
    
    public int DirectorId { get; set; }
    public Director Director { get; set; }

    public int GenreId { get; set; }
    public Genre Genre { get; set; }
}
