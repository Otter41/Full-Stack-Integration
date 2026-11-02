using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ClientApp", policy =>
    {
        policy.WithOrigins("http://localhost:5188")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("ClientApp");


// just the inventory products for now
var products = new[]
{
    new Product(1, "Laptop", 1200.50m, 25, new Category(101, "Electronics")),
    new Product(2, "Headphones", 50.00m, 100, new Category(102, "Accessories"))
};


app.MapGet("/api/productlist", (IMemoryCache cache) =>
{
    // caching this so we dont rebuild the same list every request
    var productList = cache.GetOrCreate("inventory_products", entry =>
    {
        entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);

        return products;
    });

    return Results.Ok(productList);
});


app.Run();


record Category(int Id, string Name);

record Product(int Id, string Name, decimal Price, int Stock, Category Category);
