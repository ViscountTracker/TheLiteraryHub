using Microsoft.AspNetCore.Mvc;
using TheLiteraryHub.Model;
using TheLiteraryHub.Service;

namespace TheLiteraryHub.Controllers;

public class GenreController : ControllerBase
{
    private readonly IGenreService _genreService;

    public GenreController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    [HttpGet]
    public IActionResult GetGenres()
    {
        var genres = _genreService.GetAllGenres();
        return Ok(genres);
    }

    [HttpGet("{id}")]
    public IActionResult GetGenres(int id)
    {
        var genre = _genreService.GetGenreById(id);
        if (genre == null)
        {
            return NotFound();
        }
        return Ok(genre);
    }

    [HttpPost]
    public IActionResult CreateGenre(Genre genre)
    {
        _genreService.CreateGenre(genre);
        return CreatedAtAction(nameof(GetGenres), new { id = genre.Id }, genre);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateGenre(int id, Genre genre)
    {
        if (id != genre.Id)
        {
            return BadRequest();
        }

        _genreService.UpdateGenre(genre);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteGenre(int id)
    {
        _genreService.DeleteGenre(id);
        return NoContent();
    }
}
