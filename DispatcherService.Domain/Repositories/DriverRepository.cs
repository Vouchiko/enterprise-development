using DispatcherService.Domain.Entities;

namespace DispatcherService.Domain.Repositories;

public class DriverRepository : IRepository<Driver>
{
    private readonly List<Driver> _drivers = new();

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

        _drivers.Remove(driver);
        return true;
    }

    /// <summary>
    /// Возвращает всех водителей.
    /// </summary>
    /// <returns>Список водителей.</returns>
    public IEnumerable<Driver> GetAll() => _drivers;

    /// <summary>
    /// Возвращает водителя по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор водителя.</param>
    /// <returns>Объект Driver или null, если водитель не найден.</returns>
    public Driver? GetById(int id) => _drivers.Find(d => d.Id == id);

 /*   public object GetById(object id)
    {
        throw new NotImplementedException();
    }*/

    /// <summary>
    /// Добавляет нового водителя.
    /// </summary>
    /// <param name="entity">Объект Driver для добавления.</param>
    /// <returns>Добавленный объект Driver.</returns>
    public Driver? Post(Driver entity)
    {
        _drivers.Add(entity);
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
        return true;
    }
}