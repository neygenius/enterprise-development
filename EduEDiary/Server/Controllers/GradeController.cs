using AutoMapper;
using EduEDiary.Domain;
using EduEDiary.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Server.DTO;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GradeController(
    IRepository<Grade> repository,
    IRepository<Student> studentRepository,
    IRepository<Subject> subjectRepository,
    IMapper mapper
    ) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех оценок
    /// </summary>
    /// <returns>Список всех оценок и http status</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Grade>>> Get()
    {
        var grades = await repository.GetAll();

        return Ok(grades);
    }

    /// <summary>
    /// Возвращает оценку по указанному идентификатору
    /// </summary>
    /// <param name="id">Идентификатор оценки</param>
    /// <returns>Оценка и http status</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Grade>> Get(int id)
    {
        var grade = await repository.Get(id);
        if (grade == null)
            return NotFound();

        return Ok(grade);
    }

    /// <summary>
    /// Добавляет оценку с указанным идентификатором в коллекцию
    /// </summary>
    /// <param name="value">Экземпляр, добавляемый в коллекцию</param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] GradeDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var grade = mapper.Map<Grade>(value);
        var student = await studentRepository.Get(value.StudentId);
        if (student == null)
            return NotFound();

        var subject = await subjectRepository.Get(value.SubjectId);
        if (subject == null)
            return NotFound();

        grade.Student = student;
        grade.Subject = subject;
        await repository.Post(grade);

        return Ok();
    }

    /// <summary>
    /// Заменяет оценку с указанным идентификатором в коллекцию
    /// </summary>
    /// <param name="id">Идентификатор оценки</param>
    /// <param name="value">Экземпляр, заменяющий старый экземпляр в коллекции</param>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] GradeDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var checkGrade = await repository.Get(id);
        if (checkGrade == null)
            return NotFound();

        var grade = mapper.Map<Grade>(value);
        grade.Id = id;
        var student = await studentRepository.Get(value.StudentId);
        if (student == null)
            return NotFound();

        var subject = await subjectRepository.Get(value.SubjectId);
        if (subject == null)
            return NotFound();

        grade.Student = student;
        grade.Subject = subject;
        await repository.Put(grade, id);

        return Ok();
    }

    /// <summary>
    /// Удаляет оценку с указанным идентификатором из коллекции
    /// </summary>
    /// <param name="id">Идентификатор оценки</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var grade = await repository.Get(id);
        if (grade == null)
            return NotFound();

        await repository.Delete(id);

        return Ok();
    }
}
