namespace Forms
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
            createOrderButton = new Button();
            giveInProgressButton = new Button();
            orderIsFinishedButton = new Button();
            orderIsPaidButton = new Button();
            refreshButton = new Button();
            dataGridView = new DataGridView();
            menuStrip1 = new MenuStrip();
            справочникиToolStripMenuItem = new ToolStripMenuItem();
            компонентыToolStripMenuItem = new ToolStripMenuItem();
            изделияToolStripMenuItem = new ToolStripMenuItem();
            отчетыToolStripMenuItem = new ToolStripMenuItem();
            списокКомпонентовToolStripMenuItem = new ToolStripMenuItem();
            компонентыПоИзделиямToolStripMenuItem = new ToolStripMenuItem();
            списокЗаказовToolStripMenuItem = new ToolStripMenuItem();
            buttonImplementers = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // createOrderButton
            // 
            createOrderButton.Location = new Point(812, 58);
            createOrderButton.Margin = new Padding(4, 3, 4, 3);
            createOrderButton.Name = "createOrderButton";
            createOrderButton.Size = new Size(88, 27);
            createOrderButton.TabIndex = 0;
            createOrderButton.Text = "Создать заказ";
            createOrderButton.UseVisualStyleBackColor = true;
            createOrderButton.Click += CreateOrderButton_Click;
            // 
            // giveInProgressButton
            // 
            giveInProgressButton.Location = new Point(812, 137);
            giveInProgressButton.Margin = new Padding(4, 3, 4, 3);
            giveInProgressButton.Name = "giveInProgressButton";
            giveInProgressButton.Size = new Size(88, 27);
            giveInProgressButton.TabIndex = 1;
            giveInProgressButton.Text = "Отдать на выполнение";
            giveInProgressButton.UseVisualStyleBackColor = true;
            giveInProgressButton.Click += GiveInProgressButton_Click;
            // 
            // orderIsFinishedButton
            // 
            orderIsFinishedButton.Location = new Point(812, 218);
            orderIsFinishedButton.Margin = new Padding(4, 3, 4, 3);
            orderIsFinishedButton.Name = "orderIsFinishedButton";
            orderIsFinishedButton.Size = new Size(107, 27);
            orderIsFinishedButton.TabIndex = 2;
            orderIsFinishedButton.Text = "Заказ готов";
            orderIsFinishedButton.UseVisualStyleBackColor = true;
            orderIsFinishedButton.Click += OrderIsFinishedButton_Click;
            // 
            // orderIsPaidButton
            // 
            orderIsPaidButton.Location = new Point(812, 310);
            orderIsPaidButton.Margin = new Padding(4, 3, 4, 3);
            orderIsPaidButton.Name = "orderIsPaidButton";
            orderIsPaidButton.Size = new Size(121, 27);
            orderIsPaidButton.TabIndex = 3;
            orderIsPaidButton.Text = "Заказ оплачен";
            orderIsPaidButton.UseVisualStyleBackColor = true;
            orderIsPaidButton.Click += OrderIsPaidButton_Click;
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(812, 454);
            refreshButton.Margin = new Padding(4, 3, 4, 3);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(88, 27);
            refreshButton.TabIndex = 4;
            refreshButton.Text = "Обновить список";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += RefreshButton_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(41, 42);
            dataGridView.Margin = new Padding(4, 3, 4, 3);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(733, 385);
            dataGridView.TabIndex = 5;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { справочникиToolStripMenuItem, отчетыToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(933, 24);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            справочникиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { компонентыToolStripMenuItem, изделияToolStripMenuItem });
            справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            справочникиToolStripMenuItem.Size = new Size(94, 20);
            справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // компонентыToolStripMenuItem
            // 
            компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
            компонентыToolStripMenuItem.Size = new Size(145, 22);
            компонентыToolStripMenuItem.Text = "Компоненты";
            компонентыToolStripMenuItem.Click += КомпонентыToolStripMenuItem_Click;
            // 
            // изделияToolStripMenuItem
            // 
            изделияToolStripMenuItem.Name = "изделияToolStripMenuItem";
            изделияToolStripMenuItem.Size = new Size(145, 22);
            изделияToolStripMenuItem.Text = "Изделия";
            изделияToolStripMenuItem.Click += ИзделияToolStripMenuItem_Click;
            // 
            // отчетыToolStripMenuItem
            // 
            отчетыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { списокКомпонентовToolStripMenuItem, компонентыПоИзделиямToolStripMenuItem, списокЗаказовToolStripMenuItem });
            отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            отчетыToolStripMenuItem.Size = new Size(58, 20);
            отчетыToolStripMenuItem.Text = "отчеты";
            // 
            // списокКомпонентовToolStripMenuItem
            // 
            списокКомпонентовToolStripMenuItem.Name = "списокКомпонентовToolStripMenuItem";
            списокКомпонентовToolStripMenuItem.Size = new Size(218, 22);
            списокКомпонентовToolStripMenuItem.Text = "Список компонентов";

            // 
            // компонентыПоИзделиямToolStripMenuItem
            // 
            компонентыПоИзделиямToolStripMenuItem.Name = "компонентыПоИзделиямToolStripMenuItem";
            компонентыПоИзделиямToolStripMenuItem.Size = new Size(218, 22);
            компонентыПоИзделиямToolStripMenuItem.Text = "Компоненты по изделиям";

            // 
            // списокЗаказовToolStripMenuItem
            // 
            списокЗаказовToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem";
            списокЗаказовToolStripMenuItem.Size = new Size(218, 22);
            списокЗаказовToolStripMenuItem.Text = "Список заказов";

            // 
            // buttonImplementers
            // 
            buttonImplementers.Location = new Point(812, 404);
            buttonImplementers.Name = "buttonImplementers";
            buttonImplementers.Size = new Size(75, 23);
            buttonImplementers.TabIndex = 7;
            buttonImplementers.Text = "Список исполнителей";
            buttonImplementers.UseVisualStyleBackColor = true;
            buttonImplementers.Click += buttonImplementers_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(buttonImplementers);
            Controls.Add(dataGridView);
            Controls.Add(refreshButton);
            Controls.Add(orderIsPaidButton);
            Controls.Add(orderIsFinishedButton);
            Controls.Add(giveInProgressButton);
            Controls.Add(createOrderButton);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormMain";
            Text = "FormMain";
            Load += FormMain_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button createOrderButton;
        private Button giveInProgressButton;
        private Button orderIsFinishedButton;
        private Button orderIsPaidButton;
        private Button refreshButton;
        private DataGridView dataGridView;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem справочникиToolStripMenuItem;
        private ToolStripMenuItem компонентыToolStripMenuItem;
        private ToolStripMenuItem изделияToolStripMenuItem;
        private ToolStripMenuItem отчетыToolStripMenuItem;
        private ToolStripMenuItem списокКомпонентовToolStripMenuItem;
        private ToolStripMenuItem компонентыПоИзделиямToolStripMenuItem;
        private ToolStripMenuItem списокЗаказовToolStripMenuItem;
        private Button buttonImplementers;
    }
}