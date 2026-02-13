using System;
using System.Collections.Generic;

namespace NutrientCalculator.Models
{

    public class ProductEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string State { get; set; } = string.Empty;

        // Вместо словаря — коллекция join-entity
        public ICollection<ProductNutrientEntity> ProductNutrients { get; set; } = [];

        public string? CategoryType { get; set; }
    }
}
