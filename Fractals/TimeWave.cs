using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Fractals
{
    class TimeWave
    {
        private const int a = 64;

        private int[] KingWenSequence = { 0, 0, 0, 2, 7, 4, 3, 2, 6, 8, 13, 5, 26, 25, 24, 15, 13, 16, 14, 19, 17, 24, 20, 25, 63, 60, 56, 55, 47, 53, 36, 38, 39, 43, 39, 35, 22, 24, 22, 21, 29, 30, 27, 26, 26, 21, 23, 19, 57, 62, 61, 55, 57, 57, 35, 50, 40, 29, 28, 26, 50, 51, 52, 61, 60, 60, 42, 42, 43, 43, 42, 41, 45, 41, 46, 23, 35, 34, 21, 21, 19, 51, 40, 49, 29, 29, 31, 40, 36, 33, 29, 26, 30, 16, 18, 14, 66, 64, 64, 56, 53, 57, 49, 51, 47, 44, 46, 47, 56, 51, 53, 25, 37, 30, 31, 28, 30, 36, 35, 22, 28, 32, 27, 32, 34, 35, 52, 49, 48, 51, 51, 53, 40, 43, 42, 26, 30, 28, 55, 41, 53, 52, 51, 47, 61, 64, 65, 39, 41, 41, 22, 21, 23, 43, 41, 38, 24, 22, 24, 14, 17, 19, 52, 50, 47, 42, 40, 42, 26, 27, 27, 34, 38, 33, 44, 44, 42, 41, 40, 37, 33, 31, 26, 44, 34, 38, 46, 44, 44, 36, 37, 34, 36, 36, 36, 38, 43, 38, 27, 26, 30, 32, 37, 29, 50, 49, 48, 29, 37, 36, 10, 19, 17, 24, 20, 25, 53, 52, 50, 53, 57, 55, 34, 44, 45, 13, 9, 5, 34, 26, 32, 31, 41, 42, 31, 32, 30, 21, 19, 23, 43, 36, 31, 47, 45, 43, 47, 62, 52, 41, 36, 38, 46, 47, 40, 43, 42, 42, 36, 38, 43, 53, 52, 53, 47, 49, 48, 47, 41, 44, 15, 11, 19, 51, 40, 49, 23, 23, 25, 34, 30, 27, 7, 4, 4, 32, 22, 32, 68, 70, 66, 68, 79, 71, 43, 45, 41, 38, 40, 41, 24, 25, 23, 35, 33, 38, 43, 50, 48, 18, 17, 26, 34, 38, 33, 38, 40, 41, 34, 31, 30, 33, 33, 35, 28, 23, 22, 26, 30, 26, 75, 77, 71, 62, 63, 63, 37, 40, 41, 49, 47, 51, 32, 37, 33, 49, 47, 44, 32, 38, 28, 38, 39, 37, 22, 20, 17, 44, 50, 40, 32, 33, 33, 40, 44, 39, 32, 32, 40, 39, 34, 41, 33, 33, 32, 32, 38, 36, 22, 20, 20, 12, 13, 10 };
        private long max;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public double Highest;
        public double Lowest;

        public TimeWave()
        {
            max = 111285730126426;
            EndDate = new DateTime(2012, 12, 21);

            Thread t = new Thread(new ThreadStart(FindMax));
            t.Start();
        }

        public void FindMax()
        {
            long a = max;
            long factor = 100000000000000;
            while (factor > 1)
            {
                try
                {
                    CalculateFractal(0, a, 768);
                }
                catch (Exception)
                {
                    factor /= 10;
                }

                if (a + factor < 0)
                    a += factor;
                else
                    break;
            }

            max = a - 1;
            EndDate = new DateTime(2012, 12, 21);
            Thread.CurrentThread.Abort();
        }

        public List<double> CalculateFractal(long start, long span, int imageWidth)
        {
            if (span < max)
            {
                List<double> values = new List<double>();
                Highest = 0;
                Lowest = max;

                double sum = 0;
                double x2;

                for (int x = 0; x < imageWidth; x++)
                {
                    try
                    {
                        if (start >= 0 && span > 0)
                        {
                            x2 = start + (x * (span / (double)imageWidth));

                            sum = 0;
                            sum += v(x2);
                            for (int i = 0; i < 10; i++)
                                sum += 2 * v(x2 / Math.Pow(a, i)) * Math.Pow(a, i);
                        }

                        if (sum > Highest)
                            Highest = sum;
                        if (sum < Lowest)
                            Lowest = sum;

                        values.Add(sum);
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                }

                values.Reverse();
                return values;
            }
            else
                return null;
        }

        public double v(double x)
        {
            try
            {
                return KingWenSequence[(long)x % 384] + (x - (long)x) *
                    (KingWenSequence[(long)(x + 1) % 384] - KingWenSequence[(long)x % 384]);
            }
            catch (IndexOutOfRangeException)
            {
                throw new Exception(x.ToString() + " is too large.");
            }
        }

        public string ValidateDays(string days)
        {
            if (string.IsNullOrEmpty(days))
                return "0";
            else
            {
                bool flag = false;
                char numStart = (char)48;
                char numEnd = (char)57;
                string s = "";

                foreach (char c in days)
                {
                    if (c >= numStart && c <= numEnd)
                        s += c;
                    else
                        flag = true;
                }

                if (flag)
                    MessageBox.Show("Characters other than numbers have been stripped out of the 'days' box.", "Numbers only!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (long.Parse(days) > max)
                {
                    MessageBox.Show("The number of days you have asked to compute is bigger than this program can handle.", "Too many days!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return max.ToString();
                }
                else
                    return s;
            }
        }


    }
}
