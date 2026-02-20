using WebApplication1.Repository.Entites;

namespace WebApplication1.Repository.Entities;

public class User : BaseEntity
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Phone { get; set; } = null!;
}