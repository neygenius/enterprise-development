using System.ComponentModel.DataAnnotations;

namespace Server.DTO;

public class StudentDto
{
    /// <summary>
    /// Серия и номер паспорта учащегося
    /// </summary>
    [RegularExpression(@"\d{4}\s\d{6}")]
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
    /// Идентификатор класса учащегося
    /// </summary>
    public required int ClassId { get; set; }
}
