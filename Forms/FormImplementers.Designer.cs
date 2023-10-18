namespace Forms
{
    partial class FormImplementers
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
            dataGridView = new DataGridView();
            ButtonAddImplementers = new Button();
            ButtonChangeImplementers = new Button();
            ButtonUpdateImplementers = new Button();
            ButtonDeleteImplementer = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(33, 2);
            dataGridView.Margin = new Padding(4, 3, 4, 3);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(555, 425);
            dataGridView.TabIndex = 5;
            // 
            // ButtonAddImplementers
            // 
            ButtonAddImplementers.Location = new Point(679, 44);
            ButtonAddImplementers.Name = "ButtonAddImplementers";
            ButtonAddImplementers.Size = new Size(75, 23);
            ButtonAddImplementers.TabIndex = 6;
            ButtonAddImplementers.Text = "Добавить исполнителя";
            ButtonAddImplementers.UseVisualStyleBackColor = true;
            ButtonAddImplementers.Click += ButtonAddImplementers_Click;
            // 
            // ButtonChangeImplementers
            // 
            ButtonChangeImplementers.Location = new Point(679, 120);
            ButtonChangeImplementers.Name = "ButtonChangeImplementers";
            ButtonChangeImplementers.Size = new Size(75, 23);
            ButtonChangeImplementers.TabIndex = 7;
            ButtonChangeImplementers.Text = "Изменить исполнителя";
            ButtonChangeImplementers.UseVisualStyleBackColor = true;
            ButtonChangeImplementers.Click += ButtonChangeImplementers_Click;
            // 
            // ButtonUpdateImplementers
            // 
            ButtonUpdateImplementers.Location = new Point(679, 226);
            ButtonUpdateImplementers.Name = "ButtonUpdateImplementers";
            ButtonUpdateImplementers.Size = new Size(75, 23);
            ButtonUpdateImplementers.TabIndex = 8;
            ButtonUpdateImplementers.Text = "Обновить список исполнителей";
            ButtonUpdateImplementers.UseVisualStyleBackColor = true;
            ButtonUpdateImplementers.Click += ButtonUpdateImplementers_Click;
            // 
            // ButtonDeleteImplementer
            // 
            ButtonDeleteImplementer.Location = new Point(679, 329);
            ButtonDeleteImplementer.Name = "ButtonDeleteImplementer";
            ButtonDeleteImplementer.Size = new Size(75, 23);
            ButtonDeleteImplementer.TabIndex = 9;
            ButtonDeleteImplementer.Text = "Удалить исполнителя";
            ButtonDeleteImplementer.UseVisualStyleBackColor = true;
            ButtonDeleteImplementer.Click += ButtonDeleteImplementer_Click;
            // 
            // FormImplementers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ButtonDeleteImplementer);
            Controls.Add(ButtonUpdateImplementers);
            Controls.Add(ButtonChangeImplementers);
            Controls.Add(ButtonAddImplementers);
            Controls.Add(dataGridView);
            Name = "FormImplementers";
            Text = "FormImplementers";
            Load += FormComponents_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView;
        private Button ButtonAddImplementers;
        private Button ButtonChangeImplementers;
        private Button ButtonUpdateImplementers;
        private Button ButtonDeleteImplementer;
    }
}