using EduEDiary.Domain;
using EduEDiary.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Server.DTO;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QueryController(IRepository<Student> studentRepository, IRepository<Subject> subjectRepository, IRepository<Grade> gradeRepository) : ControllerBase
{
    /// <summary>
    /// Запрос 1: Вывести информацию обо всех предметах
    /// </summary>
    [HttpGet("all_subjects")]
    public ActionResult<IEnumerable<Subject>> GetAllSubjects()
    {
        var subjects = subjectRepository.GetAll().ToList();
        return Ok(subjects);
    }

    /// <summary>
    /// Запрос 2: Вывести информацию обо всех учениках в указанном классе, упорядочить по ФИО
    /// </summary>
    /// <param name="classId">Идентификатор класса</param>
    [HttpGet("all_students_in_selected_class")]
    public ActionResult<IEnumerable<Student>> GetAllStudentsInSelectedClass(int classId)
    {
        var students = studentRepository.GetAll()
            .Where(s => s.Class.Id == classId)
            .OrderBy(s => s.FullName)
            .ToList();

        return Ok(students);
    }

    /// <summary>
    /// Запрос 3: Вывести информацию обо всех учениках, получивших оценки в указанный день
    /// </summary>
    /// <param name="day">Дата получения оценки</param>
    [HttpGet("all_students_that_get_grade_in_selected_day")]
    public ActionResult<IEnumerable<StudentGradeDto>> GetAllStudentsThatGetGradeInSelectedDay(DateOnly day)
    {
        var students = gradeRepository.GetAll()
            .Where(g => g.Date == day)
            .Select(g => new StudentGradeDto
            {
                StudentId = g.Student.Id,
                FullName = g.Student.FullName,
                Subject = g.Subject.Name,
                GradeValue = g.GradeValue,
                Date = g.Date
            })
            .ToList();

        return Ok(students);
    }

    /// <summary>
    /// Запрос 4: Вывести топ 5 учеников по среднему баллу
    /// </summary>
    [HttpGet("top_five_students_for_avg_grade")]
    public ActionResult<IEnumerable<StudentAvgGradeDto>> GetTopFiveStudentsForAvgGrade()
    {
        var students = studentRepository.GetAll()
            .Select(s => new StudentAvgGradeDto
            {
                StudentId = s.Id,
                FullName = s.FullName,
                AvgGrade = gradeRepository.GetAll()
                    .Where(g => g.Student.Id == s.Id)
                    .Average(g => g.GradeValue)
            })
            .OrderByDescending(s => s.AvgGrade)
            .Take(5)
            .ToList();

        return Ok(students);
    }

    /// <summary>
    /// Запрос 5: Вывести учеников с максимальным средним баллом за указанный период
    /// </summary>
    /// <param name="start">Начало периода</param>
    /// <param name="end">Конец периода</param>
    [HttpGet("students_with_max_avg_grade_for_time_span")]
    public ActionResult<IEnumerable<StudentAvgGradeDto>> GetStudentsWithMaxAvgGradeForTimeSpan(DateOnly start, DateOnly end)
    {
        var sGrades = studentRepository.GetAll()
            .Select(s => new
            {
                Student = s,
                AvgGrade = gradeRepository.GetAll()
                    .Where(g => g.Student.Id == s.Id && g.Date >= start && g.Date <= end)
                    .Average(g => g.GradeValue)
            })
            .ToList();

        var maxAvgGrade = sGrades.Max(a => a.AvgGrade);

        var students = sGrades
            .Where(a => a.AvgGrade == maxAvgGrade)
            .Select(a => new StudentAvgGradeDto
            {
                StudentId = a.Student.Id,
                FullName = a.Student.FullName,
                AvgGrade = a.AvgGrade
            })
            .ToList();

        return Ok(students);
    }

    /// <summary>
    /// Запрос 6: Вывести информацию о минимальном, среднем и максимальном балле по каждому предмету
    /// </summary>
    [HttpGet("min_avg_max_grade_for_each_subject")]
    public ActionResult<IEnumerable<GradeStatisticsDto>> GetMinAvgMaxGradeForEachSubject()
    {
        var statistics = subjectRepository.GetAll()
            .Select(s => new GradeStatisticsDto
            {
                Subject = s.Name,
                MinGrade = gradeRepository.GetAll()
                    .Where(g => g.Subject.Id == s.Id)
                    .Min(g => g.GradeValue),
                MaxGrade = gradeRepository.GetAll()
                    .Where(g => g.Subject.Id == s.Id)
                    .Max(g => g.GradeValue),
                AvgGrade = gradeRepository.GetAll()
                    .Where(g => g.Subject.Id == s.Id)
                    .Average(g => g.GradeValue)
            })
            .ToList();

        return Ok(statistics);
    }
}
