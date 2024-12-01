using AutoMapper;
using EduEDiary.Domain;
using EduEDiary.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Server.DTO;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController(IRepository<Student> repository, IRepository<Class> classRepository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех студентов
    /// </summary>
    /// <returns>Список всех студентов и http status</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> Get()
    {
        var students = await repository.GetAll();

        return Ok(students);
    }

    /// <summary>
    /// Возвращает студента по указанному идентификатору
    /// </summary>
    /// <param name="id">Идентификатор студента</param>
    /// <returns>Студент и http status</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> Get(int id)
    {
        var student = await repository.Get(id);
        if (student == null)
            return NotFound();

        return Ok(student);
    }

    /// <summary>
    /// Добавляет студента с указанным идентификатором в коллекцию
    /// </summary>
    /// <param name="value">Экземпляр, добавляемый в коллекцию</param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] StudentDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var student = mapper.Map<Student>(value);
        var classValue = await classRepository.Get(value.ClassId);
        if (classValue == null)
            return NotFound();

        student.Class = classValue;
        await repository.Post(student);

        return Ok();
    }

    /// <summary>
    /// Заменяет студента с указанным идентификатором в коллекцию
    /// </summary>
    /// <param name="id">Идентификатор студента</param>
    /// <param name="value">Экземпляр, заменяющий старый экземпляр в коллекции</param>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] StudentDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var checkStudent = await repository.Get(id);
        if (checkStudent == null)
            return NotFound();

        var student = mapper.Map<Student>(value);
        student.Id = id;
        var classValue = await classRepository.Get(value.ClassId);
        if (classValue == null)
            return NotFound();

        student.Class = classValue;
        await repository.Put(student, id);

        return Ok();
    }

    /// <summary>
    /// Удаляет студента с указанным идентификатором из коллекции
    /// </summary>
    /// <param name="id">Идентификатор студента</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var student = await repository.Get(id);
        if (student == null)
            return NotFound();

        await repository.Delete(id);

        return Ok();
    }
}
