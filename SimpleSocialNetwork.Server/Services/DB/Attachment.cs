using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SimpleSocialNetwork.Server.Services.DB
{
    public class Attachment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public byte[] Content { get; set; } = null!;
        [Required]
        public Type Type { get; set; }
        [Required]
        public int PostId { get; set; }
        public Post Post { get; } = null!;
    }
    public enum Type
    {
        Png = 0,
        Jpeg = 1
    }
}
