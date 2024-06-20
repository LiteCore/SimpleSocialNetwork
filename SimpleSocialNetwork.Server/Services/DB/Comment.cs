using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SimpleSocialNetwork.Server.Services.DB
{
    public class Comment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; } = null!;
        [Required]
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        [Required]
        public int PostId { get; set; }
        public Post Post { get; set; } = null!;
    }
}
