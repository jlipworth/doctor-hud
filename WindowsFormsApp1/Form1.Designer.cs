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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pRAM = new System.Diagnostics.PerformanceCounter();
            this.pCPU = new System.Diagnostics.PerformanceCounter();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.spo2ProgressBar = new MetroFramework.Controls.MetroProgressBar();
            this.heartrateLabel = new MetroFramework.Controls.MetroLabel();
            this.spo2Label = new MetroFramework.Controls.MetroLabel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.pRAM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCPU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
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
            this.metroLabel1.Location = new System.Drawing.Point(48, 235);
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
            this.metroLabel2.Location = new System.Drawing.Point(48, 151);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(61, 25);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "SpO2:";
            // 
            // spo2ProgressBar
            // 
            this.spo2ProgressBar.Location = new System.Drawing.Point(188, 134);
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
            this.heartrateLabel.Location = new System.Drawing.Point(500, 235);
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
            this.spo2Label.Location = new System.Drawing.Point(836, 151);
            this.spo2Label.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.spo2Label.Name = "spo2Label";
            this.spo2Label.Size = new System.Drawing.Size(42, 25);
            this.spo2Label.TabIndex = 5;
            this.spo2Label.Text = "0 %";
            // 
            // chart1
            // 
            chartArea6.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chart1.Legends.Add(legend6);
            this.chart1.Location = new System.Drawing.Point(48, 310);
            this.chart1.Margin = new System.Windows.Forms.Padding(6);
            this.chart1.Name = "chart1";
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series11.Legend = "Legend1";
            series11.Name = "Systolic";
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series12.IsXValueIndexed = true;
            series12.Legend = "Legend1";
            series12.Name = "Diastolic";
            this.chart1.Series.Add(series11);
            this.chart1.Series.Add(series12);
            this.chart1.Size = new System.Drawing.Size(944, 400);
            this.chart1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1020, 1812);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.spo2Label);
            this.Controls.Add(this.heartrateLabel);
            this.Controls.Add(this.spo2ProgressBar);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1020, 1718);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(20, 115, 20, 19);
            this.Text = "Doctor Hud";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pRAM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCPU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
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
    }
}

