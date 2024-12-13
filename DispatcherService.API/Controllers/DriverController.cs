using DispatcherService.API.Services;
using Microsoft.AspNetCore.Mvc;
using DispatcherService.API.DTO;

namespace DispatcherService.API.Controllers;

/// <summary>
/// Контроллер для управления водителями
/// </summary>
/// <param name="driverService">Сервис для работы с водителями</param>
[Route("api/[controller]")]
[ApiController]
public class DriverController(IService<DriverDto, DriverFullDto> driverService) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех водителей
    /// </summary>
    /// <returns>Список водителей</returns>
    [HttpGet]
    public ActionResult<IEnumerable<DriverFullDto>> Get()
    {
        return Ok(driverService.GetAll());
    }

    /// <summary>
    /// Возвращает водителя по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор водителя</param>
    /// <returns>Водитель или "Не найдено"</returns>
    [HttpGet("{id}")]
    public ActionResult<DriverFullDto> Get(int id)
    {
        var result = driverService.GetById(id);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Добавляет нового водителя
    /// </summary>
    /// <param name="value">Информация о новом водителе</param>
    /// <returns>Добавленный водитель или "Плохой запрос"</returns>
    [HttpPost]
    public ActionResult<DriverFullDto> Post([FromBody] DriverDto value)
    {
        var result = driverService.Post(value);
        if (result == null)
            return BadRequest();

        return Ok(result);
    }

    /// <summary>
    /// Изменяет водителя по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор водителя</param>
    /// <param name="value">Обновлённая информация о водителе</param>
    /// <returns>Результат операции</returns>
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] DriverDto value)
    {
        var result = driverService.Put(id, value);
        if (!result)
            return BadRequest();

        return Ok();
    }

    /// <summary>
    /// Удаляет водителя по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор водителя</param>
    /// <returns>Результат операции</returns>
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var result = driverService.Delete(id);
        if (!result)
            return NotFound();

        return Ok();
    }
}
