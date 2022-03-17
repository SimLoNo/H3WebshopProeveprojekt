namespace H3WebshopProeveprojekt.Api.DTO
{
    public class AccountResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public int AccountRoleId { get; set; }
        public AccountAccountRoleResponse AccountRole { get; set; }

    }

    public class AccountAccountRoleResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
