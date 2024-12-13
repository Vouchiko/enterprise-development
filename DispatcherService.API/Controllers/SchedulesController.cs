using Microsoft.AspNetCore.Mvc;
using DispatcherService.API.DTO;
using DispatcherService.API.Services;

namespace DispatcherService.API.Controllers;

/// <summary>
/// Контроллер для управления расписанием 
/// </summary>
/// <param name="schedulesService">Сервис для работы с расписанием</param>
[Route("api/[controller]")]
[ApiController]
public class SchedulesController(IService<SchedulesDto, SchedulesFullDto> schedulesService) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех расписаний
    /// </summary>
    /// <returns>Список расписаний</returns>
    [HttpGet]
    public ActionResult<IEnumerable<SchedulesFullDto>> Get()
    {
        return Ok(schedulesService.GetAll());
    }

    /// <summary>
    /// Возвращает расписание по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор расписания</param>
    /// <returns>Расписание или "Не найдено"</returns>
    [HttpGet("{id}")]
    public ActionResult<SchedulesFullDto> Get(int id)
    {
        var result = schedulesService.GetById(id);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Добавляет новое расписание 
    /// </summary>
    /// <param name="value">Информация о новом расписании</param>
    /// <returns>Добавленное расписание или "Плохой запрос"</returns>
    [HttpPost]
    public ActionResult<SchedulesFullDto> Post([FromBody] SchedulesDto value)
    {
        var result = schedulesService.Post(value);
        if (result == null)
            return BadRequest();

        return Ok(result);
    }

    /// <summary>
    /// Изменяет расписание по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор расписания</param>
    /// <param name="value">Обновлённая информация о расписании</param>
    /// <returns>Результат операции</returns>
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] SchedulesDto value)
    {
        var result = schedulesService.Put(id, value);
        if (!result)
            return BadRequest();

        return Ok();
    }

    /// <summary>
    /// Удаляет расписание по идентификатору 
    /// </summary>
    /// <param name="id">Идентификатор расписания</param>
    /// <returns>Результат операции</returns>
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var result = schedulesService.Delete(id);
        if (!result)
            return NotFound();

        return Ok();
    }
}
