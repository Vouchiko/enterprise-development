using DispatcherService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DispatcherService.Domain.Repositories;

public class SchedulesRepository(DispatcherServiceContext context, IRepository<Driver> driverRepository, IRepository<Transport> transportRepository) : IRepository<Schedule>
{
    /// <summary>
    /// Удаляет расписание по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор расписания.</param>
    /// <returns>Возвращает true, если расписание успешно удалено, иначе false.</returns>
    public bool Delete(int id)
    {
        var schedule = GetById(id);

        if (schedule == null)
            return false;

        context.Schedules.Remove(schedule);
        context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Возвращает список всех расписаний.
    /// </summary>
    /// <returns>Список расписаний.</returns>
    public IEnumerable<Schedule> GetAll() => context.Schedules.ToList();

    /// <summary>
    /// Возвращает расписание по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор расписания.</param>
    /// <returns>Объект Schedule или null, если расписание не найдено.</returns>
    public Schedule? GetById(int id) => context.Schedules.FirstOrDefault(s => s.Id == id);

    /// <summary>
    /// Добавляет новое расписание.
    /// </summary>
    /// <param name="entity">Объект Schedule для добавления.</param>
    /// <returns>Добавленный объект Schedule.</returns>
    public Schedule? Post(Schedule entity)
    {
        var driver = driverRepository.GetById(entity.Driver?.Id ?? - 1);

        var transport = transportRepository.GetById(entity.Transport?.Id ?? -1);

        if (driver == null || transport == null)
            return null;

        context.Schedules.Add(entity);
        context.SaveChanges();
        return entity;
    }

    /// <summary>
    /// Обновляет расписание по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор расписания.</param>
    /// <param name="entity">Объект Schedule с обновленными данными.</param>
    /// <returns>Возвращает true, если обновление прошло успешно, иначе false.</returns>
    public bool Put(int id, Schedule entity)
    {
        var oldSchedule = GetById(id);
        if (oldSchedule == null)
            return false;

        var driver = driverRepository.GetById(entity.Driver?.Id ?? -1);
        var transport = transportRepository.GetById(entity.Transport?.Id ?? -1);

        if (driver == null || transport == null)
            return false;

        oldSchedule.RouteNumber = entity.RouteNumber;
        oldSchedule.StartTime = entity.StartTime;
        oldSchedule.EndTime = entity.EndTime;
        oldSchedule.Transport = entity.Transport;
        oldSchedule.Driver = entity.Driver;
        oldSchedule.TransportId = entity.TransportId;
        oldSchedule.DriverId = entity.DriverId;

        context.SaveChanges();
        return true;
    }
}
