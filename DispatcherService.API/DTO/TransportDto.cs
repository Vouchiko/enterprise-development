namespace DispatcherService.API.DTO;

/// <summary>
/// Представляет информацию о транспортном средстве для передачи данных.
/// </summary>
public class TransportDto
{
    /// <summary>
    /// Регистрационный номер транспортного средства.
    /// </summary>
    public string? RegistrationNumber { get; set; }

    /// <summary>
    /// Тип транспортного средства (например, автобус, троллейбус).
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// Модель транспортного средства.
    /// </summary>
    public string? Model { get; set; }

    /// <summary>
    /// Указывает, является ли транспортное средство низкопольным.
    /// </summary>
    public bool? IsLowFloor { get; set; }

    /// <summary>
    /// Максимальная вместимость пассажиров.
    /// </summary>
    public int? MaxCapacity { get; set; }

    /// <summary>
    /// Год выпуска транспортного средства.
    /// </summary>
    public int? YearOfManufacture { get; set; }
}