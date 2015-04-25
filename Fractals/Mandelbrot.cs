using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

/*
 * This class was designed to compute values for the Mandelbrot set
 * using the CLI.
 * This function was based on code found at
 * http://www.openicon.com/tech/icon/icon_construction_mandelbrot.html
 * comments : Drew Morgan
 */

namespace Fractals
{
    class Mandelbrot
    {
        private Main Parent;

        public double x, y, x2, y2, x0, y0;
        public int iter;

        public double xMin { get; set; }
        public double xMax { get; set; }
        public double yMin { get; set; }
        public double yMax { get; set; }

        public Mandelbrot(Main parent)
        {
            Parent = parent;
            xMin = -2.5;
            xMax = 1.5;
            yMin = -2;
            yMax = 2;
        }

        public List<double[]> CalculateFractal(Size screen, int maxIteration, bool giveUpdates)
        {
            // Defaults set for all parameters except screen
            List<double[]> values = new List<double[]>();

            // screen coordinate
            int screenX;
            int screenY;
            int screenXMax = screen.Width;
            int screenYMax = screen.Height;

            double pixelWidth = (xMax - xMin) / screenXMax;
            double pixelHeight = (yMax - yMin) / screenYMax;

            for (screenY = 0; screenY < screenYMax; screenY++)
            {
                for (screenX = 0; screenX < screenXMax; screenX++)
                {
                    double[] value = { (double)screenX, (double)(screenYMax - screenY - 1), 0.0 };

                    iter = 0;
                    x = xMin + (screenX * pixelWidth);
                    y = yMin + (screenY * pixelHeight);

                    x0 = x;
                    y0 = y;
                    x2 = x * x;
                    y2 = y * y;

                    while ((x2 + y2 < 8) && iter < maxIteration)
                    {
                        y = (2 * x * y) + y0;
                        x = x2 - y2 + x0;
                        x2 = x * x;
                        y2 = y * y;
                        iter++;
                    }

                    value[2] = (double)iter;
                    values.Add(value);
                }

                if (giveUpdates)
                {
                    Parent.UpdateSaveProgress(screenY * 100/ (double)screenYMax);
                }
            }

            return values;
        }
    }
}
