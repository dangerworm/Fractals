namespace Fractals
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FractalSelect = new System.Windows.Forms.TabControl();
            this.MandelbrotJulia = new System.Windows.Forms.TabPage();
            this.chk3D = new System.Windows.Forms.CheckBox();
            this.pgsSaveProgress = new System.Windows.Forms.ProgressBar();
            this.btnOutputHighRes = new System.Windows.Forms.Button();
            this.rdoJulia = new System.Windows.Forms.RadioButton();
            this.rdoMandelbrot = new System.Windows.Forms.RadioButton();
            this.lblImageSize = new System.Windows.Forms.Label();
            this.txtImageSize = new System.Windows.Forms.TextBox();
            this.lblMandelbrotWorking = new System.Windows.Forms.Label();
            this.Reset = new System.Windows.Forms.Button();
            this.lblJuliaWorking = new System.Windows.Forms.Label();
            this.imgJulia = new System.Windows.Forms.PictureBox();
            this.lblComplex = new System.Windows.Forms.Label();
            this.Complex = new System.Windows.Forms.TextBox();
            this.imgMandelbrot = new System.Windows.Forms.PictureBox();
            this.TimeWave = new System.Windows.Forms.TabPage();
            this.imgTimeWave = new System.Windows.Forms.PictureBox();
            this.EndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.StartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblDays = new System.Windows.Forms.Label();
            this.Days = new System.Windows.Forms.TextBox();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.FractalSelect.SuspendLayout();
            this.MandelbrotJulia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgJulia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMandelbrot)).BeginInit();
            this.TimeWave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTimeWave)).BeginInit();
            this.SuspendLayout();
            // 
            // FractalSelect
            // 
            this.FractalSelect.Controls.Add(this.MandelbrotJulia);
            this.FractalSelect.Controls.Add(this.TimeWave);
            this.FractalSelect.HotTrack = true;
            this.FractalSelect.Location = new System.Drawing.Point(12, 12);
            this.FractalSelect.Name = "FractalSelect";
            this.FractalSelect.SelectedIndex = 0;
            this.FractalSelect.Size = new System.Drawing.Size(792, 475);
            this.FractalSelect.TabIndex = 0;
            this.FractalSelect.Click += new System.EventHandler(this.FractalSelect_Click);
            // 
            // MandelbrotJulia
            // 
            this.MandelbrotJulia.BackColor = System.Drawing.SystemColors.Control;
            this.MandelbrotJulia.Controls.Add(this.chk3D);
            this.MandelbrotJulia.Controls.Add(this.pgsSaveProgress);
            this.MandelbrotJulia.Controls.Add(this.btnOutputHighRes);
            this.MandelbrotJulia.Controls.Add(this.rdoJulia);
            this.MandelbrotJulia.Controls.Add(this.rdoMandelbrot);
            this.MandelbrotJulia.Controls.Add(this.lblImageSize);
            this.MandelbrotJulia.Controls.Add(this.txtImageSize);
            this.MandelbrotJulia.Controls.Add(this.lblMandelbrotWorking);
            this.MandelbrotJulia.Controls.Add(this.Reset);
            this.MandelbrotJulia.Controls.Add(this.lblJuliaWorking);
            this.MandelbrotJulia.Controls.Add(this.imgJulia);
            this.MandelbrotJulia.Controls.Add(this.lblComplex);
            this.MandelbrotJulia.Controls.Add(this.Complex);
            this.MandelbrotJulia.Controls.Add(this.imgMandelbrot);
            this.MandelbrotJulia.Location = new System.Drawing.Point(4, 22);
            this.MandelbrotJulia.Name = "MandelbrotJulia";
            this.MandelbrotJulia.Padding = new System.Windows.Forms.Padding(3);
            this.MandelbrotJulia.Size = new System.Drawing.Size(784, 449);
            this.MandelbrotJulia.TabIndex = 0;
            this.MandelbrotJulia.Text = "Mandelbrot and Julia Sets";
            // 
            // chk3D
            // 
            this.chk3D.AutoSize = true;
            this.chk3D.Location = new System.Drawing.Point(660, 8);
            this.chk3D.Name = "chk3D";
            this.chk3D.Size = new System.Drawing.Size(118, 17);
            this.chk3D.TabIndex = 43;
            this.chk3D.Text = "3D Surface Render";
            this.chk3D.UseVisualStyleBackColor = true;
            this.chk3D.Visible = false;
            this.chk3D.CheckedChanged += new System.EventHandler(this.chk3D_CheckedChanged);
            // 
            // pgsSaveProgress
            // 
            this.pgsSaveProgress.Location = new System.Drawing.Point(450, 420);
            this.pgsSaveProgress.Name = "pgsSaveProgress";
            this.pgsSaveProgress.Size = new System.Drawing.Size(328, 22);
            this.pgsSaveProgress.TabIndex = 42;
            // 
            // btnOutputHighRes
            // 
            this.btnOutputHighRes.Location = new System.Drawing.Point(283, 420);
            this.btnOutputHighRes.Name = "btnOutputHighRes";
            this.btnOutputHighRes.Size = new System.Drawing.Size(161, 23);
            this.btnOutputHighRes.TabIndex = 6;
            this.btnOutputHighRes.Text = "Output High Resolution Copy";
            this.btnOutputHighRes.UseVisualStyleBackColor = true;
            this.btnOutputHighRes.Click += new System.EventHandler(this.btnOutputHighRes_Click);
            // 
            // rdoJulia
            // 
            this.rdoJulia.AutoSize = true;
            this.rdoJulia.Location = new System.Drawing.Point(92, 423);
            this.rdoJulia.Name = "rdoJulia";
            this.rdoJulia.Size = new System.Drawing.Size(46, 17);
            this.rdoJulia.TabIndex = 4;
            this.rdoJulia.TabStop = true;
            this.rdoJulia.Text = "Julia";
            this.rdoJulia.UseVisualStyleBackColor = true;
            // 
            // rdoMandelbrot
            // 
            this.rdoMandelbrot.AutoSize = true;
            this.rdoMandelbrot.Checked = true;
            this.rdoMandelbrot.Location = new System.Drawing.Point(9, 423);
            this.rdoMandelbrot.Name = "rdoMandelbrot";
            this.rdoMandelbrot.Size = new System.Drawing.Size(78, 17);
            this.rdoMandelbrot.TabIndex = 3;
            this.rdoMandelbrot.TabStop = true;
            this.rdoMandelbrot.Text = "Mandelbrot";
            this.rdoMandelbrot.UseVisualStyleBackColor = true;
            // 
            // lblImageSize
            // 
            this.lblImageSize.AutoSize = true;
            this.lblImageSize.Location = new System.Drawing.Point(144, 425);
            this.lblImageSize.Name = "lblImageSize";
            this.lblImageSize.Size = new System.Drawing.Size(82, 13);
            this.lblImageSize.TabIndex = 38;
            this.lblImageSize.Text = "Image Size (px):";
            // 
            // txtImageSize
            // 
            this.txtImageSize.Location = new System.Drawing.Point(232, 422);
            this.txtImageSize.Name = "txtImageSize";
            this.txtImageSize.Size = new System.Drawing.Size(45, 20);
            this.txtImageSize.TabIndex = 5;
            this.txtImageSize.Text = "800";
            this.txtImageSize.Leave += new System.EventHandler(this.txtImageSize_Leave);
            // 
            // lblMandelbrotWorking
            // 
            this.lblMandelbrotWorking.AutoSize = true;
            this.lblMandelbrotWorking.BackColor = System.Drawing.Color.Black;
            this.lblMandelbrotWorking.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMandelbrotWorking.ForeColor = System.Drawing.Color.White;
            this.lblMandelbrotWorking.Location = new System.Drawing.Point(20, 391);
            this.lblMandelbrotWorking.Name = "lblMandelbrotWorking";
            this.lblMandelbrotWorking.Size = new System.Drawing.Size(66, 13);
            this.lblMandelbrotWorking.TabIndex = 31;
            this.lblMandelbrotWorking.Text = "Working...";
            this.lblMandelbrotWorking.Visible = false;
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(322, 5);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(68, 21);
            this.Reset.TabIndex = 2;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // lblJuliaWorking
            // 
            this.lblJuliaWorking.AutoSize = true;
            this.lblJuliaWorking.BackColor = System.Drawing.Color.Black;
            this.lblJuliaWorking.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJuliaWorking.ForeColor = System.Drawing.Color.White;
            this.lblJuliaWorking.Location = new System.Drawing.Point(406, 391);
            this.lblJuliaWorking.Name = "lblJuliaWorking";
            this.lblJuliaWorking.Size = new System.Drawing.Size(66, 13);
            this.lblJuliaWorking.TabIndex = 30;
            this.lblJuliaWorking.Text = "Working...";
            this.lblJuliaWorking.Visible = false;
            // 
            // imgJulia
            // 
            this.imgJulia.Location = new System.Drawing.Point(396, 32);
            this.imgJulia.Name = "imgJulia";
            this.imgJulia.Size = new System.Drawing.Size(382, 382);
            this.imgJulia.TabIndex = 27;
            this.imgJulia.TabStop = false;
            this.imgJulia.MouseDown += new System.Windows.Forms.MouseEventHandler(this.JuliaBox_MouseDown);
            this.imgJulia.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FractalBox_MouseMove);
            this.imgJulia.MouseUp += new System.Windows.Forms.MouseEventHandler(this.JuliaBox_MouseUp);
            // 
            // lblComplex
            // 
            this.lblComplex.AutoSize = true;
            this.lblComplex.Location = new System.Drawing.Point(6, 9);
            this.lblComplex.Name = "lblComplex";
            this.lblComplex.Size = new System.Drawing.Size(80, 13);
            this.lblComplex.TabIndex = 26;
            this.lblComplex.Text = "Complex Value:";
            // 
            // Complex
            // 
            this.Complex.Location = new System.Drawing.Point(92, 6);
            this.Complex.Name = "Complex";
            this.Complex.Size = new System.Drawing.Size(209, 20);
            this.Complex.TabIndex = 1;
            this.Complex.Text = "-0.74543+0.11301i";
            this.Complex.Click += new System.EventHandler(this.Complex_Click);
            this.Complex.Leave += new System.EventHandler(this.Complex_Leave);
            // 
            // imgMandelbrot
            // 
            this.imgMandelbrot.BackColor = System.Drawing.Color.Transparent;
            this.imgMandelbrot.Location = new System.Drawing.Point(8, 32);
            this.imgMandelbrot.Name = "imgMandelbrot";
            this.imgMandelbrot.Size = new System.Drawing.Size(382, 382);
            this.imgMandelbrot.TabIndex = 24;
            this.imgMandelbrot.TabStop = false;
            this.imgMandelbrot.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MandelbrotBox_DoubleClick);
            this.imgMandelbrot.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MandelbrotBox_MouseDown);
            this.imgMandelbrot.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FractalBox_MouseMove);
            this.imgMandelbrot.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MandelbrotBox_MouseUp);
            // 
            // TimeWave
            // 
            this.TimeWave.BackColor = System.Drawing.Color.Transparent;
            this.TimeWave.Controls.Add(this.imgTimeWave);
            this.TimeWave.Controls.Add(this.EndDate);
            this.TimeWave.Controls.Add(this.lblEndDate);
            this.TimeWave.Controls.Add(this.StartDate);
            this.TimeWave.Controls.Add(this.lblStartDate);
            this.TimeWave.Controls.Add(this.lblDays);
            this.TimeWave.Controls.Add(this.Days);
            this.TimeWave.Location = new System.Drawing.Point(4, 22);
            this.TimeWave.Name = "TimeWave";
            this.TimeWave.Padding = new System.Windows.Forms.Padding(3);
            this.TimeWave.Size = new System.Drawing.Size(784, 449);
            this.TimeWave.TabIndex = 1;
            this.TimeWave.Text = "Time Wave";
            this.TimeWave.UseVisualStyleBackColor = true;
            // 
            // imgTimeWave
            // 
            this.imgTimeWave.Location = new System.Drawing.Point(8, 32);
            this.imgTimeWave.Name = "imgTimeWave";
            this.imgTimeWave.Size = new System.Drawing.Size(768, 411);
            this.imgTimeWave.TabIndex = 23;
            this.imgTimeWave.TabStop = false;
            this.imgTimeWave.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TimeWaveBox_MouseDown);
            this.imgTimeWave.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TimeWaveBox_MouseMove);
            this.imgTimeWave.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TimeWaveBox_MouseUp);
            // 
            // EndDate
            // 
            this.EndDate.Location = new System.Drawing.Point(576, 6);
            this.EndDate.Name = "EndDate";
            this.EndDate.Size = new System.Drawing.Size(200, 20);
            this.EndDate.TabIndex = 9;
            this.EndDate.Value = new System.DateTime(2012, 12, 21, 0, 0, 0, 0);
            this.EndDate.ValueChanged += new System.EventHandler(this.EndDate_ValueChanged);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(515, 10);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(55, 13);
            this.lblEndDate.TabIndex = 21;
            this.lblEndDate.Text = "End Date:";
            // 
            // StartDate
            // 
            this.StartDate.Location = new System.Drawing.Point(69, 6);
            this.StartDate.Name = "StartDate";
            this.StartDate.Size = new System.Drawing.Size(200, 20);
            this.StartDate.TabIndex = 7;
            this.StartDate.Value = new System.DateTime(2008, 8, 19, 0, 0, 0, 0);
            this.StartDate.ValueChanged += new System.EventHandler(this.StartDate_ValueChanged);
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(5, 10);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(58, 13);
            this.lblStartDate.TabIndex = 19;
            this.lblStartDate.Text = "Start Date:";
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Location = new System.Drawing.Point(296, 9);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(70, 13);
            this.lblDays.TabIndex = 18;
            this.lblDays.Text = "Days Shown:";
            // 
            // Days
            // 
            this.Days.Location = new System.Drawing.Point(372, 6);
            this.Days.Name = "Days";
            this.Days.Size = new System.Drawing.Size(119, 20);
            this.Days.TabIndex = 8;
            this.Days.TextChanged += new System.EventHandler(this.Days_TextChanged);
            this.Days.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Days_KeyUp);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 499);
            this.Controls.Add(this.FractalSelect);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Fractal Generator";
            this.Load += new System.EventHandler(this.Main_Load);
            this.FractalSelect.ResumeLayout(false);
            this.MandelbrotJulia.ResumeLayout(false);
            this.MandelbrotJulia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgJulia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMandelbrot)).EndInit();
            this.TimeWave.ResumeLayout(false);
            this.TimeWave.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTimeWave)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl FractalSelect;
        private System.Windows.Forms.TabPage MandelbrotJulia;
        private System.Windows.Forms.TabPage TimeWave;
        private System.Windows.Forms.PictureBox imgTimeWave;
        private System.Windows.Forms.DateTimePicker EndDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker StartDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.TextBox Days;
        private System.Windows.Forms.Label lblComplex;
        private System.Windows.Forms.TextBox Complex;
        private System.Windows.Forms.PictureBox imgMandelbrot;
        private System.Windows.Forms.PictureBox imgJulia;
        private System.Windows.Forms.Label lblJuliaWorking;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Label lblMandelbrotWorking;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.Button btnOutputHighRes;
        private System.Windows.Forms.RadioButton rdoJulia;
        private System.Windows.Forms.RadioButton rdoMandelbrot;
        private System.Windows.Forms.Label lblImageSize;
        private System.Windows.Forms.TextBox txtImageSize;
        private System.Windows.Forms.ProgressBar pgsSaveProgress;
        private System.Windows.Forms.CheckBox chk3D;
    }
}

