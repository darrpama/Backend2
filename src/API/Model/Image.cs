using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model;

public class Images
{
    [Column("id")]
    public Guid Id { get; set; }
    [Column("image")]
    public byte[] Image { get; set; }
}

