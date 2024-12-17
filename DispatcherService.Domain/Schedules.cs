using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DispatcherService.Domain.Entities;

/// <summary>
/// Представляет информацию о расписании.
/// </summary>
[Table("schedules")]
public class Schedule
{
    /// <summary>
    /// Уникальный идентификатор расписания.
    /// </summary>
    [Key]
    [Column("id")]
    public required int Id { get; set; }

    /// <summary>
    /// Идентификатор транспортного средства, связанного с расписанием.
    /// </summary>
    [Column("transport_id")]
    public int? TransportId { get; set; }

    /// <summary>
    /// Идентификатор водителя, связанного с расписанием.
    /// </summary>
    [Column("driver_id")]
    public int? DriverId { get; set; }

    /// <summary>
    /// Номер маршрута.
    /// </summary>
    [Column("route_number")]
    public string? RouteNumber { get; set; }

    /// <summary>
    /// Время начала работы по расписанию.
    /// </summary>
    [Column("start_time")]
    public DateTime? StartTime { get; set; }

    /// <summary>
    /// Время окончания работы по расписанию.
    /// </summary>
    [Column("end_time")]
    public DateTime? EndTime { get; set; }

    /// <summary>
    /// Транспортное средство, связанное с этим расписанием.
    /// </summary>
    [ForeignKey("TransportId")]
    public Transport? Transport { get; set; }

    /// <summary>
    /// Водитель, связанный с этим расписанием.
    /// </summary>
    [ForeignKey("DriverId")]
    public Driver? Driver { get; set; }

    // Конструктор по умолчанию
    public Schedule()
    {
    }

    // Конструктор с параметрами
    public Schedule(int id, int? transportId = null, int? driverId = null, string? routeNumber = null, DateTime? startTime = null, DateTime? endTime = null, Transport? transport = null, Driver driver = null)
    {
        Id = id;
        TransportId = transportId;
        DriverId = driverId;
        RouteNumber = routeNumber;
        StartTime = startTime;
        EndTime = endTime;
        Transport = transport;
        Driver = driver;
    }
}
