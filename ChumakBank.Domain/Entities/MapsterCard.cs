using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using ChumakBank.Domain.Common;

namespace ChumakBank.Domain.Entities;

public class MapsterCard : BaseEntity
{
    public Guid CardIdFromSystem { get; set; }
    
    [DefaultValue(0)]
    public float Balance { get; set; }

    [ForeignKey("User")]
    public User User { get; set; }
}