using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}

public class InventoryManager
{
    private List<Product> _products;

    public InventoryManager()
    {
        _products = new List<Product>();
        // Initialize with some sample data (in a real app, this would come from a database)
        _products.Add(new Product { ProductId = 1, Name = "Laptop", Category = "Electronics", Price = 1200.00m, Quantity = 10 });
        _products.Add(new Product { ProductId = 2, Name = "Mouse", Category = "Electronics", Price = 25.00m, Quantity = 50 });
    }

    public void AddProduct(Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product), "Product cannot be null.");
        }
        _products.Add(product);
        Console.WriteLine($"Product '{product.Name}' added to inventory.");
    }

    public Product GetProductById(int productId)
    {
        return _products.FirstOrDefault(p => p.ProductId == productId);
    }

    public void UpdateProductQuantity(int productId, int newQuantity)
    {
        Product product = GetProductById(productId);
        if (product != null)
        {
            product.Quantity = newQuantity;
            Console.WriteLine($"Quantity for '{product.Name}' updated to {newQuantity}.");
        }
        else
        {
            Console.WriteLine($"Product with ID {productId} not found.");
        }
    }

    public void RemoveProduct(int productId)
    {
        Product productToRemove = GetProductById(productId);
        if (productToRemove != null)
        {
            _products.Remove(productToRemove);
            Console.WriteLine($"Product '{productToRemove.Name}' removed from inventory.");
        }
        else
        {
            Console.WriteLine($"Product with ID {productId} not found.");
        }
    }

    public List<Product> GetAllProducts()
    {
        return new List<Product>(_products); // Return a copy to prevent external modification
    }

    public void DisplayInventory()
    {
        Console.WriteLine("\n--- Current Inventory ---");
        foreach (var product in _products)
        {
            Console.WriteLine($"ID: {product.ProductId}, Name: {product.Name}, Category: {product.Category}, Price: {product.Price:C}, Quantity: {product.Quantity}");
        }
        Console.WriteLine("-------------------------\n");
    }
}
