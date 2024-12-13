namespace DispatcherService.API.DTO;

/// <summary>
/// Представляет полную информацию о транспортном средстве для передачи данных.
/// </summary>
public class TransportFullDto
{
    /// <summary>
    /// Идентификатор транспортного средства.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Регистрационный номер транспортного средства.
    /// </summary>
    public string? RegistrationNumber { get; set; }

    /// <summary>
    /// Тип транспортного средства.
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// Модель транспортного средства.
    /// </summary>
    public string? Model { get; set; }

    /// <summary>
    /// Максимальная вместимость пассажиров.
    /// </summary>
    public int? MaxCapacity { get; set; }

    /// <summary>
    /// Год выпуска транспортного средства.
    /// </summary>
    public int? YearOfManufacture { get; set; }

    /// <summary>
    /// Признак низкопольного транспортного средства.
    /// </summary>
    public bool? IsLowFloor { get; set; }
}

