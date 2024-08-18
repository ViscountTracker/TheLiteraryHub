using TheLiteraryHub.Model;

namespace TheLiteraryHub.Service;

public class GenreService : IGenreService
{
    private List<Genre> _genres = new List<Genre>();

    public IEnumerable<Genre> GetAllGenres()
    {
        return _genres;
    }
    public Genre GetGenreById(int id)
    {
        return _genres.FirstOrDefault(g => g.Id == id);
    }
    public void AddGenre(Genre genre)
    {
        if (genre.Id == 0)
        {
            genre.Id = _genres.Max(g => g.Id) + 1;
        }
        _genres.Add(genre);
    }
    public void UpdateGenre(Genre genre)
    {
        var existingGenre = _genres.FirstOrDefault(g => g.Id == genre.Id);
        if (existingGenre != null)
        {
            existingGenre.Name = genre.Name;
        }
        else
        {
            throw new Exception($"Genre with ID: {genre.Id} not found");
        }
    }
    public void DeleteGenre(int id)
    {
        var genreToDelete = _genres.FirstOrDefault(g => g.Id == id);
        if (genreToDelete != null)
        {
            _genres.Remove(genreToDelete);

        }
        else
        {
            throw new Exception($"Genre with ID: {id} not found");
        }
    }
    public void CreateGenre(Genre genre)
    {
        if (genre.Id == 0)
        {
            genre.Id = _genres.Max(a => a.Id) + 1;
        }

        _genres.Add(genre);
    }
}
