namespace GasBubble.WinForm
{
    partial class GasBubbleForm
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtSimTime = new System.Windows.Forms.TextBox();
            this.txtTimeStep = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnInitialize = new System.Windows.Forms.Button();
            this.btnPlot = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkboxBorehole = new System.Windows.Forms.CheckBox();
            this.checkboxChokeline = new System.Windows.Forms.CheckBox();
            this.checkboxRealtime = new System.Windows.Forms.CheckBox();
            this.checkboxBoreholeFirst = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(15, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(83, 37);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(15, 55);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(83, 37);
            this.btnStop.TabIndex = 0;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(15, 141);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(646, 387);
            this.txtResult.TabIndex = 1;
            // 
            // txtSimTime
            // 
            this.txtSimTime.Location = new System.Drawing.Point(561, 11);
            this.txtSimTime.Name = "txtSimTime";
            this.txtSimTime.Size = new System.Drawing.Size(68, 22);
            this.txtSimTime.TabIndex = 2;
            // 
            // txtTimeStep
            // 
            this.txtTimeStep.Location = new System.Drawing.Point(561, 39);
            this.txtTimeStep.Name = "txtTimeStep";
            this.txtTimeStep.Size = new System.Drawing.Size(68, 22);
            this.txtTimeStep.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(448, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Simulation Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(448, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Time Step";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkRed;
            this.btnExit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExit.Location = new System.Drawing.Point(578, 98);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(83, 37);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnInitialize
            // 
            this.btnInitialize.Location = new System.Drawing.Point(15, 98);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(83, 37);
            this.btnInitialize.TabIndex = 0;
            this.btnInitialize.Text = "Initialize";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // btnPlot
            // 
            this.btnPlot.Location = new System.Drawing.Point(104, 98);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(83, 37);
            this.btnPlot.TabIndex = 0;
            this.btnPlot.Text = "Plot";
            this.btnPlot.UseVisualStyleBackColor = true;
            this.btnPlot.Click += new System.EventHandler(this.btnPlot_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(635, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "sec";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(635, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "sec";
            // 
            // checkboxBorehole
            // 
            this.checkboxBorehole.AutoSize = true;
            this.checkboxBorehole.Location = new System.Drawing.Point(276, 16);
            this.checkboxBorehole.Name = "checkboxBorehole";
            this.checkboxBorehole.Size = new System.Drawing.Size(87, 21);
            this.checkboxBorehole.TabIndex = 5;
            this.checkboxBorehole.Text = "Borehole";
            this.checkboxBorehole.UseVisualStyleBackColor = true;
            // 
            // checkboxChokeline
            // 
            this.checkboxChokeline.AutoSize = true;
            this.checkboxChokeline.Location = new System.Drawing.Point(276, 44);
            this.checkboxChokeline.Name = "checkboxChokeline";
            this.checkboxChokeline.Size = new System.Drawing.Size(92, 21);
            this.checkboxChokeline.TabIndex = 5;
            this.checkboxChokeline.Text = "Chokeline";
            this.checkboxChokeline.UseVisualStyleBackColor = true;
            // 
            // checkboxRealtime
            // 
            this.checkboxRealtime.AutoSize = true;
            this.checkboxRealtime.Location = new System.Drawing.Point(561, 71);
            this.checkboxRealtime.Name = "checkboxRealtime";
            this.checkboxRealtime.Size = new System.Drawing.Size(85, 21);
            this.checkboxRealtime.TabIndex = 5;
            this.checkboxRealtime.Text = "Realtime";
            this.checkboxRealtime.UseVisualStyleBackColor = true;
            // 
            // checkboxBoreholeFirst
            // 
            this.checkboxBoreholeFirst.AutoSize = true;
            this.checkboxBoreholeFirst.Location = new System.Drawing.Point(276, 71);
            this.checkboxBoreholeFirst.Name = "checkboxBoreholeFirst";
            this.checkboxBoreholeFirst.Size = new System.Drawing.Size(126, 21);
            this.checkboxBoreholeFirst.TabIndex = 5;
            this.checkboxBoreholeFirst.Text = "Borehole First?";
            this.checkboxBoreholeFirst.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(276, 105);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(68, 22);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(350, 105);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(68, 22);
            this.textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(424, 105);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(68, 22);
            this.textBox3.TabIndex = 2;
            // 
            // GasBubbleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(673, 540);
            this.Controls.Add(this.checkboxRealtime);
            this.Controls.Add(this.checkboxBoreholeFirst);
            this.Controls.Add(this.checkboxChokeline);
            this.Controls.Add(this.checkboxBorehole);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTimeStep);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtSimTime);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnInitialize);
            this.Controls.Add(this.btnPlot);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "GasBubbleForm";
            this.Text = "Gas Bubble Model";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtSimTime;
        private System.Windows.Forms.TextBox txtTimeStep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.Button btnPlot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkboxBorehole;
        private System.Windows.Forms.CheckBox checkboxChokeline;
        private System.Windows.Forms.CheckBox checkboxRealtime;
        private System.Windows.Forms.CheckBox checkboxBoreholeFirst;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
    }
}

