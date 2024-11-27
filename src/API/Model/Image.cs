using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model;

public class Image : BaseModel
{
    [Column("image")]
    public byte[] ByteImage { get; set; }
}

