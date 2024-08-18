using TheLiteraryHub.Model;

namespace TheLiteraryHub.Service;

public interface IGenreService
{
    IEnumerable<Genre> GetAllGenres();
    Genre GetGenreById(int id);
    void AddGenre(Genre genre);
    void UpdateGenre(Genre genre);
    void DeleteGenre(int id);
    void CreateGenre(Genre genre);
}