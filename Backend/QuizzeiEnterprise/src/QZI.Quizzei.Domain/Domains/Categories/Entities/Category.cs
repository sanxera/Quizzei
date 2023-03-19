using System;
using QZI.Quizzei.Domain.Abstractions;

namespace QZI.Quizzei.Domain.Domains.Categories.Entities;

public class Category : Entity
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool Active { get; set; }

    public static Category CreateQuizCategory(string name)
    {
        return new Category
        {
            Description = name,
            Active = true,
            CreatedAt = DateTime.Now,
            CreatedBy = "Admin"
        };
    }
}