namespace DispatcherService.Domain.Entities;

/// <summary>
/// Представляет водителя.
/// </summary>
public class Driver
{
    /// <summary>
    /// Уникальный идентификатор водителя.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Полное имя водителя.
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// Паспортные данные.
    /// </summary>
    public string Passport { get; set; }

    /// <summary>
    /// Номер водительского удостоверения.
    /// </summary>
    public string DriverLicense { get; set; }

    /// <summary>
    /// Адрес проживания.
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Телефонный номер.
    /// </summary>
    public string PhoneNumber { get; set; }

    // Конструктор с параметрами
    public Driver(int id, string fullName, string passport, string driverLicense, string address, string phoneNumber)
    {
        Id = id;
        FullName = fullName;
        Passport = passport;
        DriverLicense = driverLicense;
        Address = address;
        PhoneNumber = phoneNumber;
    }
}
