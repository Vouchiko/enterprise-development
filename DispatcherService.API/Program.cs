using System.Reflection;
using DispatcherService.API;
using DispatcherService.API.DTO;
using DispatcherService.API.Services;
using DispatcherService.Domain.Entities;
using DispatcherService.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ��������� ����� � ��������
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// ���������� ��������
builder.Services.AddSingleton<IService<DriverDto, DriverFullDto>, DriverService>();
builder.Services.AddSingleton<IService<TransportDto, TransportFullDto>, TransportService>();
builder.Services.AddSingleton<IService<SchedulesDto, SchedulesFullDto>, SchedulesService>();
builder.Services.AddSingleton<IQueryService, QueryService>();

// ���������� ������������
builder.Services.AddSingleton<IRepository<Driver>, DriverRepository>();
builder.Services.AddSingleton<IRepository<Transport>, TransportRepository>();
builder.Services.AddSingleton<IRepository<Schedule>, SchedulesRepository>();

// ���������� AutoMapper ��� ��������
builder.Services.AddAutoMapper(typeof(Mapping));

var app = builder.Build();

// ��������� ��� ����������
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// �������� ��� ������������
app.MapControllers();

app.Run();
