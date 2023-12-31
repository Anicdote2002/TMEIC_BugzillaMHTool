﻿//Name: MH Tool.Designer.cs
//Author:
//Date:
//Modified:
/*----
 * Alexander Summerton - 11/14/2022 - Removed XML Edit and Test Cookie buttons following program update.
 */


using System.Windows.Forms;

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
            this.typeRequisit = new System.Windows.Forms.RadioButton();
            this.typeASC = new System.Windows.Forms.RadioButton();
            this.typeQC = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.checkedListBox_QC = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox_Req = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox_ASC = new System.Windows.Forms.CheckedListBox();
            this.comboBox_ProjMan = new System.Windows.Forms.ComboBox();
            this.comboBox_SysEng = new System.Windows.Forms.ComboBox();
            this.comboBox_HrdwEng = new System.Windows.Forms.ComboBox();
            this.comboBox_ControlEng = new System.Windows.Forms.ComboBox();
            this.comboBox_HMIEng = new System.Windows.Forms.ComboBox();
            this.comboBox_AppEng = new System.Windows.Forms.ComboBox();
            this.comboBox_DriveEng = new System.Windows.Forms.ComboBox();
            this.comboBox_CompTech = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.checkedListBox_General = new System.Windows.Forms.CheckedListBox();
            this.checkBox_General = new System.Windows.Forms.CheckBox();
            this.radioButton_Yes = new System.Windows.Forms.RadioButton();
            this.radioButton_No = new System.Windows.Forms.RadioButton();
            this.label21 = new System.Windows.Forms.Label();
            this.get_users = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.email_list = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(773, 457);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(179, 42);
            this.button4.TabIndex = 12;
            this.button4.Text = "Create New Project";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 128);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bugzilla Login";
            // 
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            this.textBox1.Location = new System.Drawing.Point(173, 128);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(363, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "first.last@tmeic.com";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 159);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Bugzilla Password";
            // 
            // textBox2
            // 
            this.textBox2.AllowDrop = true;
            this.textBox2.Location = new System.Drawing.Point(173, 159);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(363, 22);
            this.textBox2.TabIndex = 1;
            this.textBox2.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 198);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(563, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Note - Project Name should include the project number, OEM, End User, and Project" +
    " Contents. ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(240, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(471, 31);
            this.label4.TabIndex = 5;
            this.label4.Text = "MH Bugzilla Project Creation Utility";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 226);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Example:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 249);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Retrofit Example:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(169, 226);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(176, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "12345 - ZPMC/Brisbane 2QC";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(169, 249);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(297, 16);
            this.label8.TabIndex = 5;
            this.label8.Text = "12345 - DPW/Vancouver Maxview Smart Landing";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 287);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 16);
            this.label9.TabIndex = 5;
            this.label9.Text = "Project Name:";
            // 
            // textBox3
            // 
            this.textBox3.AllowDrop = true;
            this.textBox3.Location = new System.Drawing.Point(174, 284);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(570, 22);
            this.textBox3.TabIndex = 2;
            // 
            // typeRequisit
            // 
            this.typeRequisit.AutoSize = true;
            this.typeRequisit.Location = new System.Drawing.Point(652, 591);
            this.typeRequisit.Margin = new System.Windows.Forms.Padding(4);
            this.typeRequisit.Name = "typeRequisit";
            this.typeRequisit.Size = new System.Drawing.Size(125, 20);
            this.typeRequisit.TabIndex = 6;
            this.typeRequisit.TabStop = true;
            this.typeRequisit.Text = "Requisition Only";
            this.typeRequisit.UseVisualStyleBackColor = true;
            this.typeRequisit.CheckedChanged += new System.EventHandler(this.typeRequisit_CheckedChanged);
            // 
            // typeASC
            // 
            this.typeASC.AutoSize = true;
            this.typeASC.Location = new System.Drawing.Point(32, 591);
            this.typeASC.Margin = new System.Windows.Forms.Padding(4);
            this.typeASC.Name = "typeASC";
            this.typeASC.Size = new System.Drawing.Size(55, 20);
            this.typeASC.TabIndex = 4;
            this.typeASC.TabStop = true;
            this.typeASC.Text = "ASC";
            this.typeASC.UseVisualStyleBackColor = true;
            this.typeASC.CheckedChanged += new System.EventHandler(this.typeASC_CheckedChanged);
            // 
            // typeQC
            // 
            this.typeQC.AutoSize = true;
            this.typeQC.Location = new System.Drawing.Point(341, 591);
            this.typeQC.Margin = new System.Windows.Forms.Padding(4);
            this.typeQC.Name = "typeQC";
            this.typeQC.Size = new System.Drawing.Size(80, 20);
            this.typeQC.TabIndex = 5;
            this.typeQC.TabStop = true;
            this.typeQC.Text = "QC/RTG";
            this.typeQC.UseVisualStyleBackColor = true;
            this.typeQC.CheckedChanged += new System.EventHandler(this.typeQC_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 571);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 16);
            this.label10.TabIndex = 5;
            this.label10.Text = "Project Type:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = global::MH_Creation_Tool_v2.Properties.Resources.TMEIC_Color;
            this.pictureBox1.Location = new System.Drawing.Point(281, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(411, 62);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 741);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 16);
            this.label11.TabIndex = 5;
            this.label11.Text = "Project Manager";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 801);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(123, 16);
            this.label12.TabIndex = 5;
            this.label12.Text = "Hardware Engineer";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(32, 831);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 16);
            this.label13.TabIndex = 5;
            this.label13.Text = "Control Engineer";
            // 
            // textBox7
            // 
            this.textBox7.AllowDrop = true;
            this.textBox7.Location = new System.Drawing.Point(173, 319);
            this.textBox7.Margin = new System.Windows.Forms.Padding(4);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox7.Size = new System.Drawing.Size(571, 110);
            this.textBox7.TabIndex = 3;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(773, 507);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(195, 22);
            this.progressBar1.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(536, 741);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 16);
            this.label15.TabIndex = 5;
            this.label15.Text = "HMI Engineer";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(493, 771);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(131, 16);
            this.label16.TabIndex = 5;
            this.label16.Text = "Application Engineer";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(29, 771);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(109, 16);
            this.label17.TabIndex = 13;
            this.label17.Text = "System Engineer";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(490, 801);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(134, 16);
            this.label18.TabIndex = 15;
            this.label18.Text = "Computer Technician";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(528, 831);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(96, 16);
            this.label19.TabIndex = 17;
            this.label19.Text = "Drive Engineer";
            // 
            // checkedListBox_QC
            // 
            this.checkedListBox_QC.FormattingEnabled = true;
            this.checkedListBox_QC.Items.AddRange(new object[] {
            "Safety PLC",
            "Op Cab/Gantry HMI Screens",
            "Op Cab/Gantry Machine Configuration",
            "Maxview Smart Landing",
            "Maxview Smart Move",
            "RCMS HMI Project",
            "RCMS HMI Screens",
            "RCMS Machine Configuration"});
            this.checkedListBox_QC.Location = new System.Drawing.Point(341, 618);
            this.checkedListBox_QC.Name = "checkedListBox_QC";
            this.checkedListBox_QC.Size = new System.Drawing.Size(255, 89);
            this.checkedListBox_QC.TabIndex = 33;
            this.checkedListBox_QC.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox_QC_ItemClick);
            // 
            // checkedListBox_Req
            // 
            this.checkedListBox_Req.FormattingEnabled = true;
            this.checkedListBox_Req.Items.AddRange(new object[] {
            "Requistion Crane Director",
            "Requistion Drive Software",
            "Requistion HMI",
            "Requistion Machine Configuration",
            "Requistion PLC Software",
            "Requistion General Software",
            "Requistion Hardware",
            "Requistion Maxview",
            "Requistion Maxview 4D"});
            this.checkedListBox_Req.Location = new System.Drawing.Point(652, 618);
            this.checkedListBox_Req.Name = "checkedListBox_Req";
            this.checkedListBox_Req.Size = new System.Drawing.Size(255, 89);
            this.checkedListBox_Req.TabIndex = 23;
            this.checkedListBox_Req.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox_Req_ItemClick);
            // 
            // checkedListBox_ASC
            // 
            this.checkedListBox_ASC.FormattingEnabled = true;
            this.checkedListBox_ASC.Items.AddRange(new object[] {
            "Crane Director",
            "Maxview ASC",
            "Maxview Clear Zone",
            "Maxview Clear path",
            "Maxview Chassis Guidance",
            "Maxview 4D",
            "Maxview+Smart+Move",
            "Maxview Machine Configuration",
            "RCMS HMI Project",
            "RCMS HMI Screens",
            "RCMS Machine Configuration",
            "Yard HMI Project",
            "Yard HMI File Server Machine Configuration",
            "Yard PLC",
            "Yard IO Project",
            "Safety PLC",
            "ROS HMI Screens",
            "ROS Machine Configuration",
            "ROS IO Project",
            "ROS PLC"});
            this.checkedListBox_ASC.Location = new System.Drawing.Point(32, 618);
            this.checkedListBox_ASC.Name = "checkedListBox_ASC";
            this.checkedListBox_ASC.Size = new System.Drawing.Size(255, 89);
            this.checkedListBox_ASC.TabIndex = 24;
            this.checkedListBox_ASC.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox_ASC_ItemClick);
            // 
            // comboBox_ProjMan
            // 
            this.comboBox_ProjMan.FormattingEnabled = true;
            this.comboBox_ProjMan.Location = new System.Drawing.Point(145, 738);
            this.comboBox_ProjMan.Name = "comboBox_ProjMan";
            this.comboBox_ProjMan.Size = new System.Drawing.Size(276, 24);
            this.comboBox_ProjMan.TabIndex = 25;
            this.comboBox_ProjMan.KeyPress += comboBox_ProjMan_TextChanged;
            // 
            // comboBox_SysEng
            // 
            this.comboBox_SysEng.FormattingEnabled = true;
            this.comboBox_SysEng.Location = new System.Drawing.Point(145, 768);
            this.comboBox_SysEng.Name = "comboBox_SysEng";
            this.comboBox_SysEng.Size = new System.Drawing.Size(276, 24);
            this.comboBox_SysEng.TabIndex = 26;
            this.comboBox_SysEng.KeyPress += comboBox_SysEng_TextChanged;
            // 
            // comboBox_HrdwEng
            // 
            this.comboBox_HrdwEng.FormattingEnabled = true;
            this.comboBox_HrdwEng.Location = new System.Drawing.Point(145, 798);
            this.comboBox_HrdwEng.Name = "comboBox_HrdwEng";
            this.comboBox_HrdwEng.Size = new System.Drawing.Size(276, 24);
            this.comboBox_HrdwEng.TabIndex = 27;
            this.comboBox_HrdwEng.KeyPress += comboBox_HrdwEng_TextChanged;
            // 
            // comboBox_ControlEng
            // 
            this.comboBox_ControlEng.FormattingEnabled = true;
            this.comboBox_ControlEng.Location = new System.Drawing.Point(145, 828);
            this.comboBox_ControlEng.Name = "comboBox_ControlEng";
            this.comboBox_ControlEng.Size = new System.Drawing.Size(276, 24);
            this.comboBox_ControlEng.TabIndex = 28;
            this.comboBox_ControlEng.KeyPress += comboBox_ControlEng_TextChanged;
            // 
            // comboBox_HMIEng
            // 
            this.comboBox_HMIEng.FormattingEnabled = true;
            this.comboBox_HMIEng.Location = new System.Drawing.Point(631, 738);
            this.comboBox_HMIEng.Name = "comboBox_HMIEng";
            this.comboBox_HMIEng.Size = new System.Drawing.Size(276, 24);
            this.comboBox_HMIEng.TabIndex = 29;
            this.comboBox_HMIEng.KeyPress += comboBox_HMIEng_TextChanged;
            // 
            // comboBox_AppEng
            // 
            this.comboBox_AppEng.FormattingEnabled = true;
            this.comboBox_AppEng.Location = new System.Drawing.Point(631, 768);
            this.comboBox_AppEng.Name = "comboBox_AppEng";
            this.comboBox_AppEng.Size = new System.Drawing.Size(276, 24);
            this.comboBox_AppEng.TabIndex = 30;
            this.comboBox_AppEng.KeyPress += comboBox_AppEng_TextChanged;
            // 
            // comboBox_DriveEng
            // 
            this.comboBox_DriveEng.FormattingEnabled = true;
            this.comboBox_DriveEng.Location = new System.Drawing.Point(631, 828);
            this.comboBox_DriveEng.Name = "comboBox_DriveEng";
            this.comboBox_DriveEng.Size = new System.Drawing.Size(276, 24);
            this.comboBox_DriveEng.TabIndex = 31;
            this.comboBox_DriveEng.KeyPress += comboBox_DriveEng_TextChanged;
            // 
            // comboBox_CompTech
            // 
            this.comboBox_CompTech.FormattingEnabled = true;
            this.comboBox_CompTech.Location = new System.Drawing.Point(631, 798);
            this.comboBox_CompTech.Name = "comboBox_CompTech";
            this.comboBox_CompTech.Size = new System.Drawing.Size(276, 24);
            this.comboBox_CompTech.TabIndex = 32;
            this.comboBox_CompTech.KeyPress += comboBox_CompTech_TextChanged;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(338, 461);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(133, 16);
            this.label20.TabIndex = 34;
            this.label20.Text = "General Component: ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 319);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(123, 16);
            this.label14.TabIndex = 5;
            this.label14.Text = "Project Description:";
            // 
            // checkedListBox_General
            // 
            this.checkedListBox_General.FormattingEnabled = true;
            this.checkedListBox_General.Items.AddRange(new object[] {
            "General Hardware",
            "Crane PLC",
            "General Software",
            "Drive Hardware",
            "Drive Software",
            "LCMS HMI Project",
            "LCMS HMI Screens",
            "LCMS Machine Configuration",
            "Elementaries"});
            this.checkedListBox_General.Location = new System.Drawing.Point(489, 461);
            this.checkedListBox_General.Name = "checkedListBox_General";
            this.checkedListBox_General.Size = new System.Drawing.Size(255, 89);
            this.checkedListBox_General.TabIndex = 35;
            this.checkedListBox_General.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox_General_ItemClick);
            // 
            // checkBox_General
            // 
            this.checkBox_General.AutoSize = true;
            this.checkBox_General.Location = new System.Drawing.Point(386, 480);
            this.checkBox_General.Name = "checkBox_General";
            this.checkBox_General.Size = new System.Drawing.Size(85, 20);
            this.checkBox_General.TabIndex = 36;
            this.checkBox_General.Text = "Select All";
            this.checkBox_General.UseVisualStyleBackColor = true;
            this.checkBox_General.Click += new System.EventHandler(this.checkBox_General_Checked);
            // 
            // radioButton_Yes
            // 
            this.radioButton_Yes.AutoSize = true;
            this.radioButton_Yes.Location = new System.Drawing.Point(173, 483);
            this.radioButton_Yes.Name = "radioButton_Yes";
            this.radioButton_Yes.Size = new System.Drawing.Size(52, 20);
            this.radioButton_Yes.TabIndex = 37;
            this.radioButton_Yes.TabStop = true;
            this.radioButton_Yes.Text = "Yes";
            this.radioButton_Yes.UseVisualStyleBackColor = true;
            this.radioButton_Yes.CheckedChanged += new System.EventHandler(this.radioButton_Yes_CheckedChanged);
            // 
            // radioButton_No
            // 
            this.radioButton_No.AutoSize = true;
            this.radioButton_No.Location = new System.Drawing.Point(174, 509);
            this.radioButton_No.Name = "radioButton_No";
            this.radioButton_No.Size = new System.Drawing.Size(46, 20);
            this.radioButton_No.TabIndex = 38;
            this.radioButton_No.TabStop = true;
            this.radioButton_No.Text = "No";
            this.radioButton_No.UseVisualStyleBackColor = true;
            this.radioButton_No.CheckedChanged += new System.EventHandler(this.radioButton_No_CheckedChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(15, 461);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(255, 16);
            this.label21.TabIndex = 39;
            this.label21.Text = "Please select if project is requistion or not:";
            // 
            // get_users
            // 
            this.get_users.Location = new System.Drawing.Point(773, 226);
            this.get_users.Name = "get_users";
            this.get_users.Size = new System.Drawing.Size(128, 42);
            this.get_users.TabIndex = 40;
            this.get_users.Text = "Get Users Emails";
            this.get_users.UseVisualStyleBackColor = true;
            this.get_users.Click += new System.EventHandler(this.button1_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(770, 198);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(272, 16);
            this.label22.TabIndex = 41;
            this.label22.Text = "Enter your Credentials to retrieve user emails";
            // 
            // email_list
            // 
            this.email_list.FormattingEnabled = true;
            this.email_list.ItemHeight = 16;
            this.email_list.Location = new System.Drawing.Point(773, 281);
            this.email_list.Name = "email_list";
            this.email_list.Size = new System.Drawing.Size(241, 148);
            this.email_list.TabIndex = 42;
            // 
            // MH_tool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1048, 941);
            this.Controls.Add(this.email_list);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.get_users);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.radioButton_No);
            this.Controls.Add(this.radioButton_Yes);
            this.Controls.Add(this.checkBox_General);
            this.Controls.Add(this.checkedListBox_General);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.comboBox_CompTech);
            this.Controls.Add(this.comboBox_DriveEng);
            this.Controls.Add(this.comboBox_AppEng);
            this.Controls.Add(this.comboBox_HMIEng);
            this.Controls.Add(this.comboBox_ControlEng);
            this.Controls.Add(this.comboBox_HrdwEng);
            this.Controls.Add(this.comboBox_SysEng);
            this.Controls.Add(this.comboBox_ProjMan);
            this.Controls.Add(this.checkedListBox_ASC);
            this.Controls.Add(this.checkedListBox_Req);
            this.Controls.Add(this.checkedListBox_QC);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.typeQC);
            this.Controls.Add(this.typeASC);
            this.Controls.Add(this.typeRequisit);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
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
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.RadioButton typeRequisit;
        private System.Windows.Forms.RadioButton typeASC;
        private System.Windows.Forms.RadioButton typeQC;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckedListBox checkedListBox_QC;
        private System.Windows.Forms.CheckedListBox checkedListBox_Req;
        private System.Windows.Forms.CheckedListBox checkedListBox_ASC;
        private System.Windows.Forms.ComboBox comboBox_ProjMan;
        private System.Windows.Forms.ComboBox comboBox_SysEng;
        private System.Windows.Forms.ComboBox comboBox_HrdwEng;
        private System.Windows.Forms.ComboBox comboBox_ControlEng;
        private System.Windows.Forms.ComboBox comboBox_HMIEng;
        private System.Windows.Forms.ComboBox comboBox_AppEng;
        private System.Windows.Forms.ComboBox comboBox_DriveEng;
        private System.Windows.Forms.ComboBox comboBox_CompTech;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckedListBox checkedListBox_General;
        private System.Windows.Forms.CheckBox checkBox_General;
        private System.Windows.Forms.RadioButton radioButton_Yes;
        private System.Windows.Forms.RadioButton radioButton_No;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button get_users;
        private Label label22;
        private ListBox email_list;
        //private System.Windows.Forms.Button button1;
        //private System.Windows.Forms.Button button2;


        //  private System.Windows.Forms.RadioButton CraneDirector;
        //   private System.Windows.Forms.RadioButton Maxview_ASC;
        //   private System.Windows.Forms.RadioButton Maxview_Clear_Zone;
        //   private System.Windows.Forms.RadioButton Maxview_Clear_Path;
        //   private System.Windows.Forms.RadioButton Maxview_Chassis_Guide;
        //   private System.Windows.Forms.RadioButton Maxview_Chassis_Guidance;
        //  private System.Windows.Forms.RadioButton Maxview_Clear_Zone;
        //  private System.Windows.Forms.RadioButton Maxview_Clear_Zone;
        //   private System.Windows.Forms.RadioButton Maxview_Clear_Zone;


    }
}

