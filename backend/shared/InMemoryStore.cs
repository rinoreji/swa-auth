using System;
using System.Collections.Generic;
using System.Linq;

public class InMemoryStore
{
    private static List<Product> Products { get; set; } = new List<Product>{
                new Product{ Id=1, Description="An apple mobile which is nothing like apple", Quantity=1, Name="iPhone 9" }
                , new Product{ Id=2, Description="MacBook Pro 2021 with mini-LED display ", Quantity=1, Name="MacBook Pro" }
                , new Product{ Id=3, Description="Samsung's new variant which goes beyond Galaxy to the Universe", Quantity=1, Name="Samsung Universe 9" }
            };

    internal static List<Product> GetProducts()
    {
        return Products;
    }

    internal static Product AddProduct(Product p)
    {
        p.Id = Products.Count + 1;
        Products.Add(p);
        return p;
    }

    internal static Product UpdateProduct(int value, Product p)
    {
        var prod = Products.Where(p => p.Id == value).FirstOrDefault();
        if (prod != null)
        {
            prod.Description = p.Description;
            prod.Name = p.Name;
            prod.Quantity = p.Quantity;
            return prod;
        }

        return p;
    }

    internal static void DeleteProduct(int value)
    {
        var prod = Products.Where(p => p.Id == value).FirstOrDefault();
        if (prod != null)
        {
            Products.Remove(prod);
        }
    }
}