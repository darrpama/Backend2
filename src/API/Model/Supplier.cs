using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model;

public class Supplier : BaseModel
{
    [Column("name")]
    [MaxLength(100)]
    public string Name { get; set; } = "";

    [Column("address_id")]
    public Guid AddressId { get; set; }
    
    [Column("phone_number")]
    [MaxLength(100)]
    public string PhoneNumber { get; set; } = "";
}


