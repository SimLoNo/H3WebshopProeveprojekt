using System.ComponentModel.DataAnnotations;

namespace H3WebshopProeveprojekt.Api.Database.Entities
{
    public class AccountRole
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
