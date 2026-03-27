using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDFtoImage;

namespace PdfToImageApp
{
    public partial class Form1 : Form
    {
        private string[]? selectedFilePaths;

        public Form1()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            selectfile.Click += Selectfile_Click;
            conversion.Click += Conversion_Click;

            dropPanel.DragEnter += DropPanel_DragEnter;
            dropPanel.DragDrop += DropPanel_DragDrop;
            dropPanel.Click += DropPanel_Click;
            dropHintLabel.Click += DropPanel_Click;
            fileSummaryLabel.Click += DropPanel_Click;

            UpdateSelectedFiles(null);
        }

        private void Selectfile_Click(object? sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "PDF Files|*.pdf",
                Multiselect = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                UpdateSelectedFiles(openFileDialog.FileNames);
            }
        }

        private void DropPanel_Click(object? sender, EventArgs e)
        {
            Selectfile_Click(sender, e);
        }

        private void DropPanel_DragEnter(object? sender, DragEventArgs e)
        {
            string[] files = GetPdfFilesFromDragData(e.Data);
            e.Effect = files.Length > 0 ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void DropPanel_DragDrop(object? sender, DragEventArgs e)
        {
            string[] files = GetPdfFilesFromDragData(e.Data);
            if (files.Length == 0)
            {
                MessageBox.Show("请拖入一个或多个 PDF 文件。");
                return;
            }

            UpdateSelectedFiles(files);
        }

        private async void Conversion_Click(object? sender, EventArgs e)
        {
            if (selectedFilePaths == null || selectedFilePaths.Length == 0)
            {
                MessageBox.Show("请先选择文件！");
                return;
            }

            conversion.Enabled = false;
            selectfile.Enabled = false;
            dropPanel.Enabled = false;
            progress.Value = 0;
            total.Text = $"准备转换 0/{selectedFilePaths.Length}";

            try
            {
                await Task.Run(() =>
                {
                    int fileCount = selectedFilePaths.Length;

                    for (int fileIndex = 0; fileIndex < fileCount; fileIndex++)
                    {
                        string filePath = selectedFilePaths[fileIndex];
                        ConvertFile(filePath, fileIndex, fileCount);
                    }
                });

                MessageBox.Show("✅ 所有文件已转换完成！");
                UpdateSelectedFiles(selectedFilePaths);
                total.Text = $"已完成 {selectedFilePaths.Length}/{selectedFilePaths.Length}";
                progress.Value = 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"转换过程中出错：{ex.Message}");
                total.Text = "转换失败";
            }
            finally
            {
                conversion.Enabled = true;
                selectfile.Enabled = true;
                dropPanel.Enabled = true;
            }
        }

        private void ConvertFile(string filePath, int fileIndex, int totalFiles)
        {
            string directory = Path.GetDirectoryName(filePath) ?? AppDomain.CurrentDomain.BaseDirectory;
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
            string outputFolder = GetOutputFolder(directory, fileNameWithoutExtension);

            Directory.CreateDirectory(outputFolder);

            if (Path.GetExtension(filePath).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
            {
                ConvertPdfToImages(filePath, outputFolder, fileNameWithoutExtension, fileIndex, totalFiles);
            }
        }

        private string GetOutputFolder(string directory, string fileNameWithoutExtension)
        {
            return subDirectoryOption.Checked
                ? Path.Combine(directory, fileNameWithoutExtension)
                : directory;
        }

        // PDF 转图片 (使用 PDFtoImage / PDFium)
        private void ConvertPdfToImages(string pdfFilePath, string outputDirectory, string baseFileName, int fileIndex, int totalFiles)
        {
            byte[] pdfBytes = File.ReadAllBytes(pdfFilePath);
            int totalPageCount = Conversion.GetPageCount(pdfBytes);
            RenderOptions renderOptions = new RenderOptions(Dpi: 300, UseTiling: true);

            for (int pageIndex = 0; pageIndex < totalPageCount; pageIndex++)
            {
                string outputPath = Path.Combine(
                    outputDirectory,
                    $"{baseFileName}{(pageIndex == 0 ? "" : $"{pageIndex + 1}")}.jpg");

                Conversion.SaveJpeg(outputPath, pdfBytes, pageIndex, options: renderOptions);

                Invoke(new Action(() =>
                {
                    progress.Value = (int)Math.Round(((fileIndex + ((pageIndex + 1d) / totalPageCount)) / totalFiles) * 100);
                    total.Text = $"文件 {fileIndex + 1}/{totalFiles} · 第 {pageIndex + 1}/{totalPageCount} 页";
                }));
            }
        }

        private void UpdateSelectedFiles(string[]? filePaths)
        {
            selectedFilePaths = filePaths?
                .Where(path => path.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToArray();

            if (selectedFilePaths == null || selectedFilePaths.Length == 0)
            {
                selectedFilePaths = null;
                fileSummaryLabel.Text = "当前未选择文件";
                dropHintLabel.Text = "拖拽 PDF 到这里，或点击选择文件";
                total.Text = "未开始转换";
                progress.Value = 0;
                return;
            }

            if (selectedFilePaths.Length == 1)
            {
                fileSummaryLabel.Text = Path.GetFileName(selectedFilePaths[0]);
            }
            else
            {
                string previewNames = string.Join("、", selectedFilePaths.Take(3).Select(Path.GetFileName));
                if (selectedFilePaths.Length > 3)
                {
                    previewNames += $" 等 {selectedFilePaths.Length} 个文件";
                }

                fileSummaryLabel.Text = previewNames;
            }

            dropHintLabel.Text = $"已选择 {selectedFilePaths.Length} 个 PDF 文件";
            total.Text = "等待开始转换";
        }

        private static string[] GetPdfFilesFromDragData(IDataObject? data)
        {
            if (data?.GetData(DataFormats.FileDrop) is not string[] droppedFiles)
            {
                return Array.Empty<string>();
            }

            return droppedFiles
                .Where(path => File.Exists(path) && path.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
                .ToArray();
        }
    }
}
