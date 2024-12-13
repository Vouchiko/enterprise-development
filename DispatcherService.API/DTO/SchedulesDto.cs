namespace DispatcherService.API.DTO;

/// <summary>
/// Представляет информацию о расписании для передачи данных.
/// </summary>
public class SchedulesDto
{
    /// <summary>
    /// Номер маршрута.
    /// </summary>
    public string? RouteNumber { get; set; }

    /// <summary>
    /// Время начала поездки.
    /// </summary>
    public DateTime? StartTime { get; set; }

    /// <summary>
    /// Время окончания поездки.
    /// </summary>
    public DateTime? EndTime { get; set; }

    /// <summary>
    /// Информация о транспортном средстве, задействованном в поездке.
    /// </summary>
    public TransportFullDto? Transport { get; set; }

    /// <summary>
    /// Информация о водителе, выполняющем поездку.
    /// </summary>
    public DriverFullDto? Driver { get; set; }
}