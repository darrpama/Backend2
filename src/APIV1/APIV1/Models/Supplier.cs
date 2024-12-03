using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIV1.Models;
/// <summary>
/// Presents a Supplier object.
/// </summary>
public class Supplier : BaseModel
{
    /// <summary>
    /// The name of supplier.
    /// </summary>
    [Column("name")]
    [MaxLength(100)]
    public string Name { get; set; } = "";

    /// <summary>
    /// The phone number of supplier.
    /// </summary>
    [Column("phone_number")]
    [MaxLength(100)]
    public string PhoneNumber { get; set; } = "";
    
    /// <summary>
    /// Navigational property
    /// </summary>
    [Required]
    public Address? Address { get; set; }
}


