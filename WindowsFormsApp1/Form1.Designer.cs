namespace WindowsFormsApp1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pRAM = new System.Diagnostics.PerformanceCounter();
            this.pCPU = new System.Diagnostics.PerformanceCounter();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.spo2ProgressBar = new MetroFramework.Controls.MetroProgressBar();
            this.heartrateLabel = new MetroFramework.Controls.MetroLabel();
            this.spo2Label = new MetroFramework.Controls.MetroLabel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.axVLCPlugin21 = new AxAXVLC.AxVLCPlugin2();
            this.buttonPlay = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.pRAM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCPU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axVLCPlugin21)).BeginInit();
            this.SuspendLayout();
            // 
            // pRAM
            // 
            this.pRAM.CategoryName = "Memory";
            this.pRAM.CounterName = "% Committed Bytes in Use";
            // 
            // pCPU
            // 
            this.pCPU.CategoryName = "Processor";
            this.pCPU.CounterName = "% Processor Time";
            this.pCPU.InstanceName = "_Total";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(948, 337);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(96, 25);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Heart_rate:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(948, 253);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(61, 25);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "SpO2:";
            // 
            // spo2ProgressBar
            // 
            this.spo2ProgressBar.Location = new System.Drawing.Point(1088, 236);
            this.spo2ProgressBar.Margin = new System.Windows.Forms.Padding(6);
            this.spo2ProgressBar.Name = "spo2ProgressBar";
            this.spo2ProgressBar.Size = new System.Drawing.Size(540, 50);
            this.spo2ProgressBar.TabIndex = 3;
            this.spo2ProgressBar.Click += new System.EventHandler(this.metroProgressBar2_Click);
            // 
            // heartrateLabel
            // 
            this.heartrateLabel.AutoSize = true;
            this.heartrateLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.heartrateLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.heartrateLabel.Location = new System.Drawing.Point(1400, 337);
            this.heartrateLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.heartrateLabel.Name = "heartrateLabel";
            this.heartrateLabel.Size = new System.Drawing.Size(22, 25);
            this.heartrateLabel.TabIndex = 4;
            this.heartrateLabel.Text = "0";
            this.heartrateLabel.Click += new System.EventHandler(this.metroLabel3_Click);
            // 
            // spo2Label
            // 
            this.spo2Label.AutoSize = true;
            this.spo2Label.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.spo2Label.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.spo2Label.Location = new System.Drawing.Point(1736, 253);
            this.spo2Label.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.spo2Label.Name = "spo2Label";
            this.spo2Label.Size = new System.Drawing.Size(42, 25);
            this.spo2Label.TabIndex = 5;
            this.spo2Label.Text = "0 %";
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(948, 412);
            this.chart1.Margin = new System.Windows.Forms.Padding(6);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Systolic";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.IsXValueIndexed = true;
            series4.Legend = "Legend1";
            series4.Name = "Diastolic";
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(944, 400);
            this.chart1.TabIndex = 6;
            // 
            // axVLCPlugin21
            // 
            this.axVLCPlugin21.Enabled = true;
            this.axVLCPlugin21.Location = new System.Drawing.Point(98, 130);
            this.axVLCPlugin21.Margin = new System.Windows.Forms.Padding(4);
            this.axVLCPlugin21.MaximumSize = new System.Drawing.Size(600, 450);
            this.axVLCPlugin21.Name = "axVLCPlugin21";
            this.axVLCPlugin21.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axVLCPlugin21.OcxState")));
            this.axVLCPlugin21.Size = new System.Drawing.Size(600, 450);
            this.axVLCPlugin21.TabIndex = 9;
            this.axVLCPlugin21.Enter += new System.EventHandler(this.axVLCPlugin21_Enter);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(264, 750);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(288, 106);
            this.buttonPlay.TabIndex = 10;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseSelectable = true;
            this.buttonPlay.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2134, 785);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.axVLCPlugin21);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.spo2Label);
            this.Controls.Add(this.heartrateLabel);
            this.Controls.Add(this.spo2ProgressBar);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(20, 115, 20, 19);
            this.Text = " Hello ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pRAM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCPU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axVLCPlugin21)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Diagnostics.PerformanceCounter pRAM;
        private System.Diagnostics.PerformanceCounter pCPU;
        private System.Windows.Forms.Timer timer;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroProgressBar spo2ProgressBar;
        private MetroFramework.Controls.MetroLabel heartrateLabel;
        private MetroFramework.Controls.MetroLabel spo2Label;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private AxAXVLC.AxVLCPlugin2 axVLCPlugin21;
        private MetroFramework.Controls.MetroButton buttonPlay;
    }
}

