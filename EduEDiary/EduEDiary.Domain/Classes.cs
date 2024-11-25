namespace EduEDiary.Domain;

public class Classes
{
    /// <summary>
    /// Идентификатор класса
    /// </summary>
    public required int Id { get; set; }
    /// <summary>
    /// Номер класса
    /// </summary>
    public required int Number { get; set; }
    /// <summary>
    /// Литера класса
    /// </summary>
    public required string Letter { get; set; }
}