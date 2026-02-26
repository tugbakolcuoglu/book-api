using WebApplication1.Controllers.VMs;
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
        var book = await bookRepository.GetBookByIdAsync(id);
        if (book == null)
            return null;

        var result = new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            IsAvailable = book.IsAvailable,
            Type = book.Type
        };
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
        return await bookRepository.DeleteBookAsync(id);
    }

    public async Task<bool> UpdateBookAsync(Guid id, UpdateBookRequest request)
    {
        // BURDAKI AMACIMIZ SERVISE KATMANINDA BIR IS MANTIGINI SIMULE ETMEYE CALISMAK. 
        // YOKSA UPDATE ISLEIMINI REPOSITOY KATMANINDA YAPARDIK, EF CHANGE TRACKER ORDA DAHA RAHAT CALISIR, EKSTRA BIR UPDATE METODU CALISTIRMADAN DIREK SAVECHAGES YAPABILIRDIK
        var entity = await bookRepository.GetBookByIdAsync(id);
        if (entity == null) return false;

        entity.Title = request.Title;
        entity.Author = request.Author;
        entity.IsAvailable = request.IsAvailable;

        var result = await bookRepository.UpdateBookAsync(entity);

        return result >= 0;
    }
}