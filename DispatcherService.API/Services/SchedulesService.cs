using AutoMapper;
using DispatcherService.API.DTO;
using DispatcherService.Domain.Entities;
using DispatcherService.Domain.Repositories;

namespace DispatcherService.API.Services;

/// <summary>
/// Сервис для управления данными о расписаниях.
/// Реализует интерфейс IService для выполнения операций CRUD с расписаниями.
/// </summary>
public class SchedulesService(
    IRepository<Schedule> schedulesRepository,
    IRepository<Driver> driverRepository,
    IRepository<Transport> transportRepository,
    IMapper mapper)
    : IService<SchedulesDto, SchedulesFullDto>
{
    private int _id = 1;

    /// <summary>
    /// Удаляет расписание по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор расписания для удаления.</param>
    /// <returns>True, если удаление прошло успешно; иначе - False.</returns>
    public bool Delete(int id)
    {
        return schedulesRepository.Delete(id);
    }

    /// <summary>
    /// Получает список всех расписаний.
    /// </summary>
    /// <returns>Перечисление всех расписаний.</returns>
    public IEnumerable<SchedulesFullDto> GetAll()
    {
        return schedulesRepository.GetAll().Select(mapper.Map<SchedulesFullDto>);
    }

    /// <summary>
    /// Получает расписание по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор расписания.</param>
    /// <returns>Full-dto расписания с указанным идентификатором или null, если не найдено.</returns>
    public SchedulesFullDto? GetById(int id)
    {
        var schedule = schedulesRepository.GetById(id);
        if (schedule == null) return null;

        var scheduleFullDto = mapper.Map<SchedulesFullDto>(schedule);

        if (schedule.Driver != null)
        {
            scheduleFullDto.Driver = 
                mapper.Map<DriverFullDto>(driverRepository.GetById(schedule.Driver.Id));
        }

        if (schedule.Transport != null)
        {
            scheduleFullDto.Transport = 
                mapper.Map<TransportFullDto>(transportRepository.GetById(schedule.Transport.Id));
        }

        return scheduleFullDto;
    }

    /// <summary>
    /// Добавляет новое расписание.
    /// </summary>
    /// <param name="entity">DTO объекта расписания для добавления.</param>
    /// <returns>Full-dto добавленного расписания или null, если добавление не удалось.</returns>
    public SchedulesFullDto? Post(SchedulesDto entity)
    {
        var schedule = mapper.Map<Schedule>(entity);
        if (schedule == null) return null;

        schedule.Id = _id++;

        var scheduleFullDto = mapper.Map<SchedulesFullDto>(schedulesRepository.Post(schedule));

        if (entity.Driver != null)
            scheduleFullDto.Driver =
                mapper.Map <DriverFullDto>(driverRepository.GetById(entity.Driver.Id));

        if (entity.Transport != null)
            scheduleFullDto.Transport = 
                mapper.Map<TransportFullDto>(transportRepository.GetById(entity.Transport.Id));

        return scheduleFullDto;
    }

    /// <summary>
    /// Обновляет данные о расписании по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор расписания для обновления.</param>
    /// <param name="entity">DTO объекта расписания с новыми данными.</param>
    /// <returns>True, если обновление прошло успешно; иначе - False.</returns>
    public bool Put(int id, SchedulesDto entity)
    {
        var schedule = mapper.Map<Schedule>(entity);
        return schedulesRepository.Put(id, schedule);
    }
}
