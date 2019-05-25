using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace 大地坐标转换
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Parameter.x = 1;
            ReadAndWrite obj = new ReadAndWrite();
            obj.read();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (Parameter.p1[0, 0] == 0) MessageBox.Show("请先导入文件并计算！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                ReadAndWrite obj = new ReadAndWrite();
                obj.write();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Parameter.x = 0;
            ReadAndWrite obj = new ReadAndWrite();
            obj.read();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ReadAndWrite obj = new ReadAndWrite();
            obj.write();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Parameter.x = 0;
            ReadAndWrite obj = new ReadAndWrite();
            obj.read();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            ReadAndWrite obj = new ReadAndWrite();
            obj.write();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            listView3.Items.Clear();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Parameter.line; i++)
            {
                CoordinateConvert obj1 = new CoordinateConvert();
                Parameter.m = Parameter.p[i, 2];
                obj1.gausszheng(Parameter.p[i, 0], Parameter.p[i, 1], out Parameter.p1[i, 0], out Parameter.p1[i, 1]);
                ListViewItem lv = new ListViewItem();
                lv.Text = (i + 1).ToString();
                lv.SubItems.Add(Parameter.p1[i, 0].ToString("F4"));
                lv.SubItems.Add(Parameter.p1[i, 1].ToString("F4"));
                listView1.Items.Add(lv);
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            CoordinateConvert obj1 = new CoordinateConvert();
            for (int i = 0; i < Parameter.line; i++)
                obj1.gaussfan(Parameter.p[i, 0], Parameter.p[i, 1], out  Parameter.p1[i, 0], out  Parameter.p1[i, 1], Parameter.p[i, 2]);
            for (int i = 0; i < Parameter.line; i++)
            {
                ListViewItem lv = new ListViewItem();
                lv.Text = (i + 1).ToString();
                lv.SubItems.Add(Parameter.p1[i, 0].ToString("F4"));
                lv.SubItems.Add(Parameter.p1[i, 1].ToString("F4"));
                listView2.Items.Add(lv);
            }
        }
        private void button12_Click(object sender, EventArgs e)
        {
            CoordinateConvert obj1 = new CoordinateConvert();
            if (radioButton3.Checked == true)
                Parameter.m = 3;
            else
            {
                Parameter.m = 6;
            }
            for (int i = 0; i < Parameter.line; i++)
            {
                obj1.gaussfan(Parameter.p[i, 0], Parameter.p[i, 1], out  Parameter.p2[i, 0], out  Parameter.p2[i, 1], Parameter.p[i, 2]);
                Parameter.x = 1;
                obj1.gausszheng(Parameter.p2[i, 0], Parameter.p2[i, 1], out Parameter.p1[i, 0], out Parameter.p1[i, 1]);
            }
            for (int i = 0; i < Parameter.line; i++)
            {
                ListViewItem lv = new ListViewItem();
                lv.Text = (i + 1).ToString();
                lv.SubItems.Add(Parameter.p1[i, 0].ToString("F4"));
                lv.SubItems.Add(Parameter.p1[i, 1].ToString("F4"));
                listView3.Items.Add(lv);
            }
        }
    }
}

