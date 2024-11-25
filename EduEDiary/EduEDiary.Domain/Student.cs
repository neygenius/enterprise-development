namespace EduEDiary.Domain;

public class Student
{
    /// <summary>
    /// Идентификатор учащегося
    /// </summary>
    public required int Id { get; set; }
    /// <summary>
    /// Серия и номер паспорта учащегося
    /// </summary>
    public required string Passport { get; set; }
    /// <summary>
    /// ФИО учащегося
    /// </summary>
    public required string FullName { get; set; }
    /// <summary>
    /// Дата рождения учащегося
    /// </summary>
    public required DateOnly BirthDate { get; set; }
    /// <summary>
    /// Класс учащегося
    /// </summary>
    public required Class Class { get; set; }
}