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

    public Task<List<Book>> GetBooksByIdAsync(Guid id)
    {
        var books = dbContext.Books.Where(book => book.Id == id).ToListAsync();
        return books;
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
    
    public async Task UpdateBookAsync(Book book)
    {
        var existingBook = await dbContext.Books.FindAsync(book.Id);
        if (existingBook != null)
        {
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.IsAvailable = book.IsAvailable;
            existingBook.Type = book.Type;
    
            await dbContext.SaveChangesAsync();
        }
    }
}