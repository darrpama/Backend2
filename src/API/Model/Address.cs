using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model;

public class Address
{
    [Column("id")]
    public Guid Id { get; set; }
    [Column("country")]
    public string Country { get; set; }
    [Column("city")]
    public string City { get; set; }
    [Column("street")]
    public string Street { get; set; }
}
