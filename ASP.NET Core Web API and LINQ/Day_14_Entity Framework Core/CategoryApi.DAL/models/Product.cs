

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{

    [Key]
    public int ProductId { get; set; }

    [Required]
    public string ProductName { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

   
    public int CategoryId { get; set; }

    
    [ForeignKey("CategoryId")]
    public Category Category { get; set; }

}
