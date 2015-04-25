using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

//using Plot3D;

namespace Fractals
{
    public partial class Main : Form
    {
        private List<double[]> mandelbrotValues;
        private List<double[]> juliaValues;
        private List<double[]> tempValues;
        private List<double> timeWaveValues;

        private Bitmap mandelbrotFractal;
        private Bitmap juliaFractal;
        private Bitmap tempFractal;
        private Bitmap timeWaveFractal;
        private Graphics mandelbrotGraphics;
        private Graphics juliaGraphics;
        private Graphics tempGraphics;
        private Graphics timeWaveGraphics;

        //private Surface3DRenderer surfaceRenderer;

        private Mandelbrot mandelbrot;
        private Julia julia;
        private TimeWave timeWave;

        private bool mouseDown;
        private bool mandelbrotCalculated;
        private bool render3D;
        private bool timeWaveCalculated;

        private int mouseX;
        private int mouseY;

        private int numZooms;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;

            //surfaceRenderer = new Surface3DRenderer(2, -3, 4, 0, 0, imgJulia.Width, imgJulia.Height, 0.5, 0, 0);
            //surfaceRenderer.ColorSchema = new ColorSchema(10);
            //render3D = false;

            mandelbrot = new Mandelbrot(this);
            julia = new Julia(this);

            DrawMandelbrot();
            DrawJulia();

            timeWave = new TimeWave();
            timeWaveCalculated = false;

            numZooms = 0;

            //mandelbrot = new Mandelbrot(new Point(MandelbrotBox.Width / 2, MandelbrotBox.Height / 2);
            //mandelbrotCalculated = false;
            //julia = new Julia(new Point(JuliaBox.Width / 2, JuliaBox.Height / 2);
            //juliaCalculated = false;
        }

        private void DrawMandelbrot()
        {
            lblMandelbrotWorking.Visible = true;
            Application.DoEvents();

            mandelbrotFractal = new Bitmap(imgMandelbrot.Width, imgMandelbrot.Height);
            mandelbrotGraphics = Graphics.FromImage(mandelbrotFractal);

            mandelbrotValues = mandelbrot.CalculateFractal(imgMandelbrot.Size, 750, false);

            double max = 0.0;

            foreach (double[] v in mandelbrotValues)
            {
                if (v[2] > max)
                {
                    max = v[2];
                }
            }

            foreach (double[] v in mandelbrotValues)
            {
                Color c = Color.Black;
                int specialNumber = 3;

                double maxPower = Math.Pow(specialNumber, 6);

                for (int i = -1; i < 5; i++)
                {
                    double power0 = Math.Pow(specialNumber, i);
                    double power1 = Math.Pow(specialNumber, i + 1);

                    if (i == -1)
                    {
                        power0 = 0;
                    }

                    if (v[2] / max >= power0 / maxPower && v[2] / max < power1 / maxPower)
                    {
                        int value = 255 * (int)(((v[2] / max) / (power1 / maxPower)) * 1000) / 1000;

                        switch (i + 1)
                        {
                            case 0:
                                c = Color.FromArgb(0, value, 255);
                                break;
                            case 1:
                                c = Color.FromArgb(0, 255, 255 - value);
                                break;
                            case 2:
                                c = Color.FromArgb(value, 255, 0);
                                break;
                            case 3:
                                c = Color.FromArgb(255, value, 0);
                                break;
                            case 4:
                                c = Color.FromArgb(255, 255 - value, 0);
                                break;
                            case 5:
                                c = Color.FromArgb(255 - value, 0, 255);
                                break;
                        }
                    }
                }

                /*
                for (int m = 0; m < numColours; m++)
                {
                    if (v[2] > f * m && v[2] < f * (m + 1))
                    {
                        c = Color.FromArgb((int)(255 - (255 * m / ((float)div + 1)) -
                                           (int)(v[2] * (int)(255 / (m * f))) / (float)div),
                                           (int)(3 * (255 - (255 * m / (div + 1)) -
                                           (int)(v[2] * (int)(255 / (m * f))) / (float)div) / 4.0),
                                           0);
                    }
                }
                */

                mandelbrotFractal.SetPixel((int)v[0], (int)v[1], c);
            }

            //mandelbrotGraphics.DrawLine(Pens.White,
            //             new Point(mandelbrotFractal.Width / 2, mandelbrotFractal.Height),
            //             new Point(mandelbrotFractal.Width / 2, 0));
            //mandelbrotGraphics.DrawLine(Pens.White,
            //                         new Point(0, mandelbrotFractal.Height / 2),
            //                         new Point(mandelbrotFractal.Width, mandelbrotFractal.Height / 2));

            imgMandelbrot.Image = mandelbrotFractal;
            lblMandelbrotWorking.Visible = false;
        }

        private void MandelbrotBox_MouseDown(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void MandelbrotBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (Math.Abs(e.X - mouseX) > 4 && Math.Abs(e.Y - mouseY) > 4)
            {
                double xRange = mandelbrot.xMax - mandelbrot.xMin;
                double previousXMin = mandelbrot.xMin;
                double minX = e.X > mouseX ? mouseX : e.X;
                double maxX = e.X > mouseX ? e.X : mouseX;

                double yRange = mandelbrot.yMax - mandelbrot.yMin;
                double previousYMin = mandelbrot.yMin;
                double minY = e.Y > mouseY ? imgMandelbrot.Height - e.Y : imgMandelbrot.Height - mouseY;
                double maxY = e.Y > mouseY ? imgMandelbrot.Height - mouseY : imgMandelbrot.Height - e.Y;

                double maxDiff = Math.Max(maxX - minX, maxY - minY);

                mandelbrot.xMin = previousXMin + xRange * (minX / imgMandelbrot.Width);
                mandelbrot.xMax = previousXMin + xRange * ((minX + maxDiff) / imgMandelbrot.Width);

                mandelbrot.yMin = previousYMin + yRange * (minY / imgMandelbrot.Height);
                mandelbrot.yMax = previousYMin + yRange * ((minY + maxDiff) / imgMandelbrot.Height);

                DrawMandelbrot();

                if (numZooms++ == 4)
                {
                    MessageBox.Show("Just so you know; the further you zoom in, the longer it'll take to calculate the fractals.", "Heads-up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void MandelbrotBox_DoubleClick(object sender, MouseEventArgs e)
        {
            julia.cx = mandelbrot.xMin + (e.X / (double)imgMandelbrot.Width) * (mandelbrot.xMax - mandelbrot.xMin);
            julia.cy = mandelbrot.yMin + (e.Y / (double)imgMandelbrot.Height) * (mandelbrot.yMax - mandelbrot.yMin);

            Complex.Text = ((float)julia.cx).ToString();
            if (julia.cy > 0)
                Complex.Text += "+";
            Complex.Text += ((float)julia.cy).ToString() + "i";

            Graphics.FromImage(imgMandelbrot.Image).DrawEllipse(new Pen(Color.PaleGreen, 2), e.X - 2, e.Y - 2, 4, 4);
            imgMandelbrot.Invalidate();
            Application.DoEvents();

            DrawJulia();
        }

        private void Complex_Click(object sender, EventArgs e)
        {
            string[] cValues = Complex.Text.Substring(1).Split("+-".ToCharArray());
            cValues[0] = Complex.Text[0] + cValues[0];

            if (Complex.SelectionStart <= cValues[0].Length)
            {
                Complex.SelectionStart = 0;
                Complex.SelectionLength = cValues[0].Length;
            }
            else
            {
                Complex.SelectionStart = cValues[0].Length;
                Complex.SelectionLength = cValues[1].Length;
            }
        }

        private void Complex_Leave(object sender, EventArgs e)
        {
            string[] cValues = Complex.Text.Substring(1).Split("+-".ToCharArray());
            cValues[0] = Complex.Text[0] + cValues[0];
            julia.cx = 0.0;
            julia.cy = 0.0;

            try
            {
                foreach (string c in cValues)
                {
                    if (c.Contains("i"))
                        julia.cy += Double.Parse(c.Replace("i", ""));
                    else
                        julia.cx += Double.Parse(c);
                }

                DrawJulia();
            }
            catch (FormatException)
            {
                MessageBox.Show("Couldn't parse the complex number, so using last good values.", "NACN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DrawJulia();
            }
        }

        private void chk3D_CheckedChanged(object sender, EventArgs e)
        {
            render3D = chk3D.Checked;
            Application.DoEvents();
            DrawJulia();
        }

        private void DrawJulia()
        {
            lblJuliaWorking.Visible = true;
            Application.DoEvents();

            juliaFractal = new Bitmap(imgJulia.Width, imgJulia.Height);
            juliaGraphics = Graphics.FromImage(juliaFractal);

            juliaValues = julia.CalculateFractal(imgJulia.Size, 50, 750, false);

            if (render3D)
            {
                double density = (julia.zxMax - julia.zxMin) / imgJulia.Width;

                //surfaceRenderer.RenderSurface(juliaGraphics,
                //                              new PointF((float)julia.zxMin, (float)julia.zyMin),
                //                              new PointF((float)julia.zxMax, (float)julia.zyMax),
                //                              density, juliaValues);
            }
            else
            {
                double max = 0.0;

                foreach (double[] v in juliaValues)
                {
                    if (v[2] > max)
                    {
                        max = v[2];
                    }
                }

                int specialNumber = 3;
                double maxPower = Math.Pow(specialNumber, 6);

                foreach (double[] v in juliaValues)
                {
                    Color c = Color.Black;

                    for (int i = -1; i < 5; i++)
                    {
                        double power0 = Math.Pow(specialNumber, i);
                        double power1 = Math.Pow(specialNumber, i + 1);

                        if (i == -1)
                        {
                            power0 = 0;
                        }

                        if (v[2] / max >= power0 / maxPower && v[2] / max < power1 / maxPower)
                        {
                            int value = 255 * (int)(((v[2] / max) / (power1 / maxPower)) * 1000) / 1000;

                            switch (i + 1)
                            {
                                case 0:
                                    c = Color.FromArgb(0, value, 255);
                                    break;
                                case 1:
                                    c = Color.FromArgb(0, 255, 255 - value);
                                    break;
                                case 2:
                                    c = Color.FromArgb(value, 255, 0);
                                    break;
                                case 3:
                                    c = Color.FromArgb(255, value, 0);
                                    break;
                                case 4:
                                    c = Color.FromArgb(255, 255 - value, 0);
                                    break;
                                case 5:
                                    c = Color.FromArgb(255 - value, 0, 255);
                                    break;
                            }
                        }
                    }

                    /*
                    for (int m = 0; m < numColours; m++)
                    {
                        if (v[2] > f * m && v[2] < f * (m + 1))
                        {
                            c = Color.FromArgb((int)(255 - (255 * m / ((float)div + 1)) -
                                               (int)(v[2] * (int)(255 / (m * f))) / (float)div),
                                               (int)(3 * (255 - (255 * m / (div + 1)) -
                                               (int)(v[2] * (int)(255 / (m * f))) / (float)div) / 4.0),
                                               0);
                        }
                    }
                    */

                    juliaFractal.SetPixel((int)v[0], (int)v[1], c);
                }
            }

            imgJulia.Image = juliaFractal;
            lblJuliaWorking.Visible = false;
        }

        private void JuliaBox_MouseDown(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void JuliaBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (Math.Abs(e.X - mouseX) > 4 && Math.Abs(e.Y - mouseY) > 4)
            {
                double juliaXRange = julia.zxMax - julia.zxMin;
                double previousXMin = julia.zxMin;
                double minX = e.X > mouseX ? mouseX : e.X;
                double maxX = e.X > mouseX ? e.X : mouseX;

                double juliaYRange = julia.zyMax - julia.zyMin;
                double previousYMin = julia.zyMin;
                double minY = e.Y > mouseY ? imgJulia.Height - e.Y : imgJulia.Height - mouseY;
                double maxY = e.Y > mouseY ? imgJulia.Height - mouseY : imgJulia.Height - e.Y;

                double maxDiff = Math.Max(maxX - minX, maxY - minY);

                julia.zxMin = previousXMin + juliaXRange * (minX / imgJulia.Width);
                julia.zxMax = previousXMin + juliaXRange * ((minX + maxDiff) / imgJulia.Width);

                julia.zyMin = previousYMin + juliaYRange * (minY / imgJulia.Height);
                julia.zyMax = previousYMin + juliaYRange * ((minY + maxDiff) / imgJulia.Height);

                DrawJulia();

                if (numZooms++ == 4)
                {
                    MessageBox.Show("Just so you know; the further you zoom in, the longer it'll take to calculate the fractal.", "A heads-up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
   
        private void FractalBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if ((PictureBox)sender == imgMandelbrot)
                {
                    tempFractal = new Bitmap(mandelbrotFractal);
                }
                else
                {
                    tempFractal = new Bitmap(juliaFractal);
                }

                Graphics tmp = Graphics.FromImage(tempFractal);

                float x = e.X > mouseX ? mouseX : e.X;
                float y = e.Y > mouseY ? mouseY : e.Y;
                float w = e.X > mouseX ? e.X - mouseX : mouseX - e.X;
                float h = e.Y > mouseY ? e.Y - mouseY : mouseY - e.Y;

                w = h = Math.Max(w, h);

                tmp.DrawRectangle(new Pen(Color.Green), x, y, w, h);

                if ((PictureBox)sender == imgMandelbrot)
                {
                    imgMandelbrot.Image = tempFractal;
                    imgMandelbrot.Invalidate();
                }

                else
                {
                    imgJulia.Image = tempFractal;
                    imgJulia.Invalidate();
                }

                Application.DoEvents();
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            numZooms = 0;

            mandelbrot.xMin = -2.5;
            mandelbrot.xMax = 1.5;
            mandelbrot.yMin = -2.0;
            mandelbrot.yMax = 2.0;

            DrawMandelbrot();

            julia.zxMin = -2.0;
            julia.zxMax = 2.0;
            julia.zyMin = -2.0;
            julia.zyMax = 2.0;

            DrawJulia();
        }

        private void DrawTimeWave(long numDays)
        {
            timeWaveFractal = new Bitmap(imgTimeWave.Width, imgTimeWave.Height);
            timeWaveGraphics = Graphics.FromImage(timeWaveFractal);
            Pen greenPen = new Pen(Color.Green, 1);
            Pen redPen = new Pen(Color.Red, 1);

            try
            {
                timeWaveValues = timeWave.CalculateFractal((new DateTime(2012, 12, 21) - EndDate.Value).Days, numDays, imgTimeWave.Width);

                if (timeWaveValues == null)
                    timeWaveValues = new List<double>();

                for (int i = 0; i < imgTimeWave.Width; i++)
                    timeWaveGraphics.DrawLine(greenPen,
                        i, imgTimeWave.Height - 1, i,
                        (float)(imgTimeWave.Height -
                        (
                            (
                                (Double.Parse(timeWaveValues[i].ToString()) - timeWave.Lowest) /
                                (timeWave.Highest - timeWave.Lowest)) *
                                imgTimeWave.Height
                            )
                        )
                    );

                int now = (EndDate.Value - DateTime.Now).Days;
                if (now < numDays)
                {
                    float nowPoint = imgTimeWave.Width - ((float)now / long.Parse(Days.Text) * imgTimeWave.Width);
                    timeWaveGraphics.DrawLine(redPen, nowPoint, 0, nowPoint, imgTimeWave.Height);
                }

                imgTimeWave.Image = timeWaveFractal;
                timeWaveCalculated = true;
            }
            catch (ArgumentOutOfRangeException)
            { }
        }

        private void TimeWaveBox_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            mouseX = e.X;
        }

        private void TimeWaveBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Pen pen = new Pen(Color.LightBlue, 1);
                DrawTimeWave(long.Parse(Days.Text = timeWave.ValidateDays(Days.Text)));
                mandelbrotGraphics.DrawRectangle(pen, mouseX, 0, e.X - mouseX, imgTimeWave.Height);
            }
        }

        private void TimeWaveBox_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;

            int endX = e.X;
            if (mouseX > endX)
            {
                endX = mouseX;
                mouseX = e.X;
            }

            TimeSpan span;

            try
            {
                span = new TimeSpan((int)(long.Parse(Days.Text) * (mouseX / (double)imgTimeWave.Width)), 0, 0, 0);
                StartDate.Value += span;

                span = new TimeSpan((int)(long.Parse(Days.Text) * (endX / (double)imgTimeWave.Width)), 0, 0, 0);
                EndDate.Value -= span;
            }
            catch (ArgumentOutOfRangeException)
            {
                Days.Text = ((endX - mouseX) * long.Parse(Days.Text) / imgTimeWave.Width).ToString();
            }
        }

        private void Days_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case System.Windows.Forms.Keys.Up:
                    Days.Text = (long.Parse(Days.Text) + 1).ToString();
                    break;
                case System.Windows.Forms.Keys.Down:
                    Days.Text = (long.Parse(Days.Text) - 1).ToString();
                    break;
            }
        }

        private void Days_TextChanged(object sender, EventArgs e)
        {
            long numDays = long.Parse(Days.Text = timeWave.ValidateDays(Days.Text));
            if (numDays > 0)
                DrawTimeWave(numDays);
        }

        private void EndDate_ValueChanged(object sender, EventArgs e)
        {
            if (EndDate.Value > new DateTime(2012, 12, 21))
                EndDate.Value = new DateTime(2012, 12, 21);

            if (EndDate.Value > StartDate.Value)
            {
                timeWave.StartDate = StartDate.Value;
                timeWave.EndDate = EndDate.Value;
            }
            else
            {
                timeWave.StartDate = EndDate.Value;
                timeWave.EndDate = StartDate.Value;
            }
            Days.Text = (timeWave.EndDate - timeWave.StartDate).Days.ToString();
        }

        private void FractalSelect_Click(object sender, EventArgs e)
        {
            if (FractalSelect.SelectedIndex == 1 && timeWaveCalculated == false)
                StartDate.Value = DateTime.Now;
        }

        private void StartDate_ValueChanged(object sender, EventArgs e)
        {
            if (EndDate.Value > StartDate.Value)
            {
                timeWave.StartDate = StartDate.Value;
                timeWave.EndDate = EndDate.Value;
            }
            else
            {
                timeWave.StartDate = EndDate.Value;
                timeWave.EndDate = StartDate.Value;
            }
            Days.Text = (timeWave.EndDate - timeWave.StartDate).Days.ToString();
        }

        public void UpdateSaveProgress(double percentComplete)
        {
            pgsSaveProgress.Value = Convert.ToInt32(percentComplete);
            Application.DoEvents();
        }

        private void btnOutputHighRes_Click(object sender, EventArgs e)
        {
            int size = Int32.Parse(txtImageSize.Text);
            DialogResult yesNo = DialogResult.Yes;

            if (size >= 2500 && size < 6000)
            {
                yesNo = MessageBox.Show("This is going to be a big image...like, really really big. Make sure you know how to kill " +
                    "the program if you need to and only continue if you're sure." + Environment.NewLine + Environment.NewLine +
                    "Do you want to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else if (size >= 6000 && size < 8000)
            {
                yesNo = MessageBox.Show("That's going to be a seriously big image - over 36 Megapixels. That kind of size is known to " +
                    "work on a fairly new laptop with 4GB of memory running Windows 7, but if you're running anything less then " +
                    "you may want to reconsider or use a different machine. At least make sure you know how to kill the program." + Environment.NewLine + Environment.NewLine +
                    "Do you want to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else if (size >= 8000)
            {
                yesNo = MessageBox.Show("OK, that's massive. As in stupidly, insanely high resolution. This one slowed down my AMD Phenom, " +
                    "4GB, Windows 7 system to the point where I had to kill the program, so make sure you know how to do the same. " +
                    "If you're absolutely sure, by all means continue, but you have been warned." + Environment.NewLine + Environment.NewLine +
                    "Do you want to do it?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            if (yesNo == DialogResult.Yes)
            {
                dlgSave.AddExtension = true;
                dlgSave.DefaultExt = ".png";
                dlgSave.Filter = "PNG Format|*.png";
                DialogResult dResult = dlgSave.ShowDialog();

                if (dResult == System.Windows.Forms.DialogResult.OK)
                {
                    tempFractal = new Bitmap(size, size);
                    tempGraphics = Graphics.FromImage(tempFractal);

                    pgsSaveProgress.Value = 0;

                    double max = 0.0;

                    if (rdoMandelbrot.Checked)
                    {
                        tempValues = mandelbrot.CalculateFractal(new Size(size, size), 750, true);

                        foreach (double[] v in mandelbrotValues)
                        {
                            if (v[2] > max)
                            {
                                max = v[2];
                            }
                        }
                    }
                    else
                    {
                        tempValues = julia.CalculateFractal(new Size(size, size), 50, 750, true);

                        foreach (double[] v in juliaValues)
                        {
                            if (v[2] > max)
                            {
                                max = v[2];
                            }
                        }
                    }

                    int specialNumber = 3;
                    double maxPower = Math.Pow(specialNumber, 6);

                    long count = -1;

                    foreach (double[] v in tempValues)
                    {
                        count++;
                        Color c = Color.Black;

                        for (int i = -1; i < 5; i++)
                        {
                            double power0 = Math.Pow(specialNumber, i);
                            double power1 = Math.Pow(specialNumber, i + 1);

                            if (i == -1)
                            {
                                power0 = 0;
                            }

                            if (v[2] / max >= power0 / maxPower && v[2] / max < power1 / maxPower)
                            {
                                int value = 255 * (int)(((v[2] / max) / (power1 / maxPower)) * 1000) / 1000;

                                switch (i + 1)
                                {
                                    case 0:
                                        c = Color.FromArgb(0, value, 255);
                                        break;
                                    case 1:
                                        c = Color.FromArgb(0, 255, 255 - value);
                                        break;
                                    case 2:
                                        c = Color.FromArgb(value, 255, 0);
                                        break;
                                    case 3:
                                        c = Color.FromArgb(255, value, 0);
                                        break;
                                    case 4:
                                        c = Color.FromArgb(255, 255 - value, 0);
                                        break;
                                    case 5:
                                        c = Color.FromArgb(255 - value, 0, 255);
                                        break;
                                }
                            }
                        }

                        tempFractal.SetPixel((int)v[0], (int)v[1], c);

                        if (count % (tempValues.Count / 100) == 0)
                        {
                            UpdateSaveProgress(count * 100 / (double)tempValues.Count);
                        }
                    }

                    tempFractal.Save(dlgSave.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
        }

        private void txtImageSize_Leave(object sender, EventArgs e)
        {
            int size;

            if (!Int32.TryParse(txtImageSize.Text, out size) || size < 20)
            {
                MessageBox.Show("Cannot parse the number entered for image size. Defaulting to 800.", "No idea", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtImageSize.Text = "800";
            }
        }
    }
}
