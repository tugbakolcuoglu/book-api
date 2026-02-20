using WebApplication1.Service.DTOs;

namespace WebApplication1.Interfaces;

public interface IBookService
{
    Task<List<BookDto>> GetAllBooksAsync();
    Task<BookDto?> GetBookByIdAsync(Guid id);
}