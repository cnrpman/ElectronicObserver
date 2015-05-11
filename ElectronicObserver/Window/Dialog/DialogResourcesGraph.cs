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

        private void loadResChart()
        {
            System.DateTime mindt = System.DateTime.Today;
            List<string[]> dat=ReadCSV( System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase+"Record\\ResourceRecord.csv");
            for (int i = 0; i < dat.Count; i++)
            {
                System.DateTime parsedt = System.DateTime.Parse(dat[i][0]);
                if (parsedt < mindt)
                    mindt = parsedt;
                double dt=parsedt.ToOADate();

                
                this.chart1.Series[0].Points.Add(new DataPoint(dt,dat[i][1]));
                this.chart1.Series[1].Points.Add(new DataPoint(dt, dat[i][2]));
                this.chart1.Series[2].Points.Add(new DataPoint(dt, dat[i][3]));
                this.chart1.Series[3].Points.Add(new DataPoint(dt, dat[i][4]));
                this.chart1.Series[4].Points.Add(new DataPoint(dt, dat[i][6]));
            }
            int maxdays = (int)Math.Ceiling((System.DateTime.Today - mindt).TotalDays);
            maxdays = Math.Max(maxdays, 2);
            trackBarDate.Maximum = maxdays;
            trackBarDate.Value = maxdays;
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
            this.chart1.ChartAreas[0].AxisX.Minimum = (System.DateTime.Today - new System.TimeSpan(tb.Value, 0, 0, 0)).ToOADate();
        }
    }
}
