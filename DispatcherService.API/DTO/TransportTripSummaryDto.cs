namespace DispatcherService.API.DTO;

/// <summary>
/// Сводная информация о времени поездок для транспортных средств
/// </summary>
public class TransportTripSummaryDto
{
    /// <summary>
    /// Тип транспортного средства
    /// </summary>
    public string? TransportType { get; set; }

    /// <summary>
    /// Модель транспортного средства
    /// </summary>
    public string? Model { get; set; }

    /// <summary>
    /// Суммарное время поездок (в часах)
    /// </summary>
    public double TotalTime { get; set; }
}
