using Microsoft.EntityFrameworkCore;
using SpreadShirtShop.Data;
var builder = WebApplication.CreateBuilder(args);


var conectionString = builder.Configuration.GetConnectionString("SpreadShirtShopContext");

builder.Services.AddDbContext<SpreadShirtShopContext>(options =>
    options.UseSqlServer(conectionString));

// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
