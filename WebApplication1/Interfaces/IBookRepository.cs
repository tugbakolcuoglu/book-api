using WebApplication1.Repository.Entites;
using WebApplication1.Repository.Entities;

namespace WebApplication1.Interfaces;

public interface IBookRepository
{
    Task<List<Book>> GetAllBooksAsync();
    Task<Book?> GetBookByIdAsync(Guid id);
    Task AddBookAsync(Book book);
    Task<bool> DeleteBookAsync(Guid id);
    Task<int> UpdateBookAsync(Book entity);
}