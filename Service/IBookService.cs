using TheLiteraryHub.Model;

namespace TheLiteraryHub.Service
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
        void CreateBook(Book book);
    }
}