using System.ComponentModel.DataAnnotations;

namespace MapsterCard.AppDbContext.Entities;

public sealed class SystemCard : BaseEntity
{
    [MaxLength(16)]
    [MinLength(16)]
    public string CardNumber { get; set; }

    [MaxLength(3)]
    [MinLength(3)]
    public string CVV { get; set; }
    
    [MinLength(3)]
    public string CountryName { get; set; }
    
    public DateOnly CreatedAt { get; set; }
    public DateOnly Expire { get; set; }
}