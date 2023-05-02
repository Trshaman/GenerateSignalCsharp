using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System;

namespace SRStoSine
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
      this.button1 = new System.Windows.Forms.Button();
      this.SignalProperties = new System.Windows.Forms.DataGridView();
      this.Ampatitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Offset = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Phase = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Cycle = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Freq = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Ratio = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.SignalType = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Fs = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Sample = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.RepeatAllSignal = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.numericChartRangeControlClient1 = new DevExpress.XtraEditors.NumericChartRangeControlClient();
      this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.button3 = new System.Windows.Forms.Button();
      this.chartControl2 = new DevExpress.XtraCharts.ChartControl();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.button2 = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.SignalProperties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericChartRangeControlClient1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chartControl2)).BeginInit();
      this.tabPage2.SuspendLayout();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
      this.button1.Location = new System.Drawing.Point(57, 11);
      this.button1.Margin = new System.Windows.Forms.Padding(2);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(118, 37);
      this.button1.TabIndex = 3;
      this.button1.Text = "Create";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // SignalProperties
      // 
      this.SignalProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.SignalProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ampatitude,
            this.Offset,
            this.Phase,
            this.Cycle,
            this.Freq,
            this.Ratio,
            this.SignalType,
            this.Fs,
            this.Sample,
            this.RepeatAllSignal});
      this.SignalProperties.Location = new System.Drawing.Point(294, 11);
      this.SignalProperties.Name = "SignalProperties";
      this.SignalProperties.Size = new System.Drawing.Size(1044, 180);
      this.SignalProperties.TabIndex = 28;
      // 
      // Ampatitude
      // 
      this.Ampatitude.HeaderText = "Ampatitude";
      this.Ampatitude.Name = "Ampatitude";
      // 
      // Offset
      // 
      this.Offset.HeaderText = "Offset";
      this.Offset.Name = "Offset";
      // 
      // Phase
      // 
      this.Phase.HeaderText = "Phase";
      this.Phase.Name = "Phase";
      // 
      // Cycle
      // 
      this.Cycle.HeaderText = "Cycle";
      this.Cycle.Name = "Cycle";
      // 
      // Freq
      // 
      this.Freq.HeaderText = "Freq";
      this.Freq.Name = "Freq";
      // 
      // Ratio
      // 
      this.Ratio.HeaderText = "Ratio";
      this.Ratio.Name = "Ratio";
      // 
      // SignalType
      // 
      this.SignalType.HeaderText = "SignalType";
      this.SignalType.Name = "SignalType";
      // 
      // Fs
      // 
      this.Fs.HeaderText = "Fs";
      this.Fs.Name = "Fs";
      // 
      // Sample
      // 
      this.Sample.HeaderText = "Sample";
      this.Sample.Name = "Sample";
      // 
      // RepeatAllSignal
      // 
      this.RepeatAllSignal.HeaderText = "RepeatAllSignal";
      this.RepeatAllSignal.Name = "RepeatAllSignal";
      // 
      // chartControl1
      // 
      this.chartControl1.Location = new System.Drawing.Point(22, 18);
      this.chartControl1.Name = "chartControl1";
      this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
      this.chartControl1.Size = new System.Drawing.Size(1265, 510);
      this.chartControl1.TabIndex = 29;
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Location = new System.Drawing.Point(12, 197);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(1326, 590);
      this.tabControl1.TabIndex = 30;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.button3);
      this.tabPage1.Controls.Add(this.chartControl2);
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(1318, 564);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Generated Signals";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // button3
      // 
      this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button3.Location = new System.Drawing.Point(1116, 238);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(118, 45);
      this.button3.TabIndex = 31;
      this.button3.Text = "Export PDF";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.button3_Click);
      // 
      // chartControl2
      // 
      this.chartControl2.Location = new System.Drawing.Point(21, 18);
      this.chartControl2.Name = "chartControl2";
      this.chartControl2.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
      this.chartControl2.Size = new System.Drawing.Size(1077, 510);
      this.chartControl2.TabIndex = 30;
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.chartControl1);
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(1318, 564);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "All Data";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // button2
      // 
      this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button2.Location = new System.Drawing.Point(57, 98);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(118, 45);
      this.button2.TabIndex = 31;
      this.button2.Text = "Clear";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1350, 817);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.tabControl1);
      this.Controls.Add(this.SignalProperties);
      this.Controls.Add(this.button1);
      this.Margin = new System.Windows.Forms.Padding(2);
      this.Name = "Form1";
      this.Text = "Generate Wave";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      ((System.ComponentModel.ISupportInitialize)(this.SignalProperties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericChartRangeControlClient1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.chartControl2)).EndInit();
      this.tabPage2.ResumeLayout(false);
      this.ResumeLayout(false);

        }

        #endregion
        private Button button1;
        private DataGridView SignalProperties;
    private DataGridViewTextBoxColumn Ampatitude;
    private DataGridViewTextBoxColumn Offset;
    private DataGridViewTextBoxColumn Phase;
    private DataGridViewTextBoxColumn Cycle;
    private DataGridViewTextBoxColumn Freq;
    private DataGridViewTextBoxColumn Ratio;
    private DataGridViewComboBoxColumn SignalType;
    private DataGridViewTextBoxColumn Fs;
    private DataGridViewTextBoxColumn Sample;
    private DataGridViewTextBoxColumn RepeatAllSignal;
        private DevExpress.XtraEditors.NumericChartRangeControlClient numericChartRangeControlClient1;
        private DevExpress.XtraCharts.ChartControl chartControl1;
    private TabControl tabControl1;
    private TabPage tabPage1;
    private DevExpress.XtraCharts.ChartControl chartControl2;
    private TabPage tabPage2;
    private Button button2;
    private Button button3;
  }
}