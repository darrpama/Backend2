using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model;

public abstract class BaseModel
{
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
}