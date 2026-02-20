using BooksApi.Controllers.VMs;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers;
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
        var serviceResult = await bookService.GetBooksByIdAsync(id);
        return Ok(serviceResult);
    }

    
}