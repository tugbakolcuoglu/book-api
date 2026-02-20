using BooksApi.Service.DTOs;

namespace BooksApi.Controllers.VMs;

public class GetAllBooksResponse
{
    public List<BookDto> Books { get; set; } = new List<BookDto>();
    public int TotalCount { get; set; }
}