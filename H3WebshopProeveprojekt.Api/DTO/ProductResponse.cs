using H3WebshopProeveprojekt.Api.Database.Entities;

namespace H3WebshopProeveprojekt.Api.DTO
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public float Price { get; set; }

        public int DiscountPercentage { get; set; }

        public int CategoryId { get; set; }
        public string ProductImage { get; set; }

        public ProductCategoryResponse Category { get; set; }
    }

    public class ProductCategoryResponse
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
