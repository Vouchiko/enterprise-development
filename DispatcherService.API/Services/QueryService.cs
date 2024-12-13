using AutoMapper;
using DispatcherService.API.DTO;
using DispatcherService.API.Services;
using DispatcherService.Domain.Entities;
using DispatcherService.Domain.Repositories;


namespace DispatcherService.API.Services;

/// <summary>
/// Сервис для работы с транспортом и поездками
/// </summary>
public class QueryService(IRepository<Transport> transportRepository, IRepository<Schedule> scheduleRepository, IMapper mapper) : IQueryService
{
    /// <summary>
    /// Получить сведения о конкретном транспортном средстве по ID
    /// </summary>
    /// <param name="transportId">Идентификатор транспорта</param>
    /// <returns>Информация о транспорте</returns>
    public TransportFullDto GetTransportDetails(int transportId)
    {
        var transport = transportRepository.GetAll().FirstOrDefault(t => t.Id == transportId);
        return mapper.Map<TransportFullDto>(transport);
    }

    /// <summary>
    /// Получить всех водителей, совершивших поездки за указанный период, упорядочить по ФИО
    /// </summary>
    /// <param name="startDate">Начальная дата</param>
    /// <param name="endDate">Конечная дата</param>
    /// <returns>Список водителей</returns>
    public List<DriverDto> GetDriversByTripPeriod(DateTime startDate, DateTime endDate)
    {
        var drivers = scheduleRepository.GetAll()
            .Where(s => s.StartTime >= startDate && s.EndTime <= endDate)
            .Select(s => s.Driver)
            .Distinct()
            .OrderBy(d => d.FullName)
            .ToList();

        return mapper.Map<List<DriverDto>>(drivers);
    }

    /// <summary>
    /// Получить сводное время поездок для каждого типа и модели транспорта
    /// </summary>
    /// <returns>Список сводной информации о поездках</returns>
    public List<TransportTripSummaryDto> GetTotalTripTimeByTransportTypeAndModel()
    {
        var transportSummary = scheduleRepository.GetAll()
            .Where(s => s.StartTime.HasValue && s.EndTime.HasValue)
            .GroupBy(s => new { s.Transport?.Type, s.Transport?.Model })
            .Select(g => new TransportTripSummaryDto
            {
                TransportType = g.Key.Type,
                Model = g.Key.Model,
                TotalTime = g.Sum(s => (s.EndTime!.Value - s.StartTime!.Value).TotalHours)
            })
            .ToList();

        return transportSummary;
    }

    /// <summary>
    /// Получить топ-5 водителей по количеству совершённых поездок
    /// </summary>
    /// <returns>Список водителей</returns>
    public List<TopDriversDto> GetTopDriversByTripCount()
    {
        var topDrivers = scheduleRepository.GetAll()
            .GroupBy(s => s.Driver)
            .Select(g => new TopDriversDto
            {
                DriverFullName = g.Key.FullName,
                TripCount = g.Count()
            })
            .OrderByDescending(d => d.TripCount)
            .Take(5)
            .ToList();

        return topDrivers;
    }

    /// <summary>
    /// Получить статистику поездок по каждому водителю
    /// </summary>
    /// <returns>Список статистики по водителям</returns>
    public List<DriverTripStatisticsDto> GetDriverTripStatistics()
    {
        var driverStats = scheduleRepository.GetAll()
            .Where(s => s.StartTime.HasValue && s.EndTime.HasValue)
            .GroupBy(s => s.Driver)
            .Select(g => new DriverTripStatisticsDto
            {
                DriverFullName = g.Key.FullName,
                TripCount = g.Count(),
                AverageTime = g.Average(s => (s.EndTime!.Value - s.StartTime!.Value).TotalHours),
                MaxTime = g.Max(s => (s.EndTime!.Value - s.StartTime!.Value).TotalHours)
            })
            .ToList();

        return driverStats;
    }

    /// <summary>
    /// Получить список транспортных средств с максимальным количеством поездок за указанный период
    /// </summary>
    /// <param name="startDate">Начальная дата</param>
    /// <param name="endDate">Конечная дата</param>
    /// <returns>Список транспортных средств</returns>
    public List<TransportFullDto> GetMostTripsByTransportInPeriod(DateTime startDate, DateTime endDate)
    {
        var transportTrips = scheduleRepository.GetAll()
            .Where(s => s.StartTime >= startDate && s.EndTime <= endDate)
            .GroupBy(s => s.Transport)
            .Select(g => new
            {
                Transport = g.Key,
                TripCount = g.Count()
            })
            .OrderByDescending(t => t.TripCount)
            .ToList();

        var maxTripCount = transportTrips.FirstOrDefault()?.TripCount ?? 0;
        var mostUsedTransports = transportTrips
            .Where(t => t.TripCount == maxTripCount)
            .Select(t => t.Transport)
            .ToList();

        return mapper.Map<List<TransportFullDto>>(mostUsedTransports);
    }
}
