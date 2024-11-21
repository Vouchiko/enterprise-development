namespace DispatcherService.Domain.Entities;

/// <summary>
/// Представляет расписание выхода на рейс.
/// </summary>
public class Schedule
{
    /// <summary>
    /// Уникальный идентификатор расписания.
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
    public string RouteNumber { get; set; }

    /// <summary>
    /// Время выхода на рейс.
    /// </summary>
    public DateTime StartTime { get; set; }

    /// <summary>
    /// Время окончания рейса.
    /// </summary>
    public DateTime EndTime { get; set; }

    // Навигационные свойства
    public Transport? Transport { get; set; }

    public Driver? Driver { get; set; }

    // Конструктор по умолчанию
    public Schedule()
    {
        Id = 1;
    }

    // Конструктор с параметрами
    public Schedule(int id, int transportId, int driverId, string routeNumber, DateTime startTime, DateTime endTime)
    {
        Id = id;
        TransportId = transportId;
        DriverId = driverId;
        RouteNumber = routeNumber;
        StartTime = startTime;
        EndTime = endTime;
    }
}
