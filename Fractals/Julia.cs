using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

/*
 * This class was designed to compute values for the Julia set using
 * the CLI. It computes the Julia set for Fc(z) = z^2 + c using the 
 * Distance Estimation Method for Julia set (DEM/J) algorithm, which
 * estimates the distance from point c to the nearest point in the
 * Julia set: for Fc(z)= z*z + c
 *                z(n+1) = Fc(zn)
 * This function was based on the function 'jdist' from mbrot.cpp
 * from a program mandel by Wolf Jung (GNU GPL )
 * http://www.mndynamics.com/indexp.html 
 *
 * Portions of this class have been converted from a c console program
 * written by Adam Majewski.
 * comments : Drew Morgan
 * ---------------------------------
 * I think that creating graphic can't be simpler
 * comments : Adam Majewski 
 */

namespace Fractals
{
    class Julia
    {
        private Main Parent;

        public double cx { get; set; }
        public double cy { get; set; }

        public double zxMin { get; set; }
        public double zxMax { get; set; }
        public double zyMin { get; set; }
        public double zyMax { get; set; }

        public Julia(Main parent)
        {
            Parent = parent;

            cx = -0.74543;
            cy = 0.11301;

            zxMin = -2.0;
            zxMax = 2.0;
            zyMin = -2.0;
            zyMax = 2.0;
        }

        public List<double[]> CalculateFractal(Size screen, int escapeRadius, int iterationMax, bool giveUpdates)
        {
            // Defaults set for all parameters except screen
            List<double[]> values = new List<double[]>();

            // screen coordinate
            int screenX;
            int screenY;
            int screenXMax = screen.Width;
            int screenYMax = screen.Height;
            
            double pixelWidth = (zxMax - zxMin) / screenXMax;
            double pixelHeight = (zyMax - zyMin) / screenYMax;

            // Color colour;
            double zx;
            double zy;
            double z0x;
            double z0y;
            double zxSq;
            double zySq;

            int er = escapeRadius > 0 ? escapeRadius : 50;
            int erSq = er * er;
            double distanceMax = pixelWidth / 15;

            for (screenY = 0; screenY < screenYMax; screenY++)
            {
                z0y = zyMax - screenY * pixelHeight; /* reverse Y  axis */

                if (Math.Abs(z0y) < pixelHeight / 2)
                {
                    z0y = 0.0;
                }

                for (screenX = 0; screenX < screenXMax; screenX++)
                {
                    double[] value = { (double)screenX, (double)screenY, 0.0 };

                    /* initial value of orbit z0 */
                    z0x = zxMin + screenX * pixelWidth;
                    
                    /* z = z0 */
                    zx = z0x;
                    zy = z0y;
                    zxSq = zx * zx;
                    zySq = zy * zy;

                    int i;
                    for (i = 0; i < iterationMax && (zxSq + zySq) < erSq; i++)
                    {
                        zy = 2 * zx * zy + cy;
                        zx = zxSq - zySq + cx;
                        zxSq = zx * zx;
                        zySq = zy * zy;
                    };

                    if (i == iterationMax) /* interior of Julia set */
                    {
                        value[2] = 0;
                    }
                    else /* exterior of Filled-in Julia set */
                    {
                        double distance = GetDistance(z0x, z0y, cx, cy, iterationMax);

                        if (distance < distanceMax)
                        {
                            value[2] = 0;
                        }
                        else
                        {
                            value[2] = distance;
                        }
                    }

                    values.Add(value);
                }

                if (giveUpdates)
                {
                    Parent.UpdateSaveProgress(screenY * 100 / (double)screenYMax);
                }
            }

            return values;
        }

        double GetDistance(double zx, double zy, double cx, double cy, int iMax)
        {
            double x = zx;
            double y = zy;
            double xp = 1;
            double yp = 0;
            /* temporary */
            double nz = 0;
            double nzp = 0;

            for (int i = 0; i < iMax; i++)
            { /* first derivative   zp = 2*z*zp + 1 = xp + yp*i; */
                nz = 2 * (x * xp - y * yp) + 1;
                yp = 2 * (x * yp + y * xp);
                xp = nz;
                /* z = z*z + c = x+y*i */
                nz = x * x - y * y + cx;
                y = 2 * x * y + cy;
                x = nz;
                /* */
                nz = x * x + y * y;
                nzp = xp * xp + yp * yp;

                if (nzp > Math.Pow(10, 60) || nz > Math.Pow(10, 60))
                {
                    break;
                }
            }

            double a = Math.Sqrt(nz);
            /* distance = 2 * |Zn| * log|Zn| / |dZn| */
            return 2 * a * Math.Log(a) / Math.Sqrt(nzp);
        }
    }
}
