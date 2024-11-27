using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model;

/// <summary>
/// Presents a Client object.
/// </summary>
public class Client : BaseModel
{
    /// <summary>
    /// Client name.
    /// </summary>
    [Column("client_name")]
    [MaxLength(100)]
    public string ClientName { get; set; } = "";
    
    /// <summary>
    /// Client surname.
    /// </summary>
    [Column("client_surname")]
    [MaxLength(100)]
    public string ClientSurname { get; set; } = "";
    
    /// <summary>
    /// Client birthday.
    /// </summary>
    [Column("birthday")]
    public DateTimeOffset Birthday { get; set; }
    
    /// <summary>
    /// Client gender.
    /// </summary>
    [Column("gender")]
    [MaxLength(100)]
    public string Gender { get; set; } = "";
    
    /// <summary>
    /// Client registration date.
    /// </summary>
    [Column("registration_date")]
    public DateTimeOffset RegistrationDate { get; set; }
    
    /// <summary>
    /// Client address id.
    /// </summary>
    [Column("address_id")]
    public Guid AddressId { get; set; }
}
