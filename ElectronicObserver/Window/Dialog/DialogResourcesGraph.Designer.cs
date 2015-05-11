namespace ElectronicObserver.Window.Dialog
{
    partial class DialogResourcesGraph
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.trackBarDate = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDate)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Area3DStyle.Inclination = 20;
            chartArea1.Area3DStyle.IsRightAngleAxes = false;
            chartArea1.Area3DStyle.Rotation = 5;
            chartArea1.Area3DStyle.WallWidth = 1;
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.LabelAutoFitMaxFontSize = 8;
            chartArea1.AxisX.LabelAutoFitMinFontSize = 8;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.Title = "Date";
            chartArea1.AxisX.TitleAlignment = System.Drawing.StringAlignment.Near;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY.Title = "Resources";
            chartArea1.AxisY.TitleAlignment = System.Drawing.StringAlignment.Near;
            chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY2.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated270;
            chartArea1.AxisY2.Title = "Barrel";
            chartArea1.AxisY2.TitleAlignment = System.Drawing.StringAlignment.Near;
            chartArea1.BorderColor = System.Drawing.Color.Gainsboro;
            chartArea1.Name = "ResourcesChart";
            chartArea1.ShadowColor = System.Drawing.Color.DarkGray;
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Top;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ResourcesChart";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series1.Legend = "Legend1";
            series1.Name = "fuel";
            series1.SmartLabelStyle.CalloutLineAnchorCapStyle = System.Windows.Forms.DataVisualization.Charting.LineAnchorCapStyle.None;
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series2.ChartArea = "ResourcesChart";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.Name = "ammo";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series3.ChartArea = "ResourcesChart";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.DimGray;
            series3.Legend = "Legend1";
            series3.Name = "steel";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series4.ChartArea = "ResourcesChart";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series4.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series4.Legend = "Legend1";
            series4.Name = "bauxite";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series5.ChartArea = "ResourcesChart";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.DeepSkyBlue;
            series5.Legend = "Legend1";
            series5.Name = "barrel";
            series5.SmartLabelStyle.CalloutLineAnchorCapStyle = System.Windows.Forms.DataVisualization.Charting.LineAnchorCapStyle.None;
            series5.SmartLabelStyle.CalloutStyle = System.Windows.Forms.DataVisualization.Charting.LabelCalloutStyle.None;
            series5.SmartLabelStyle.Enabled = false;
            series5.SmartLabelStyle.IsOverlappedHidden = false;
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series5.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(728, 517);
            this.chart1.TabIndex = 0;
            this.chart1.TabStop = false;
            this.chart1.Text = "ResourcesGraphLineChart";
            // 
            // trackBarDate
            // 
            this.trackBarDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarDate.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.trackBarDate.CausesValidation = false;
            this.trackBarDate.Location = new System.Drawing.Point(589, 472);
            this.trackBarDate.Maximum = 30;
            this.trackBarDate.Minimum = 1;
            this.trackBarDate.Name = "trackBarDate";
            this.trackBarDate.Size = new System.Drawing.Size(139, 45);
            this.trackBarDate.TabIndex = 2;
            this.trackBarDate.Value = 1;
            this.trackBarDate.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // DialogResourcesGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 517);
            this.Controls.Add(this.trackBarDate);
            this.Controls.Add(this.chart1);
            this.Name = "DialogResourcesGraph";
            this.Text = "DialogResourcesGraph";
            this.Load += new System.EventHandler(this.DialogResourcesGraph_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TrackBar trackBarDate;
    }
}