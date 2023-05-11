using System.ComponentModel.DataAnnotations;

namespace KozakBank.Application.Common.UseCardSystem.Models.Request;

public sealed record CreateCardRequest
{
    [Required]
    [RegularExpression("\\w{3,20}")]
    public string CountryName { get; set; }
    [Required]
    [StringLength(4)]
    public string BankIdentifier { get; set; }
}