using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H3WebshopProeveprojekt.Api.Database.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Name { get; set; }

        [Column(TypeName = "float")]
        public float Price { get; set; }

        [Column(TypeName = "tinyint")]
        public int DiscountPercentage { get; set; }

        [Column(TypeName = "int")]
        public int CategoryId { get; set; }

        [Column(TypeName ="nvarchar(30)")]
        public string ProductImage { get; set; }


        public Category Category { get; set; }
    }
}
