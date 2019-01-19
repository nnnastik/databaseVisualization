namespace chartDB
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
            this.FopdMartChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ProductClass = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Product = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SalesCity = new System.Windows.Forms.ListBox();
            this.refresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FopdMartChart)).BeginInit();
            this.SuspendLayout();
            // 
            // FopdMartChart
            // 
            this.FopdMartChart.AccessibleName = "FopdMartChart";
            chartArea2.Name = "ChartArea1";
            this.FopdMartChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.FopdMartChart.Legends.Add(legend2);
            this.FopdMartChart.Location = new System.Drawing.Point(12, 12);
            this.FopdMartChart.Name = "FopdMartChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Month";
            this.FopdMartChart.Series.Add(series2);
            this.FopdMartChart.Size = new System.Drawing.Size(671, 557);
            this.FopdMartChart.TabIndex = 0;
            this.FopdMartChart.Text = "FopdMartChart";
            this.FopdMartChart.Click += new System.EventHandler(this.chart1_Click);
            // 
            // ProductClass
            // 
            this.ProductClass.FormattingEnabled = true;
            this.ProductClass.Location = new System.Drawing.Point(701, 35);
            this.ProductClass.Name = "ProductClass";
            this.ProductClass.Size = new System.Drawing.Size(284, 134);
            this.ProductClass.TabIndex = 1;
            this.ProductClass.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(698, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Product Class";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(698, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Product";
            // 
            // Product
            // 
            this.Product.FormattingEnabled = true;
            this.Product.Location = new System.Drawing.Point(701, 212);
            this.Product.Name = "Product";
            this.Product.Size = new System.Drawing.Size(284, 121);
            this.Product.TabIndex = 4;
            this.Product.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(698, 343);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sales City";
            // 
            // SalesCity
            // 
            this.SalesCity.FormattingEnabled = true;
            this.SalesCity.Location = new System.Drawing.Point(701, 373);
            this.SalesCity.Name = "SalesCity";
            this.SalesCity.Size = new System.Drawing.Size(284, 134);
            this.SalesCity.TabIndex = 6;
            this.SalesCity.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(701, 540);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(132, 29);
            this.refresh.TabIndex = 7;
            this.refresh.Text = "Refresh Chart";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 609);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.SalesCity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Product);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProductClass);
            this.Controls.Add(this.FopdMartChart);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.FopdMartChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart FopdMartChart;
        private System.Windows.Forms.ListBox ProductClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox Product;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox SalesCity;
        private System.Windows.Forms.Button refresh;
    }
}

