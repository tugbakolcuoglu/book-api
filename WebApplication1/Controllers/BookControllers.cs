using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers.VMs;
using WebApplication1.Interfaces;

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
}