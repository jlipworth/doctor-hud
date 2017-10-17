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
            this.pRAM = new System.Diagnostics.PerformanceCounter();
            this.pCPU = new System.Diagnostics.PerformanceCounter();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.spo2ProgressBar = new MetroFramework.Controls.MetroProgressBar();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.heartRate = new LiveCharts.WinForms.AngularGauge();
            this.etCO2Panel = new LiveCharts.WinForms.AngularGauge();
            this.respirationPanel = new LiveCharts.WinForms.AngularGauge();
            this.etCO2Value = new System.Windows.Forms.Label();
            this.respirationValue = new System.Windows.Forms.Label();
            this.heartrateLabel = new System.Windows.Forms.Label();
            this.spo2Label = new System.Windows.Forms.Label();
            this.metroLabel2 = new System.Windows.Forms.Label();
            this.metroLabel3 = new System.Windows.Forms.Label();
            this.metroLabel4 = new System.Windows.Forms.Label();
            this.metroLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pRAM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCPU)).BeginInit();
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
            // spo2ProgressBar
            // 
            this.spo2ProgressBar.Location = new System.Drawing.Point(95, 57);
            this.spo2ProgressBar.Name = "spo2ProgressBar";
            this.spo2ProgressBar.Size = new System.Drawing.Size(270, 26);
            this.spo2ProgressBar.TabIndex = 3;
            this.spo2ProgressBar.Click += new System.EventHandler(this.metroProgressBar2_Click);
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(25, 474);
            this.cartesianChart1.Margin = new System.Windows.Forms.Padding(1);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(300, 188);
            this.cartesianChart1.TabIndex = 7;
            this.cartesianChart1.Text = "cartesianChart1";
            this.cartesianChart1.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.cartesianChart1_ChildChanged_1);
            // 
            // heartRate
            // 
            this.heartRate.Location = new System.Drawing.Point(95, 347);
            this.heartRate.Margin = new System.Windows.Forms.Padding(1);
            this.heartRate.Name = "heartRate";
            this.heartRate.Size = new System.Drawing.Size(228, 109);
            this.heartRate.TabIndex = 8;
            this.heartRate.Text = "angularGauge1";
            this.heartRate.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.hartRate_ChildChanged);
            // 
            // etCO2Panel
            // 
            this.etCO2Panel.Location = new System.Drawing.Point(95, 99);
            this.etCO2Panel.Margin = new System.Windows.Forms.Padding(1);
            this.etCO2Panel.Name = "etCO2Panel";
            this.etCO2Panel.Size = new System.Drawing.Size(228, 109);
            this.etCO2Panel.TabIndex = 13;
            this.etCO2Panel.Text = "angularGauge1";
            // 
            // respirationPanel
            // 
            this.respirationPanel.Location = new System.Drawing.Point(95, 217);
            this.respirationPanel.Margin = new System.Windows.Forms.Padding(1);
            this.respirationPanel.Name = "respirationPanel";
            this.respirationPanel.Size = new System.Drawing.Size(228, 109);
            this.respirationPanel.TabIndex = 14;
            this.respirationPanel.Text = "angularGauge2";
            // 
            // etCO2Value
            // 
            this.etCO2Value.AutoSize = true;
            this.etCO2Value.Location = new System.Drawing.Point(202, 180);
            this.etCO2Value.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.etCO2Value.Name = "etCO2Value";
            this.etCO2Value.Size = new System.Drawing.Size(13, 13);
            this.etCO2Value.TabIndex = 15;
            this.etCO2Value.Text = "0";
            this.etCO2Value.Click += new System.EventHandler(this.label1_Click);
            // 
            // respirationValue
            // 
            this.respirationValue.AutoSize = true;
            this.respirationValue.Location = new System.Drawing.Point(202, 299);
            this.respirationValue.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.respirationValue.Name = "respirationValue";
            this.respirationValue.Size = new System.Drawing.Size(13, 13);
            this.respirationValue.TabIndex = 16;
            this.respirationValue.Text = "0";
            // 
            // heartrateLabel
            // 
            this.heartrateLabel.AutoSize = true;
            this.heartrateLabel.Location = new System.Drawing.Point(202, 428);
            this.heartrateLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.heartrateLabel.Name = "heartrateLabel";
            this.heartrateLabel.Size = new System.Drawing.Size(13, 13);
            this.heartrateLabel.TabIndex = 17;
            this.heartrateLabel.Text = "0";
            // 
            // spo2Label
            // 
            this.spo2Label.AutoSize = true;
            this.spo2Label.Location = new System.Drawing.Point(416, 62);
            this.spo2Label.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.spo2Label.Name = "spo2Label";
            this.spo2Label.Size = new System.Drawing.Size(21, 13);
            this.spo2Label.TabIndex = 18;
            this.spo2Label.Text = "0%";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(22, 62);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(37, 13);
            this.metroLabel2.TabIndex = 19;
            this.metroLabel2.Text = "SpO2:";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(22, 145);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(49, 26);
            this.metroLabel3.TabIndex = 20;
            this.metroLabel3.Text = "etCO2\r\n (mm Hg)";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(22, 271);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(86, 26);
            this.metroLabel4.TabIndex = 21;
            this.metroLabel4.Text = "Respiration Rate\r\n (Breaths/min)\r\n";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(22, 393);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(64, 26);
            this.metroLabel1.TabIndex = 22;
            this.metroLabel1.Text = "Heart Rate\r\n (Beats/min)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(517, 756);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.spo2Label);
            this.Controls.Add(this.heartrateLabel);
            this.Controls.Add(this.respirationValue);
            this.Controls.Add(this.etCO2Value);
            this.Controls.Add(this.cartesianChart1);
            this.Controls.Add(this.spo2ProgressBar);
            this.Controls.Add(this.heartRate);
            this.Controls.Add(this.etCO2Panel);
            this.Controls.Add(this.respirationPanel);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(510, 435);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(10, 60, 10, 10);
            this.Text = "Doctor Hud";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pRAM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCPU)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Diagnostics.PerformanceCounter pRAM;
        private System.Diagnostics.PerformanceCounter pCPU;
        private System.Windows.Forms.Timer timer;
        private MetroFramework.Controls.MetroProgressBar spo2ProgressBar;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private LiveCharts.WinForms.AngularGauge heartRate;
        private LiveCharts.WinForms.AngularGauge etCO2Panel;
        private LiveCharts.WinForms.AngularGauge respirationPanel;
        private System.Windows.Forms.Label etCO2Value;
        private System.Windows.Forms.Label respirationValue;
        private System.Windows.Forms.Label heartrateLabel;
        private System.Windows.Forms.Label spo2Label;
        private System.Windows.Forms.Label metroLabel2;
        private System.Windows.Forms.Label metroLabel3;
        private System.Windows.Forms.Label metroLabel4;
        private System.Windows.Forms.Label metroLabel1;
    }
}

