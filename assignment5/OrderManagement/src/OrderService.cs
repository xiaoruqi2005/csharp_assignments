using System.Xml.Serialization;

public class OrderService
{
    private List<Order> orders = new List<Order>();

    // 添加订单
    public void AddOrder(Order order)
    {
        if (orders.Contains(order))
        {
            throw new ArgumentException("Order already exists.");
        }
        orders.Add(order);
    }

    // 删除订单
    public void RemoveOrder(string orderId)
    {
        var order = orders.FirstOrDefault(o => o.OrderId == orderId);
        if (order == null)
        {
            throw new ArgumentException($"Order with ID {orderId} not found.");
        }
        orders.Remove(order);
    }

    // 修改订单
    public void ModifyOrder(Order modifiedOrder)
    {
        var existingOrder = orders.FirstOrDefault(o => o.OrderId == modifiedOrder.OrderId);
        if (existingOrder == null)
        {
            throw new ArgumentException($"Order with ID {modifiedOrder.OrderId} not found.");
        }

        orders.Remove(existingOrder);
        orders.Add(modifiedOrder);
    }

    // 查询所有订单
    public List<Order> GetAllOrders()
    {
        return orders;
    }

    // 按订单号查询
    public List<Order> QueryByOrderId(string orderId)
    {
        return orders.Where(o => o.OrderId.Contains(orderId))
                    .OrderBy(o => o.TotalAmount)
                    .ToList();
    }

    // 按商品名称查询
    public List<Order> QueryByProductName(string productName)
    {
        return orders.Where(o => o.OrderDetails.Any(od =>
                        od.Product.Name.Contains(productName, StringComparison.OrdinalIgnoreCase)))
                    .OrderBy(o => o.TotalAmount)
                    .ToList();
    }

    // 按客户查询
    public List<Order> QueryByCustomer(string customerName)
    {
        return orders.Where(o => o.Customer.Name.Contains(customerName, StringComparison.OrdinalIgnoreCase))
                    .OrderBy(o => o.TotalAmount)
                    .ToList();
    }

    // 按金额范围查询
    public List<Order> QueryByAmountRange(decimal minAmount, decimal maxAmount)
    {
        return orders.Where(o => o.TotalAmount >= minAmount && o.TotalAmount <= maxAmount)
                    .OrderBy(o => o.TotalAmount)
                    .ToList();
    }

    // 排序方法
    public void SortOrders()
    {
        orders.Sort();
    }

    // 自定义排序
    public void SortOrders(Comparison<Order> comparison)
    {
        orders.Sort(comparison);
    }

    // 导出订单到文件
    public void ExportToFile(string filePath)
    {
        try
        {
            var serializer = new XmlSerializer(typeof(List<Order>));
            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, orders);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to export orders: " + ex.Message);
        }
    }

    // 从文件导入订单
    public void ImportFromFile(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found.", filePath);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                List<Order> importedOrders = (List<Order>)serializer.Deserialize(fs);
                orders = importedOrders;
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to import orders: " + ex.Message);
        }
    }
}