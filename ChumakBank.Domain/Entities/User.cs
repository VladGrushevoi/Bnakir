using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChumakBank.Domain.Common;

namespace ChumakBank.Domain.Entities;

public class User : BaseEntity
{
    [Required(ErrorMessage = "Name is required")]
    [Range(2, 50, ErrorMessage = "Name length must be greater then 2 chars and less then 50 chars")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Surname is required")]
    [Range(2, 50, ErrorMessage = "Surname length must be greater then 2 chars and less then 50 chars")]
    public string Surname { get; set; }
    
    [Required(ErrorMessage = "Country is required")]
    [Range(2, 50, ErrorMessage = "Country length must be greater then 2 chars and less then 50 chars")]
    public string Country { get; set; }
    
    [Required]
    public string Phone { get; set; }

    [ForeignKey("KisaCard")]
    public ICollection<KisaCard> KisaCards { get; set; }
    
    [ForeignKey("MapsterCard")]
    public ICollection<MapsterCard> MapsterCards { get; set; }
}