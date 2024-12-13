using DispatcherService.API.Services;
using Microsoft.AspNetCore.Mvc;
using DispatcherService.API.DTO;

namespace DispatcherService.API.Controllers;

/// <summary>
/// Контроллер для управления транспортом
/// </summary>
/// <param name="transportService">Сервис для работы с транспортом</param>
[Route("api/[controller]")]
[ApiController]
public class TransportController(IService<TransportDto, TransportFullDto> transportService) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех транспортных средств
    /// </summary>
    /// <returns>Список транспортных средств</returns>
    [HttpGet]
    public ActionResult<IEnumerable<TransportFullDto>> Get()
    {
        return Ok(transportService.GetAll());
    }

    /// <summary>
    /// Возвращает транспортное средство по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор транспортного средства</param>
    /// <returns>Транспортное средство или "Не найдено"</returns>
    [HttpGet("{id}")]
    public ActionResult<TransportFullDto> Get(int id)
    {
        var result = transportService.GetById(id);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Добавляет новое транспортное средство
    /// </summary>
    /// <param name="value">Информация о новом транспортном средстве</param>
    /// <returns>Добавленное транспортное средство или "Плохой запрос"</returns>
    [HttpPost]
    public ActionResult<TransportFullDto> Post([FromBody] TransportDto value)
    {
        var result = transportService.Post(value);
        if (result == null)
            return BadRequest();

        return Ok(result);
    }

    /// <summary>
    /// Изменяет транспортное средство по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор транспортного средства</param>
    /// <param name="value">Обновлённая информация о транспортном средстве</param>
    /// <returns>Результат операции</returns>
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] TransportDto value)
    {
        var result = transportService.Put(id, value);
        if (!result)
            return BadRequest();

        return Ok();
    }

    /// <summary>
    /// Удаляет транспортное средство по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор транспортного средства</param>
    /// <returns>Результат операции</returns>
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var result = transportService.Delete(id);
        if (!result)
            return NotFound();

        return Ok();
    }
}
