using AutoMapper;
using DispatcherService.API.DTO;
using DispatcherService.Domain.Entities;
using DispatcherService.Domain.Repositories;

namespace DispatcherService.API.Services;

/// <summary>
/// Сервис для управления данными о транспорте.
/// Реализует интерфейс IService для выполнения операций CRUD с транспортом.
/// </summary>
public class TransportService(IRepository<Transport> transportRepository, IMapper mapper)
    : IService<TransportDto, TransportFullDto>
{
    private int _id = 1;

    /// <summary>
    /// Удаляет транспорт по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор транспорта для удаления.</param>
    /// <returns>True, если удаление прошло успешно; иначе - False.</returns>
    public bool Delete(int id)
    {
        return transportRepository.Delete(id);
    }

    /// <summary>
    /// Получает список всех транспортных средств.
    /// </summary>
    /// <returns>Перечисление всех транспортных средств.</returns>
    public IEnumerable<TransportFullDto> GetAll()
    {
        return transportRepository.GetAll().Select(mapper.Map<TransportFullDto>);
    }

    /// <summary>
    /// Получает full-dto транспорта по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор транспорта.</param>
    /// <returns>Full-dto транспорта с указанным идентификатором или null, если не найден.</returns>
    public TransportFullDto? GetById(int id)
    {
        var transport = transportRepository.GetById(id);
        return mapper.Map<TransportFullDto>(transport);
    }

    /// <summary>
    /// Добавляет новый транспорт.
    /// </summary>
    /// <param name="entity">DTO объекта транспорта для добавления.</param>
    /// <returns>Full-dto добавленного транспорта или null, если добавление не удалось.</returns>
    public TransportFullDto? Post(TransportDto entity)
    {
        var transport = mapper.Map<Transport>(entity);
        transport.Id = _id++;
        return mapper.Map<TransportFullDto>(transportRepository.Post(transport));
    }

    /// <summary>
    /// Обновляет данные о транспорте по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор транспорта для обновления.</param>
    /// <param name="entity">DTO объекта транспорта с новыми данными.</param>
    /// <returns>True, если обновление прошло успешно; иначе - False.</returns>
    public bool Put(int id, TransportDto entity)
    {
        var transport = mapper.Map<Transport>(entity);
        return transportRepository.Put(id, transport);
    }
}
