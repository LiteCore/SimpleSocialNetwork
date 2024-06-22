namespace SimpleSocialNetwork.Server.Models.DTO
{
    public class User(Services.DB.User user)
    {
        public string UserName { get; set; } = user.UserName;
        public string Password { get; set; }
    }
}
