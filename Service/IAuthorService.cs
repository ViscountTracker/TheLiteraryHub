using TheLiteraryHub.Model;

namespace TheLiteraryHub.Service;

public interface IAuthorService
{
    IEnumerable<Author> GetAllAuthors();
    Author GetAutorById(int id);
    void CreateAuthor(Author author);
    void AddAuthor(Author author);
    void UpdateAuthor(Author author);
    void DeleteAuthor(int id);

}