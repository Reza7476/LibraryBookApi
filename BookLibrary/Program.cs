using BookLibrary;
using BookLibrary.Services.Authers;
using BookLibrary.Services.Books;
using BookLibrary.Services.Genres;
using BookLibrary.Services.Order;
using BookLibrary.Services.Users;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LibraryDbContext>(option =>
{
    option.UseSqlServer(connectionString);
    //option.UseModel()
});

builder.Services.AddScoped<IAutherService, AutherService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IBookServicecs, BookService>();
builder.Services.AddScoped<IUserServicecs, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
