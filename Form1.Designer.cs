namespace PixPDF
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
            progress = new ProgressBar();
            selectfile = new Button();
            conversion = new Button();
            total = new Label();
            hint = new TextBox();
            SuspendLayout();
            // 
            // progress
            // 
            progress.Location = new Point(79, 161);
            progress.Margin = new Padding(5, 4, 5, 4);
            progress.Name = "progress";
            progress.Size = new Size(416, 32);
            progress.TabIndex = 1;
            // 
            // selectfile
            // 
            selectfile.Location = new Point(79, 86);
            selectfile.Margin = new Padding(5, 4, 5, 4);
            selectfile.Name = "selectfile";
            selectfile.Size = new Size(118, 42);
            selectfile.TabIndex = 2;
            selectfile.Text = "选择文件";
            selectfile.UseVisualStyleBackColor = true;
            // 
            // conversion
            // 
            conversion.Location = new Point(377, 86);
            conversion.Margin = new Padding(5, 4, 5, 4);
            conversion.Name = "conversion";
            conversion.Size = new Size(118, 42);
            conversion.TabIndex = 3;
            conversion.Text = "开始转换";
            conversion.UseVisualStyleBackColor = true;
            // 
            // total
            // 
            total.AutoSize = true;
            total.BackColor = Color.Transparent;
            total.Location = new Point(275, 206);
            total.Margin = new Padding(5, 0, 5, 0);
            total.Name = "total";
            total.Size = new Size(21, 24);
            total.TabIndex = 4;
            total.Text = "0";
            // 
            // hint
            // 
            hint.ForeColor = Color.Transparent;
            hint.Location = new Point(19, 17);
            hint.Margin = new Padding(5, 4, 5, 4);
            hint.Name = "hint";
            hint.ReadOnly = true;
            hint.Size = new Size(534, 30);
            hint.TabIndex = 6;
            hint.Text = "请选择 PDF 文件";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(574, 253);
            Controls.Add(hint);
            Controls.Add(total);
            Controls.Add(conversion);
            Controls.Add(selectfile);
            Controls.Add(progress);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 4, 5, 4);
            Name = "Form1";
            Text = "PixPDF by 龙骑兵 / 里屋";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ProgressBar progress;
        private Button selectfile;
        private Button conversion;
        private Label total;
        private TextBox hint;
    }
}
