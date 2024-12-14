using AutoMapper;
using DispatcherService.API.DTO;
using DispatcherService.Domain.Entities;

namespace DispatcherService.API;

/// <summary>
/// Класс для маппинга
/// </summary>
public class Mapping : Profile
{
    /// <summary>
    /// Маппинг сущностей
    /// </summary>
    public Mapping()
    {
        // Маппинг для Transport
        CreateMap<Transport, TransportDto>().ReverseMap();
        CreateMap<Transport, TransportFullDto>().ReverseMap();

        //Driver
        CreateMap<Driver, DriverDto>().ReverseMap();
        CreateMap<Driver, DriverFullDto>().ReverseMap();

        //Schedule
        CreateMap<Schedule, SchedulesDto>().ReverseMap();
        CreateMap<Schedule, SchedulesFullDto>().ReverseMap();
    }
}
