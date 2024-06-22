using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleSocialNetwork.Server.Services.DB
{
    public class ProfilePic
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public byte[] Picture { get; set; } = null!;
        [Required]
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
