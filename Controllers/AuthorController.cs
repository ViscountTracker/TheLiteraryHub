using Microsoft.AspNetCore.Mvc;
using TheLiteraryHub.Model;
using TheLiteraryHub.Service;

namespace TheLiteraryHub.Controllers;

public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public IActionResult GetAuthors()
    {
        var authors = _authorService.GetAllAuthors();
        return Ok(authors);
    }
    [HttpGet("{id}")]
    public IActionResult GetAuthors(int id)
    {
        var author = _authorService.GetAutorById(id);
        if (author == null)
        {
            return NotFound();
        }
        return Ok(author);
    }

    [HttpPost]
    public IActionResult CreateAuthor(Author author)
    {
        _authorService.CreateAuthor(author);
        return CreatedAtAction(nameof(GetAuthors), new { id = author.Id }, author);
    }
    [HttpPut("{id}")]
    public IActionResult UpdateAuthor(int id, Author author)
    {
        if (id != author.Id)
        {
            return BadRequest();
        }

        _authorService.UpdateAuthor(author);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAuthor(int id)
    {
        _authorService.DeleteAuthor(id);
        return NoContent();
    }
}
