namespace FishShopForms
{
    partial class FormMain
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
            this.createOrderButton = new System.Windows.Forms.Button();
            this.giveInProgressButton = new System.Windows.Forms.Button();
            this.orderIsFinishedButton = new System.Windows.Forms.Button();
            this.orderIsPaidButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изделияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // createOrderButton
            // 
            this.createOrderButton.Location = new System.Drawing.Point(696, 50);
            this.createOrderButton.Name = "createOrderButton";
            this.createOrderButton.Size = new System.Drawing.Size(75, 23);
            this.createOrderButton.TabIndex = 0;
            this.createOrderButton.Text = "Создать заказ";
            this.createOrderButton.UseVisualStyleBackColor = true;
            this.createOrderButton.Click += new System.EventHandler(this.CreateOrderButton_Click);
            // 
            // giveInProgressButton
            // 
            this.giveInProgressButton.Location = new System.Drawing.Point(696, 119);
            this.giveInProgressButton.Name = "giveInProgressButton";
            this.giveInProgressButton.Size = new System.Drawing.Size(75, 23);
            this.giveInProgressButton.TabIndex = 1;
            this.giveInProgressButton.Text = "Отдать на выполнение";
            this.giveInProgressButton.UseVisualStyleBackColor = true;
            this.giveInProgressButton.Click += new System.EventHandler(this.GiveInProgressButton_Click);
            // 
            // orderIsFinishedButton
            // 
            this.orderIsFinishedButton.Location = new System.Drawing.Point(696, 189);
            this.orderIsFinishedButton.Name = "orderIsFinishedButton";
            this.orderIsFinishedButton.Size = new System.Drawing.Size(92, 23);
            this.orderIsFinishedButton.TabIndex = 2;
            this.orderIsFinishedButton.Text = "Заказ готов";
            this.orderIsFinishedButton.UseVisualStyleBackColor = true;
            this.orderIsFinishedButton.Click += new System.EventHandler(this.OrderIsFinishedButton_Click);
            // 
            // orderIsPaidButton
            // 
            this.orderIsPaidButton.Location = new System.Drawing.Point(696, 269);
            this.orderIsPaidButton.Name = "orderIsPaidButton";
            this.orderIsPaidButton.Size = new System.Drawing.Size(104, 23);
            this.orderIsPaidButton.TabIndex = 3;
            this.orderIsPaidButton.Text = "Заказ оплачен";
            this.orderIsPaidButton.UseVisualStyleBackColor = true;
            this.orderIsPaidButton.Click += new System.EventHandler(this.OrderIsPaidButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(696, 347);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 4;
            this.refreshButton.Text = "Обновить список";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(35, 36);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(628, 334);
            this.dataGridView.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.компонентыToolStripMenuItem,
            this.изделияToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // компонентыToolStripMenuItem
            // 
            this.компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
            this.компонентыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.компонентыToolStripMenuItem.Text = "Компоненты";
            this.компонентыToolStripMenuItem.Click += new System.EventHandler(this.КомпонентыToolStripMenuItem_Click);
            // 
            // изделияToolStripMenuItem
            // 
            this.изделияToolStripMenuItem.Name = "изделияToolStripMenuItem";
            this.изделияToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.изделияToolStripMenuItem.Text = "Изделия";
            this.изделияToolStripMenuItem.Click += new System.EventHandler(this.ИзделияToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.orderIsPaidButton);
            this.Controls.Add(this.orderIsFinishedButton);
            this.Controls.Add(this.giveInProgressButton);
            this.Controls.Add(this.createOrderButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createOrderButton;
        private System.Windows.Forms.Button giveInProgressButton;
        private System.Windows.Forms.Button orderIsFinishedButton;
        private System.Windows.Forms.Button orderIsPaidButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изделияToolStripMenuItem;
    }
}