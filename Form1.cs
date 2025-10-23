using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ghostscript.NET.Rasterizer;
using System.Drawing.Imaging;
using Ghostscript.NET;

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

        private void Selectfile_Click(object sender, EventArgs e)
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

        private async void Conversion_Click(object sender, EventArgs e)
        {
            if (selectedFilePaths == null || selectedFilePaths.Length == 0)
            {
                MessageBox.Show("请先选择文件！");
                return;
            }

            progress.Value = 0;

            // 遍历所有选中的 PDF 文件
            await Task.Run(() =>
            {
                foreach (var filePath in selectedFilePaths)
                {
                    ConvertFile(filePath);
                }
            });

            MessageBox.Show("所有文件已转换完成！");
        }

        private void ConvertFile(string filePath)
        {
            int totalPageCount = 0;

            // 获取原文件的目录和名称
            string directory = Path.GetDirectoryName(filePath);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);

            // 如果是 PDF 文件
            if (Path.GetExtension(filePath).ToLower() == ".pdf")
            {
                // 将 PDF 转换为图片
                totalPageCount = ConvertPdfToImages(filePath, directory, fileNameWithoutExtension);
            }
        }

        // PDF 转图片 (使用 Ghostscript.NET)
        private int ConvertPdfToImages(string pdfFilePath, string outputDirectory, string baseFileName)
        {
            int totalPageCount = 0;

            // 获取当前 EXE 所在的目录
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Ghostscript DLL 的完整路径 (gsdll64.dll 或 gsdll32.dll)
            string ghostscriptDllPath = Path.Combine(exeDirectory, "gsdll64.dll");

            // 加载 DLL
            IntPtr handle = LoadLibrary(ghostscriptDllPath);
            if (handle == IntPtr.Zero)
            {
                MessageBox.Show("无法加载 Ghostscript DLL，请确保 gsdll64.dll 存在于程序目录中。");
                return 0;
            }

            // 创建 Ghostscript 版本信息对象，指定 gsdll64.dll 的路径
            GhostscriptVersionInfo gvi = new GhostscriptVersionInfo(ghostscriptDllPath);

            // 创建 GhostscriptRasterizer 对象
            using (var rasterizer = new GhostscriptRasterizer())
            {
                // 添加 -dNOSAFER 选项以禁用安全模式
                rasterizer.CustomSwitches.Add("-dNOSAFER");

                // 打开 PDF 文件
                rasterizer.Open(pdfFilePath, gvi, false);

                // 获取页面总数
                totalPageCount = rasterizer.PageCount;

                // 遍历每一页，将每页转换为图片
                for (int i = 1; i <= totalPageCount; i++)
                {
                    Image img = rasterizer.GetPage(300, i);  // 渲染第 i 页为图片
                    string outputPath = Path.Combine(outputDirectory, $"{baseFileName}{(i == 1 ? "" : $"{i}")}.jpg");
                    img.Save(outputPath, ImageFormat.Jpeg);

                    // 更新 UI
                    Invoke(new Action(() =>
                    {
                        progress.Value = (i * 100) / totalPageCount;
                        total.Text = $"{i}/{totalPageCount}";
                    }));
                }
            }

            return totalPageCount;
        }

        [System.Runtime.InteropServices.DllImport("kernel32", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern IntPtr LoadLibrary(string lpFileName);
    }
}
