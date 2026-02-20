

using WebApplication1.Interfaces;
using WebApplication1.Service.DTOs;


namespace WebApplication1.Service;

public class BookService(IBookRepository bookRepository) : IBookService
{
    public async Task<List<BookDto>> GetAllBooksAsync()
    {
        var books = await bookRepository.GetAllBooksAsync();
        
        var result = books.Select(x => new BookDto
        {
            Id = x.Id,
            Title = x.Title,
            Author = x.Author,
            IsAvailable = x.IsAvailable,
            Type = x.Type
        }).ToList();
        
        return result;
    }
    public async Task<BookDto?> GetBookByIdAsync(Guid id)
    {
        var book = await bookRepository.GetBooksByIdAsync(id);
        
        var result = book.Select(x => new BookDto
        {
            Id = x.Id,
            Title = x.Title,
            Author = x.Author,
            IsAvailable = x.IsAvailable,
            Type = x.Type
        }).FirstOrDefault();
        
        return result;
    }
}