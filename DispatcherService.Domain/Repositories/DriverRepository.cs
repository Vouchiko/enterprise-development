using DispatcherService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DispatcherService.Domain.Repositories;

public class DriverRepository(DispatcherServiceContext context) : IRepository<Driver>
{
    /// <summary>
    /// Удаляет водителя по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор водителя.</param>
    /// <returns>Возвращает true, если водитель удалён успешно, иначе false.</returns>
    public bool Delete(int id)
    {
        var driver = GetById(id);

        if (driver == null)
            return false;

        context.Driver.Remove(driver);
        context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Возвращает всех водителей.
    /// </summary>
    /// <returns>Список водителей.</returns>
    public IEnumerable<Driver> GetAll() => context.Driver.ToList();

    /// <summary>
    /// Возвращает водителя по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор водителя.</param>
    /// <returns>Объект Driver или null, если водитель не найден.</returns>
    public Driver? GetById(int id) => context.Driver.FirstOrDefault(d => d.Id == id);

    /// <summary>
    /// Добавляет нового водителя.
    /// </summary>
    /// <param name="entity">Объект Driver для добавления.</param>
    /// <returns>Добавленный объект Driver.</returns>
    public Driver? Post(Driver entity)
    {
        context.Driver.Add(entity);
        context.SaveChanges();
        return entity;
    }

    /// <summary>
    /// Обновляет информацию о водителе.
    /// </summary>
    /// <param name="id">Идентификатор водителя.</param>
    /// <param name="entity">Объект Driver с обновлёнными данными.</param>
    /// <returns>Возвращает true, если обновление прошло успешно, иначе false.</returns>
    public bool Put(int id, Driver entity)
    {
        var oldDriver = GetById(id);
        if (oldDriver == null)
            return false;

        oldDriver.FullName = entity.FullName;
        oldDriver.Passport = entity.Passport;
        oldDriver.DriverLicense = entity.DriverLicense;
        oldDriver.Address = entity.Address;
        oldDriver.PhoneNumber = entity.PhoneNumber;

        context.SaveChanges();
        return true;
    }
}