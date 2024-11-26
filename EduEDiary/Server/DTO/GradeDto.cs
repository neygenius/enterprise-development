namespace Server.DTO;

public class GradeDto
{
    /// <summary>
    /// Идентификатор учащегося, что получил оценку
    /// </summary>
    public required int StudentId { get; set; }
    /// <summary>
    /// Идентификатор предмета, по которому получена оценка
    /// </summary>
    public required int SubjectId { get; set; }
    /// <summary>
    /// Оценка по предмету
    /// </summary>
    public required int GradeValue { get; set; }
    /// <summary>
    /// Дата получения оценки
    /// </summary>
    public required DateOnly Date { get; set; }
}
