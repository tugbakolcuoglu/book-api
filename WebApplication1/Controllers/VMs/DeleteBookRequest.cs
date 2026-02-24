namespace WebApplication1.Controllers.VMs;

public class DeleteBookRequest
{
    public Guid BookId { get; set; }
    public  DeleteBookRequest(Guid bookId)
    {
        BookId = bookId;
    }
}