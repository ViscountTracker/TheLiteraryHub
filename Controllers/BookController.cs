using Microsoft.AspNetCore.Mvc;
using TheLiteraryHub.Model;
using TheLiteraryHub.Service;

namespace TheLiteraryHub.Controllers
{
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }
        [HttpGet("{id}")]
        public IActionResult GetBooks(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            _bookService.CreateBook(book);
            return CreatedAtAction(nameof(GetBooks), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            _bookService.UpdateBook(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
            return NoContent();
        }

    }
}
