using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace H3WebshopProeveprojekt.Api.Database.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }
    }
}
