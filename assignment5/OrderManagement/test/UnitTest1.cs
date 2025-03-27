using Xunit;
using System;
using System.Linq;

public class OrderServiceTests : IDisposable
{
    private OrderService orderService;
    private Product p1, p2;
    private Customer c1, c2;
    private Order o1, o2;

    public OrderServiceTests()
    {
        // xUnit 使用构造函数替代 [TestInitialize]
        Initialize();
    }

    private void Initialize()
    {
        orderService = new OrderService();

        p1 = new Product("P001", "Laptop", 1000m);
        p2 = new Product("P002", "Mouse", 20m);

        c1 = new Customer("C001", "John Doe", "john@example.com");
        c2 = new Customer("C002", "Jane Smith", "jane@example.com");

        o1 = new Order("O001", c1, DateTime.Now);
        o1.AddOrderDetail(new OrderDetail(p1, 1));
        o1.AddOrderDetail(new OrderDetail(p2, 2));

        o2 = new Order("O002", c2, DateTime.Now.AddDays(-1));
        o2.AddOrderDetail(new OrderDetail(p1, 2));

        orderService.AddOrder(o1);
        orderService.AddOrder(o2);
    }

    public void Dispose()
    {
        // 清理资源（如果有）
    }

    [Fact]
    public void AddOrder_ShouldAddNewOrder()
    {
        Order o3 = new Order("O003", c1, DateTime.Now);
        orderService.AddOrder(o3);

        var orders = orderService.GetAllOrders();
        Assert.Equal(3, orders.Count);
        Assert.Contains(orders, o => o.OrderId == "O003");
    }

    [Fact]
    public void AddOrder_ShouldThrowException_WhenOrderExists()
    {
        Assert.Throws<ArgumentException>(() => orderService.AddOrder(o1));
    }

    [Fact]
    public void RemoveOrder_ShouldRemoveOrder()
    {
        orderService.RemoveOrder("O001");

        var orders = orderService.GetAllOrders();
        Assert.Equal(1, orders.Count);
        Assert.DoesNotContain(orders, o => o.OrderId == "O001");
    }

    [Fact]
    public void RemoveOrder_ShouldThrowException_WhenOrderNotFound()
    {
        Assert.Throws<ArgumentException>(() => orderService.RemoveOrder("O999"));
    }

    [Fact]
    public void ModifyOrder_ShouldUpdateOrder()
    {
        var modifiedOrder = new Order("O001", c2, DateTime.Now);
        modifiedOrder.AddOrderDetail(new OrderDetail(p1, 5));

        orderService.ModifyOrder(modifiedOrder);

        var orders = orderService.GetAllOrders();
        var updatedOrder = orders.First(o => o.OrderId == "O001");

        Assert.Equal(c2.CustomerId, updatedOrder.Customer.CustomerId);
        Assert.Equal(5, updatedOrder.OrderDetails.First(od => od.Product.ProductId == "P001").Quantity);
    }

    [Fact]
    public void ModifyOrder_ShouldThrowException_WhenOrderNotFound()
    {
        var nonExistingOrder = new Order("O999", c1, DateTime.Now);
        Assert.Throws<ArgumentException>(() => orderService.ModifyOrder(nonExistingOrder));
    }

    [Fact]
    public void QueryByOrderId_ShouldReturnMatchingOrders()
    {
        var results = orderService.QueryByOrderId("O001");

        Assert.Single(results);
        Assert.Equal("O001", results[0].OrderId);
    }

    [Fact]
    public void QueryByProductName_ShouldReturnMatchingOrders()
    {
        var results = orderService.QueryByProductName("Laptop");

        Assert.Equal(2, results.Count);
        Assert.All(results, o => Assert.Contains(o.OrderDetails, od => od.Product.Name == "Laptop"));
    }

    [Fact]
    public void QueryByCustomer_ShouldReturnMatchingOrders()
    {
        var results = orderService.QueryByCustomer("John");

        Assert.Single(results);
        Assert.Equal("John Doe", results[0].Customer.Name);
    }

    [Fact]
    public void QueryByAmountRange_ShouldReturnMatchingOrders()
    {
        var results = orderService.QueryByAmountRange(1000, 2000);

        // Assert
        Assert.Equal(2, results.Count); // 预期返回 2 个订单
        Assert.Contains(results, o => o.OrderId == "O001"); // 包含 O001
        Assert.Contains(results, o => o.OrderId == "O002"); // 包含 O002
        Assert.Equal(1040, results[0].TotalAmount);  // 确保排序正确（金额升序）
        Assert.Equal(2000, results[1].TotalAmount);
    }

    [Fact]
    public void SortOrders_ShouldSortByOrderIdByDefault()
    {
        orderService.SortOrders();
        var orders = orderService.GetAllOrders();

        Assert.True(orders[0].OrderId.CompareTo(orders[1].OrderId) < 0);
    }

    [Fact]
    public void SortOrders_ShouldSortByCustomComparison()
    {
        // Arrange
        var expectedOrder = new[] { "O002", "O001" }; // 预期的订单ID顺序

        // Act
        orderService.SortOrders((o1, o2) => o2.TotalAmount.CompareTo(o1.TotalAmount)); // 降序比较
        var sortedOrders = orderService.GetAllOrders();

        // Assert
        Assert.Equal(2000, sortedOrders[0].TotalAmount); // 第一个应该是 O002 (2000)
        Assert.Equal(1040, sortedOrders[1].TotalAmount); // 第二个应该是 O001 (1040)

        // 或者验证订单ID顺序
        Assert.Equal(expectedOrder, sortedOrders.Select(o => o.OrderId).ToArray());
    }

    [Fact]
    public void ExportImport_ShouldPreserveData()
    {
        string filePath = "test_orders.xml";

        orderService.ExportToFile(filePath);

        OrderService newService = new OrderService();
        newService.ImportFromFile(filePath);

        var originalOrders = orderService.GetAllOrders();
        var importedOrders = newService.GetAllOrders();

        Assert.Equal(originalOrders.Count, importedOrders.Count);
        for (int i = 0; i < originalOrders.Count; i++)
        {
            Assert.Equal(originalOrders[i].OrderId, importedOrders[i].OrderId);
            Assert.Equal(originalOrders[i].TotalAmount, importedOrders[i].TotalAmount);
        }

        System.IO.File.Delete(filePath);
    }
}

public class OrderTests
{
    [Fact]
    public void Order_Equals_ShouldReturnTrue_ForSameOrderId()
    {
        Customer c = new Customer("C001", "Test", "test@test.com");
        Order o1 = new Order("O001", c, DateTime.Now);
        Order o2 = new Order("O001", c, DateTime.Now.AddDays(1));

        Assert.True(o1.Equals(o2));
    }

    [Fact]
    public void OrderDetail_Equals_ShouldReturnTrue_ForSameProduct()
    {
        Product p = new Product("P001", "Test", 10m);
        OrderDetail od1 = new OrderDetail(p, 1);
        OrderDetail od2 = new OrderDetail(p, 2);

        Assert.True(od1.Equals(od2));
    }
}