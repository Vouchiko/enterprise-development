using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DispatcherService.Domain.Entities;

/// <summary>
/// Представляет информацию о водителе.
/// </summary>
[Table("drivers")]
public class Driver
{
    /// <summary>
    /// Уникальный идентификатор водителя.
    /// </summary>
    [Key]
    [Column("id")]
    public required int Id { get; set; }

    /// <summary>
    /// Полное имя водителя.
    /// </summary>
    [Column("full_name")]
    public string? FullName { get; set; }

    /// <summary>
    /// Паспортные данные водителя.
    /// </summary>
    [Column("passport")]
    public string? Passport { get; set; }

    /// <summary>
    /// Номер водительского удостоверения.
    /// </summary>
    [Column("driver_license")]
    public string? DriverLicense { get; set; }

    /// <summary>
    /// Адрес проживания водителя.
    /// </summary>
    [Column("address")]
    public string? Address { get; set; }

    /// <summary>
    /// Номер телефона водителя.
    /// </summary>
    [Column("phone_number")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Список расписаний, связанных с данным водителем.
    /// </summary>
    public List<Schedule>? Schedules { get; set; }

    // Конструктор по умолчанию
    public Driver()
    {
        Schedules = new List<Schedule>();
    }

    // Конструктор с параметрами
    public Driver(int id, string? fullName = null, string? passport = null, string? driverLicense = null,
                  string? address = null, string? phoneNumber = null)
    {
        Id = id;
        FullName = fullName;
        Passport = passport;
        DriverLicense = driverLicense;
        Address = address;
        PhoneNumber = phoneNumber;
        Schedules = new List<Schedule>();
    }
}
