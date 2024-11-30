using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

/// <summary>
/// Presents an Image object.
/// </summary>
public class Image : BaseModel
{
    /// <summary>
    /// A raw Image array.
    /// </summary>
    [Column("image")]
    public byte[] ByteImage { get; set; }
}

