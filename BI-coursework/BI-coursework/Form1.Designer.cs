namespace BI_coursework
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.datePieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateBarChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listBoxFactTable = new System.Windows.Forms.ListBox();
            this.btnBuildFactTable = new System.Windows.Forms.Button();
            this.btnGetDimension = new System.Windows.Forms.Button();
            this.listBoxDatesDimension = new System.Windows.Forms.ListBox();
            this.listBoxDates = new System.Windows.Forms.ListBox();
            this.btnGetDates = new System.Windows.Forms.Button();
            this.Date = new System.Windows.Forms.TabControl();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datePieChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBarChart)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.Date.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LemonChiffon;
            this.tabPage2.Controls.Add(this.datePieChart);
            this.tabPage2.Controls.Add(this.dateBarChart);
            this.tabPage2.Controls.Add(this.btnLoadData);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(557, 524);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Date";
            // 
            // datePieChart
            // 
            chartArea1.Name = "ChartArea1";
            this.datePieChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.datePieChart.Legends.Add(legend1);
            this.datePieChart.Location = new System.Drawing.Point(109, 276);
            this.datePieChart.Name = "datePieChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.datePieChart.Series.Add(series1);
            this.datePieChart.Size = new System.Drawing.Size(365, 233);
            this.datePieChart.TabIndex = 3;
            this.datePieChart.Text = "chart1";
            // 
            // dateBarChart
            // 
            chartArea2.Name = "ChartArea1";
            this.dateBarChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.dateBarChart.Legends.Add(legend2);
            this.dateBarChart.Location = new System.Drawing.Point(109, 17);
            this.dateBarChart.Name = "dateBarChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.dateBarChart.Series.Add(series2);
            this.dateBarChart.Size = new System.Drawing.Size(365, 233);
            this.dateBarChart.TabIndex = 2;
            this.dateBarChart.Text = "chart1";
            // 
            // btnLoadData
            // 
            this.btnLoadData.BackColor = System.Drawing.Color.OldLace;
            this.btnLoadData.Location = new System.Drawing.Point(8, 17);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(75, 37);
            this.btnLoadData.TabIndex = 1;
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.UseVisualStyleBackColor = false;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LemonChiffon;
            this.tabPage1.Controls.Add(this.listBoxFactTable);
            this.tabPage1.Controls.Add(this.btnBuildFactTable);
            this.tabPage1.Controls.Add(this.btnGetDimension);
            this.tabPage1.Controls.Add(this.listBoxDatesDimension);
            this.tabPage1.Controls.Add(this.listBoxDates);
            this.tabPage1.Controls.Add(this.btnGetDates);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(557, 524);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ETL";
            // 
            // listBoxFactTable
            // 
            this.listBoxFactTable.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.listBoxFactTable.FormattingEnabled = true;
            this.listBoxFactTable.Location = new System.Drawing.Point(175, 335);
            this.listBoxFactTable.Name = "listBoxFactTable";
            this.listBoxFactTable.Size = new System.Drawing.Size(196, 160);
            this.listBoxFactTable.TabIndex = 5;
            // 
            // btnBuildFactTable
            // 
            this.btnBuildFactTable.BackColor = System.Drawing.Color.OldLace;
            this.btnBuildFactTable.Location = new System.Drawing.Point(175, 269);
            this.btnBuildFactTable.Name = "btnBuildFactTable";
            this.btnBuildFactTable.Size = new System.Drawing.Size(196, 50);
            this.btnBuildFactTable.TabIndex = 4;
            this.btnBuildFactTable.Text = "Build Fact Table";
            this.btnBuildFactTable.UseVisualStyleBackColor = false;
            this.btnBuildFactTable.Click += new System.EventHandler(this.btnBuildFactTable_Click);
            // 
            // btnGetDimension
            // 
            this.btnGetDimension.BackColor = System.Drawing.Color.OldLace;
            this.btnGetDimension.Location = new System.Drawing.Point(316, 23);
            this.btnGetDimension.Name = "btnGetDimension";
            this.btnGetDimension.Size = new System.Drawing.Size(196, 50);
            this.btnGetDimension.TabIndex = 3;
            this.btnGetDimension.Text = "GetDates From Dimension";
            this.btnGetDimension.UseVisualStyleBackColor = false;
            this.btnGetDimension.Click += new System.EventHandler(this.btnGetDimension_Click);
            // 
            // listBoxDatesDimension
            // 
            this.listBoxDatesDimension.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.listBoxDatesDimension.FormattingEnabled = true;
            this.listBoxDatesDimension.HorizontalScrollbar = true;
            this.listBoxDatesDimension.Location = new System.Drawing.Point(316, 90);
            this.listBoxDatesDimension.Name = "listBoxDatesDimension";
            this.listBoxDatesDimension.Size = new System.Drawing.Size(196, 160);
            this.listBoxDatesDimension.TabIndex = 2;
            // 
            // listBoxDates
            // 
            this.listBoxDates.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.listBoxDates.FormattingEnabled = true;
            this.listBoxDates.Location = new System.Drawing.Point(39, 90);
            this.listBoxDates.Name = "listBoxDates";
            this.listBoxDates.Size = new System.Drawing.Size(196, 160);
            this.listBoxDates.TabIndex = 1;
            // 
            // btnGetDates
            // 
            this.btnGetDates.BackColor = System.Drawing.Color.OldLace;
            this.btnGetDates.Location = new System.Drawing.Point(39, 23);
            this.btnGetDates.Name = "btnGetDates";
            this.btnGetDates.Size = new System.Drawing.Size(196, 50);
            this.btnGetDates.TabIndex = 0;
            this.btnGetDates.Text = "Get Dates From Source";
            this.btnGetDates.UseVisualStyleBackColor = false;
            this.btnGetDates.Click += new System.EventHandler(this.btnGetDates_Click);
            // 
            // Date
            // 
            this.Date.AccessibleDescription = "Date";
            this.Date.AccessibleName = "Date";
            this.Date.Controls.Add(this.tabPage1);
            this.Date.Controls.Add(this.tabPage2);
            this.Date.Location = new System.Drawing.Point(0, 0);
            this.Date.Name = "Date";
            this.Date.SelectedIndex = 0;
            this.Date.Size = new System.Drawing.Size(565, 550);
            this.Date.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 546);
            this.Controls.Add(this.Date);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datePieChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBarChart)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.Date.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox listBoxFactTable;
        private System.Windows.Forms.Button btnBuildFactTable;
        private System.Windows.Forms.Button btnGetDimension;
        private System.Windows.Forms.ListBox listBoxDatesDimension;
        private System.Windows.Forms.ListBox listBoxDates;
        private System.Windows.Forms.Button btnGetDates;
        private System.Windows.Forms.TabControl Date;
        private System.Windows.Forms.DataVisualization.Charting.Chart dateBarChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart datePieChart;
    }
}