using DispatcherService.API.DTO;
using DispatcherService.API.Services;
using Microsoft.AspNetCore.Mvc;
using DispatcherService.Domain.Entities;

namespace DispatchService.API.Controllers;

/// <summary>
/// Контроллер для запросов к данным о транспорте, водителях и расписаниях
/// </summary>
/// <param name="queryService">Сервис для запросов</param>
[Route("api/[controller]")]
[ApiController]
public class QueryController(IQueryService queryService) : ControllerBase
{
    /// <summary>
    /// Возвращает сведения о транспортном средстве по идентификатору
    /// </summary>
    /// <param name="transportId">Идентификатор транспортного средства</param>
    /// <returns>Детали транспортного средства</returns>
    [HttpGet("transport/{transportId}")]
    public ActionResult<TransportFullDto> GetTransportDetails(int transportId)
    {
        var transport = queryService.GetTransportDetails(transportId);
        if (transport == null)
        {
            return NotFound();
        }
        return Ok(transport);
    }

    /// <summary>
    /// Возвращает всех водителей, совершивших поездки за заданный период, упорядоченных по ФИО
    /// </summary>
    /// <param name="startDate">Начальная дата</param>
    /// <param name="endDate">Конечная дата</param>
    /// <returns>Список водителей</returns>
    [HttpGet("drivers/trip-period")]
    public ActionResult<List<DriverFullDto>> GetDriversByTripPeriod(DateTime startDate, DateTime endDate)
    {
        var drivers = queryService.GetDriversByTripPeriod(startDate, endDate);
        return Ok(drivers);
    }

    /// <summary>
    /// Возвращает суммарное время поездок транспортных средств по типам и моделям
    /// </summary>
    /// <returns>Сводная информация о времени поездок</returns>
    [HttpGet("transport/trip-summary")]
    public ActionResult<List<TransportTripSummaryDto>> GetTotalTripTimeByTransportTypeAndModel()
    {
        var transportSummary = queryService.GetTotalTripTimeByTransportTypeAndModel();
        return Ok(transportSummary);
    }

    /// <summary>
    /// Возвращает топ 5 водителей по количеству выполненных поездок
    /// </summary>
    /// <returns>Список водителей</returns>
    [HttpGet("drivers/top")]
    public ActionResult<List<DriverFullDto>> GetTopDriversByTripCount()
    {
        var topDrivers = queryService.GetTopDriversByTripCount();
        return Ok(topDrivers);
    }

    /// <summary>
    /// Возвращает статистику поездок для каждого водителя (количество, среднее время, максимальное время)
    /// </summary>
    /// <returns>Статистика поездок</returns>
    [HttpGet("drivers/trip-stats")]
    public ActionResult<List<DriverTripStatisticsDto>> GetDriverTripStatistics()
    {
        var stats = queryService.GetDriverTripStatistics();
        return Ok(stats);
    }

    /// <summary>
    /// Возвращает транспортные средства, совершившие максимальное количество поездок за указанный период
    /// </summary>
    /// <param name="startDate">Начальная дата</param>
    /// <param name="endDate">Конечная дата</param>
    /// <returns>Список транспортных средств</returns>
    [HttpGet("transport/most-trips")]
    public ActionResult<List<TransportFullDto>> GetMostTripsByTransportInPeriod(DateTime startDate, DateTime endDate)
    {
        var mostUsedTransports = queryService.GetMostTripsByTransportInPeriod(startDate, endDate);
        return Ok(mostUsedTransports);
    }
}

