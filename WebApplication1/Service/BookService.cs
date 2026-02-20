using BooksApi.Service.DTOs;
using BooksApi.Service.interfaces;
using BooksApi.Repositories.Interfaces;
using BooksApi.Repository.Interfaces;

namespace BooksApi.service;

public class BookService(IBookRepository bookRepository) : IBookService
{
    public async task<List<BookDto>> GetAllBooksAsync()
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
        return books;
    }
    public async task<BookDto?> GetBookByIdAsync(Guid id)
    {
        var book = await bookRepository.GetBookByIdAsync(id);
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