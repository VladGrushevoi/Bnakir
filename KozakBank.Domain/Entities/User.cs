using System.ComponentModel.DataAnnotations;
using KozakBank.Domain.Common;

namespace KozakBank.Domain.Entities;

public class User : BaseEntity
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Surname { get; set; }
    [Required]
    [RegularExpression("\\d{5,20}")]
    public string Phone { get; set; }
    [Required]
    public string Country { get; set; }

    public virtual ICollection<KisaCard>? KisaCards { get; set; }
    public virtual ICollection<MapsterCard>? MapsterCards { get; set; }

}