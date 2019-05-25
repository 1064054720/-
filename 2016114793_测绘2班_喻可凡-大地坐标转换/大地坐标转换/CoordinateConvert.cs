using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
namespace 大地坐标转换
{
    class CoordinateConvert
    {
        public void gausszheng(double B, double L, out double x, out double y)
        {
            AngleConvert obj = new AngleConvert();
            double N, a0, a4, a6, a3, a5, l, n, L0;
            B = obj.DmsToRad(B);
            double cos2 = Math.Cos(B) * Math.Cos(B); L = obj.DmsToDec(L);
            if (Parameter.m == 6)
            {
                n = (int)(L / 6);
                L0 = 6 * n;
                if (L < L0) L0 = L0 - 3;
                else L0 = L0 + 3;
            }
            else
            {
                n = (int)(L / 3);
                L0 = 3 * n + 1.5;
                if (L > L0) L0 = L0 + 1.5;
                else L0 = L0 - 1.5;
            }
            l = (L - L0) / 180 * Math.PI;
            N = 6399596.652 - (21565.045 - (108.996 - 0.603 * cos2) * cos2) * cos2;
            a0 = 32144.5189 - (135.3646 - (0.7034 - 0.0041 * cos2) * cos2) * cos2;
            a4 = (0.25 + 0.00253 * cos2) * cos2 - 0.04167;
            a6 = (0.167 * cos2 - 0.083) * cos2;
            a3 = (0.3333333 + 0.001123 * cos2) * cos2 - 0.1666667;
            a5 = 0.00878 - (0.1702 - 0.20382 * cos2) * cos2;
            x = 6367452.1328 * B - (a0 - (0.5 + (a4 + a6 * l * l) * l * l) * l * l * N) * Math.Cos(B) * Math.Sin(B);
            y = (1 + (a3 + a5 * l * l) * l * l) * l * N * Math.Cos(B) + 500000;
        }
        public void gaussfan(double x, double y, out double B, out double L, double n)
        {
            y = y - 500000;
            AngleConvert obj = new AngleConvert();
            double b = x / 6367452.133; double bf = b + (50228976 + (293697 + (2383 + 22 * Math.Pow(Math.Cos(b), 2)) * Math.Pow(Math.Cos(b), 2)) * Math.Pow(Math.Cos(b), 2)) * 1e-10 * Math.Sin(b) * Math.Cos(b);
            double cos2 = Math.Cos(bf) * Math.Cos(bf);
            double b2 = (0.5 + 0.00336975 * cos2) * Math.Sin(bf) * Math.Cos(bf);
            double b3 = 0.333333 - (0.1666667 - 0.001123 * cos2) * cos2;
            double b4 = 0.25 + (0.161612 + 0.005617 * cos2) * cos2;
            double b5 = 0.2 - (0.16667 - 0.00878 * cos2) * cos2;
            double Nf = 6378140 / Math.Sqrt(1 - 0.006694384999588 * Math.Sin(bf) * Math.Sin(bf));
            double Z2 = Math.Pow(y / (Nf * Math.Cos(bf)), 2);
            double Z = y / (Nf * Math.Cos(bf));
            B = bf / Math.PI * 180 - (1 - (b4 - 0.147 * Z2) * Z2) * Z2 * b2 * 206265 / 3600;
            L = (1 - (b3 - b5 * Z2) * Z2) * Z * 206265 / 3600;
            L = n + L;
            B = obj.DecToDms(B); L = obj.DecToDms(L);
        }
    }
}
