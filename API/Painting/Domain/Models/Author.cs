namespace API.Painting.Domain.Models;

public class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NickName { get; set; }
    public string? PhotoUrl { get; set; }
}