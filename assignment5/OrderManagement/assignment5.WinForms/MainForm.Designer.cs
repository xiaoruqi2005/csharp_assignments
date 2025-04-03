namespace assignment5.WinForms
{
    partial class MainForm
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
            splitContainer1 = new SplitContainer();
            btnSearch = new Button();
            txtSearch = new TextBox();
            dgvOrders = new DataGridView();
            btnDelete = new Button();
            btnModify = new Button();
            btnAdd = new Button();
            dgvDetails = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnSearch);
            splitContainer1.Panel1.Controls.Add(txtSearch);
            splitContainer1.Panel1.Controls.Add(dgvOrders);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnDelete);
            splitContainer1.Panel2.Controls.Add(btnModify);
            splitContainer1.Panel2.Controls.Add(btnAdd);
            splitContainer1.Panel2.Controls.Add(dgvDetails);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 385;
            splitContainer1.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(109, 364);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(150, 46);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "搜索";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(81, 300);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(233, 38);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += textBox1_TextChanged;
            // 
            // dgvOrders
            // 
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Location = new Point(47, 43);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.RowHeadersWidth = 82;
            dgvOrders.Size = new Size(297, 219);
            dgvOrders.TabIndex = 0;
            dgvOrders.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(87, 404);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(255, 46);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "删除";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnModify
            // 
            btnModify.Location = new Point(87, 352);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(255, 46);
            btnModify.TabIndex = 2;
            btnModify.Text = "修改";
            btnModify.UseVisualStyleBackColor = true;
            btnModify.Click += btnModify_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(87, 300);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(255, 46);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "新增";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvDetails
            // 
            dgvDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetails.Location = new Point(37, 43);
            dgvDetails.Name = "dgvDetails";
            dgvDetails.RowHeadersWidth = 82;
            dgvDetails.Size = new Size(362, 242);
            dgvDetails.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView dgvOrders;
        public TextBox txtSearch;
        private Button btnSearch;
        private Button btnDelete;
        private Button btnModify;
        private Button btnAdd;
        private DataGridView dgvDetails;
    }
}