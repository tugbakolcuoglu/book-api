using BooksApi.Constants;
using BooksApi.Models.Entites;

namespace BooksApi.Repository.Entites;
public class Book : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public bool IsAvailable { get; set; } = true;
    public BookType Type { get; set; } = BookType.Philosophy;
}