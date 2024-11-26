using System.ComponentModel.DataAnnotations;

namespace Server.DTO;

public class ClassDto
{
    /// <summary>
    /// Номер класса
    /// </summary>
    [Range(1, 11)]
    public required int Number { get; set; }
    /// <summary>
    /// Литера
    /// </summary>
    [StringLength(2, MinimumLength = 1)]
    public required string Letter { get; set; }
}