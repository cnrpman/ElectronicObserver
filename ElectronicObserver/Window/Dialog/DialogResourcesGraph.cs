using ElectronicObserver.Resource;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ElectronicObserver.Window.Dialog
{
    public partial class DialogResourcesGraph : Form
    {
        public DialogResourcesGraph()
        {
            InitializeComponent();
            this.Text = "资源图表";
            this.Icon = ResourceManager.ImageToIcon(ResourceManager.Instance.Icons.Images[(int)ResourceManager.IconContent.FormResourcesGraph]);

            try
            {
                loadResChart();
            }
            catch (IOException)
            {
                System.Windows.Forms.MessageBox.Show("load ResourceRecord failed.","エラー", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }
        }

        private int day2tbfloor(double day)
        {
            return (int)(Math.Sqrt(day) * 10);
        }

        private int day2tbceil(double day)
        {
            return (int)Math.Ceiling(Math.Sqrt(day) * 10);
        }

        private void loadResChart()
        {
            System.DateTime mindt = System.DateTime.Now;
            System.DateTime maxdt = new System.DateTime(1, 1, 1);
            List<string[]> dat=ReadCSV( System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase+"Record\\ResourceRecord.csv");
            for (int i = 0; i < dat.Count; i++)
            {
                System.DateTime parsedt = System.DateTime.Parse(dat[i][0]);
                if (parsedt < mindt)
                    mindt = parsedt;
                if (parsedt > maxdt)
                    maxdt = parsedt;
                double dt=parsedt.ToOADate();

                
                this.chart1.Series[0].Points.Add(new DataPoint(dt,dat[i][1]));
                this.chart1.Series[1].Points.Add(new DataPoint(dt, dat[i][2]));
                this.chart1.Series[2].Points.Add(new DataPoint(dt, dat[i][3]));
                this.chart1.Series[3].Points.Add(new DataPoint(dt, dat[i][4]));
                this.chart1.Series[4].Points.Add(new DataPoint(dt, dat[i][6]));
            }
            double maxdays = (System.DateTime.Now - mindt).TotalDays;
            trackBarDate.Maximum = day2tbceil(maxdays);//the farest day

            double mindays = (System.DateTime.Now - maxdt).TotalDays;
            trackBarDate.Minimum = day2tbceil(mindays);//nearest


            this.chart1.ChartAreas[0].AxisX.Maximum = System.DateTime.Now.ToOADate();
            if ((int)Math.Ceiling((System.DateTime.Now - maxdt).TotalDays) > 30)//if the nearly log is over 30 days
            {
                trackBarDate.Value = (trackBarDate.Maximum + trackBarDate.Minimum) >> 1;
                this.chart1.ChartAreas[0].AxisX.Minimum = (System.DateTime.Now - new System.TimeSpan((int)Math.Ceiling((double)trackBarDate.Value * trackBarDate.Value / 100), 0, 0, 0)).ToOADate();
                return;
            }

            double nowdays = Math.Min(maxdays, 36.0);//show chart in 36 days firstly
            trackBarDate.Value = day2tbceil(nowdays);
            this.chart1.ChartAreas[0].AxisX.Minimum = (System.DateTime.Now - new System.TimeSpan((int)Math.Ceiling((double)trackBarDate.Value * trackBarDate.Value / 100), 0, 0, 0)).ToOADate();
        }

        public static List<String[]> ReadCSV(string filePathName)
        {
            List<String[]> dat = new List<String[]>();
            StreamReader fileReader = new StreamReader(filePathName);
            string strLine = "";
            fileReader.ReadLine();
            while (strLine != null)
            {
                strLine = fileReader.ReadLine();
                if (strLine != null && strLine.Length > 0)
                {
                    dat.Add(strLine.Split(','));
                }
            }
            fileReader.Close();
            return dat;
        }

        private void DialogResourcesGraph_Load(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            TrackBar tb = sender as TrackBar;
            this.chart1.ChartAreas[0].AxisX.Minimum = (System.DateTime.Now - new System.TimeSpan((int)Math.Ceiling((double)tb.Value*tb.Value/100), 0, 0, 0)).ToOADate();
        }
    }
}
