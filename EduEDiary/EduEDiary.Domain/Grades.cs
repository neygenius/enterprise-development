namespace EduEDiary.Domain;

public class Grades
{
    /// <summary>
    /// Идентификатор оценки
    /// </summary>
    public required int Id { get; set; }
    /// <summary>
    /// Студент, получивший оценку
    /// </summary>
    public required Students Student { get; set; }
    /// <summary>
    /// Предмет, по которому получена оценка
    /// </summary>
    public required Subjects Subject { get; set; }
    /// <summary>
    /// Оценка по предмету
    /// </summary>
    public required int Grade { get; set; }
    /// <summary>
    /// Дата полученияоценки
    /// </summary>
    public required DateOnly Date { get; set; }
}