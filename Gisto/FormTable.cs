using System;
using System.Drawing;
using System.Windows.Forms;
using Screenshot;

namespace Gisto
{
    public partial class FormTable : Form
    {
        private FormChart _formchart; //графік
        private UInt64[] _data;

        public delegate void CellClick(int byteIndex, ulong cellData);
        public event CellClick OnCellClick;

        public new void Show()
        {          
            base.Show();
            TableAutoSize();
            _formchart.Show();

            _formchart.Top = Top;
            _formchart.Left = Width;
        }

        public new void Close()
        {
            if (_formchart != null)
                _formchart.Close();
            base.Close();
        }

        public FormTable(UInt64[] inData, string entropy, string formName = "")
        {
            InitializeComponent();

            if (formName != "")
               base.Text = formName;
           
            SetData(inData, entropy);
            comboBox_table_width.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int coulumn = int.Parse(comboBox_table_width.Text);
            int row = (int) Math.Ceiling(256/(double) (coulumn));
            SetDataView(coulumn, row);
        }

        public void SetData(UInt64[] inData, string entropy)
        {
            label_entropi.Text = entropy;
            _data = new ulong[inData.Length];
            Array.Copy(inData, _data, inData.Length);
            int coulumn = comboBox_table_width.SelectedIndex + 8;
            int row = (int) Math.Ceiling(256/(double) (coulumn));
            SetDataView(coulumn, row);

            if (_formchart == null)
            {
                _formchart = new FormChart(entropy, _data);
                _formchart.Closing += ((sender, args) => _formchart = null);
                _formchart.Text = Text;
            }
            else
                _formchart.SetChartData(_data, entropy);
        }

        private void SetDataView(int tebleWidth, int tebleHeight)
        {
            data_view.Visible = false;
            Application.DoEvents();
            
            Create(data_view, tebleWidth, tebleHeight);

            if (_data != null)
                for (int i = 0, j, k = 0, m = 0; i < data_view.RowCount; i++, m += data_view.ColumnCount - 1)  //виведення даних в таблицю
                {
                    data_view.Rows[i].Cells[0].Value = "[" + m + "]";
                    for (j = 1; j < data_view.ColumnCount; j++, k++)
                        if (k < _data.Length)
                            data_view.Rows[i].Cells[j].Value = _data[k];
                        else
                            data_view.Rows[i].Cells[j].Value = "-";
                }

            TableAutoSize();
            data_view.Visible = true;
            Application.DoEvents();           
        }

        private void TableAutoSize()
        {
            data_view.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            int sumaryWidth = 0;
            for (int i = 0; i < data_view.ColumnCount; i++) //підрахунок ширини таблиці          
                sumaryWidth += data_view.Columns[i].Width;

            data_view.Width = sumaryWidth + 3;
            Width = data_view.Width + 16;
            Height = data_view.Top + data_view.Height + 39;
        }

        private static void Create(DataGridView dataGridView, int width, int heigth, int startNumbering = 0, int columnWidth = 26)
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            dataGridView.Columns.Add("", "dec");
            dataGridView.Columns[0].Width = columnWidth;
            dataGridView.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            for (int i = 1; i < width + 1; i++)
            {
                dataGridView.Columns.Add("", "[" + (i - 1 + startNumbering) + "]");
                dataGridView.Columns[i].Width = columnWidth;
                dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            for (int i = 0, j; i < heigth; i++)
            {
                dataGridView.Rows.Add("[" + (i + startNumbering) + "]", "");

                if (i%2 == 0)
                    for (j = 1; j < dataGridView.ColumnCount; j++)
                        dataGridView.Rows[i].Cells[j].Style.BackColor = Color.LightGray; //.AntiqueWhite;

            }
            dataGridView.ColumnHeadersHeight = 21;

            dataGridView.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView.RowsDefaultCellStyle.SelectionBackColor = Color.AliceBlue;

            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Height = 22*dataGridView.RowCount + 23;
            dataGridView.Width = columnWidth*dataGridView.ColumnCount + 3;
        }

        private void data_view_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (OnCellClick != null && e.ColumnIndex > 0 && e.RowIndex > -1)
            {
                string data = data_view.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (data != "-")
                {
                    int byteIndex = (e.RowIndex)*(data_view.ColumnCount - 1) + (e.ColumnIndex - 1);
                    OnCellClick(byteIndex, ulong.Parse(data));
                }
            }
        }

        private void вФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int height = data_view.Height + (data_view.Top - label_entropi.Top);
            WindowScreenshot.SaveInFile(this, "ГістоТаблиця", ScreenshotType.ClientRegion, new Rectangle(0, label_entropi.Top, data_view.Width, height));
        }

        private void копіюватиВБуферОбмінуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int height = data_view.Height + (data_view.Top - label_entropi.Top);
            WindowScreenshot.CopyToClipboard(this, ScreenshotType.ClientRegion, new Rectangle(0, label_entropi.Top, data_view.Width, height));
        }
    }
}