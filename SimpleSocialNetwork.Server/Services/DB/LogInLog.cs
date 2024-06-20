using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleSocialNetwork.Server.Services.DB
{
    public class LogInLog
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime DateTime { get; set; } = DateTime.Now.ToUniversalTime();
        [Required]
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
