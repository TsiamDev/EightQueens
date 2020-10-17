namespace EightQueens
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.bruteForceButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.methodLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.exeTimeLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.barChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.exeTestButton = new System.Windows.Forms.Button();
            this.inputSeedTextBox = new System.Windows.Forms.TextBox();
            this.inputSeedLabel = new System.Windows.Forms.Label();
            this.ExecuteTest2Button = new System.Windows.Forms.Button();
            this.flowLayoutPanel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barChart)).BeginInit();
            this.SuspendLayout();
            // 
            // bruteForceButton
            // 
            this.bruteForceButton.Location = new System.Drawing.Point(116, 35);
            this.bruteForceButton.Name = "bruteForceButton";
            this.bruteForceButton.Size = new System.Drawing.Size(75, 23);
            this.bruteForceButton.TabIndex = 0;
            this.bruteForceButton.Text = "Brute Force";
            this.bruteForceButton.UseVisualStyleBackColor = true;
            this.bruteForceButton.Click += new System.EventHandler(this.bruteForceButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(53, 32);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(450, 450);
            this.flowLayoutPanel1.TabIndex = 65;
            // 
            // methodLabel
            // 
            this.methodLabel.AutoSize = true;
            this.methodLabel.Location = new System.Drawing.Point(3, 0);
            this.methodLabel.Name = "methodLabel";
            this.methodLabel.Size = new System.Drawing.Size(74, 13);
            this.methodLabel.TabIndex = 66;
            this.methodLabel.Text = "Method Used:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 67;
            this.label1.Text = "Execution Time:";
            // 
            // exeTimeLabel
            // 
            this.exeTimeLabel.AutoSize = true;
            this.exeTimeLabel.Location = new System.Drawing.Point(3, 26);
            this.exeTimeLabel.Name = "exeTimeLabel";
            this.exeTimeLabel.Size = new System.Drawing.Size(35, 13);
            this.exeTimeLabel.TabIndex = 68;
            this.exeTimeLabel.Text = "label2";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.methodLabel);
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.exeTimeLabel);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(2, 66);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(15);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel2.TabIndex = 69;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(220, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(568, 533);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(560, 507);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.barChart);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(560, 507);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // barChart
            // 
            chartArea1.Name = "ChartArea1";
            this.barChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.barChart.Legends.Add(legend1);
            this.barChart.Location = new System.Drawing.Point(18, 45);
            this.barChart.Name = "barChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.barChart.Series.Add(series1);
            this.barChart.Size = new System.Drawing.Size(525, 300);
            this.barChart.TabIndex = 0;
            this.barChart.Text = "chart1";
            // 
            // exeTestButton
            // 
            this.exeTestButton.Location = new System.Drawing.Point(12, 35);
            this.exeTestButton.Name = "exeTestButton";
            this.exeTestButton.Size = new System.Drawing.Size(88, 23);
            this.exeTestButton.TabIndex = 70;
            this.exeTestButton.Text = "Execute Test";
            this.exeTestButton.UseVisualStyleBackColor = true;
            this.exeTestButton.Click += new System.EventHandler(this.exeTestButton_Click);
            // 
            // inputSeedTextBox
            // 
            this.inputSeedTextBox.Location = new System.Drawing.Point(8, 184);
            this.inputSeedTextBox.Name = "inputSeedTextBox";
            this.inputSeedTextBox.Size = new System.Drawing.Size(100, 20);
            this.inputSeedTextBox.TabIndex = 69;
            // 
            // inputSeedLabel
            // 
            this.inputSeedLabel.AutoSize = true;
            this.inputSeedLabel.Location = new System.Drawing.Point(5, 168);
            this.inputSeedLabel.Name = "inputSeedLabel";
            this.inputSeedLabel.Size = new System.Drawing.Size(172, 13);
            this.inputSeedLabel.TabIndex = 70;
            this.inputSeedLabel.Text = "Input seed (integer - for indiv. tests)";
            // 
            // ExecuteTest2Button
            // 
            this.ExecuteTest2Button.Location = new System.Drawing.Point(13, 12);
            this.ExecuteTest2Button.Name = "ExecuteTest2Button";
            this.ExecuteTest2Button.Size = new System.Drawing.Size(87, 23);
            this.ExecuteTest2Button.TabIndex = 71;
            this.ExecuteTest2Button.Text = "Execute Test2";
            this.ExecuteTest2Button.UseVisualStyleBackColor = true;
            this.ExecuteTest2Button.Click += new System.EventHandler(this.ExecuteTest2Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 584);
            this.Controls.Add(this.ExecuteTest2Button);
            this.Controls.Add(this.exeTestButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.inputSeedLabel);
            this.Controls.Add(this.bruteForceButton);
            this.Controls.Add(this.inputSeedTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bruteForceButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label methodLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label exeTimeLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart barChart;
        private System.Windows.Forms.Button exeTestButton;
        private System.Windows.Forms.Label inputSeedLabel;
        private System.Windows.Forms.TextBox inputSeedTextBox;
        private System.Windows.Forms.Button ExecuteTest2Button;
    }
}

