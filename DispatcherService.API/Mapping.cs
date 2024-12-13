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
        CreateMap<Transport, TransportDto>();
        CreateMap<TransportDto, Transport>();
        CreateMap<Transport, TransportFullDto>();
        CreateMap<TransportFullDto, Transport>();
        
        //Driver
        CreateMap<Driver, DriverDto>();
        CreateMap<DriverDto, Driver>();
        CreateMap<Driver, DriverFullDto>();
        CreateMap<DriverFullDto, Driver>();

        //Schedule
        CreateMap<Schedule, SchedulesDto>();
        CreateMap<SchedulesDto, Schedule>();
        CreateMap<Schedule, SchedulesFullDto>();
        CreateMap<SchedulesFullDto, Schedule>();

    }
}
