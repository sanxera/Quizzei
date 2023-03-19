using System;

namespace QZI.Quizzei.Domain.Abstractions;

public abstract class Entity
{
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
}