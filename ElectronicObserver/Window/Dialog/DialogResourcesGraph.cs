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
                System.Windows.Forms.MessageBox.Show("载入资源记录失败.请检查程序目录下Record/ResourceRecord.csv是否存在.（程序刚开始运行时不会产生该记录，请运行一段时间后再试）","错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
                this.Close();
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

        private bool loadResChart()
        {
            System.DateTime mindt = System.DateTime.Now;
            System.DateTime maxdt = new System.DateTime(1, 1, 1);
            List<string[]> dat=ReadCSV( System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase+"Record\\ResourceRecord.csv");
            if (dat.Count <= 1)
            {
                System.Windows.Forms.MessageBox.Show("资源记录过少.建议运行一段时间后再查看.目前仅有" + dat.Count + "项记录,不足以绘制折线图", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                this.Close();
                return false;
            }
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
                return true;
            }

            double nowdays = Math.Min(maxdays, 36.0);//show chart in 36 days firstly
            trackBarDate.Value = day2tbceil(nowdays);
            this.chart1.ChartAreas[0].AxisX.Minimum = (System.DateTime.Now - new System.TimeSpan((int)Math.Ceiling((double)trackBarDate.Value * trackBarDate.Value / 100), 0, 0, 0)).ToOADate();

            return true;
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

        private void checkBox_Keeper(int order,ref CheckBox cb)
        {
            int showed = 0;
            for (int i = 0; i <= 4; i++)
                showed += this.chart1.Series[i].Enabled ? 1 : 0;
            if (showed==0)
            {
                this.chart1.Series[order].Enabled = cb.Checked = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            this.chart1.Series[0].Enabled=cb.Checked;

            checkBox_Keeper(0, ref cb);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            this.chart1.Series[1].Enabled = cb.Checked;

            checkBox_Keeper(1, ref cb);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            this.chart1.Series[2].Enabled = cb.Checked;

            checkBox_Keeper(2, ref cb);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            this.chart1.Series[3].Enabled = cb.Checked;

            checkBox_Keeper(3, ref cb);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            this.chart1.Series[4].Enabled = cb.Checked;

            checkBox_Keeper(4, ref cb);
        }
    }
}
