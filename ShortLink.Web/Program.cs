
using Application.Interfaces;
using Application.Services;
using Data.Context;
using Data.Repositories;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using ShortLink.Web.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ShortLinkContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShortLinkSqlConnection"));
});
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IpersonService, PersonService>();
builder.Services.AddScoped<ILinkRepository, LinkRepository>();
builder.Services.AddScoped<ILinkService, LinkService>();
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

app.UseShortLinkUrlRedirect();


app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapFallbackToController("Index", "Link");
});

app.Run();
