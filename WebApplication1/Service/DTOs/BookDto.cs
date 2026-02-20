using BooksApi.Constants;

namespace WebApplication1.Service.DTOs;

public class BookDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsAvailable { get; set; } = true;
    public BookType Type { get; set; } = BookType.Philosophy;
}