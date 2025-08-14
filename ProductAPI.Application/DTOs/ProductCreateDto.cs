﻿namespace ProductAPI.Application.DTOs
{
    public class ProductCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
