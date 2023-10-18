namespace Forms
{
    partial class FormReportProductComponents
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
            dataGridView1 = new DataGridView();
            Comp = new DataGridViewTextBoxColumn();
            Product = new DataGridViewTextBoxColumn();
            Count = new DataGridViewTextBoxColumn();
            saveToExcel = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Comp, Product, Count });
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(386, 150);
            dataGridView1.TabIndex = 0;
            // 
            // Comp
            // 
            Comp.HeaderText = "Компоненты";
            Comp.Name = "Comp";
            // 
            // Product
            // 
            Product.HeaderText = "Изделие";
            Product.Name = "Product";
            // 
            // Count
            // 
            Count.HeaderText = "Количество";
            Count.Name = "Count";
            // 
            // saveToExcel
            // 
            saveToExcel.Location = new Point(148, 156);
            saveToExcel.Name = "saveToExcel";
            saveToExcel.Size = new Size(135, 23);
            saveToExcel.TabIndex = 1;
            saveToExcel.Text = "Сохранить в Excel";
            saveToExcel.UseVisualStyleBackColor = true;
            saveToExcel.Click += saveToExcel_Click;
            // 
            // FormReportProductComponents
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(saveToExcel);
            Controls.Add(dataGridView1);
            Name = "FormReportProductComponents";
            Text = "FormReportProductComponents";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Comp;
        private DataGridViewTextBoxColumn Product;
        private DataGridViewTextBoxColumn Count;
        private Button saveToExcel;
    }
}