using AutoMapper;
using DispatcherService.API.DTO;
using DispatcherService.Domain.Entities;
using DispatcherService.Domain.Repositories;

namespace DispatcherService.API.Services;

/// <summary>
/// Сервис для управления данными о водителях.
/// Реализует интерфейс IService для выполнения операций CRUD с водителями.
/// </summary>
public class DriverService(IRepository<Driver> driverRepository, IMapper mapper)
    : IService<DriverDto, DriverFullDto>
{
    //private int _id = 1;

    /// <summary>
    /// Удаляет водителя по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор водителя для удаления.</param>
    /// <returns>True, если удаление прошло успешно; иначе - False.</returns>
    public bool Delete(int id)
    {
        return driverRepository.Delete(id);
    }

    /// <summary>
    /// Получает список всех водителей.
    /// </summary>
    /// <returns>Перечисление всех водителей.</returns>
    public IEnumerable<DriverFullDto> GetAll()
    {
        return driverRepository.GetAll().Select(mapper.Map<DriverFullDto>);
    }

    /// <summary>
    /// Получает full-dto водителя по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор водителя.</param>
    /// <returns>Full-dto водителя с указанным идентификатором или null, если не найден.</returns>
    public DriverFullDto? GetById(int id)
    {
        var driver = driverRepository.GetById(id);
        return mapper.Map<DriverFullDto>(driver);
    }

    /// <summary>
    /// Добавляет нового водителя.
    /// </summary>
    /// <param name="entity">DTO объекта водителя для добавления.</param>
    /// <returns>Full-dto добавленного водителя или null, если добавление не удалось.</returns>
    public DriverFullDto? Post(DriverDto entity)
    {
        var driver = mapper.Map<Driver>(entity);
        //driver.Id = _id++;
        return mapper.Map<DriverFullDto>(driverRepository.Post(driver));
    }

    /// <summary>
    /// Обновляет данные о водителе по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор водителя для обновления.</param>
    /// <param name="entity">DTO объекта водителя с новыми данными.</param>
    /// <returns>True, если обновление прошло успешно; иначе - False.</returns>
    public bool Put(int id, DriverDto entity)
    {
        var driver = mapper.Map<Driver>(entity);
        return driverRepository.Put(id, driver);
    }
}
