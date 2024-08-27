using ECommerceApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();  // Adds support for controllers

// Configure DbContext with SQL Server
builder.Services.AddDbContext<ECommerceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://example.com") // Adjust the URL to your frontend
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

// Add Authentication here if needed
// builder.Services.AddAuthentication()...

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin"); // Enable CORS

// Add Authentication and Authorization middleware here
// app.UseAuthentication();
// app.UseAuthorization();

// Define your API endpoints here
app.MapGet("/products", async (ECommerceDbContext db) =>
{
    return await db.Product.ToListAsync();
}).WithName("GetProducts");

// Additional endpoints for orders, customers, etc.

app.Run();
