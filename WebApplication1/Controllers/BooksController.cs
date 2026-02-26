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

        // if (totalCount == 0)
        // {
        //     return NotFound();
        // }
        
        var response = new GetAllBooksResponse()
        {
            Books = serviceResult,
            TotalCount = totalCount
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

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteBook(Guid id)
    {
        var isDeleted = await bookService.DeleteBookAsync(id);
        if (!isDeleted)
            return NotFound("Kitap bulunamadı veya silinemedi.");
        return Ok(new { Message = "Kitap başarıyla silindi." });
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateBook(Guid id, [FromBody] UpdateBookRequest request)
    {
        var updated = await bookService.UpdateBookAsync(id, request);

        if (!updated)
            return NotFound(updated);

        return Ok(updated);
    }
    
    
    
    // update işlemi 6 adımda gerceklesecek
    // 1- requestten gelen nesne DTOya donusturulup servıs katmanına gonderılır
    // 2- servis katmanı gelen nesneyi dmo ya donusturup repository katmanına gonderır
    // 3- repository katmanı gelen model içindeki id ile db ye sorgu atıp guncellenecek modeli bulur ve gunceller
    // 4- verılen id ye sahip bir model bulunmazsa false doner ve update islemi yapilmaz. Eger model bulunursa guncellenir ve true doner
    // 5- servis katmanı repodan gelen metodun response unu doner (boolean) ve controller a gonderır
    // 6- controller gelen boolean degere gore 200 veya 40x doner.
    
    // yapılacak kilit noktalar
    // - clienttan gelecek olan isteği karsılayacak bır VM (ViewModel) olusturulacak ve bu VM requestten gelen veriyi karsilayacak
    // - bu modeli servis katmanına tasıyacak DTO (Data Transfer Object) olusturulacak
    // - bu DTO yu repo katmanına tasıayacak DMO (Data Model Object) olusturulacak
    // - mevcut reposıtory metodu ve ınterface guncellenecek ve update islemi gerceklestirilecek
    // - controllerda update islemi gerceklestirilecek ve clienta uygun response donecek (boolean)
    // - controller end-pointı HttpPut olacak ve url de id parametresi bulunacak (api/books/{id})
    
}