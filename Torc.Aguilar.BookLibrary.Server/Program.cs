using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Torc.Aguilar.BookLibrary.API.Configuration;
using Torc.Aguilar.BookLibrary.Core.Interfaces.Repositories;
using Torc.Aguilar.BookLibrary.Core.Interfaces.Services;
using Torc.Aguilar.BookLibrary.Infrastructure.Data;
using Torc.Aguilar.BookLibrary.Infrastructure.Repositories;
using Torc.Aguilar.BookLibrary.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IBookRepository, BookRepository>();


string? connectionString = builder.Configuration.GetConnectionString("BookDatabase");
if (!string.IsNullOrEmpty(connectionString))
{
    builder.Services.AddDbContext<BookLibraryContext>(options =>
    {

        options.UseSqlServer(connectionString);
    });
}

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<BookLibraryContext>();
    context.Database.Migrate();
}
app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
