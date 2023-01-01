using Microsoft.EntityFrameworkCore;
using Stock.Domain.Context;
using Stock.Domain.IRepositories;
using Stock.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IStocksDbContext, StocksDbContext>();
builder.Services.AddScoped<IStocksRepository, StocksRepository>();

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<StocksDbContext>((optionBuilder) =>
optionBuilder.UseNpgsql(builder.Configuration.GetConnectionString(nameof(StocksDbContext))));

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
