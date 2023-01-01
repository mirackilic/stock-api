namespace Stock.Domain.Entities;

public interface IBaseEntity
{
    int Id { get; set; }
    DateTime CreateTime { get; set; }
    DateTime UpdateTime { get; set; }
}

