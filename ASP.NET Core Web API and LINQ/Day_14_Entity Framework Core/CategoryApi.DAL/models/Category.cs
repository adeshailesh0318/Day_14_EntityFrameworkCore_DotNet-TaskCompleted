using System.ComponentModel.DataAnnotations;

public class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required]
    public string CategoryName { get; set; }

    // One Category has many Products
    public ICollection<Product> Products { get; set; }
        = new List<Product>();
}