﻿namespace DapperNight.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
