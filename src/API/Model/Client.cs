using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model;

public class Client : BaseModel
{
    [Column("client_name")]
    [MaxLength(100)]
    public string ClientName { get; set; } = "";
    
    [Column("client_surname")]
    [MaxLength(100)]
    public string ClientSurname { get; set; } = "";
    
    [Column("birthday")]
    public DateTimeOffset Birthday { get; set; }
    
    [Column("gender")]
    [MaxLength(100)]
    public string Gender { get; set; } = "";
    
    [Column("registration_date")]
    public DateTimeOffset RegistrationDate { get; set; }
    
    [Column("address_id")]
    public Guid AddressId { get; set; }
}
