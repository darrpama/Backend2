using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIV1.Models;
/// <summary>
/// Presents an Address object.
/// </summary>
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
    
    /// <summary>
    /// One address to many Clients.
    /// </summary>
    public List<Client> Clients { get; set; } = new List<Client>();
    
    /// <summary>
    /// One address to many Suppliers.
    /// </summary>
    public List<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
