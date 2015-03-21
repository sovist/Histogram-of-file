namespace Gisto
{
    partial class FormChart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel1 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChart));
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label_entropi = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.labelMinByte = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.зберегтиЗображенняЯкToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.копіюватиВБуферОбмінуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.колірToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            chartArea2.Area3DStyle.Enable3D = true;
            chartArea2.AxisX.CustomLabels.Add(customLabel1);
            chartArea2.Name = "ChartArea2";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.ChartAreas.Add(chartArea2);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(0, 50);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea2";
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            this.chart.Series.Add(series1);
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(300, 300);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart1";
            this.chart.Visible = false;
            // 
            // label_entropi
            // 
            this.label_entropi.AutoSize = true;
            this.label_entropi.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_entropi.Location = new System.Drawing.Point(4, 31);
            this.label_entropi.Name = "label_entropi";
            this.label_entropi.Size = new System.Drawing.Size(38, 15);
            this.label_entropi.TabIndex = 1;
            this.label_entropi.Text = "label1";
            this.toolTip1.SetToolTip(this.label_entropi, "Оцінка ентропії та середньо квадратичного відхилення частоти байтів (сігма)");
            // 
            // labelMinByte
            // 
            this.labelMinByte.AutoSize = true;
            this.labelMinByte.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.labelMinByte.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelMinByte.Location = new System.Drawing.Point(328, 5);
            this.labelMinByte.Name = "labelMinByte";
            this.labelMinByte.Size = new System.Drawing.Size(38, 15);
            this.labelMinByte.TabIndex = 6;
            this.labelMinByte.Text = "label1";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.checkBox1.Location = new System.Drawing.Point(201, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(122, 19);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Вирівняти по min";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.зберегтиЗображенняЯкToolStripMenuItem,
            this.колірToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(688, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // зберегтиЗображенняЯкToolStripMenuItem
            // 
            this.зберегтиЗображенняЯкToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вФайлToolStripMenuItem,
            this.копіюватиВБуферОбмінуToolStripMenuItem});
            this.зберегтиЗображенняЯкToolStripMenuItem.Name = "зберегтиЗображенняЯкToolStripMenuItem";
            this.зберегтиЗображенняЯкToolStripMenuItem.Size = new System.Drawing.Size(139, 20);
            this.зберегтиЗображенняЯкToolStripMenuItem.Text = "Зберегти зображення";
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
            // колірToolStripMenuItem
            // 
            this.колірToolStripMenuItem.Name = "колірToolStripMenuItem";
            this.колірToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.колірToolStripMenuItem.Text = "Колір";
            this.колірToolStripMenuItem.Click += new System.EventHandler(this.колірToolStripMenuItem_Click);
            // 
            // FormChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(688, 385);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.labelMinByte);
            this.Controls.Add(this.label_entropi);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Гістограма байтів вхідного файлу";
            this.Resize += new System.EventHandler(this.form_chart_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Label label_entropi;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label labelMinByte;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem зберегтиЗображенняЯкToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem копіюватиВБуферОбмінуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem колірToolStripMenuItem;
    }
}