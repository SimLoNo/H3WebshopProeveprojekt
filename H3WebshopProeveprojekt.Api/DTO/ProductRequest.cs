namespace H3WebshopProeveprojekt.Api.DTO
{
    public class ProductRequest
    {
        public string Name { get; set; }

        public float Price { get; set; }

        public int DiscountPercentage { get; set; }

        public int CategoryId { get; set; }
        public string ProductImage { get; set; }
    }
}
