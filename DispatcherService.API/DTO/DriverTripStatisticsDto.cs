namespace DispatcherService.API.DTO;

/// <summary>
/// Статистика поездок для водителя
/// </summary>
public class DriverTripStatisticsDto
{
    /// <summary>
    /// Полное имя водителя
    /// </summary>
    public string? DriverFullName { get; set; }

    /// <summary>
    /// Общее количество поездок
    /// </summary>
    public int TripCount { get; set; }

    /// <summary>
    /// Среднее время одной поездки (в часах)
    /// </summary>
    public double AverageTime { get; set; }

    /// <summary>
    /// Максимальное время одной поездки (в часах)
    /// </summary>
    public double MaxTime { get; set; }
}
