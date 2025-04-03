using System.Text;

public class Order : IComparable<Order>
{
    public string OrderId { get; set; }
    public Customer Customer { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }

    public Order Clone() => new Order
    {
        OrderId = OrderId,
        Customer = Customer,
        OrderDate = OrderDate,
        OrderDetails = OrderDetails.Select(od => od.Clone()).ToList()
    };
    // 添加无参构造函数
    public Order()
    {
        OrderDetails = new List<OrderDetail>();
    }
    public Order(string orderId, Customer customer, DateTime orderDate)
    {
        OrderId = orderId;
        Customer = customer;
        OrderDate = orderDate;
        OrderDetails = new List<OrderDetail>();
    }

    public decimal TotalAmount => OrderDetails.Sum(od => od.TotalAmount);

    public void AddOrderDetail(OrderDetail orderDetail)
    {
        if (OrderDetails.Contains(orderDetail))
        {
            throw new ArgumentException("Order detail already exists for this product.");
        }
        OrderDetails.Add(orderDetail);
    }

    public void RemoveOrderDetail(Product product)
    {
        var detail = OrderDetails.FirstOrDefault(od => od.Product.Equals(product));
        if (detail != null)
        {
            OrderDetails.Remove(detail);
        }
        else
        {
            throw new ArgumentException("Product not found in order details.");
        }
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Order other = (Order)obj;
        return OrderId == other.OrderId;
    }

    public override int GetHashCode()
    {
        return OrderId.GetHashCode();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Order ID: {OrderId}");
        sb.AppendLine($"Customer: {Customer}");
        sb.AppendLine($"Order Date: {OrderDate:yyyy-MM-dd}");
        sb.AppendLine("Order Details:");
        foreach (var detail in OrderDetails)
        {
            sb.AppendLine($"  {detail}");
        }
        sb.AppendLine($"Total Amount: {TotalAmount:C}");
        return sb.ToString();
    }

    public int CompareTo(Order other)
    {
        return OrderId.CompareTo(other.OrderId);
    }
}