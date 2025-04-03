using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace assignment5.WinForms
{
    public partial class MainForm : Form
    {
        private readonly OrderService _orderService = new OrderService();
        private readonly BindingSource _ordersBinding = new BindingSource();
        private readonly BindingSource _detailsBinding = new BindingSource();

        public MainForm()
        {
            InitializeComponent();
            ConfigureDataGridViews();
            InitializeDataBinding();
            LoadOrders();
        }

        private void InitializeDataBinding()
        {
            // 主从数据绑定
            _ordersBinding.DataSource = typeof(List<Order>);
            _detailsBinding.DataSource = _ordersBinding;
            _detailsBinding.DataMember = "OrderDetails";

            dgvOrders.DataSource = _ordersBinding;
            dgvDetails.DataSource = _detailsBinding;
        }


        private void ConfigureDataGridViews()
        {
            // 订单列表配置
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.Columns.AddRange(
                new DataGridViewTextBoxColumn { DataPropertyName = "OrderId", HeaderText = "订单号" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Customer.Name", HeaderText = "客户" },
                new DataGridViewTextBoxColumn { DataPropertyName = "OrderDate", HeaderText = "日期" },
                new DataGridViewTextBoxColumn { DataPropertyName = "TotalAmount", HeaderText = "总金额" }
            );

            // 订单明细配置
            dgvDetails.AutoGenerateColumns = false;
            dgvDetails.Columns.AddRange(
                new DataGridViewTextBoxColumn { DataPropertyName = "Product.Name", HeaderText = "商品" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Product.Price", HeaderText = "单价" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "数量" },
                new DataGridViewTextBoxColumn { DataPropertyName = "TotalAmount", HeaderText = "小计" }
            );
        }

        private void LoadOrders()
        {
            _ordersBinding.DataSource = _orderService.GetAllOrders();
        }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var results = _orderService.QueryByOrderId(txtSearch.Text);
            _ordersBinding.DataSource = results;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var form = new OrderEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _orderService.AddOrder(form.Order);
                LoadOrders();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (_ordersBinding.Current is Order selected)
            {
                using var form = new OrderEditForm(selected.Clone());
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _orderService.ModifyOrder(form.Order);
                    LoadOrders();
                }
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
    {
        // 响应式布局
        splitContainer1.SplitterDistance = (int)(this.ClientSize.Height * 0.6);
    }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_ordersBinding.Current is Order selected)
            {
                try
                {
                    _orderService.RemoveOrder(selected.OrderId);
                    LoadOrders();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
