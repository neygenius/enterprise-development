using AutoMapper;
using EduEDiary.Domain;
using EduEDiary.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Server.DTO;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassController(IRepository<Class> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех классов
    /// </summary>
    /// <returns>Список всех классов и http status</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Class>>> Get()
    {
        var classes = await repository.GetAll();

        return Ok(classes);
    }

    /// <summary>
    /// Возвращает класс по указанному идентификатору
    /// </summary>
    /// <param name="id">Идентификатор класса</param>
    /// <returns>Класс и http status</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Class>> Get(int id)
    {
        var classValue = await repository.Get(id);
        if (classValue == null)
            return NotFound();

        return Ok(classValue);
    }

    /// <summary>
    /// Добавляет класс с указанным идентификатором в коллекцию
    /// </summary>
    /// <param name="value">Экземпляр, добавляемый в коллекцию</param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ClassDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var classValue = mapper.Map<Class>(value);
        await repository.Post(classValue);

        return Ok();
    }

    /// <summary>
    /// Заменяет класс с указанным идентификатором в коллекции
    /// </summary>
    /// <param name="id">Идентификатор класса</param>
    /// <param name="value">Экземпляр, заменяющий старый экземпляр в коллекции</param>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ClassDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var checkClass = await repository.Get(id);
        if (checkClass == null)
            return NotFound();

        var classValue = mapper.Map<Class>(value);
        classValue.Id = id;
        await repository.Put(classValue, id);

        return Ok();
    }

    /// <summary>
    /// Удаляет класс с указанным идентификатором из коллекции
    /// </summary>
    /// <param name="id">Идентификатор класса</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var classValue = await repository.Get(id);
        if (classValue == null)
            return NotFound();

        await repository.Delete(id);

        return Ok();
    }
}
