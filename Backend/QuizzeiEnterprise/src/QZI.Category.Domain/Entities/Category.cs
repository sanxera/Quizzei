using System;
using QZI.Category.Domain.Entities.Base;

namespace QZI.Category.Domain.Entities
{
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
}
