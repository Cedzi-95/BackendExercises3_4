public class ProductService
{
    public Product CreateProduct( string name, double price, double amount, string category)
    {
        //validate name, atleast 5 character
        if (string.IsNullOrEmpty(name) || name.Length < 5)
        {
            throw new ProductValidationException("Product name must be atleast 5 characters!");
        }
         // Validate amount (must be greater than 0)
        if (amount <= 0)
        {
            throw new ProductValidationException("Amount must be greater than 0.");
        }

        // Validate price (must be 0 or greater)
        if (price < 0)
        {
            throw new ProductValidationException("Price cannot be negative.");
        }

        return new Product(name, price, amount, category);
    }
}



public class Product
{
    public Guid Id { get; set; }
     public string Name { get; set; }
    public double Price { get; set; }
    public double Amount { get; set; }
    public string Category { get; set; }

    public Product(string name, double price, double amount, string category)
    {
        this.Name = name;
        this.Price = price;
        this.Amount = amount;
        this.Category = category;
    }

}

//product model class
public class ProductDto
{
    public string Name { get; set; }
    public double Price { get; set; }
    public double Amount { get; set; }
    public string Category { get; set; }

// Default parameterless constructor for deserialization
    public ProductDto() {}

    //Constuctor for converting from product to productDTO
    public ProductDto(Product product)
    {
        Name = product.Name;
        Price = product.Price;
        Amount = product.Amount;
        Category = product.Category;
    }

}


public class ProductValidationException : Exception
{
    public ProductValidationException(string message) : base (message) {}
}