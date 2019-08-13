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
            this.Date = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnGetDates = new System.Windows.Forms.Button();
            this.listBoxDates = new System.Windows.Forms.ListBox();
            this.listBoxDatesDimension = new System.Windows.Forms.ListBox();
            this.btnGetDimension = new System.Windows.Forms.Button();
            this.lstChartKey = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.Date.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Date
            // 
            this.Date.AccessibleName = "Date";
            this.Date.Controls.Add(this.tabPage1);
            this.Date.Controls.Add(this.tabPage2);
            this.Date.Controls.Add(this.tabPage3);
            this.Date.Controls.Add(this.tabPage4);
            this.Date.Location = new System.Drawing.Point(0, 0);
            this.Date.Name = "Date";
            this.Date.SelectedIndex = 0;
            this.Date.Size = new System.Drawing.Size(788, 438);
            this.Date.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnGetDimension);
            this.tabPage1.Controls.Add(this.listBoxDatesDimension);
            this.tabPage1.Controls.Add(this.listBoxDates);
            this.tabPage1.Controls.Add(this.btnGetDates);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(780, 412);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ETL";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnGetDates
            // 
            this.btnGetDates.Location = new System.Drawing.Point(39, 23);
            this.btnGetDates.Name = "btnGetDates";
            this.btnGetDates.Size = new System.Drawing.Size(196, 50);
            this.btnGetDates.TabIndex = 0;
            this.btnGetDates.Text = "Get Dates From Source";
            this.btnGetDates.UseVisualStyleBackColor = true;
            this.btnGetDates.Click += new System.EventHandler(this.btnGetDates_Click);
            // 
            // listBoxDates
            // 
            this.listBoxDates.FormattingEnabled = true;
            this.listBoxDates.Location = new System.Drawing.Point(39, 99);
            this.listBoxDates.Name = "listBoxDates";
            this.listBoxDates.Size = new System.Drawing.Size(196, 160);
            this.listBoxDates.TabIndex = 1;
            // 
            // listBoxDatesDimension
            // 
            this.listBoxDatesDimension.FormattingEnabled = true;
            this.listBoxDatesDimension.HorizontalScrollbar = true;
            this.listBoxDatesDimension.Location = new System.Drawing.Point(316, 99);
            this.listBoxDatesDimension.Name = "listBoxDatesDimension";
            this.listBoxDatesDimension.Size = new System.Drawing.Size(196, 160);
            this.listBoxDatesDimension.TabIndex = 2;
            // 
            // btnGetDimension
            // 
            this.btnGetDimension.Location = new System.Drawing.Point(316, 23);
            this.btnGetDimension.Name = "btnGetDimension";
            this.btnGetDimension.Size = new System.Drawing.Size(196, 50);
            this.btnGetDimension.TabIndex = 3;
            this.btnGetDimension.Text = "GetDates From Dimension";
            this.btnGetDimension.UseVisualStyleBackColor = true;
            this.btnGetDimension.Click += new System.EventHandler(this.btnGetDimension_Click);
            // 
            // lstChartKey
            // 
            this.lstChartKey.FormattingEnabled = true;
            this.lstChartKey.Location = new System.Drawing.Point(29, 79);
            this.lstChartKey.Name = "lstChartKey";
            this.lstChartKey.Size = new System.Drawing.Size(255, 212);
            this.lstChartKey.TabIndex = 0;
            this.lstChartKey.SelectedIndexChanged += new System.EventHandler(this.listBoxDates_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lstChartKey);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(780, 412);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dashboard 1";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(780, 412);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Dashboard 3";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(780, 412);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Dashboard 2";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Date);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Date.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl Date;
        private System.Windows.Forms.Button btnGetDimension;
        private System.Windows.Forms.ListBox listBoxDatesDimension;
        private System.Windows.Forms.ListBox listBoxDates;
        private System.Windows.Forms.Button btnGetDates;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox lstChartKey;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
    }
}