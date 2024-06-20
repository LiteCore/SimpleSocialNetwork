using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleSocialNetwork.Server.Services.DB
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; } = null!;
        public byte[]? ProfilePic { get; set; } = null;
        [Required]
        public byte[] Password { get; set; } = null!;
        [Required]
        public byte[] Salt { get; set; } = null!;

        public ICollection<LogInLog> LogInLogs { get; } = new List<LogInLog>();
    }
}
