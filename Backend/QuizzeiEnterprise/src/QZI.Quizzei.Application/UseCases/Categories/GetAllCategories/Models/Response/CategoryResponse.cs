﻿namespace QZI.Quizzei.Application.UseCases.Categories.GetAllCategories.Models.Response;

public class CategoryResponse
{
    public int IdCategory { get; set; }
    public string Name { get; set; }

    public CategoryResponse(int idCategory, string name)
    {
        IdCategory = idCategory;
        Name = name;
    }
}