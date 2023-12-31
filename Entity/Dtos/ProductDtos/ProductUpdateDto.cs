﻿
namespace Entity.Dtos.ProductDtos
{
    public record ProductUpdateDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public bool StockStatus { get; init; }
    }
}
