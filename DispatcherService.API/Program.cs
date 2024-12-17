using System.Reflection;
using DispatcherService.API;
using DispatcherService.API.DTO;
using DispatcherService.API.Services;
using DispatcherService.Domain;
using DispatcherService.Domain.Entities;
using DispatcherService.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Добавление контроллеров
builder.Services.AddControllers();

// Добавление генератора документации Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// Добавление сервисов
builder.Services.AddScoped<IService<DriverDto, DriverFullDto>, DriverService>();
builder.Services.AddScoped<IService<SchedulesDto, SchedulesFullDto>, SchedulesService>();
builder.Services.AddScoped<IService<TransportDto, TransportFullDto>, TransportService>();
builder.Services.AddScoped<IQueryService, QueryService>();

//Добавление репозиториев
builder.Services.AddScoped<IRepository<Driver>, DriverRepository>();
builder.Services.AddScoped<IRepository<Schedule>, SchedulesRepository>();
builder.Services.AddScoped<IRepository<Transport>, TransportRepository>();

// Подключение контекста базы данных с использованием PostgreSQL
builder.Services.AddDbContext<DispatcherServiceContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgre")));

// Добавление AutoMapper для маппинга
builder.Services.AddAutoMapper(typeof(Mapping));

var app = builder.Build();

// Настройка для разработки
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
