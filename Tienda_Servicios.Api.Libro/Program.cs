using MediatR;
using Microsoft.EntityFrameworkCore;
using Tienda_Servicios.Api.Libro.Application;
using Tienda_Servicios.Api.Libro.ApplicationDBContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<LibreriaContexto>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"));
});
builder.Services.AddMediatR(typeof(Nuevo.Handler).Assembly);
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
