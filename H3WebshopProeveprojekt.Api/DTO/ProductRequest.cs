﻿namespace H3WebshopProeveprojekt.Api.DTO
{
    public class ProductRequest
    {
        public string Name { get; set; }

        public float Price { get; set; }

        public int DiscountPercentage { get; set; }

        public string Category { get; set; }
    }
}