using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APIV1.Models;
/// <summary>
/// Presents an Address object.
/// </summary>
[Owned]
public class Address : BaseModel
{
    /// <summary>
    /// Country of address.
    /// </summary>
    [Column("country")]
    [MaxLength(100)]
    public string Country { get; set; } = "";

    /// <summary>
    /// City of address.
    /// </summary>
    [Column("city")]
    [MaxLength(100)]
    public string City { get; set; } = "";

    /// <summary>
    /// Street of address.
    /// </summary>
    [Column("street")]
    [MaxLength(100)]
    public string Street { get; set; } = "";
    
    private Guid ClientId { get; set; }
    [ForeignKey("ClientId")]
    private Client? Client { get; set; } = null!;
    
    private Guid SupplierId { get; set; }
    [ForeignKey("SupplierId")]
    private Supplier? Supplier { get; set; } = null!;
}
