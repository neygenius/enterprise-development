namespace EduEDiary.Domain;

public class Grade
{
    /// <summary>
    /// Идентификатор оценки
    /// </summary>
    public required int Id { get; set; }
    /// <summary>
    /// Учащийся, получивший оценку
    /// </summary>
    public required Student Student { get; set; }
    /// <summary>
    /// Предмет, по которому получена оценка
    /// </summary>
    public required Subject Subject { get; set; }
    /// <summary>
    /// Оценка по предмету
    /// </summary>
    public required int GradeValue { get; set; }
    /// <summary>
    /// Дата получения оценки
    /// </summary>
    public required DateOnly Date { get; set; }
}