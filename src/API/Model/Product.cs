using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model;

public class Product : BaseModel
{
    [Column("name")]
    public string Name { get; set; } = "";
    
    [Column("category")]
    public string Category { get; set; } = "";
    
    [Column("price")]
    public double Price { get; set; }
    
    [Column("available_stock")]
    public int AvailableStock { get; set; }
    
    [Column("last_update_date")]
    public DateTime LastUpdateDate { get; set; }
    
    [Column("supplier_id")]
    public Guid SupplierId { get; set; }
    
    [Column("image_id")]
    public Guid ImageId { get; set; }
}

