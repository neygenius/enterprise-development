using AutoMapper;
using EduEDiary.Domain;
using EduEDiary.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Server.DTO;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GradeController(IRepository<Grade> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех оценок
    /// </summary>
    /// <returns>Список всех оценок и http status</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Grade>> Get()
    {
        return Ok(repository.GetAll());
    }

    /// <summary>
    /// Возвращает оценку по указанному идентификатору
    /// </summary>
    /// <param name="id">Идентификатор оценки</param>
    /// <returns>Оценка и http status</returns>
    [HttpGet("{id}")]
    public ActionResult<Grade> Get(int id)
    {
        var grade = repository.Get(id);

        if (grade == null)
            return NotFound();

        return Ok(grade);
    }

    /// <summary>
    /// Добавляет оценку с указанным идентификатором в коллекцию
    /// </summary>
    /// <param name="value">Экземпляр, добавляемый в коллекцию</param>
    [HttpPost]
    public IActionResult Post([FromBody] GradeDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var grade = mapper.Map<Grade>(value);
        repository.Post(grade);

        return Ok();
    }

    /// <summary>
    /// Заменяет оценку с указанным идентификатором в коллекцию
    /// </summary>
    /// <param name="id">Идентификатор оценки</param>
    /// <param name="value">Экземпляр, заменяющий старый экземпляр в коллекции</param>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] GradeDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var grade = mapper.Map<Grade>(value);
        grade.Id = id;

        if (!repository.Put(grade, id))
            return NotFound();

        return Ok();
    }

    /// <summary>
    /// Удаляет оценку с указанным идентификатором из коллекции
    /// </summary>
    /// <param name="id">Идентификатор оценки</param>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!repository.Delete(id))
            return NotFound();

        return Ok();
    }
}
