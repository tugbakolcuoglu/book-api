using BooksApi.Constants;

namespace WebApplication1.Controllers.VMs;

public class CreateBookRequest
{
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public bool IsAvailable { get; set; } = true;
    public BookType Type { get; set; } = BookType.Mystery;
}