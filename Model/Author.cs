namespace TheLiteraryHub.Model;

public class Author
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public DateTime? BirthDate { get; set; }
    public Genre genre { get; set; }

}
