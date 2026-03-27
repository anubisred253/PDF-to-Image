using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDFtoImage;

namespace PixPDF
{
    public partial class Form1 : Form
    {
        private string[]? selectedFilePaths = null;

        public Form1()
        {
            InitializeComponent();

            // 将窗体的 StartPosition 设置为屏幕中央
            this.StartPosition = FormStartPosition.CenterScreen;

            // 禁止窗口最大化和调整尺寸
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // 配置 hint TextBox
            hint.BorderStyle = BorderStyle.None;  // 去掉黑框
            hint.Multiline = true;                // 启用多行
            hint.WordWrap = true;                 // 启用自动换行
            hint.Height = 40; // 设置合适的高度

            // 文件选择按钮点击事件
            selectfile.Click += Selectfile_Click;

            // 转换按钮点击事件
            conversion.Click += Conversion_Click;
        }

        private void Selectfile_Click(object? sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "PDF Files|*.pdf",
                Multiselect = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePaths = openFileDialog.FileNames;
                hint.Text = string.Join(", ", openFileDialog.SafeFileNames);
            }
        }

        private async void Conversion_Click(object? sender, EventArgs e)
        {
            if (selectedFilePaths == null || selectedFilePaths.Length == 0)
            {
                MessageBox.Show("请先选择文件！");
                return;
            }

            // 禁用按钮，防止重复点击
            conversion.Enabled = false;
            selectfile.Enabled = false;
            hint.Text = "正在转换，请稍候...";
            progress.Value = 0;
            total.Text = "0";

            try
            {
                await Task.Run(() =>
                {
                    foreach (var filePath in selectedFilePaths)
                    {
                        ConvertFile(filePath);
                    }
                });

                MessageBox.Show("✅ 所有文件已转换完成！");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"转换过程中出错：{ex.Message}");
            }
            finally
            {
                // 转换完成后恢复按钮
                conversion.Enabled = true;
                selectfile.Enabled = true;
                hint.Text = "请选择 PDF 文件";
            }
        }


        private void ConvertFile(string filePath)
        {
            int totalPageCount = 0;

            // 获取原文件的目录和名称
            string directory = Path.GetDirectoryName(filePath) ?? AppDomain.CurrentDomain.BaseDirectory;
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);

            // 新建一个与 PDF 同名的文件夹
            string outputFolder = Path.Combine(directory, fileNameWithoutExtension);
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }


            // 如果是 PDF 文件
            if (Path.GetExtension(filePath).ToLower() == ".pdf")
            {
                // 将 PDF 转换为图片
                totalPageCount = ConvertPdfToImages(filePath, outputFolder, fileNameWithoutExtension);

            }
        }

        // PDF 转图片 (使用 PDFtoImage / PDFium)
        private int ConvertPdfToImages(string pdfFilePath, string outputDirectory, string baseFileName)
        {
            byte[] pdfBytes = File.ReadAllBytes(pdfFilePath);
            int totalPageCount = Conversion.GetPageCount(pdfBytes);
            RenderOptions renderOptions = new RenderOptions(Dpi: 300, UseTiling: true);

            for (int i = 0; i < totalPageCount; i++)
            {
                string outputPath = Path.Combine(outputDirectory, $"{baseFileName}{(i == 0 ? "" : $"{i + 1}")}.jpg");
                Conversion.SaveJpeg(outputPath, pdfBytes, i, options: renderOptions);

                // 更新 UI
                Invoke(new Action(() =>
                {
                    progress.Value = ((i + 1) * 100) / totalPageCount;
                    total.Text = $"{i + 1}/{totalPageCount}";
                }));
            }

            return totalPageCount;
        }
    }
}
