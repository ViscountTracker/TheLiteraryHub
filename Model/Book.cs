namespace TheLiteraryHub.Model;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Author author { get; set; }
    public Genre genre { get; set; }
    public DateTime PublicationDate { get; set; }
}
