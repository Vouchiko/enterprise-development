using DispatcherService.API.DTO;

namespace DispatcherService.API.Services;

/// <summary>
/// Интерфейс для сервиса запросов к данным о поездках и водителях
/// </summary>
public interface IQueryService
{
    /// <summary>
    /// Выводит все сведения о конкретном транспортном средстве
    /// </summary>
    /// <param name="transportId">Идентификатор транспортного средства</param>
    /// <returns>Сведения о транспортном средстве</returns>
    TransportFullDto GetTransportDetails(int transportId);

    /// <summary>
    /// Выводит всех водителей, совершивших поездки за указанный период, упорядочить по ФИО
    /// </summary>
    /// <param name="startDate">Начальная дата</param>
    /// <param name="endDate">Конечная дата</param>
    /// <returns>Список водителей</returns>
    List<DriverDto> GetDriversByTripPeriod(DateTime startDate, DateTime endDate);

    /// <summary>
    /// Выводит суммарное время поездок транспортного средства каждого типа и модели
    /// </summary>
    /// <returns>Сводная информация по времени поездок</returns>
    List<TransportTripSummaryDto> GetTotalTripTimeByTransportTypeAndModel();

    /// <summary>
    /// Выводит топ 5 водителей по количеству совершённых поездок
    /// </summary>
    /// <returns>Список топ 5 водителей</returns>
    List<TopDriversDto> GetTopDriversByTripCount();

    /// <summary>
    /// Выводит информацию о количестве поездок, среднем времени и максимальном времени поездки для каждого водителя
    /// </summary>
    /// <returns>Статистика по водителям</returns>
    List<DriverTripStatisticsDto> GetDriverTripStatistics();

    /// <summary>
    /// Выводит информацию о транспортных средствах, совершивших максимальное число поездок за указанный период
    /// </summary>
    /// <param name="startDate">Начальная дата</param>
    /// <param name="endDate">Конечная дата</param>
    /// <returns>Список транспортных средств с максимальным числом поездок</returns>
    List<TransportFullDto> GetMostTripsByTransportInPeriod(DateTime startDate, DateTime endDate);
}
