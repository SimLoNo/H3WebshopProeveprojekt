using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H3WebshopProeveprojekt.Api.Database.Entities
{
    public class AccountRole
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName= "nvarchar(20)")]
        public string Name { get; set; }


        public List<Account> Accounts { get; set; }

    }
}
