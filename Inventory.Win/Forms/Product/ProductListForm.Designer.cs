namespace Inventory.Win.Forms.Product
{
    partial class ProductListForm
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
            productGridView = new DataGridView();
            Name = new DataGridViewTextBoxColumn();
            CategoryName = new DataGridViewTextBoxColumn();
            UnitName = new DataGridViewTextBoxColumn();
            MinStock = new DataGridViewTextBoxColumn();
            Id = new DataGridViewTextBoxColumn();
            createProductBtn = new Button();
            groupBox1 = new GroupBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            categoryCombo = new ComboBox();
            unitCombo = new ComboBox();
            minStockTxt = new TextBox();
            nameTxt = new TextBox();
            ((System.ComponentModel.ISupportInitialize)productGridView).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // productGridView
            // 
            productGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            productGridView.Columns.AddRange(new DataGridViewColumn[] { Name, CategoryName, UnitName, MinStock, Id });
            productGridView.Dock = DockStyle.Bottom;
            productGridView.Location = new Point(0, 135);
            productGridView.Name = "productGridView";
            productGridView.ReadOnly = true;
            productGridView.RightToLeft = RightToLeft.Yes;
            productGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            productGridView.Size = new Size(628, 468);
            productGridView.TabIndex = 0;
            productGridView.CellDoubleClick += productGridView_CellDoubleClick;
            // 
            // Name
            // 
            Name.DataPropertyName = "Name";
            Name.HeaderText = "نام";
            Name.Name = "Name";
            Name.ReadOnly = true;
            // 
            // CategoryName
            // 
            CategoryName.DataPropertyName = "CategoryName";
            CategoryName.HeaderText = "دسته بندی";
            CategoryName.Name = "CategoryName";
            CategoryName.ReadOnly = true;
            // 
            // UnitName
            // 
            UnitName.DataPropertyName = "UnitName";
            UnitName.HeaderText = "واحد";
            UnitName.Name = "UnitName";
            UnitName.ReadOnly = true;
            // 
            // MinStock
            // 
            MinStock.DataPropertyName = "MinStock";
            MinStock.HeaderText = "میزان هشدار";
            MinStock.Name = "MinStock";
            MinStock.ReadOnly = true;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            // 
            // createProductBtn
            // 
            createProductBtn.Location = new Point(12, 81);
            createProductBtn.Name = "createProductBtn";
            createProductBtn.Size = new Size(47, 30);
            createProductBtn.TabIndex = 1;
            createProductBtn.Text = "ثبت ";
            createProductBtn.UseVisualStyleBackColor = true;
            createProductBtn.Click += createProductBtn_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(categoryCombo);
            groupBox1.Controls.Add(unitCombo);
            groupBox1.Controls.Add(minStockTxt);
            groupBox1.Controls.Add(nameTxt);
            groupBox1.Controls.Add(createProductBtn);
            groupBox1.Location = new Point(0, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.RightToLeft = RightToLeft.Yes;
            groupBox1.Size = new Size(632, 123);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "ثبت محصول جدید ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(44, 33);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 9;
            label4.Text = "مقدار هشدار";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(226, 34);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 8;
            label3.Text = "واحد";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(340, 35);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 7;
            label2.Text = "دسته بندی";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(599, 34);
            label1.Name = "label1";
            label1.Size = new Size(21, 15);
            label1.TabIndex = 6;
            label1.Text = "نام";
            // 
            // categoryCombo
            // 
            categoryCombo.FormattingEnabled = true;
            categoryCombo.Location = new Point(261, 53);
            categoryCombo.Name = "categoryCombo";
            categoryCombo.Size = new Size(138, 23);
            categoryCombo.TabIndex = 5;
            // 
            // unitCombo
            // 
            unitCombo.FormattingEnabled = true;
            unitCombo.Location = new Point(119, 52);
            unitCombo.Name = "unitCombo";
            unitCombo.Size = new Size(138, 23);
            unitCombo.TabIndex = 4;
            // 
            // minStockTxt
            // 
            minStockTxt.Location = new Point(13, 52);
            minStockTxt.Name = "minStockTxt";
            minStockTxt.Size = new Size(100, 23);
            minStockTxt.TabIndex = 3;
            // 
            // nameTxt
            // 
            nameTxt.Location = new Point(405, 52);
            nameTxt.Name = "nameTxt";
            nameTxt.Size = new Size(219, 23);
            nameTxt.TabIndex = 2;
            // 
            // ProductListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(628, 603);
            Controls.Add(groupBox1);
            Controls.Add(productGridView);
            Text = "محصولات";
            Load += ProductListForm_Load;
            ((System.ComponentModel.ISupportInitialize)productGridView).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView productGridView;
        private Button createProductBtn;
        private GroupBox groupBox1;
        private TextBox minStockTxt;
        private TextBox nameTxt;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox categoryCombo;
        private ComboBox unitCombo;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn CategoryName;
        private DataGridViewTextBoxColumn UnitName;
        private DataGridViewTextBoxColumn MinStock;
        private DataGridViewTextBoxColumn Id;
    }
}