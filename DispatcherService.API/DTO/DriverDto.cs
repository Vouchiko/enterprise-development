namespace DispatcherService.API.DTO;

/// <summary>
/// Представляет информацию о водителе для передачи данных.
/// </summary>
public class DriverDto
{
    /// <summary>
    /// Полное имя водителя.
    /// </summary>
    public string? FullName { get; set; }

    /// <summary>
    /// Паспортные данные водителя.
    /// </summary>
    public string? Passport { get; set; }

    /// <summary>
    /// Номер водительского удостоверения.
    /// </summary>
    public string? DriverLicense { get; set; }

    /// <summary>
    /// Адрес проживания водителя.
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// Контактный номер телефона водителя.
    /// </summary>
    public string? PhoneNumber { get; set; }
}