using Magazine.WebApi.Services;
using Magazine.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Добавляем ProductService в контейнер зависимостей с временем жизни Scoped
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();
