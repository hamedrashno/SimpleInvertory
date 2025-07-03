namespace Inventory.Win
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainMenu = new MenuStrip();
            محصولاتToolStripMenuItem = new ToolStripMenuItem();
            لیستمحصولاتToolStripMenuItem = new ToolStripMenuItem();
            دستهبندیمحصولاتToolStripMenuItem = new ToolStripMenuItem();
            واحداندازهگیریToolStripMenuItem = new ToolStripMenuItem();
            انبارToolStripMenuItem = new ToolStripMenuItem();
            لیستانبارهاToolStripMenuItem = new ToolStripMenuItem();
            نوعتراکنشانبارToolStripMenuItem = new ToolStripMenuItem();
            تراکنشToolStripMenuItem1 = new ToolStripMenuItem();
            ثبتفاکتورخریدToolStripMenuItem = new ToolStripMenuItem();
            ثبتToolStripMenuItem = new ToolStripMenuItem();
            برداشتازانبارToolStripMenuItem = new ToolStripMenuItem();
            ثبتفاکتToolStripMenuItem = new ToolStripMenuItem();
            mainMenu.SuspendLayout();
            SuspendLayout();
            // 
            // mainMenu
            // 
            mainMenu.Items.AddRange(new ToolStripItem[] { محصولاتToolStripMenuItem, انبارToolStripMenuItem, تراکنشToolStripMenuItem1 });
            mainMenu.Location = new Point(0, 0);
            mainMenu.Name = "mainMenu";
            mainMenu.Size = new Size(734, 24);
            mainMenu.TabIndex = 0;
            mainMenu.Text = "menuStrip1";
            // 
            // محصولاتToolStripMenuItem
            // 
            محصولاتToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { لیستمحصولاتToolStripMenuItem, دستهبندیمحصولاتToolStripMenuItem, واحداندازهگیریToolStripMenuItem });
            محصولاتToolStripMenuItem.Name = "محصولاتToolStripMenuItem";
            محصولاتToolStripMenuItem.Size = new Size(69, 20);
            محصولاتToolStripMenuItem.Text = "محصولات";
            // 
            // لیستمحصولاتToolStripMenuItem
            // 
            لیستمحصولاتToolStripMenuItem.Name = "لیستمحصولاتToolStripMenuItem";
            لیستمحصولاتToolStripMenuItem.Size = new Size(204, 22);
            لیستمحصولاتToolStripMenuItem.Text = "محصولات";
            لیستمحصولاتToolStripMenuItem.Click += لیستمحصولاتToolStripMenuItem_Click;
            // 
            // دستهبندیمحصولاتToolStripMenuItem
            // 
            دستهبندیمحصولاتToolStripMenuItem.Name = "دستهبندیمحصولاتToolStripMenuItem";
            دستهبندیمحصولاتToolStripMenuItem.Size = new Size(204, 22);
            دستهبندیمحصولاتToolStripMenuItem.Text = "دسته بندی محصولات";
            // 
            // واحداندازهگیریToolStripMenuItem
            // 
            واحداندازهگیریToolStripMenuItem.Name = "واحداندازهگیریToolStripMenuItem";
            واحداندازهگیریToolStripMenuItem.Size = new Size(204, 22);
            واحداندازهگیریToolStripMenuItem.Text = "واحد اندازه گیری محصولات";
            // 
            // انبارToolStripMenuItem
            // 
            انبارToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { لیستانبارهاToolStripMenuItem, نوعتراکنشانبارToolStripMenuItem });
            انبارToolStripMenuItem.Name = "انبارToolStripMenuItem";
            انبارToolStripMenuItem.Size = new Size(38, 20);
            انبارToolStripMenuItem.Text = "انبار";
            // 
            // لیستانبارهاToolStripMenuItem
            // 
            لیستانبارهاToolStripMenuItem.Name = "لیستانبارهاToolStripMenuItem";
            لیستانبارهاToolStripMenuItem.Size = new Size(151, 22);
            لیستانبارهاToolStripMenuItem.Text = "انبارها";
            // 
            // نوعتراکنشانبارToolStripMenuItem
            // 
            نوعتراکنشانبارToolStripMenuItem.Name = "نوعتراکنشانبارToolStripMenuItem";
            نوعتراکنشانبارToolStripMenuItem.Size = new Size(151, 22);
            نوعتراکنشانبارToolStripMenuItem.Text = "نوع تراکنش انبار";
            // 
            // تراکنشToolStripMenuItem1
            // 
            تراکنشToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { ثبتفاکتورخریدToolStripMenuItem, ثبتToolStripMenuItem, برداشتازانبارToolStripMenuItem });
            تراکنشToolStripMenuItem1.Name = "تراکنشToolStripMenuItem1";
            تراکنشToolStripMenuItem1.Size = new Size(54, 20);
            تراکنشToolStripMenuItem1.Text = "تراکنش";
            // 
            // ثبتفاکتورخریدToolStripMenuItem
            // 
            ثبتفاکتورخریدToolStripMenuItem.Name = "ثبتفاکتورخریدToolStripMenuItem";
            ثبتفاکتورخریدToolStripMenuItem.Size = new Size(193, 22);
            ثبتفاکتورخریدToolStripMenuItem.Text = "افزایش موجودی (فاکتور)";
            // 
            // ثبتToolStripMenuItem
            // 
            ثبتToolStripMenuItem.Name = "ثبتToolStripMenuItem";
            ثبتToolStripMenuItem.Size = new Size(193, 22);
            ثبتToolStripMenuItem.Text = "افزایش موجودی (تکی)";
            // 
            // برداشتازانبارToolStripMenuItem
            // 
            برداشتازانبارToolStripMenuItem.Name = "برداشتازانبارToolStripMenuItem";
            برداشتازانبارToolStripMenuItem.Size = new Size(193, 22);
            برداشتازانبارToolStripMenuItem.Text = "برداشت از انبار";
            // 
            // ثبتفاکتToolStripMenuItem
            // 
            ثبتفاکتToolStripMenuItem.Name = "ثبتفاکتToolStripMenuItem";
            ثبتفاکتToolStripMenuItem.Size = new Size(180, 22);
            ثبتفاکتToolStripMenuItem.Text = "ثبت فاکت";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(734, 396);
            Controls.Add(mainMenu);
            MainMenuStrip = mainMenu;
            Name = "MainForm";
            Text = "سیستم انبار";
            mainMenu.ResumeLayout(false);
            mainMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mainMenu;
        private ToolStripMenuItem محصولاتToolStripMenuItem;
        private ToolStripMenuItem لیستمحصولاتToolStripMenuItem;
        private ToolStripMenuItem دستهبندیمحصولاتToolStripMenuItem;
        private ToolStripMenuItem واحداندازهگیریToolStripMenuItem;
        private ToolStripMenuItem انبارToolStripMenuItem;
        private ToolStripMenuItem لیستانبارهاToolStripMenuItem;
        private ToolStripMenuItem نوعتراکنشانبارToolStripMenuItem;
        private ToolStripMenuItem ثبتفاکتToolStripMenuItem;
        private ToolStripMenuItem تراکنشToolStripMenuItem1;
        private ToolStripMenuItem ثبتفاکتورخریدToolStripMenuItem;
        private ToolStripMenuItem ثبتToolStripMenuItem;
        private ToolStripMenuItem برداشتازانبارToolStripMenuItem;
    }
}
