using BooksApi.Models.Entites;

namespace BooksApi.Repository.Entites;

public class User : BaseEntity
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Phone { get; set; } = null!;
}