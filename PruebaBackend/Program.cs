using Microsoft.EntityFrameworkCore;
using PruebaBackend.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyectar servicios de DbContext y definir db SER
//builder.Services.AddDbContext<ClienteDbContext>(options => options.UseInMemoryDatabase("SER"));
//builder.Services.AddDbContext<ProductoDbContext>(options => options.UseInMemoryDatabase("SER"));
//builder.Services.AddDbContext<TasaCambioDbContext>(options => options.UseInMemoryDatabase("SER"));
builder.Services.AddDbContext<ClienteDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PruebaBackendConnectionString")));
builder.Services.AddDbContext<ProductoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PruebaBackendConnectionString")));
builder.Services.AddDbContext<TasaCambioDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PruebaBackendConnectionString")));

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
