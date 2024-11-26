namespace Server.DTO;

public class GradeStatisticsDto
{
    /// <summary>
    /// Название предмета
    /// </summary>
    public required string Subject { get; set; }
    /// <summary>
    /// Минимальная оценка по предмету
    /// </summary>
    public int MinGrade { get; set; }
    /// <summary>
    /// Максимальная оценка по предмету
    /// </summary>
    public int MaxGrade { get; set; }
    /// <summary>
    /// Средняя оценка по предмету
    /// </summary>
    public double AvgGrade { get; set; }
}
