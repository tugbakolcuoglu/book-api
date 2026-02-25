using Microsoft.EntityFrameworkCore;
using WebApplication1.Interfaces;
using WebApplication1.Repository;
using WebApplication1.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer("Server=db41761.public.databaseasp.net; Database=db41761; User Id=db41761; " +
                     "Password=5t!YZ7z+3x@N; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;"));

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();