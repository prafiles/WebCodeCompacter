namespace WebCodeCompacter
{
    partial class MainWindow
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
            this.txt_FileName = new System.Windows.Forms.TextBox();
            this.lbl_FileName = new System.Windows.Forms.Label();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lbl_Total = new System.Windows.Forms.Label();
            this.lbl_CompressedRatio = new System.Windows.Forms.Label();
            this.lbl_Output = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.rtb_CompressedCode = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txt_FileName
            // 
            this.txt_FileName.Location = new System.Drawing.Point(75, 12);
            this.txt_FileName.Name = "txt_FileName";
            this.txt_FileName.Size = new System.Drawing.Size(391, 20);
            this.txt_FileName.TabIndex = 0;
            // 
            // lbl_FileName
            // 
            this.lbl_FileName.AutoSize = true;
            this.lbl_FileName.Location = new System.Drawing.Point(12, 15);
            this.lbl_FileName.Name = "lbl_FileName";
            this.lbl_FileName.Size = new System.Drawing.Size(60, 13);
            this.lbl_FileName.TabIndex = 1;
            this.lbl_FileName.Text = "File Name :";
            // 
            // btn_Browse
            // 
            this.btn_Browse.Location = new System.Drawing.Point(484, 10);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(75, 23);
            this.btn_Browse.TabIndex = 2;
            this.btn_Browse.Text = "Browse";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // lbl_Total
            // 
            this.lbl_Total.AutoSize = true;
            this.lbl_Total.Location = new System.Drawing.Point(12, 45);
            this.lbl_Total.Name = "lbl_Total";
            this.lbl_Total.Size = new System.Drawing.Size(93, 13);
            this.lbl_Total.TabIndex = 3;
            this.lbl_Total.Text = "Total Processed : ";
            // 
            // lbl_CompressedRatio
            // 
            this.lbl_CompressedRatio.AutoSize = true;
            this.lbl_CompressedRatio.Location = new System.Drawing.Point(398, 45);
            this.lbl_CompressedRatio.Name = "lbl_CompressedRatio";
            this.lbl_CompressedRatio.Size = new System.Drawing.Size(102, 13);
            this.lbl_CompressedRatio.TabIndex = 4;
            this.lbl_CompressedRatio.Text = "Compressed Ratio : ";
            // 
            // lbl_Output
            // 
            this.lbl_Output.AutoSize = true;
            this.lbl_Output.Location = new System.Drawing.Point(223, 45);
            this.lbl_Output.Name = "lbl_Output";
            this.lbl_Output.Size = new System.Drawing.Size(48, 13);
            this.lbl_Output.TabIndex = 5;
            this.lbl_Output.Text = "Output : ";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(15, 66);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(544, 13);
            this.progressBar.TabIndex = 6;
            // 
            // rtb_CompressedCode
            // 
            this.rtb_CompressedCode.Location = new System.Drawing.Point(15, 92);
            this.rtb_CompressedCode.Name = "rtb_CompressedCode";
            this.rtb_CompressedCode.Size = new System.Drawing.Size(544, 260);
            this.rtb_CompressedCode.TabIndex = 7;
            this.rtb_CompressedCode.Text = "";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 364);
            this.Controls.Add(this.rtb_CompressedCode);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lbl_Output);
            this.Controls.Add(this.lbl_CompressedRatio);
            this.Controls.Add(this.lbl_Total);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.lbl_FileName);
            this.Controls.Add(this.txt_FileName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Web Code Compacter";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_FileName;
        private System.Windows.Forms.Label lbl_FileName;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label lbl_Total;
        private System.Windows.Forms.Label lbl_CompressedRatio;
        private System.Windows.Forms.Label lbl_Output;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.RichTextBox rtb_CompressedCode;
    }
}

