using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers.VMs;
using WebApplication1.Interfaces;
using WebApplication1.Service.DTOs;

namespace WebApplication1.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BooksController(IBookService bookService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var serviceResult = await bookService.GetAllBooksAsync();
        var totalCount = serviceResult.Count;

        if (totalCount == 0)
        {
            return NotFound();
        }
        
        var response = new GetAllBooksResponse()
        {
            Books = serviceResult,
            TotalCount = serviceResult.Count
        };
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var serviceResult = await bookService.GetBookByIdAsync(id);
        return Ok(serviceResult);
    }

    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody]AddBookRequest request)
    {
        var bookDto = new BookDto()
        {
            Title = request.Title,
            Author = request.Author,
            IsAvailable = request.IsAvailable,
            Type = request.Type
        };
        var response = await bookService.AddBookAsync(bookDto);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(Guid id)
    {
        var isDeleted = await bookService.DeleteBookAsync(id);
        if (!isDeleted)
            return NotFound("Kitap bulunamadı veya silinemedi.");
        return Ok(new { Message = "Kitap başarıyla silindi." });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBook([FromQuery]Guid id, [FromBody] UpdateBookRequest request)
    {
        var bookDto = new BookDto
        {
            Id = id,
            Title = request.Title,
            Author = request.Author,
            IsAvailable = request.IsAvailable
        };
        var updated = await bookService.UpdateBookAsync(bookDto);
        if (!updated)
            return NotFound();
        return Ok();
    }
}