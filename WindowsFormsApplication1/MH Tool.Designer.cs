namespace WindowsFormsApplication1
{
    partial class MH_tool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MH_tool));
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.typeRetro = new System.Windows.Forms.RadioButton();
            this.typeASC = new System.Windows.Forms.RadioButton();
            this.typeQC = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(203, 536);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 34);
            this.button4.TabIndex = 12;
            this.button4.Text = "Create New Project";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bugzilla Login";
            // 
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            this.textBox1.Location = new System.Drawing.Point(130, 122);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(273, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "first.last@tmeic.com";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Bugzilla Password";
            // 
            // textBox2
            // 
            this.textBox2.AllowDrop = true;
            this.textBox2.Location = new System.Drawing.Point(130, 147);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(273, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(456, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Note - Project Name should include the project number, OEM, End User, and Project" +
    " Contents. ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(382, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "MH Bugzilla Project Creation Utility";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Example:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Retrofit Example:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(127, 219);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "12345 - ZPMC/Brisbane 2QC";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(127, 248);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(245, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "12345 - DPW/Vancouver Maxview Smart Landing";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 279);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Project Name";
            // 
            // textBox3
            // 
            this.textBox3.AllowDrop = true;
            this.textBox3.Location = new System.Drawing.Point(130, 279);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(273, 20);
            this.textBox3.TabIndex = 2;
            // 
            // typeRetro
            // 
            this.typeRetro.AutoSize = true;
            this.typeRetro.Location = new System.Drawing.Point(273, 396);
            this.typeRetro.Name = "typeRetro";
            this.typeRetro.Size = new System.Drawing.Size(130, 17);
            this.typeRetro.TabIndex = 6;
            this.typeRetro.TabStop = true;
            this.typeRetro.Text = "Smart Landing Retrofit";
            this.typeRetro.UseVisualStyleBackColor = true;
            // 
            // typeASC
            // 
            this.typeASC.AutoSize = true;
            this.typeASC.Location = new System.Drawing.Point(130, 396);
            this.typeASC.Name = "typeASC";
            this.typeASC.Size = new System.Drawing.Size(46, 17);
            this.typeASC.TabIndex = 4;
            this.typeASC.TabStop = true;
            this.typeASC.Text = "ASC";
            this.typeASC.UseVisualStyleBackColor = true;
            // 
            // typeQC
            // 
            this.typeQC.AutoSize = true;
            this.typeQC.Location = new System.Drawing.Point(182, 396);
            this.typeQC.Name = "typeQC";
            this.typeQC.Size = new System.Drawing.Size(68, 17);
            this.typeQC.TabIndex = 5;
            this.typeQC.TabStop = true;
            this.typeQC.Text = "QC/RTG";
            this.typeQC.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 396);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Project Type:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(80, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(303, 50);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 422);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Project Manager";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 447);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "HW Engineer";
            // 
            // textBox4
            // 
            this.textBox4.AllowDrop = true;
            this.textBox4.Location = new System.Drawing.Point(130, 422);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(273, 20);
            this.textBox4.TabIndex = 7;
            this.textBox4.Text = "first.last@tmeic.com";
            // 
            // textBox5
            // 
            this.textBox5.AllowDrop = true;
            this.textBox5.Location = new System.Drawing.Point(130, 447);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(273, 20);
            this.textBox5.TabIndex = 8;
            this.textBox5.Text = "first.last@tmeic.com";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 469);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "SW Engineer";
            // 
            // textBox6
            // 
            this.textBox6.AllowDrop = true;
            this.textBox6.Location = new System.Drawing.Point(130, 469);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(273, 20);
            this.textBox6.TabIndex = 9;
            this.textBox6.Text = "first.last@tmeic.com";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 311);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "Project Descreption";
            // 
            // textBox7
            // 
            this.textBox7.AllowDrop = true;
            this.textBox7.Location = new System.Drawing.Point(130, 311);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox7.Size = new System.Drawing.Size(273, 79);
            this.textBox7.TabIndex = 3;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(303, 547);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 492);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 13);
            this.label15.TabIndex = 5;
            this.label15.Text = "HMI Engineer";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 515);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 13);
            this.label16.TabIndex = 5;
            this.label16.Text = "App Engineer";
            // 
            // textBox8
            // 
            this.textBox8.AllowDrop = true;
            this.textBox8.Location = new System.Drawing.Point(130, 492);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(273, 20);
            this.textBox8.TabIndex = 10;
            this.textBox8.Text = "first.last@tmeic.com";
            // 
            // textBox9
            // 
            this.textBox9.AllowDrop = true;
            this.textBox9.Location = new System.Drawing.Point(130, 515);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(273, 20);
            this.textBox9.TabIndex = 11;
            this.textBox9.Text = "first.last@tmeic.com";
            // 
            // MH_tool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(470, 576);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.typeQC);
            this.Controls.Add(this.typeASC);
            this.Controls.Add(this.typeRetro);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MH_tool";
            this.Text = "MH_tool";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.RadioButton typeRetro;
        private System.Windows.Forms.RadioButton typeASC;
        private System.Windows.Forms.RadioButton typeQC;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
    }
}

