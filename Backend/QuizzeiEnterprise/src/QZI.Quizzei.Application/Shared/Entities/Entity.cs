namespace QZI.Quizzei.Application.Shared.Entities;

public abstract class Entity
{
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; } = null!;
}