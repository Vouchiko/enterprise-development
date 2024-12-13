using System.Reflection;
using DispatcherService.API;
using DispatcherService.API.DTO;
using DispatcherService.API.Services;
using DispatcherService.Domain.Entities;
using DispatcherService.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Настройка служб и сервисов
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// Добавление сервисов
builder.Services.AddSingleton<IService<DriverDto, DriverFullDto>, DriverService>();
builder.Services.AddSingleton<IService<TransportDto, TransportFullDto>, TransportService>();
builder.Services.AddSingleton<IService<SchedulesDto, SchedulesFullDto>, SchedulesService>();
builder.Services.AddSingleton<IQueryService, QueryService>();

// Добавление репозиториев
builder.Services.AddSingleton<IRepository<Driver>, DriverRepository>();
builder.Services.AddSingleton<IRepository<Transport>, TransportRepository>();
builder.Services.AddSingleton<IRepository<Schedule>, SchedulesRepository>();

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

// Маршруты для контроллеров
app.MapControllers();

app.Run();
