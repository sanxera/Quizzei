﻿namespace QZI.Category.Domain.Dtos
{
    public class CategoryDto
    {
        public int IdCategory { get; set; }
        public string Name { get; set; }

        public CategoryDto(int idCategory, string name)
        {
            IdCategory = idCategory;
            Name = name;
        }
    }
}
