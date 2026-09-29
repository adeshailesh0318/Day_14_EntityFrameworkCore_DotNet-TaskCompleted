
using Microsoft.EntityFrameworkCore;
using System;

public class ProductDBContext:DbContext
{

    public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options)
    {
    }


    public DbSet<Category> Categories { get; set; }

    public DbSet<Product> Products { get; set; }

}
