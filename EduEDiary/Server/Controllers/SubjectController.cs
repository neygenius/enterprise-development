using AutoMapper;
using EduEDiary.Domain;
using EduEDiary.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Server.DTO;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubjectController(IRepository<Subject> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех предметов
    /// </summary>
    /// <returns>Список всех предметов и http status</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Subject>> Get()
    {
        return Ok(repository.GetAll());
    }

    /// <summary>
    /// Возвращает предмет по указанному идентификатору
    /// </summary>
    /// <param name="id">Идентификатор предмета</param>
    /// <returns>Предмет и http status</returns>
    [HttpGet("{id}")]
    public ActionResult<Subject> Get(int id)
    {
        var subject = repository.Get(id);

        if (subject == null)
            return NotFound();

        return Ok(subject);
    }

    /// <summary>
    /// Добавить предмет с указанным идентификатором в коллекцию
    /// </summary>
    /// <param name="value">Экземпляр, добавляемый в коллекцию</param>
    [HttpPost]
    public IActionResult Post([FromBody] SubjectDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var subject = mapper.Map<Subject>(value);
        repository.Post(subject);

        return Ok();
    }

    /// <summary>
    /// Заменяет предмет с указанным идентификатором в коллекцию
    /// </summary>
    /// <param name="id">Идентификатор предмета</param>
    /// <param name="value">Экземпляр, заменяющий старый экземпляр в коллекции</param>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] SubjectDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var subject = mapper.Map<Subject>(value);
        subject.Id = id;

        if (!repository.Put(subject, id))
            return NotFound();

        return Ok();
    }

    /// <summary>
    /// Удаляет предмет с указанным идентификатором из коллекции
    /// </summary>
    /// <param name="id">Идентификатор предмета</param>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!repository.Delete(id))
            return NotFound();

        return Ok();
    }
}