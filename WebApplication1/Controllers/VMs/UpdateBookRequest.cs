using WebApplication1.Interfaces;

namespace WebApplication1.Controllers.VMs;

public class UpdateBookRequest 
{
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsAvailable { get; set; }
}