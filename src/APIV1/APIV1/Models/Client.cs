using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIV1.Models;

/// <summary>
/// Presents a Client object.
/// </summary>
public class Client : BaseModel
{
    /// <summary>
    /// Client name.
    /// </summary>
    [MaxLength(100)]
    [Column("client_name")]
    public string ClientName { get; set; } = "";
    
    /// <summary>
    /// Client surname.
    /// </summary>
    [MaxLength(100)]
    [Column("client_surname")]
    public string ClientSurname { get; set; } = "";
    
    /// <summary>
    /// Client birthday.
    /// </summary>
    [Column("birthday")]
    public DateTimeOffset Birthday { get; set; }
    
    /// <summary>
    /// Client gender.
    /// </summary>
    [MaxLength(100)]
    [Column("gender")]
    public string Gender { get; set; } = "";
    
    /// <summary>
    /// Client registration date.
    /// </summary>
    [Column("registration_date")]
    public DateTimeOffset RegistrationDate { get; set; }
    
    /// <summary>
    /// Navigational property
    /// </summary>
    public Address? Address { get; set; }
}