namespace DispatcherService.API.DTO;

/// <summary>
/// Представляет полную информацию о расписании для передачи данных.
/// </summary>
public class SchedulesFullDto
{
    /// <summary>
    /// Идентификатор расписания.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор транспортного средства.
    /// </summary>
    public int TransportId { get; set; }

    /// <summary>
    /// Идентификатор водителя.
    /// </summary>
    public int DriverId { get; set; }

    /// <summary>
    /// Номер маршрута.
    /// </summary>
    public string? RouteNumber { get; set; }

    /// <summary>
    /// Время начала рейса.
    /// </summary>
    public DateTime StartTime { get; set; }

    /// <summary>
    /// Время окончания рейса.
    /// </summary>
    public DateTime EndTime { get; set; }

    /// <summary>
    /// Полная информация о транспортном средстве.
    /// </summary>
    public TransportFullDto? Transport { get; set; }

    /// <summary>
    /// Полная информация о водителе.
    /// </summary>
    public DriverFullDto? Driver { get; set; }
}