namespace DispatcherService.Domain.Entities;

/// <summary>
/// Представляет транспортное средство.
/// </summary>
public class Transport
{
    /// <summary>
    /// Уникальный идентификатор транспортного средства.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Государственный номер.
    /// </summary>
    public string RegistrationNumber { get; set; }

    /// <summary>
    /// Тип транспортного средства (Автобус, Троллейбус, Трамвай).
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Модель транспортного средства.
    /// </summary>
    public string Model { get; set; }

    /// <summary>
    /// Низкопольный (true/false).
    /// </summary>
    public bool IsLowFloor { get; set; }

    /// <summary>
    /// Максимальная вместимость.
    /// </summary>
    public int MaxCapacity { get; set; }

    /// <summary>
    /// Год выпуска.
    /// </summary>
    public int YearOfManufacture { get; set; }

    // Конструктор с параметрами
    public Transport(int id, string registrationNumber, string type, string model, bool isLowFloor, int maxCapacity, int yearOfManufacture)
    {
        Id = id;
        RegistrationNumber = registrationNumber;
        Type = type;
        Model = model;
        IsLowFloor = isLowFloor;
        MaxCapacity = maxCapacity;
        YearOfManufacture = yearOfManufacture;

    }
}
