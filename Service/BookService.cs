using TheLiteraryHub.Model;

namespace TheLiteraryHub.Service;

public class BookService : IBookService
{
    private List<Book> _books = new List<Book>();
    public IEnumerable<Book> GetAllBooks()
    {
        return _books;
    }

    public Book GetBookById(int id)
    {
        return _books.FirstOrDefault(b => b.Id == id);
    }

    public void AddBook(Book book)
    {
        if (book.Id == 0)
        {
            book.Id = _books.Max(b => b.Id) + 1;
        }
        _books.Add(book);
    }

    public void UpdateBook(Book book)
    {
        var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);
        if (existingBook != null)
        {
            // Update properties of the existing book
            existingBook.Title = book.Title;
            // Update other relevant properties based on your needs (e.g., Description, Keywords)

            // Consider using reflection for more flexible property updates
            // if the number of properties is large or frequently changing
        }
        else
        {
            throw new Exception($"Book with ID: {book.Id} not found");
        }
    }

    public void DeleteBook(int id)
    {
        var bookToDelete = _books.FirstOrDefault(b => b.Id == id);
        if (bookToDelete != null)
        {
            _books.Remove(bookToDelete);
        }
        else
        {
            throw new Exception($"Book with ID: {id} not found");
        }
    }

    public void CreateBook(Book book)
    {
        if (book.Id == 0)
        {
            book.Id = _books.Max(a => a.Id) + 1;
        }

        _books.Add(book);
    }
}