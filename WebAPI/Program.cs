using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.OpenApi.Models;
using WebAPI.Installers;

var builder = WebApplication.CreateBuilder(args);



builder.Services.InstallServicesInAssembly(builder.Configuration);

// Add services to the container.
/* in class MvcInstaller
builder.Services.AddScoped<IPostRepository,PostRepository>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddSingleton(AutoMapperConfig.Initialize());

builder.Services.AddControllers();
*/
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

/* in class SwaggerInstaller
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "WebAPI", Version = "v1"
    });
});
*/

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
