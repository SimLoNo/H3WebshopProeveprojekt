namespace H3WebshopProeveprojekt.Api.DTO
{
    public class AccountRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public int AccountRoleId { get; set; }
    }
}
