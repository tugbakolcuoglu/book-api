using WebApplication1.Repository.Entites;
using WebApplication1.Repository.Entities;

namespace WebApplication1.Interfaces;

public interface IBookRepository
{
    Task<List<Book>> GetAllBooksAsync();
    Task<List<Book>> GetBooksByIdAsync(Guid id);
    Task AddBookAsync(Book book);
    Task UpdateBookAsync(Book book);
}