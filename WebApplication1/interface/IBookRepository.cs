using BooksApi.Repository.Entites;

namespace BooksApi.Repository.Interfaces;

public interface IBookRepository
{
    Task<List<Book>> GetAllBooksAsync();
    Task<List<Book>> GetBooksByIdAsync(Guid id);
}