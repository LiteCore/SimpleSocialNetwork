using Microsoft.EntityFrameworkCore;

namespace SimpleSocialNetwork.Server.Services.DB
{
    public class SocialNetworkDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<LogInLog> LogInLogs { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public SocialNetworkDBContext(DbContextOptions<SocialNetworkDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
