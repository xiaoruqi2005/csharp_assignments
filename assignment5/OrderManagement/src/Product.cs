public class Product
{
    public string ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product() { } // 无参构造函数
    public Product(string productId, string name, decimal price)
    {
        ProductId = productId;
        Name = name;
        Price = price;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Product other = (Product)obj;
        return ProductId == other.ProductId;
    }

    public override int GetHashCode()
    {
        return ProductId.GetHashCode();
    }

    public override string ToString()
    {
        return $"Product ID: {ProductId}, Name: {Name}, Price: {Price:C}";
    }
}