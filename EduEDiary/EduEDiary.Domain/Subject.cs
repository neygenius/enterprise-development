namespace EduEDiary.Domain;

public class Subject
{
    /// <summary>
    /// Идентификатор предмета
    /// </summary>
    public required int Id { get; set; }
    /// <summary>
    /// Название предмета
    /// </summary>
    public required string Name { get; set; }
    /// <summary>
    /// Год обучения предмету
    /// </summary>
    public required string Year { get; set; }
}
