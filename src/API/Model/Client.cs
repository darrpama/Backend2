using System.ComponentModel.DataAnnotations.Schema;
public class Client
{
    [Column("id")]
    public Guid Id { get; set; }
    [Column("client_name")]
    public string ClientName { get; set; } = "";
    [Column("client_surname")]
    public string ClientSurname { get; set; } = "";
    [Column("birthday")]
    public DateTime Birthday { get; set; }
    [Column("gender")]
    public string Gender { get; set; } = "";
    [Column("registration_date")]
    public DateTime RegistrationDate { get; set; }
    [Column("address_id")]
    public Guid AddressId { get; set; }
}