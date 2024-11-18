using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model;

public class Supplier
{
    [Column("id")]
    public Guid Id { get; set; }
    [Column("name")]
    public string Name { get; set; } = "";
    [Column("address_id")]
    public Guid AddressId { get; set; }
    [Column("phone_number")]
    public string PhoneNumber { get; set; } = "";
}


