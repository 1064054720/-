using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
namespace 大地坐标转换
{
    class ReadAndWrite
    {
        public void read()
        {
            int u = 1;
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                Parameter.a = op.FileName;
                int i, line = 0;
                string[] L = new string[20];
                StreamReader rd = File.OpenText(Parameter.a);
                while (rd.Peek() >= 0)
                {
                    L[line] = rd.ReadLine();
                    line++;
                }
                if (line == 0) { MessageBox.Show("数据文件为空文件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); u = 0; }
                Parameter.line = line;
                for (i = 0; i < line; i++)
                {
                    string[] data1 = L[i].Split(',');
                    try
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            Parameter.p[i, j] = Convert.ToDouble(data1[j]);
                        }
                        if (Parameter.x == 1)
                        {
                            if (Parameter.p[i, 0] < 0 || Parameter.p[i, 0] > 90) { MessageBox.Show("在第" + (i + 1) + "行纬度有问题！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); u = 0; }
                            if (Parameter.p[i, 1] < 0 || Parameter.p[i, 1] > 360) { MessageBox.Show("在第" + (i + 1) + "行经度有问题！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); u = 0; }
                        }
                    }
                    catch { MessageBox.Show("数据在第" + (i + 1) + "行有缺失！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); u = 0; }
                } if (u == 1) MessageBox.Show("数据导入成功！", "提示");
            } 
        }
        public void write()
        {
            OpenFileDialog op1 = new OpenFileDialog();
            
            if (op1.ShowDialog() == DialogResult.OK)
            {
                Parameter.b = op1.FileName;
                int i;
                using (StreamWriter sw = new StreamWriter(Parameter.b))
                {
                    for (i = 0; i < Parameter.line; i++)
                    {
                        sw.WriteLine("{0},{1}", Parameter.p1[i, 0], Parameter.p1[i, 1]);
                    }
                    MessageBox.Show("数据导出成功!", "提示");
                }
            }
        }
    }
}
