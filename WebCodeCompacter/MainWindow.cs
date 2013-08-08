using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WebCodeCompacter
{
    public partial class MainWindow : Form
    {
        delegate void SetTextCallback(string text);
        delegate void SetProgessBarCallback(int value);
        delegate void SetTotalValueCallback(long value);
        delegate void SetOutputValueCallback(long value);
        delegate void SetCompresssedRatioCallback(float value);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (MessageBox.Show("This project is for free purposes only and can be used for commercial production or can be redestributed by express consent from the developer.", "License", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                this.Close();
            }
            rtb_CompressedCode.ScrollBars = RichTextBoxScrollBars.Vertical;
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            rtb_CompressedCode.Text = "";
            processFile();
        }
        private void outputText(string text)
        {
            if (this.rtb_CompressedCode.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(outputText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.rtb_CompressedCode.Text += text;
            }
        }
        private void setProgessBar(int value)
        {
            if (value > 100) value = 100;
            if (this.progressBar.InvokeRequired)
            {
                SetProgessBarCallback d = new SetProgessBarCallback(setProgessBar);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                this.progressBar.Value = value;
            }
        }
        private void setTotalValue(long value)
        {
            if (this.lbl_Total.InvokeRequired)
            {
                SetTotalValueCallback d = new SetTotalValueCallback(setTotalValue);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                this.lbl_Total.Text = "Total Processed : " + value.ToString();
            }
        }
        private void setOutputValue(long value)
        {
            if (this.lbl_Output.InvokeRequired)
            {
                SetOutputValueCallback d = new SetOutputValueCallback(setOutputValue);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                this.lbl_Output.Text = "Output : " + value.ToString();
            }
        }
        private void setCompressedRatioValue(float value)
        {
            if (this.lbl_Output.InvokeRequired)
            {
                SetCompresssedRatioCallback d = new SetCompresssedRatioCallback(setCompressedRatioValue);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                this.lbl_CompressedRatio.Text = "Compressed Ratio : " + value.ToString();
            }
        }
    }
}
