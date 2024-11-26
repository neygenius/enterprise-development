namespace Server.DTO;

public class StudentGradeDto
{
    /// <summary>
    /// Идентификатор учащегося, что получил оценку
    /// </summary>
    public int StudentId { get; set; }
    /// <summary>
    /// Имя учащегося
    /// </summary>
    public required string FullName { get; set; }
    /// <summary>
    /// Название предмета, по которому получена оценка
    /// </summary>
    public required string Subject { get; set; }
    /// <summary>
    /// Оценка учащегося
    /// </summary>
    public int GradeValue { get; set; }
    /// <summary>
    /// День, когда получена оценка
    /// </summary>
    public DateOnly Date { get; set; }
}
