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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.executeTest3Button = new System.Windows.Forms.Button();
            this.oneQForEachRowButton = new System.Windows.Forms.Button();
            this.permutationsButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.execAllTestsButton = new System.Windows.Forms.Button();
            this.highResBarChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.flowLayoutPanel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barChart)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.highResBarChart)).BeginInit();
            this.SuspendLayout();
            // 
            // bruteForceButton
            // 
            this.bruteForceButton.Location = new System.Drawing.Point(5, 3);
            this.bruteForceButton.Name = "bruteForceButton";
            this.bruteForceButton.Size = new System.Drawing.Size(88, 23);
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
            this.flowLayoutPanel2.Location = new System.Drawing.Point(13, 114);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(15);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel2.TabIndex = 69;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(220, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(804, 577);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(708, 507);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.highResBarChart);
            this.tabPage2.Controls.Add(this.barChart);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(796, 551);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // barChart
            // 
            chartArea2.Name = "ChartArea1";
            this.barChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.barChart.Legends.Add(legend2);
            this.barChart.Location = new System.Drawing.Point(18, 6);
            this.barChart.Name = "barChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.barChart.Series.Add(series2);
            this.barChart.Size = new System.Drawing.Size(748, 300);
            this.barChart.TabIndex = 0;
            this.barChart.Text = "chart1";
            // 
            // exeTestButton
            // 
            this.exeTestButton.Location = new System.Drawing.Point(5, 32);
            this.exeTestButton.Name = "exeTestButton";
            this.exeTestButton.Size = new System.Drawing.Size(88, 23);
            this.exeTestButton.TabIndex = 70;
            this.exeTestButton.Text = "Execute Test";
            this.exeTestButton.UseVisualStyleBackColor = true;
            this.exeTestButton.Click += new System.EventHandler(this.exeTestButton_Click);
            // 
            // inputSeedTextBox
            // 
            this.inputSeedTextBox.Location = new System.Drawing.Point(15, 232);
            this.inputSeedTextBox.Name = "inputSeedTextBox";
            this.inputSeedTextBox.Size = new System.Drawing.Size(100, 20);
            this.inputSeedTextBox.TabIndex = 69;
            // 
            // inputSeedLabel
            // 
            this.inputSeedLabel.AutoSize = true;
            this.inputSeedLabel.Location = new System.Drawing.Point(12, 216);
            this.inputSeedLabel.Name = "inputSeedLabel";
            this.inputSeedLabel.Size = new System.Drawing.Size(172, 13);
            this.inputSeedLabel.TabIndex = 70;
            this.inputSeedLabel.Text = "Input seed (integer - for indiv. tests)";
            // 
            // ExecuteTest2Button
            // 
            this.ExecuteTest2Button.Location = new System.Drawing.Point(3, 33);
            this.ExecuteTest2Button.Name = "ExecuteTest2Button";
            this.ExecuteTest2Button.Size = new System.Drawing.Size(95, 23);
            this.ExecuteTest2Button.TabIndex = 71;
            this.ExecuteTest2Button.Text = "Execute Test2";
            this.ExecuteTest2Button.UseVisualStyleBackColor = true;
            this.ExecuteTest2Button.Click += new System.EventHandler(this.ExecuteTest2Button_Click);
            // 
            // executeTest3Button
            // 
            this.executeTest3Button.Location = new System.Drawing.Point(3, 33);
            this.executeTest3Button.Name = "executeTest3Button";
            this.executeTest3Button.Size = new System.Drawing.Size(86, 23);
            this.executeTest3Button.TabIndex = 73;
            this.executeTest3Button.Text = "Execute Test3";
            this.executeTest3Button.UseVisualStyleBackColor = true;
            this.executeTest3Button.Click += new System.EventHandler(this.executeTest3Button_Click);
            // 
            // oneQForEachRowButton
            // 
            this.oneQForEachRowButton.Location = new System.Drawing.Point(3, 4);
            this.oneQForEachRowButton.Name = "oneQForEachRowButton";
            this.oneQForEachRowButton.Size = new System.Drawing.Size(95, 23);
            this.oneQForEachRowButton.TabIndex = 74;
            this.oneQForEachRowButton.Text = "1 Q for each row";
            this.oneQForEachRowButton.UseVisualStyleBackColor = true;
            this.oneQForEachRowButton.Click += new System.EventHandler(this.oneQForEachRowButton_Click);
            // 
            // permutationsButton
            // 
            this.permutationsButton.Location = new System.Drawing.Point(3, 4);
            this.permutationsButton.Name = "permutationsButton";
            this.permutationsButton.Size = new System.Drawing.Size(86, 23);
            this.permutationsButton.TabIndex = 75;
            this.permutationsButton.Text = "Permutations";
            this.permutationsButton.UseVisualStyleBackColor = true;
            this.permutationsButton.Click += new System.EventHandler(this.permutationsButton_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.bruteForceButton);
            this.panel1.Controls.Add(this.exeTestButton);
            this.panel1.Location = new System.Drawing.Point(13, 258);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 60);
            this.panel1.TabIndex = 76;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.oneQForEachRowButton);
            this.panel2.Controls.Add(this.ExecuteTest2Button);
            this.panel2.Location = new System.Drawing.Point(12, 324);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(103, 60);
            this.panel2.TabIndex = 77;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.permutationsButton);
            this.panel3.Controls.Add(this.executeTest3Button);
            this.panel3.Location = new System.Drawing.Point(120, 258);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(93, 60);
            this.panel3.TabIndex = 78;
            // 
            // execAllTestsButton
            // 
            this.execAllTestsButton.Location = new System.Drawing.Point(125, 333);
            this.execAllTestsButton.Name = "execAllTestsButton";
            this.execAllTestsButton.Size = new System.Drawing.Size(86, 39);
            this.execAllTestsButton.TabIndex = 79;
            this.execAllTestsButton.Text = "Execute All Tests";
            this.execAllTestsButton.UseVisualStyleBackColor = true;
            this.execAllTestsButton.Click += new System.EventHandler(this.execAllTestsButton_Click);
            // 
            // highResBarChart
            // 
            chartArea1.Name = "ChartArea1";
            this.highResBarChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.highResBarChart.Legends.Add(legend1);
            this.highResBarChart.Location = new System.Drawing.Point(18, 299);
            this.highResBarChart.Name = "highResBarChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.highResBarChart.Series.Add(series1);
            this.highResBarChart.Size = new System.Drawing.Size(748, 246);
            this.highResBarChart.TabIndex = 1;
            this.highResBarChart.Text = "HighResBarChart";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 601);
            this.Controls.Add(this.execAllTestsButton);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.inputSeedLabel);
            this.Controls.Add(this.inputSeedTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barChart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.highResBarChart)).EndInit();
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
        private System.Windows.Forms.Button executeTest3Button;
        private System.Windows.Forms.Button oneQForEachRowButton;
        private System.Windows.Forms.Button permutationsButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button execAllTestsButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart highResBarChart;
    }
}

