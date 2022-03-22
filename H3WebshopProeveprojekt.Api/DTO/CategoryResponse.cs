using System.Collections.Generic;

namespace H3WebshopProeveprojekt.Api.DTO
{
    public class CategoryResponse
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<CategoryProductResponse> Products { get; set; }


    }

    public class CategoryProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int DiscountPercentage { get; set; }
        public int CategoryId { get; set; }
        public string ProductImage { get; set; }
    }
}
