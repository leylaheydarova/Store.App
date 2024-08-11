using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Store.App.Context;
using Store.App.Dtos.Category;
using Store.App.Profiles;
using Store.App.Validations.Category;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(fv=>fv.RegisterValidatorsFromAssemblyContaining<CategoryPostDtoValidation>());
builder.Services.AddAutoMapper(typeof(CategoryMap));
builder.Services.AddDbContext<StoreDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
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
