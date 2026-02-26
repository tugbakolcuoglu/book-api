using Microsoft.EntityFrameworkCore;
using WebApplication1.Interfaces;
using WebApplication1.Repository.Entities;

namespace WebApplication1.Repository;

public class BookRepository(AppDbContext dbContext) : IBookRepository
{
    
    public async Task<List<Book>> GetAllBooksAsync()
    {
        var books = await dbContext.Books.ToListAsync();
        return books;
    }

    public async Task<Book?> GetBookByIdAsync(Guid id)
    {
        var book = await dbContext.Books.FindAsync(id);
        return book;
    }
    
    public async Task AddBookAsync(Book book)
    {
        await dbContext.Books.AddAsync(book);
        await dbContext.SaveChangesAsync();
    }
    
    public async Task<bool> DeleteBookAsync(Guid id)
    {
        var book = await dbContext.Books.FindAsync(id);
        if (book == null)
            return false;
        dbContext.Books.Remove(book);
        await dbContext.SaveChangesAsync();
        return true;
    }
    
    public async Task<int> UpdateBookAsync(Book entity)
    {
        dbContext.Books.Update(entity);
        return await dbContext.SaveChangesAsync();
    }
}