namespace NailWarehouseAutomation
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
            statusStrip1 = new StatusStrip();
            WarehouseMenuStrip = new MenuStrip();
            AddToolStripMenuItem = new ToolStripMenuItem();
            ChangeToolStripMenuItem = new ToolStripMenuItem();
            DeleteToolStripMenuItem = new ToolStripMenuItem();
            WarehouseDataGridView = new DataGridView();
            WarehouseMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)WarehouseDataGridView).BeginInit();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.FromArgb(113, 9, 170);
            statusStrip1.Location = new Point(0, 557);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1075, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // WarehouseMenuStrip
            // 
            WarehouseMenuStrip.BackColor = Color.FromArgb(18, 64, 171);
            WarehouseMenuStrip.Items.AddRange(new ToolStripItem[] { AddToolStripMenuItem, ChangeToolStripMenuItem, DeleteToolStripMenuItem });
            WarehouseMenuStrip.Location = new Point(0, 0);
            WarehouseMenuStrip.Name = "WarehouseMenuStrip";
            WarehouseMenuStrip.Size = new Size(1075, 31);
            WarehouseMenuStrip.TabIndex = 1;
            WarehouseMenuStrip.Text = "menuStrip";
            // 
            // AddToolStripMenuItem
            // 
            AddToolStripMenuItem.BackColor = Color.FromArgb(255, 211, 0);
            AddToolStripMenuItem.Font = new Font("Segoe UI", 12.25F, FontStyle.Bold);
            AddToolStripMenuItem.ForeColor = Color.FromArgb(18, 64, 171);
            AddToolStripMenuItem.Margin = new Padding(0, 0, 5, 0);
            AddToolStripMenuItem.Name = "AddToolStripMenuItem";
            AddToolStripMenuItem.Size = new Size(103, 27);
            AddToolStripMenuItem.Text = "Добавить";
            AddToolStripMenuItem.Click += AddToolStripMenuItem_Click;
            // 
            // ChangeToolStripMenuItem
            // 
            ChangeToolStripMenuItem.BackColor = Color.FromArgb(255, 211, 0);
            ChangeToolStripMenuItem.Font = new Font("Segoe UI", 12.25F, FontStyle.Bold);
            ChangeToolStripMenuItem.ForeColor = Color.FromArgb(18, 64, 171);
            ChangeToolStripMenuItem.Margin = new Padding(0, 0, 5, 0);
            ChangeToolStripMenuItem.Name = "ChangeToolStripMenuItem";
            ChangeToolStripMenuItem.Size = new Size(104, 27);
            ChangeToolStripMenuItem.Text = "Изменить";
            ChangeToolStripMenuItem.Click += ChangeToolStripMenuItem_Click;
            // 
            // DeleteToolStripMenuItem
            // 
            DeleteToolStripMenuItem.BackColor = Color.FromArgb(255, 211, 0);
            DeleteToolStripMenuItem.Font = new Font("Segoe UI", 12.25F, FontStyle.Bold);
            DeleteToolStripMenuItem.ForeColor = Color.FromArgb(18, 64, 171);
            DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            DeleteToolStripMenuItem.Size = new Size(89, 27);
            DeleteToolStripMenuItem.Text = "Удалить";
            // 
            // WarehouseDataGridView
            // 
            WarehouseDataGridView.AllowUserToOrderColumns = true;
            WarehouseDataGridView.BackgroundColor = Color.White;
            WarehouseDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            WarehouseDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            WarehouseDataGridView.Dock = DockStyle.Fill;
            WarehouseDataGridView.Location = new Point(0, 31);
            WarehouseDataGridView.Name = "WarehouseDataGridView";
            WarehouseDataGridView.Size = new Size(1075, 526);
            WarehouseDataGridView.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1075, 579);
            Controls.Add(WarehouseDataGridView);
            Controls.Add(statusStrip1);
            Controls.Add(WarehouseMenuStrip);
            MainMenuStrip = WarehouseMenuStrip;
            Name = "MainForm";
            Text = "Warehouse";
            WarehouseMenuStrip.ResumeLayout(false);
            WarehouseMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)WarehouseDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private MenuStrip WarehouseMenuStrip;
        private ToolStripMenuItem AddToolStripMenuItem;
        private ToolStripMenuItem ChangeToolStripMenuItem;
        private ToolStripMenuItem DeleteToolStripMenuItem;
        private DataGridView WarehouseDataGridView;
    }
}
