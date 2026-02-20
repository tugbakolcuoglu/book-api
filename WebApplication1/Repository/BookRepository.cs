using Microsoft.EntityFrameworkCore;
using WebApplication1.Interfaces;
using WebApplication1.Repository.Entities;

namespace WebApplication1.Repository;

public class BookRepository(AppDbContext dbContext) : IBookRepository
{
    // Repository katmaninin isi DB 'ye sorgu atmaktir ve servis katmanina vermektir. Is mantigi Logicler servis katmaninda yapilacak. 

    public async Task<List<Book>> GetAllBooksAsync()
    {
        var books = await dbContext.Books.ToListAsync();
        return books;
    }

    public Task<List<Book>> GetBooksByIdAsync(Guid id)
    {
        var books = dbContext.Books.Where(book => book.Id == id).ToListAsync();
        return books;
    }
}