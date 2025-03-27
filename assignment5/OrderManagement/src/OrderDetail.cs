public class OrderDetail
{
    public Product Product { get; set; }
    public int Quantity { get; set; }

    public OrderDetail() { } // 无参构造函数
    public OrderDetail(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    public decimal TotalAmount => Product.Price * Quantity;

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        OrderDetail other = (OrderDetail)obj;
        return Product.Equals(other.Product);
    }

    public override int GetHashCode()
    {
        return Product.GetHashCode();
    }

    public override string ToString()
    {
        return $"{Product} x {Quantity} = {TotalAmount:C}";
    }
}