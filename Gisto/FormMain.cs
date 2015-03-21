using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Gisto
{
    public partial class FormMain : Form
    {
        private Thread _threadCoding;
        private Thread _threadDone;
        private DateTime _dtStart;
        private ulong[] _byteFreqOriginalFile;
        private string _originalFileName;
        private double _entropy;
        private double _sigma;
        private string _fileSize;
        private FormTable _formTable;

        public FormMain()
        {
            InitializeComponent();
            labelTime.Text = @"Час розрахунку: -";
        }

        private void buttonInputFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxInputFile.Text = _originalFileName = openFileDialog.FileName;
               
                labelTime.Text = @"Час розрахунку: 00:00:00.00";
                _fileSize = new FileSizeInfo(_originalFileName).ShortForm;
                labelFileSize.Text = @"Розмір - " + _fileSize;
                labelInFileEntropy.Text = @"Ентропія - розрахунок..." + Environment.NewLine + @"Сігма - розрахунок...";
                файлToolStripMenuItem.Enabled = false;
                Application.DoEvents();
                               
                _threadCoding = new Thread(CalcEntropi);
                _threadDone = new Thread(DoneAfterCoding);
                progressBar1.Value = 0;
                progressBar1.Visible = true;
                _dtStart = DateTime.Now;
                _threadCoding.Start();
                _threadDone.Start();
            }
        }

        private void CalcEntropi()
        {
            _entropy = Entropy.Calculate(_originalFileName, out _byteFreqOriginalFile, UpdatePogressbar);
        }

        public void UpdatePogressbar(int value)
        {
            Action<int> progress = (value1 =>
            {
                try
                {
                    labelTime.Text = @"Час розрахунку: " + (DateTime.Now - _dtStart).ToString().Substring(0, 12);
                }
                catch (ArgumentOutOfRangeException) { }

                progressBar1.Value = value1;
            });
            Invoke(new MethodInvoker(() => progress(value)));
        }

        private void DoneAfterCoding()
        {
            bool flag = true;
            while (flag)
                if (_threadCoding.IsAlive)
                    Thread.Sleep(200);
                else
                {
                    flag = false;
                    Done();
                }
        }

        private void Done()
        {
            Action done = () =>
            {
                _sigma = Sigma(_byteFreqOriginalFile);
                labelInFileEntropy.Text = @"Ентропія - " + _entropy + Environment.NewLine +  @"Сігма - " + _sigma;
                файлToolStripMenuItem.Enabled = true;
                groupBoxFile.Enabled = true;
                progressBar1.Visible = false;
                string info = "H = " + _entropy + "       σ = " + _sigma;

                if(_formTable != null)
                    _formTable.Close();

                _formTable = new FormTable(_byteFreqOriginalFile, info, _originalFileName) {Left = 0, Top = 0};
                _formTable.Closing += (sender, args) => _formTable = null;
                _formTable.Show();
                this.Focus();
            };
            Invoke(new MethodInvoker(done));
        }

        private double Sigma(ulong[] masData)
        {
            double n = masData.Sum(arg => (double)arg), m = n / masData.Length, sigma = masData.Sum(t => Math.Pow(t - m, 2));
            return Math.Sqrt(sigma / n);
        }

        private void зберегтиЯкToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = @"Введіть ім'я файлу",
                DefaultExt = @".gisto",
                FileName = @"gisto.gisto",
                Filter = @"Файли гісто (*.gisto)|*.gisto|Всі файли (*.*)|*.*",
                InitialDirectory = Application.StartupPath
            };

            if (_formTable != null)
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                    sw.Close();

                    using (BinaryWriter fileWrite = new BinaryWriter(File.Open(saveFileDialog.FileName, FileMode.Open, FileAccess.Write)))
                    {
                        for (int i = 0; i < _byteFreqOriginalFile.Length; i++)
                            fileWrite.Write(_byteFreqOriginalFile[i]);
                        fileWrite.Write(_entropy);
                        fileWrite.Write(_sigma);
                        fileWrite.Write(_fileSize);
                        fileWrite.Write(_originalFileName);
                    }
                }
        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Виберіть файл який потрібно відкрити",
                Filter = "Файли гісто (*.gisto)|*.gisto|Всі файли (*.*)|*.*",
                InitialDirectory = Application.StartupPath
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (BinaryReader fileRead = new BinaryReader(File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read)))
                {
                    ulong[] data = new ulong[256];
                    for (int i = 0; i < 256; i++)
                        data[i] = fileRead.ReadUInt64();

                    _entropy = fileRead.ReadDouble();
                    _sigma = fileRead.ReadDouble();
                    _byteFreqOriginalFile = data;
                    labelFileSize.Text = _fileSize = fileRead.ReadString();
                    _originalFileName = fileRead.ReadString();

                    labelInFileEntropy.Text = @"Ентропія - " + _entropy + Environment.NewLine + @"Сігма - " + _sigma;
                    string info = "H = " + _entropy + "       σ = " + _sigma;

                    if (_formTable != null)
                        _formTable.Close();

                    _formTable = new FormTable(_byteFreqOriginalFile, info, _originalFileName) { Left = 0, Top = 0 };
                    _formTable.Closing += (sender0, args) => _formTable = null;
                    _formTable.Show();
                    this.Focus();
                }
            }
        }
    }
}
