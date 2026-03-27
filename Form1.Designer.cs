namespace PdfToImageApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            titleLabel = new Label();
            subtitleLabel = new Label();
            dropPanel = new Panel();
            dropHintLabel = new Label();
            fileSummaryLabel = new Label();
            outputGroup = new GroupBox();
            sameDirectoryOption = new RadioButton();
            subDirectoryOption = new RadioButton();
            selectfile = new Button();
            conversion = new Button();
            progress = new ProgressBar();
            total = new Label();
            dropPanel.SuspendLayout();
            outputGroup.SuspendLayout();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Microsoft YaHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 134);
            titleLabel.ForeColor = Color.FromArgb(31, 41, 55);
            titleLabel.Location = new Point(28, 22);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(236, 40);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "PDF to Image";
            // 
            // subtitleLabel
            // 
            subtitleLabel.AutoSize = true;
            subtitleLabel.Font = new Font("Microsoft YaHei UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            subtitleLabel.ForeColor = Color.FromArgb(107, 114, 128);
            subtitleLabel.Location = new Point(31, 71);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(343, 24);
            subtitleLabel.TabIndex = 1;
            subtitleLabel.Text = "支持批量选择 PDF，也支持拖拽到下方区域";
            // 
            // dropPanel
            // 
            dropPanel.AllowDrop = true;
            dropPanel.BackColor = Color.FromArgb(247, 250, 252);
            dropPanel.BorderStyle = BorderStyle.FixedSingle;
            dropPanel.Controls.Add(dropHintLabel);
            dropPanel.Controls.Add(fileSummaryLabel);
            dropPanel.Location = new Point(31, 113);
            dropPanel.Name = "dropPanel";
            dropPanel.Size = new Size(632, 150);
            dropPanel.TabIndex = 2;
            // 
            // dropHintLabel
            // 
            dropHintLabel.AutoSize = true;
            dropHintLabel.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 134);
            dropHintLabel.ForeColor = Color.FromArgb(37, 99, 235);
            dropHintLabel.Location = new Point(145, 36);
            dropHintLabel.Name = "dropHintLabel";
            dropHintLabel.Size = new Size(327, 31);
            dropHintLabel.TabIndex = 0;
            dropHintLabel.Text = "拖拽 PDF 到这里，或点击选择文件";
            // 
            // fileSummaryLabel
            // 
            fileSummaryLabel.Font = new Font("Microsoft YaHei UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            fileSummaryLabel.ForeColor = Color.FromArgb(75, 85, 99);
            fileSummaryLabel.Location = new Point(27, 84);
            fileSummaryLabel.Name = "fileSummaryLabel";
            fileSummaryLabel.Size = new Size(576, 42);
            fileSummaryLabel.TabIndex = 1;
            fileSummaryLabel.Text = "当前未选择文件";
            fileSummaryLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // outputGroup
            // 
            outputGroup.Controls.Add(sameDirectoryOption);
            outputGroup.Controls.Add(subDirectoryOption);
            outputGroup.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            outputGroup.ForeColor = Color.FromArgb(31, 41, 55);
            outputGroup.Location = new Point(31, 282);
            outputGroup.Name = "outputGroup";
            outputGroup.Size = new Size(632, 95);
            outputGroup.TabIndex = 3;
            outputGroup.TabStop = false;
            outputGroup.Text = "输出位置";
            // 
            // sameDirectoryOption
            // 
            sameDirectoryOption.AutoSize = true;
            sameDirectoryOption.Font = new Font("Microsoft YaHei UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            sameDirectoryOption.Location = new Point(304, 42);
            sameDirectoryOption.Name = "sameDirectoryOption";
            sameDirectoryOption.Size = new Size(203, 28);
            sameDirectoryOption.TabIndex = 1;
            sameDirectoryOption.Text = "生成在 PDF 当前目录下";
            sameDirectoryOption.UseVisualStyleBackColor = true;
            // 
            // subDirectoryOption
            // 
            subDirectoryOption.AutoSize = true;
            subDirectoryOption.Checked = true;
            subDirectoryOption.Font = new Font("Microsoft YaHei UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            subDirectoryOption.Location = new Point(27, 42);
            subDirectoryOption.Name = "subDirectoryOption";
            subDirectoryOption.Size = new Size(251, 28);
            subDirectoryOption.TabIndex = 0;
            subDirectoryOption.TabStop = true;
            subDirectoryOption.Text = "生成在与 PDF 同名的子目录中";
            subDirectoryOption.UseVisualStyleBackColor = true;
            // 
            // selectfile
            // 
            selectfile.BackColor = Color.White;
            selectfile.FlatStyle = FlatStyle.Flat;
            selectfile.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            selectfile.ForeColor = Color.FromArgb(31, 41, 55);
            selectfile.Location = new Point(31, 396);
            selectfile.Name = "selectfile";
            selectfile.Size = new Size(190, 48);
            selectfile.TabIndex = 4;
            selectfile.Text = "选择 PDF 文件";
            selectfile.UseVisualStyleBackColor = false;
            // 
            // conversion
            // 
            conversion.BackColor = Color.FromArgb(37, 99, 235);
            conversion.FlatStyle = FlatStyle.Flat;
            conversion.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            conversion.ForeColor = Color.White;
            conversion.Location = new Point(473, 396);
            conversion.Name = "conversion";
            conversion.Size = new Size(190, 48);
            conversion.TabIndex = 5;
            conversion.Text = "开始转换";
            conversion.UseVisualStyleBackColor = false;
            // 
            // progress
            // 
            progress.Location = new Point(31, 468);
            progress.Name = "progress";
            progress.Size = new Size(632, 26);
            progress.TabIndex = 6;
            // 
            // total
            // 
            total.Font = new Font("Microsoft YaHei UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            total.ForeColor = Color.FromArgb(75, 85, 99);
            total.Location = new Point(31, 505);
            total.Name = "total";
            total.Size = new Size(632, 24);
            total.TabIndex = 7;
            total.Text = "未开始转换";
            total.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(694, 551);
            Controls.Add(total);
            Controls.Add(progress);
            Controls.Add(conversion);
            Controls.Add(selectfile);
            Controls.Add(outputGroup);
            Controls.Add(dropPanel);
            Controls.Add(subtitleLabel);
            Controls.Add(titleLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "PDF to Image";
            dropPanel.ResumeLayout(false);
            dropPanel.PerformLayout();
            outputGroup.ResumeLayout(false);
            outputGroup.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Label subtitleLabel;
        private Panel dropPanel;
        private Label dropHintLabel;
        private Label fileSummaryLabel;
        private GroupBox outputGroup;
        private RadioButton sameDirectoryOption;
        private RadioButton subDirectoryOption;
        private Button selectfile;
        private Button conversion;
        private ProgressBar progress;
        private Label total;
    }
}
