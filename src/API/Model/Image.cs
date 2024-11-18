using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model;

public class Images
{
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Column("image")]
    public byte[] Image { get; set; }
}

