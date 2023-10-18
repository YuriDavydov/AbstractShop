namespace Forms
{
    partial class FormImplementer
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
            label1 = new Label();
            textBoxFIO = new TextBox();
            label2 = new Label();
            label3 = new Label();
            textBoxRest = new TextBox();
            textBoxWorkTime = new TextBox();
            ButtonAddImplementer = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(610, 78);
            label1.Name = "label1";
            label1.Size = new Size(109, 15);
            label1.TabIndex = 0;
            label1.Text = "ФИО исполнителя";
            // 
            // textBoxFIO
            // 
            textBoxFIO.Location = new Point(610, 109);
            textBoxFIO.Name = "textBoxFIO";
            textBoxFIO.Size = new Size(100, 23);
            textBoxFIO.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(610, 165);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 2;
            label2.Text = "Время работы";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(610, 266);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 3;
            label3.Text = "Перерыв";
            // 
            // textBoxRest
            // 
            textBoxRest.Location = new Point(610, 308);
            textBoxRest.Name = "textBoxRest";
            textBoxRest.Size = new Size(100, 23);
            textBoxRest.TabIndex = 4;
            // 
            // textBoxWorkTime
            // 
            textBoxWorkTime.Location = new Point(610, 202);
            textBoxWorkTime.Name = "textBoxWorkTime";
            textBoxWorkTime.Size = new Size(100, 23);
            textBoxWorkTime.TabIndex = 5;
            // 
            // ButtonAddImplementer
            // 
            ButtonAddImplementer.Location = new Point(610, 378);
            ButtonAddImplementer.Name = "ButtonAddImplementer";
            ButtonAddImplementer.Size = new Size(75, 23);
            ButtonAddImplementer.TabIndex = 6;
            ButtonAddImplementer.Text = "Добавить исполнителя";
            ButtonAddImplementer.UseVisualStyleBackColor = true;
            ButtonAddImplementer.Click += ButtonAddImplementer_Click;
            // 
            // FormImplementer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ButtonAddImplementer);
            Controls.Add(textBoxWorkTime);
            Controls.Add(textBoxRest);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBoxFIO);
            Controls.Add(label1);
            Name = "FormImplementer";
            Text = "Implementer";
            Load += FormImplementer_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxFIO;
        private Label label2;
        private Label label3;
        private TextBox textBoxRest;
        private TextBox textBoxWorkTime;
        private Button ButtonAddImplementer;
    }
}