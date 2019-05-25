using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
namespace 大地坐标转换
{
    class AngleConvert
    {
        public double DmsToDec(double a)
        {
            double j = (a - (int)a) * 100; j = (int)j;
            double k = (a - (int)a) * 10000 - j * 100;
            return (int)a + j / 60 + k / 3600;
        }
        public double DmsToRad(double e)
        {
            double j = (e - (int)e) * 100; j = (int)j;
            double k = (e - (int)e) * 10000 - j * 100;
            double c = (int)e + j / 60 + k / 3600;
            double b = c / 180 * Math.PI; return b;
        }
        public double DecToDms(double d)
        {
            int Degree = Convert.ToInt16(Math.Truncate(d));//度
            d = d - Degree;
            int M = Convert.ToInt16(Math.Truncate((d) * 60));//分
            int S = Convert.ToInt16(Math.Round((d * 60 - M) * 60));
            if (S > 59.5)
            {
                M = M + 1;
                S = 0;
            }
            if (M > 59.5)
            {
                M = 0;
                Degree = Degree + 1;
            }
            string rstr = Degree.ToString() + ".";
            if (M < 10)
            {
                rstr = rstr + "0" + M.ToString();
            }
            else
            {
                rstr = rstr + M.ToString();
            }
            if (S < 10)
            {
                rstr = rstr + "0" + S.ToString();
            }
            else
            {
                rstr = rstr + S.ToString();
            }
            double rstr1 = double.Parse(rstr);
            return rstr1;
        }
    }
}
