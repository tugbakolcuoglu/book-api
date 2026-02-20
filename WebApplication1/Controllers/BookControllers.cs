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
    
    // TODO: Create, Delete Endpointleri implemente edilecek.

    // [HttpPost]
    // public async Task<IActionResult> Create(CreateBookRequest request)
    // {
    //     var bookDto = new BookDto()
    //     {
    //         // id basma isi logic olarak application (servise) konusudur. orda basialcak.
    //         Title = request.Title,
    //         Author = request.Author,
    //         IsAvailable = request.IsAvailable,
    //         Type = request.Type
    //     };
    //     var createResult = await bookService.CreateNewBookAsync(bookDto); // gelen kitap nesnesine Id eklicek, ve repository'e gonderecek. true || false donecek
    //     if (createResult)
    //     {
    //         return Ok();
    //     }
    //     return BadRequest();
    // }
    
    // servis katmaninda bu islem icin CreateNewBookAsync metodu olusturulacak. Bu metod gelen kitap nesnesine Id basip repository'e gonderecek.
    // ONCE INTERFACE (IBookService) EKLENECEK, SONRA SOMUT SINIT (BookService) EKLENECEK
    // ayni mantik repositoy icin de gecerli.
    
    // Doyasiyla kod yazmaya reposiyotu katmanidan baslanarak yapilirsa hata ihtimali duser.
    // cunku en icerden baslamis oluruz, disari dgoru (controller) a varmis oluruz.

}
