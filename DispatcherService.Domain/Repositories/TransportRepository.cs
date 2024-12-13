using DispatcherService.Domain.Entities;

namespace DispatcherService.Domain.Repositories;

public class TransportRepository : IRepository<Transport>
{
    private readonly List<Transport> _transports = new();

    /// <summary>
    /// Удаляет транспортное средство по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор транспортного средства.</param>
    /// <returns>Возвращает true, если транспортное средство удалено успешно, иначе false.</returns>
    public bool Delete(int id)
    {
        var transport = GetById(id);

        if (transport == null)
            return false;

        _transports.Remove(transport);
        return true;
    }

    /// <summary>
    /// Возвращает список всех транспортных средств.
    /// </summary>
    /// <returns>Список транспортных средств.</returns>
    public IEnumerable<Transport> GetAll() => _transports;

    /// <summary>
    /// Возвращает транспортное средство по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор транспортного средства.</param>
    /// <returns>Объект Transport или null, если транспортное средство не найдено.</returns>
    public Transport? GetById(int id) => _transports.Find(t => t.Id == id);

    /// <summary>
    /// Добавляет новое транспортное средство.
    /// </summary>
    /// <param name="entity">Объект Transport для добавления.</param>
    /// <returns>Добавленный объект Transport.</returns>
    public Transport? Post(Transport entity)
    {
        _transports.Add(entity);
        return entity;
    }

    /// <summary>
    /// Обновляет информацию о транспортном средстве.
    /// </summary>
    /// <param name="id">Идентификатор транспортного средства.</param>
    /// <param name="entity">Объект Transport с обновленными данными.</param>
    /// <returns>Возвращает true, если обновление прошло успешно, иначе false.</returns>
    public bool Put(int id, Transport entity)
    {
        var oldTransport = GetById(id);
        if (oldTransport == null)
            return false;

        oldTransport.RegistrationNumber = entity.RegistrationNumber;
        oldTransport.Type = entity.Type;
        oldTransport.Model = entity.Model;
        oldTransport.IsLowFloor = entity.IsLowFloor;
        oldTransport.MaxCapacity = entity.MaxCapacity;
        oldTransport.YearOfManufacture = entity.YearOfManufacture;
        return true;
    }
}