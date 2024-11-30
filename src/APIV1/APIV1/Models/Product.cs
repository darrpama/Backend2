using System.ComponentModel.DataAnnotations.Schema;

namespace APIV1.Models;
/// <summary>
/// Presents a Client object.
/// </summary>
public class Product : BaseModel
{
    /// <summary>
    /// Product name.
    /// </summary>
    [Column("name")]
    public string Name { get; set; } = "";

    /// <summary>
    /// Product category.
    /// </summary>
    [Column("category")]
    public string Category { get; set; } = "";

    /// <summary>
    /// Product price.
    /// </summary>
    [Column("price")]
    public double Price { get; set; }

    /// <summary>
    /// Product available value.
    /// </summary>
    [Column("available_stock")]
    public int AvailableStock { get; set; }

    /// <summary>
    /// Product last update date.
    /// </summary>
    [Column("last_update_date")]
    public DateTimeOffset LastUpdateDate { get; set; }

    /// <summary>
    /// Id of a supplier of current product.
    /// </summary>
    [Column("supplier_id")]
    public Guid SupplierId { get; set; }

    /// <summary>
    /// Id of an Image of current product.
    /// </summary>
    [Column("image_id")]
    public Guid ImageId { get; set; }
}

