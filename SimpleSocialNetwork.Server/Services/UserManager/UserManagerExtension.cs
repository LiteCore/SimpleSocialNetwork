using Microsoft.Extensions.Options;
using SimpleSocialNetwork.Server.Services.DB;

namespace SimpleSocialNetwork.Server.Services.UserManager
{
    public class UserManagerOptions
    {

    }
    public static class UserManagerExtension
    {
        public static IServiceCollection AddUserManager(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddSingleton<UserManager>(sp =>
            {
                using (var scope = sp.CreateScope())
                {
                    var options = scope.ServiceProvider.GetRequiredService<IOptions<UserManagerOptions>>();
                    var db = scope.ServiceProvider.GetRequiredService<SocialNetworkDBContext>();
                    return new UserManager(db, options.Value);
                }
            });
        }
    }
}
