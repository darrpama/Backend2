using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;
/// <summary>
/// Presents a BaseModel object.
/// </summary>
public abstract class BaseModel
{
    /// <summary>
    /// An unique Id.
    /// </summary>
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
}