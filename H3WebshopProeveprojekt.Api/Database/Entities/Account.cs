using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H3WebshopProeveprojekt.Api.Database.Entities
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName="nvarchar(30)")]
        public string Username { get; set; }
        [Column(TypeName = "nvarchar(30)")]

        public string Password { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string UserFirstName { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string UserLastName { get; set; }
        [Column(TypeName = "int")]
        public int AccountRoleId { get; set; }


        public AccountRole AccountRole { get; set; }
    }

    
}
