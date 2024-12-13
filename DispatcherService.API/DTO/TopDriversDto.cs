namespace DispatcherService.API.DTO;

/// <summary>
/// DTO для представления данных о топ-водителях по количеству поездок
/// </summary>
public class TopDriversDto
{
    /// <summary>
    /// Полное имя водителя
    /// </summary>
    public string DriverFullName { get; set; }

    /// <summary>
    /// Количество совершённых поездок
    /// </summary>
    public int TripCount { get; set; }

    /// <summary>
    /// Конструктор по умолчанию
    /// </summary>
    public TopDriversDto()
    {
    }

    /// <summary>
    /// Конструктор с параметрами
    /// </summary>
    /// <param name="driverFullName">Полное имя водителя</param>
    /// <param name="tripCount">Количество поездок</param>
    public TopDriversDto(string driverFullName, int tripCount)
    {
        DriverFullName = driverFullName;
        TripCount = tripCount;
    }
}
