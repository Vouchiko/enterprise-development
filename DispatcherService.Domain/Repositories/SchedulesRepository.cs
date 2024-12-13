using DispatcherService.Domain.Entities;

namespace DispatcherService.Domain.Repositories;

public class SchedulesRepository : IRepository<Schedule>
{
    private readonly List<Schedule> _schedules = new();

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

        _schedules.Remove(schedule);
        return true;
    }

    /// <summary>
    /// Возвращает список всех расписаний.
    /// </summary>
    /// <returns>Список расписаний.</returns>
    public IEnumerable<Schedule> GetAll() => _schedules;

    /// <summary>
    /// Возвращает расписание по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор расписания.</param>
    /// <returns>Объект Schedule или null, если расписание не найдено.</returns>
    public Schedule? GetById(int id) => _schedules.Find(s => s.Id == id);

    /// <summary>
    /// Добавляет новое расписание.
    /// </summary>
    /// <param name="entity">Объект Schedule для добавления.</param>
    /// <returns>Добавленный объект Schedule.</returns>
    public Schedule? Post(Schedule entity)
    {
        _schedules.Add(entity);
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

        oldSchedule.RouteNumber = entity.RouteNumber;
        oldSchedule.StartTime = entity.StartTime;
        oldSchedule.EndTime = entity.EndTime;
        oldSchedule.Transport = entity.Transport;
        oldSchedule.Driver = entity.Driver;
        oldSchedule.TransportId = entity.TransportId;
        oldSchedule.DriverId = entity.DriverId;
        return true;
    }
}
