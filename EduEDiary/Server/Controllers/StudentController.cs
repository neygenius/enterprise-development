using AutoMapper;
using EduEDiary.Domain;
using EduEDiary.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Server.DTO;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController(IRepository<Student> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех студентов
    /// </summary>
    /// <returns>Список всех студентов и http status</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Student>> Get()
    {
        return Ok(repository.GetAll());
    }

    /// <summary>
    /// Возвращает студента по указанному идентификатору
    /// </summary>
    /// <param name="id">Идентификатор студента</param>
    /// <returns>Студент и http status</returns>
    [HttpGet("{id}")]
    public ActionResult<Student> Get(int id)
    {
        var student = repository.Get(id);

        if (student == null)
            return NotFound();

        return Ok(student);
    }

    /// <summary>
    /// Добавляет студента с указанным идентификатором в коллекцию
    /// </summary>
    /// <param name="value">Экземпляр, добавляемый в коллекцию</param>
    [HttpPost]
    public IActionResult Post([FromBody] StudentDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var student = mapper.Map<Student>(value);
        repository.Post(student);

        return Ok();
    }

    /// <summary>
    /// Заменяет студента с указанным идентификатором в коллекцию
    /// </summary>
    /// <param name="id">Идентификатор студента</param>
    /// <param name="value">Экземпляр, заменяющий старый экземпляр в коллекции</param>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] StudentDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var student = mapper.Map<Student>(value);
        student.Id = id;

        if (!repository.Put(student, id))
            return NotFound();

        return Ok();
    }

    /// <summary>
    /// Удаляет студента с указанным идентификатором из коллекции
    /// </summary>
    /// <param name="id">Идентификатор студента</param>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!repository.Delete(id))
            return NotFound();

        return Ok();
    }
}

