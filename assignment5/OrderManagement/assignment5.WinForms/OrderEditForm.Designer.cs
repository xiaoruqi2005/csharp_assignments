namespace assignment5.WinForms
{
    partial class OrderEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            OrderId = new TextBox();
            label1 = new Label();
            label2 = new Label();
            Customer = new ComboBox();
            label3 = new Label();
            OrderDate = new DateTimePicker();
            dgvDetails = new DataGridView();
            cmbProducts = new ComboBox();
            numQuantity = new NumericUpDown();
            AddDetail = new Button();
            RemoveDetail = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43.2075462F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 56.7924538F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 245F));
            tableLayoutPanel1.Controls.Add(OrderId, 0, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 1);
            tableLayoutPanel1.Controls.Add(label2, 1, 1);
            tableLayoutPanel1.Controls.Add(Customer, 2, 0);
            tableLayoutPanel1.Controls.Add(label3, 2, 1);
            tableLayoutPanel1.Controls.Add(OrderDate, 1, 0);
            tableLayoutPanel1.Location = new Point(12, 23);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 51.54639F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 48.45361F));
            tableLayoutPanel1.Size = new Size(776, 97);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // OrderId
            // 
            OrderId.Location = new Point(3, 3);
            OrderId.Name = "OrderId";
            OrderId.Size = new Size(200, 38);
            OrderId.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 50);
            label1.Name = "label1";
            label1.Size = new Size(87, 31);
            label1.TabIndex = 1;
            label1.Text = "订单ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(232, 50);
            label2.Name = "label2";
            label2.Size = new Size(110, 31);
            label2.TabIndex = 3;
            label2.Text = "订单时间";
            // 
            // Customer
            // 
            Customer.FormattingEnabled = true;
            Customer.Location = new Point(533, 3);
            Customer.Name = "Customer";
            Customer.Size = new Size(240, 39);
            Customer.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(533, 50);
            label3.Name = "label3";
            label3.Size = new Size(62, 31);
            label3.TabIndex = 5;
            label3.Text = "顾客";
            // 
            // OrderDate
            // 
            OrderDate.Location = new Point(232, 3);
            OrderDate.Name = "OrderDate";
            OrderDate.Size = new Size(295, 38);
            OrderDate.TabIndex = 2;
            // 
            // dgvDetails
            // 
            dgvDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetails.Location = new Point(15, 163);
            dgvDetails.Name = "dgvDetails";
            dgvDetails.RowHeadersWidth = 82;
            dgvDetails.Size = new Size(480, 275);
            dgvDetails.TabIndex = 1;
            // 
            // cmbProducts
            // 
            cmbProducts.FormattingEnabled = true;
            cmbProducts.Location = new Point(530, 179);
            cmbProducts.Name = "cmbProducts";
            cmbProducts.Size = new Size(242, 39);
            cmbProducts.TabIndex = 2;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(532, 249);
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(240, 38);
            numQuantity.TabIndex = 3;
            // 
            // AddDetail
            // 
            AddDetail.Location = new Point(545, 310);
            AddDetail.Name = "AddDetail";
            AddDetail.Size = new Size(194, 46);
            AddDetail.TabIndex = 4;
            AddDetail.Text = "添加细节";
            AddDetail.UseVisualStyleBackColor = true;
            // 
            // RemoveDetail
            // 
            RemoveDetail.Location = new Point(545, 362);
            RemoveDetail.Name = "RemoveDetail";
            RemoveDetail.Size = new Size(194, 46);
            RemoveDetail.TabIndex = 5;
            RemoveDetail.Text = "删除细节";
            RemoveDetail.UseVisualStyleBackColor = true;
            // 
            // OrderEditForm
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(RemoveDetail);
            Controls.Add(AddDetail);
            Controls.Add(numQuantity);
            Controls.Add(cmbProducts);
            Controls.Add(dgvDetails);
            Controls.Add(tableLayoutPanel1);
            Name = "OrderEditForm";
            Text = "OrderEditForm";
            Load += OrderEditForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TextBox OrderId;
        private Label label1;
        private Label label2;
        private ComboBox Customer;
        private Label label3;
        private DateTimePicker OrderDate;
        private DataGridView dgvDetails;
        private ComboBox cmbProducts;
        private NumericUpDown numQuantity;
        private Button AddDetail;
        private Button RemoveDetail;
    }
}