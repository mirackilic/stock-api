using System.ComponentModel.DataAnnotations;

namespace Stock.Domain.Entities;

public class Stocks : BaseEntity
{
    [Required]
    public string VariantCode { get; set; }
    [Required]
    public char ProductCode { get; set; }
    [Required]
    public int Quantity { get; set; }
}
