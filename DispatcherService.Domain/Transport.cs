using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DispatcherService.Domain.Entities;

/// <summary>
/// Представляет информацию о транспортном средстве.
/// </summary>
[Table("transports")]
public class Transport
{
    /// <summary>
    /// Уникальный идентификатор транспортного средства.
    /// </summary>
    [Key]
    [Column("id")]
    public required int Id { get; set; }

    /// <summary>
    /// Регистрационный номер транспортного средства.
    /// </summary>
    [Column("registration_number")]
    public string? RegistrationNumber { get; set; }

    /// <summary>
    /// Тип транспортного средства (например, автобус, трамвай и т.д.).
    /// </summary>
    [Column("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Модель транспортного средства.
    /// </summary>
    [Column("model")]
    public string? Model { get; set; }

    /// <summary>
    /// Признак низкопольного транспортного средства.
    /// </summary>
    [Column("is_low_floor")]
    public bool? IsLowFloor { get; set; }

    /// <summary>
    /// Максимальная вместимость транспортного средства.
    /// </summary>
    [Column("max_capacity")]
    public int? MaxCapacity { get; set; }

    /// <summary>
    /// Год выпуска транспортного средства.
    /// </summary>
    [Column("year_of_manufacture")]
    public int? YearOfManufacture { get; set; }

    /// <summary>
    /// Список расписаний, связанных с данным транспортным средством.
    /// </summary>
    public List<Schedule>? Schedules { get; set; }

    // Конструктор по умолчанию
    public Transport()
    {
        Schedules = new List<Schedule>();
    }

    // Конструктор с параметрами
    public Transport(int id, string? registrationNumber = null, string? type = null, string? model = null,
                     bool? isLowFloor = null, int? maxCapacity = null, int? yearOfManufacture = null)
    {
        Id = id;
        RegistrationNumber = registrationNumber;
        Type = type;
        Model = model;
        IsLowFloor = isLowFloor;
        MaxCapacity = maxCapacity;
        YearOfManufacture = yearOfManufacture;
        Schedules = new List<Schedule>();
    }
}