using System.ComponentModel.DataAnnotations;

namespace Stock.Domain.Entities;

public class BaseEntity : IBaseEntity
{
    public int Id { get; set; }
    [Required]
    public DateTime CreateTime { get; set; }
    public DateTime UpdateTime { get; set; }
}
