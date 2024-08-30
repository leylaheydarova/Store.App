using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Store.Core.Repositories.Abstractions.Categories;
using Store.Data.Context;
using Store.Data.Repositories.Concretes.Categories;
using Store.Service.Dtos.Category;
using Store.Service.Profiles;
using Store.Service.Services.Abstractions;
using Store.Service.Services.Concretes;
using Store.Service.Validations.Category;

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

//Activation Repository and Services
builder.Services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
builder.Services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddCors(o => o.AddPolicy("Store", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Store");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
