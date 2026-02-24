using BooksApi.Constants;

namespace WebApplication1.Controllers.VMs;

public class AddBookRequest
{
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsAvailable { get; set; }
    public BookType Type { get; set; }
}