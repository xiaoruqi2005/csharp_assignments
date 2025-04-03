using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment5.WinForms
{
    public partial class OrderEditForm : Form
    {
        public Order Order { get; private set; }
        private readonly BindingSource _detailsBinding = new BindingSource();
        private readonly List<Product> _products = GetSampleProducts();
        private readonly List<Customer> _customers = GetSampleCustomers();

        public OrderEditForm(Order order = null)
        {
            InitializeComponent();
            Order = order ?? new Order
            {
                OrderId = GenerateOrderId(),
                OrderDate = DateTime.Now,
                OrderDetails = new List<OrderDetail>()
            };
            InitializeDataBinding();
        }

        private void InitializeDataBinding()
        {
            // 订单基本信息绑定
            OrderId.DataBindings.Add("Text", Order, "OrderId");
            OrderDate.DataBindings.Add("Value", Order, "OrderDate");

            // 客户下拉框
            Customer.DataSource = _customers;
            Customer.DisplayMember = "Name";
            Customer.ValueMember = "CustomerId";
            if (Order.Customer != null)
                Customer.SelectedValue = Order.Customer.CustomerId;

            // 订单明细绑定
            _detailsBinding.DataSource = Order.OrderDetails;
            dgvDetails.DataSource = _detailsBinding;

            // 商品选择下拉框
            cmbProducts.DataSource = _products;
            cmbProducts.DisplayMember = "Name";
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedItem is Product product &&
       numQuantity.Value > 0) // 直接使用Value属性
            {
                Order.OrderDetails.Add(new OrderDetail(product, (int)numQuantity.Value));
                _detailsBinding.ResetBindings(false);
                numQuantity.Value = numQuantity.Minimum; // 重置为最小值（通常是0）
            }
        }

        private void btnRemoveDetail_Click(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedItem is Product product)
            {
                int quantity = (int)numQuantity.Value;
                if (quantity > 0)
                {
                    Order.OrderDetails.Add(new OrderDetail(product, quantity));
                    _detailsBinding.ResetBindings(false);
                    numQuantity.Value = numQuantity.Minimum;
                }
                else
                {
                    MessageBox.Show("数量必须大于0", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Customer.SelectedItem is Customer customer)
            {
                Order.Customer = customer;
                DialogResult = DialogResult.OK;
            }
        }

        private static string GenerateOrderId() => $"O{Guid.NewGuid().ToString("N").Substring(0, 8)}";

        private static List<Product> GetSampleProducts() => new List<Product>
    {
        new Product("P001", "笔记本电脑", 5999m),
        new Product("P002", "鼠标", 99m),
        new Product("P003", "键盘", 199m)
    };

        private static List<Customer> GetSampleCustomers() => new List<Customer>
    {
        new Customer("C001", "张三", "zhang@example.com"),
        new Customer("C002", "李四", "li@example.com")
    };

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OrderEditForm_Load(object sender, EventArgs e)
        {

        }
    }
}
