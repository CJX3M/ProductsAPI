using Microsoft.EntityFrameworkCore;
using ProductsAPI;
using ProductsAPI.Data;
using ProductsAPI.Repositories;
using ProductsAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<InventoryContext>(options =>
    options.UseInMemoryDatabase("InventoryDB"));

builder.Services.AddScoped<IProductRepository, ProductRepositories>();
builder.Services.AddScoped<IProductService, ProductServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        SeedData.Initialize(services);
    }
    app.UseStaticFiles();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Products API V1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
