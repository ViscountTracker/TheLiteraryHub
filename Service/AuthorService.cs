using TheLiteraryHub.Model;

namespace TheLiteraryHub.Service;

public class AuthorService : IAuthorService
{
    private List<Author> _authors = new List<Author>();
    public IEnumerable<Author> GetAllAuthors()
    {
        return _authors;
    }
    public Author GetAutorById(int id)
    {
        return _authors.FirstOrDefault(a => a.Id == id);
    }
    public void AddAuthor(Author author)
    {
        if (author.Id == 0)
        {
            author.Id = _authors.Max(a => a.Id) + 1;
        }
        _authors.Add(author);
    }
    public void UpdateAuthor(Author author)
    {
        var existingAuthor = _authors.FirstOrDefault(a => a.Id == author.Id);
        if (existingAuthor != null)
        {
            // Update properties of the existing genre
            existingAuthor.FullName = author.FullName;
            // Update other relevant properties based on your needs (e.g., Description, Keywords)

            // Consider using reflection for more flexible property updates
            // if the number of properties is large or frequently changing
        }
        else
        {
            throw new Exception($"Author with ID: {author.Id} not found");
        }
    }
    public void DeleteAuthor(int id)
    {
        var authorToDelete = _authors.FirstOrDefault(a => a.Id == id);
        if (authorToDelete != null)
        {
            _authors.Remove(authorToDelete);
        }
        else
        {
            throw new Exception($"Author with ID: {id} not found");
        }
    }
    public void CreateAuthor(Author author)
    {

        if (author.Id == 0)
        {
            author.Id = _authors.Max(a => a.Id) + 1;
        }

        _authors.Add(author);
    }
}

