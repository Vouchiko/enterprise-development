using System.Reflection;
using DispatcherService.API;
using DispatcherService.API.DTO;
using DispatcherService.API.Services;
using DispatcherService.Domain;
using DispatcherService.Domain.Entities;
using DispatcherService.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ���������� ������������
builder.Services.AddControllers();

// ���������� ���������� ������������ Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// ����������� �������� ��� ������ � ����������
builder.Services.AddScoped<IService<DriverDto, DriverFullDto>, DriverService>();
builder.Services.AddScoped<IService<SchedulesDto, SchedulesFullDto>, SchedulesService>();
builder.Services.AddScoped<IService<TransportDto, TransportFullDto>, TransportService>();
builder.Services.AddScoped<IQueryService, QueryService>();

// ����������� ������������ ��� ������ � ����� ������
builder.Services.AddScoped<IRepository<Driver>, DriverRepository>();
builder.Services.AddScoped<IRepository<Schedule>, SchedulesRepository>();
builder.Services.AddScoped<IRepository<Transport>, TransportRepository>();

// ����������� ��������� ���� ������ � �������������� PostgreSQL
builder.Services.AddDbContext<DispatcherServiceContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgre")));

// ����������� AutoMapper ��� ��������������� �������� DTO � ���������
builder.Services.AddAutoMapper(typeof(Mapping));

var app = builder.Build();

// ����������� Swagger � ������ ����������
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
