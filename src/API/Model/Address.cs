using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model;

public class Address : BaseModel
{
    [Column("country")]
    [MaxLength(100)]
    public string Country { get; set; } = "";

    [Column("city")]
    [MaxLength(100)]
    public string City { get; set; } = "";

    [Column("street")]
    [MaxLength(100)]
    public string Street { get; set; } = "";
}
