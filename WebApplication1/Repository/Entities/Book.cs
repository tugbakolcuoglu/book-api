using BooksApi.Constants;
using WebApplication1.Repository.Entites;

namespace WebApplication1.Repository.Entities;
public class Book : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public bool IsAvailable { get; set; } = true;
    public BookType Type { get; set; } = BookType.Philosophy;
}