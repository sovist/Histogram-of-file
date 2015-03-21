namespace Gisto
{
    partial class FormTable
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTable));
            this.comboBox_table_width = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_entropi = new System.Windows.Forms.Label();
            this.data_view = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.зберегтиЗображенняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.копіюватиВБуферОбмінуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.data_view)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_table_width
            // 
            this.comboBox_table_width.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_table_width.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comboBox_table_width.FormattingEnabled = true;
            this.comboBox_table_width.Items.AddRange(new object[] {
            "8",
            "10",
            "16"});
            this.comboBox_table_width.Location = new System.Drawing.Point(223, 1);
            this.comboBox_table_width.Name = "comboBox_table_width";
            this.comboBox_table_width.Size = new System.Drawing.Size(38, 23);
            this.comboBox_table_width.TabIndex = 0;
            this.toolTip1.SetToolTip(this.comboBox_table_width, "ширина таблиці(в стовпчиках)");
            this.comboBox_table_width.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(152, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cтовпчики";
            // 
            // label_entropi
            // 
            this.label_entropi.AutoSize = true;
            this.label_entropi.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_entropi.Location = new System.Drawing.Point(4, 30);
            this.label_entropi.Name = "label_entropi";
            this.label_entropi.Size = new System.Drawing.Size(38, 15);
            this.label_entropi.TabIndex = 2;
            this.label_entropi.Text = "label2";
            this.toolTip1.SetToolTip(this.label_entropi, "Оцінка ентропії та середньо квадратичного відхилення частоти байтів (сігма)");
            // 
            // data_view
            // 
            this.data_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_view.Location = new System.Drawing.Point(0, 48);
            this.data_view.Name = "data_view";
            this.data_view.Size = new System.Drawing.Size(240, 150);
            this.data_view.TabIndex = 3;
            this.data_view.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_view_CellClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.зберегтиЗображенняToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(360, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // зберегтиЗображенняToolStripMenuItem
            // 
            this.зберегтиЗображенняToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вФайлToolStripMenuItem,
            this.копіюватиВБуферОбмінуToolStripMenuItem});
            this.зберегтиЗображенняToolStripMenuItem.Name = "зберегтиЗображенняToolStripMenuItem";
            this.зберегтиЗображенняToolStripMenuItem.Size = new System.Drawing.Size(139, 20);
            this.зберегтиЗображенняToolStripMenuItem.Text = "Зберегти зображення";
            // 
            // вФайлToolStripMenuItem
            // 
            this.вФайлToolStripMenuItem.Name = "вФайлToolStripMenuItem";
            this.вФайлToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.вФайлToolStripMenuItem.Text = "В файл...";
            this.вФайлToolStripMenuItem.Click += new System.EventHandler(this.вФайлToolStripMenuItem_Click);
            // 
            // копіюватиВБуферОбмінуToolStripMenuItem
            // 
            this.копіюватиВБуферОбмінуToolStripMenuItem.Name = "копіюватиВБуферОбмінуToolStripMenuItem";
            this.копіюватиВБуферОбмінуToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.копіюватиВБуферОбмінуToolStripMenuItem.Text = "Копіювати в буфер обміну";
            this.копіюватиВБуферОбмінуToolStripMenuItem.Click += new System.EventHandler(this.копіюватиВБуферОбмінуToolStripMenuItem_Click);
            // 
            // FormTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(360, 215);
            this.Controls.Add(this.data_view);
            this.Controls.Add(this.label_entropi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_table_width);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Статистика байтів вхідного файлу";
            ((System.ComponentModel.ISupportInitialize)(this.data_view)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_table_width;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_entropi;
        public System.Windows.Forms.DataGridView data_view;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem зберегтиЗображенняToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem копіюватиВБуферОбмінуToolStripMenuItem;
    }
}