using WebApplication1.Interfaces;
using WebApplication1.Service.DTOs;


namespace WebApplication1.Service;

public class BookService : IBookService
{
    private readonly IBookRepository bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        this.bookRepository = bookRepository;
    }
    
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
    
    public async Task<BookDto> AddBookAsync(BookDto bookDto)
    {
        var book = new Repository.Entities.Book
        {
            Id = Guid.NewGuid(),
            Title = bookDto.Title,
            Author = bookDto.Author,
            IsAvailable = bookDto.IsAvailable,
            Type = bookDto.Type
        };
        
        await bookRepository.AddBookAsync(book);
        return new BookDto()
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            IsAvailable = book.IsAvailable,
            Type = book.Type
        };
    }

    public async Task<bool> DeleteBookAsync(Guid id)
    {
        var books = await bookRepository.GetBooksByIdAsync(id);
        if (books == null || !books.Any())
        {
            return false;
        }
        return await bookRepository.DeleteBookAsync(id);
    }
    
    public async Task<bool> UpdateBookAsync(BookDto bookDto)
    {
        var book = new Repository.Entities.Book
        {
            Id = bookDto.Id,
            Title = bookDto.Title,
            Author = bookDto.Author,
            IsAvailable = bookDto.IsAvailable,
            Type = bookDto.Type
        };
        await bookRepository.UpdateBookAsync(book);
        return true;
    }
}