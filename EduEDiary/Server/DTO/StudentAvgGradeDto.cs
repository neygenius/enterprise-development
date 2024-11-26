namespace Server.DTO;

public class StudentAvgGradeDto
{
    /// <summary>
    /// Идентификатор учащегося, что получил оценку
    /// </summary>
    public required int StudentId { get; set; }
    /// <summary>
    /// Имя учащегося
    /// </summary>
    public required string FullName { get; set; }
    /// <summary>
    /// Средняя оценка учащегося
    /// </summary>
    public double AvgGrade { get; set; }
}
