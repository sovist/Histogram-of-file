using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Screenshot;

namespace Gisto
{
    public partial class FormChart : Form
    {
        private int _indexMin;
        private ulong[] _dataLongs;

        public FormChart(string entropy, UInt64[] masData)
        {
            InitializeComponent();           
            SetChartData(masData, entropy);
        }

        public void SetChartData(UInt64[] masData, string entropy)
        {
            label_entropi.Text = entropy;
            if (masData != null)
            {
                _dataLongs = new ulong[masData.Length];
                Array.Copy(masData, _dataLongs, masData.Length);
                _indexMin = GetIndexMin(_dataLongs);
                labelMinByte.Text = @"Мінімальне значення = " + masData[_indexMin] + @", байт №" + _indexMin;
                SetChart(_dataLongs);
            }
        }

        private void SetChart(UInt64[] masData)
        {
            Series series = new Series { ChartType = SeriesChartType.Column };

            for (int i = 0; i < masData.Length; i++)
                series.Points.Add(new DataPoint(i, masData[i]));

            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.ChartAreas.Add("");

            chart.Series.Add(series);
            chart.Series[0].IsVisibleInLegend = false;
            chart.Series[0].MarkerColor = Color.Red;
            chart.Series[0].Color = Color.Orange;

            ChartArea chartArea = chart.ChartAreas[0];
            chartArea.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;

            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.IntervalOffset = 0;

            chartArea.AxisX.Maximum = masData.Length;
            chartArea.AxisX.Interval = 16;

            chartArea.AxisX.Title = "Номер байта";
            chartArea.AxisY.Title = "Частота байта";

            chartArea.AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chartArea.AxisY.LabelAutoFitStyle = LabelAutoFitStyles.WordWrap;

            chartArea.AxisY.ScaleBreakStyle.StartFromZero = StartFromZero.Yes;
            chartArea.AxisY.ScaleBreakStyle.MaxNumberOfBreaks = 3;
            chartArea.AxisY.ScaleBreakStyle.Enabled = true;
            chartArea.AxisY.ScaleBreakStyle.CollapsibleSpaceThreshold = 10;
            chartArea.AxisY.ScaleBreakStyle.Spacing = 1.5;

            Controls.Add(chart);
            chart.Visible = true;
            UpdateSize();
        }

        private void form_chart_Resize(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void UpdateSize()
        {
            chart.Width = this.Width - 16;
            chart.Height = this.Height - chart.Top - 39;
            label_entropi.Left = (Width - label_entropi.Width) / 2 + 10;
        }

        private int GetIndexMin(ulong[] dataLongs)
        {
            int min = 0;
            ulong minData = dataLongs[0];

            for (int i = 1; i < dataLongs.Length; i++)
                if (dataLongs[i] < minData)
                {
                    minData = dataLongs[i];
                    min = i;
                }
            return min;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ulong[] masLongs = _dataLongs;
            if (checkBox1.Checked)
            {
                 masLongs = new ulong[_dataLongs.Length];
                for (int i = 0; i < _dataLongs.Length; i++)
                    masLongs[i] = _dataLongs[i] - _dataLongs[_indexMin];
            }

            SetChart(masLongs);
        }

        private void вФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int height = chart.Height + (chart.Top - label_entropi.Top);
            WindowScreenshot.SaveInFile(this, "Гістограма", ScreenshotType.ClientRegion, new Rectangle(0, label_entropi.Top, chart.Width, height));
        }

        private void копіюватиВБуферОбмінуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int height = chart.Height + (chart.Top - label_entropi.Top);
            WindowScreenshot.CopyToClipboard(this, ScreenshotType.ClientRegion, new Rectangle(0, label_entropi.Top, chart.Width, height));
        }

        private void колірToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AnyColor = true;
            colorDlg.SolidColorOnly = false;
            colorDlg.Color = Color.Orange;

            if (colorDlg.ShowDialog() == DialogResult.OK)
                chart.Series[0].Color = colorDlg.Color;
        }
    }
}
