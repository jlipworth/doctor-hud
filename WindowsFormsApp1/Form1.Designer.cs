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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.spo2ProgressBar = new MetroFramework.Controls.MetroProgressBar();
            this.heartrateLabel = new MetroFramework.Controls.MetroLabel();
            this.spo2Label = new MetroFramework.Controls.MetroLabel();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.heartRate = new LiveCharts.WinForms.AngularGauge();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.etCO2Value = new MetroFramework.Controls.MetroLabel();
            this.respirationValue = new MetroFramework.Controls.MetroLabel();
            this.etCO2Panel = new LiveCharts.WinForms.AngularGauge();
            this.respirationPanel = new LiveCharts.WinForms.AngularGauge();
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
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(66, 910);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(103, 25);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Heart_rate:";
            this.metroLabel1.Click += new System.EventHandler(this.metroLabel1_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.metroLabel2.Location = new System.Drawing.Point(66, 156);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(61, 25);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "SpO2:";
            this.metroLabel2.Click += new System.EventHandler(this.metroLabel2_Click);
            // 
            // spo2ProgressBar
            // 
            this.spo2ProgressBar.Location = new System.Drawing.Point(253, 135);
            this.spo2ProgressBar.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.spo2ProgressBar.Name = "spo2ProgressBar";
            this.spo2ProgressBar.Size = new System.Drawing.Size(720, 62);
            this.spo2ProgressBar.TabIndex = 3;
            this.spo2ProgressBar.Click += new System.EventHandler(this.metroProgressBar2_Click);
            // 
            // heartrateLabel
            // 
            this.heartrateLabel.AutoSize = true;
            this.heartrateLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.heartrateLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.heartrateLabel.Location = new System.Drawing.Point(545, 990);
            this.heartrateLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
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
            this.spo2Label.Location = new System.Drawing.Point(1117, 156);
            this.spo2Label.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.spo2Label.Name = "spo2Label";
            this.spo2Label.Size = new System.Drawing.Size(43, 25);
            this.spo2Label.TabIndex = 5;
            this.spo2Label.Text = "0 %";
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(66, 1130);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(799, 448);
            this.cartesianChart1.TabIndex = 7;
            this.cartesianChart1.Text = "cartesianChart1";
            this.cartesianChart1.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.cartesianChart1_ChildChanged_1);
            // 
            // heartRate
            // 
            this.heartRate.Location = new System.Drawing.Point(253, 827);
            this.heartRate.Name = "heartRate";
            this.heartRate.Size = new System.Drawing.Size(607, 261);
            this.heartRate.TabIndex = 8;
            this.heartRate.Text = "angularGauge1";
            this.heartRate.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.hartRate_ChildChanged);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.ForeColor = System.Drawing.Color.Black;
            this.metroLabel3.Location = new System.Drawing.Point(66, 348);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(67, 25);
            this.metroLabel3.TabIndex = 9;
            this.metroLabel3.Text = "etCO2:";
            this.metroLabel3.Click += new System.EventHandler(this.metroLabel3_Click_1);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(66, 642);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(148, 25);
            this.metroLabel4.TabIndex = 10;
            this.metroLabel4.Text = "respiration_rate:";
            // 
            // etCO2Value
            // 
            this.etCO2Value.AutoSize = true;
            this.etCO2Value.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.etCO2Value.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.etCO2Value.Location = new System.Drawing.Point(545, 404);
            this.etCO2Value.Name = "etCO2Value";
            this.etCO2Value.Size = new System.Drawing.Size(22, 25);
            this.etCO2Value.TabIndex = 11;
            this.etCO2Value.Text = "0";
            this.etCO2Value.Click += new System.EventHandler(this.etCO2Value_Click);
            // 
            // respirationValue
            // 
            this.respirationValue.AutoSize = true;
            this.respirationValue.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.respirationValue.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.respirationValue.Location = new System.Drawing.Point(545, 685);
            this.respirationValue.Name = "respirationValue";
            this.respirationValue.Size = new System.Drawing.Size(22, 25);
            this.respirationValue.TabIndex = 12;
            this.respirationValue.Text = "0";
            this.respirationValue.Click += new System.EventHandler(this.metroLabel6_Click);
            // 
            // etCO2Panel
            // 
            this.etCO2Panel.Location = new System.Drawing.Point(253, 237);
            this.etCO2Panel.Name = "etCO2Panel";
            this.etCO2Panel.Size = new System.Drawing.Size(607, 261);
            this.etCO2Panel.TabIndex = 13;
            this.etCO2Panel.Text = "angularGauge1";
            // 
            // respirationPanel
            // 
            this.respirationPanel.Location = new System.Drawing.Point(253, 517);
            this.respirationPanel.Name = "respirationPanel";
            this.respirationPanel.Size = new System.Drawing.Size(607, 261);
            this.respirationPanel.TabIndex = 14;
            this.respirationPanel.Text = "angularGauge2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1360, 2164);
            this.Controls.Add(this.respirationValue);
            this.Controls.Add(this.etCO2Value);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.cartesianChart1);
            this.Controls.Add(this.spo2Label);
            this.Controls.Add(this.heartrateLabel);
            this.Controls.Add(this.spo2ProgressBar);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.heartRate);
            this.Controls.Add(this.etCO2Panel);
            this.Controls.Add(this.respirationPanel);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(1360, 2058);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(27, 143, 27, 24);
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
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroProgressBar spo2ProgressBar;
        private MetroFramework.Controls.MetroLabel heartrateLabel;
        private MetroFramework.Controls.MetroLabel spo2Label;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private LiveCharts.WinForms.AngularGauge heartRate;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel etCO2Value;
        private MetroFramework.Controls.MetroLabel respirationValue;
        private LiveCharts.WinForms.AngularGauge etCO2Panel;
        private LiveCharts.WinForms.AngularGauge respirationPanel;
    }
}

