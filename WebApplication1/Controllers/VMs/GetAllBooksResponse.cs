

using WebApplication1.Service.DTOs;

namespace WebApplication1.Controllers.VMs;

public class GetAllBooksResponse
{
    public List<BookDto> Books { get; set; } = new List<BookDto>();
    public int TotalCount { get; set; }
}