using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model;

public class Client
{
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Column("client_name")]
    public string ClientName { get; set; } = "";
    [Column("client_surname")]
    public string ClientSurname { get; set; } = "";
    [Column("birthday")]
    public DateTimeOffset Birthday { get; set; }
    [Column("gender")]
    public string Gender { get; set; } = "";
    [Column("registration_date")]
    public DateTimeOffset RegistrationDate { get; set; }
    [Column("address_id")]
    public Guid AddressId { get; set; }
}
