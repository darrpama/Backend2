using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model;

public class Images : BaseModel
{
    [Column("image")]
    public byte[] Image { get; set; } = [];
}

