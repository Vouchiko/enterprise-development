namespace DispatcherService.API.DTO;

/// Представляет полную информацию о водителе для передачи данных.
/// </summary>
public class DriverFullDto
{
    /// <summary>
    /// Идентификатор водителя.
    /// </summary>
    public int Id { get; set; }

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
    /// Телефонный номер водителя.
    /// </summary>
    public string? PhoneNumber { get; set; }
}