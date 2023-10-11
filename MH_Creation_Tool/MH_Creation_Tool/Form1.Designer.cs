//Name: MH Tool.Designer.cs
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
            button4 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            textBox3 = new TextBox();
            typeRequisit = new RadioButton();
            typeASC = new RadioButton();
            typeQC = new RadioButton();
            label10 = new Label();
            pictureBox1 = new PictureBox();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            textBox7 = new TextBox();
            progressBar1 = new ProgressBar();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            label19 = new Label();
            checkedListBox_QC = new CheckedListBox();
            checkedListBox_Req = new CheckedListBox();
            checkedListBox_ASC = new CheckedListBox();
            comboBox_ProjMan = new ComboBox();
            comboBox_SysEng = new ComboBox();
            comboBox_HrdwEng = new ComboBox();
            comboBox_ControlEng = new ComboBox();
            comboBox_HMIEng = new ComboBox();
            comboBox_AppEng = new ComboBox();
            comboBox_DriveEng = new ComboBox();
            comboBox_CompTech = new ComboBox();
            label20 = new Label();
            label14 = new Label();
            checkedListBox_General = new CheckedListBox();
            checkBox_General = new CheckBox();
            radioButton_Yes = new RadioButton();
            radioButton_No = new RadioButton();
            label21 = new Label();
            get_users = new Button();
            label22 = new Label();
            email_list = new ListBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button4
            // 
            button4.Location = new Point(145, 1188);
            button4.Margin = new Padding(4, 5, 4, 5);
            button4.Name = "button4";
            button4.Size = new Size(179, 52);
            button4.TabIndex = 12;
            button4.Text = "Create New Project";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 160);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(103, 20);
            label1.TabIndex = 5;
            label1.Text = "Bugzilla Login";
            // 
            // textBox1
            // 
            textBox1.AllowDrop = true;
            textBox1.Location = new Point(173, 160);
            textBox1.Margin = new Padding(4, 5, 4, 5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(363, 27);
            textBox1.TabIndex = 0;
            textBox1.Text = "first.last@tmeic.com";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 199);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(127, 20);
            label2.TabIndex = 5;
            label2.Text = "Bugzilla Password";
            // 
            // textBox2
            // 
            textBox2.AllowDrop = true;
            textBox2.Location = new Point(173, 199);
            textBox2.Margin = new Padding(4, 5, 4, 5);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(363, 27);
            textBox2.TabIndex = 1;
            textBox2.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 248);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(632, 20);
            label3.TabIndex = 5;
            label3.Text = "Note - Project Name should include the project number, OEM, End User, and Project Contents. ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(273, 115);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(471, 31);
            label4.TabIndex = 5;
            label4.Text = "MH Bugzilla Project Creation Utility";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 282);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 5;
            label5.Text = "Example:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 311);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(123, 20);
            label6.TabIndex = 5;
            label6.Text = "Retrofit Example:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(169, 282);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(197, 20);
            label7.TabIndex = 5;
            label7.Text = "12345 - ZPMC/Brisbane 2QC";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(169, 311);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(332, 20);
            label8.TabIndex = 5;
            label8.Text = "12345 - DPW/Vancouver Maxview Smart Landing";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(15, 359);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(102, 20);
            label9.TabIndex = 5;
            label9.Text = "Project Name:";
            // 
            // textBox3
            // 
            textBox3.AllowDrop = true;
            textBox3.Location = new Point(174, 355);
            textBox3.Margin = new Padding(4, 5, 4, 5);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(570, 27);
            textBox3.TabIndex = 2;
            // 
            // typeRequisit
            // 
            typeRequisit.AutoSize = true;
            typeRequisit.Location = new Point(652, 739);
            typeRequisit.Margin = new Padding(4, 5, 4, 5);
            typeRequisit.Name = "typeRequisit";
            typeRequisit.Size = new Size(138, 24);
            typeRequisit.TabIndex = 6;
            typeRequisit.TabStop = true;
            typeRequisit.Text = "Requisition Only";
            typeRequisit.UseVisualStyleBackColor = true;
            typeRequisit.CheckedChanged += typeRequisit_CheckedChanged;
            // 
            // typeASC
            // 
            typeASC.AutoSize = true;
            typeASC.Location = new Point(32, 739);
            typeASC.Margin = new Padding(4, 5, 4, 5);
            typeASC.Name = "typeASC";
            typeASC.Size = new Size(57, 24);
            typeASC.TabIndex = 4;
            typeASC.TabStop = true;
            typeASC.Text = "ASC";
            typeASC.UseVisualStyleBackColor = true;
            typeASC.CheckedChanged += typeASC_CheckedChanged;
            // 
            // typeQC
            // 
            typeQC.AutoSize = true;
            typeQC.Location = new Point(341, 739);
            typeQC.Margin = new Padding(4, 5, 4, 5);
            typeQC.Name = "typeQC";
            typeQC.Size = new Size(81, 24);
            typeQC.TabIndex = 5;
            typeQC.TabStop = true;
            typeQC.Text = "QC/RTG";
            typeQC.UseVisualStyleBackColor = true;
            typeQC.CheckedChanged += typeQC_CheckedChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(15, 714);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(93, 20);
            label10.TabIndex = 5;
            label10.Text = "Project Type:";
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = null;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(330, 45);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(383, 65);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(32, 926);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(118, 20);
            label11.TabIndex = 5;
            label11.Text = "Project Manager";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(15, 1001);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(136, 20);
            label12.TabIndex = 5;
            label12.Text = "Hardware Engineer";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(32, 1039);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(120, 20);
            label13.TabIndex = 5;
            label13.Text = "Control Engineer";
            // 
            // textBox7
            // 
            textBox7.AllowDrop = true;
            textBox7.Location = new Point(173, 399);
            textBox7.Margin = new Padding(4, 5, 4, 5);
            textBox7.Multiline = true;
            textBox7.Name = "textBox7";
            textBox7.ScrollBars = ScrollBars.Vertical;
            textBox7.Size = new Size(571, 136);
            textBox7.TabIndex = 3;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(341, 1199);
            progressBar1.Margin = new Padding(4, 5, 4, 5);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(195, 28);
            progressBar1.TabIndex = 11;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(536, 926);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(99, 20);
            label15.TabIndex = 5;
            label15.Text = "HMI Engineer";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(493, 964);
            label16.Margin = new Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new Size(148, 20);
            label16.TabIndex = 5;
            label16.Text = "Application Engineer";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(29, 964);
            label17.Margin = new Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new Size(118, 20);
            label17.TabIndex = 13;
            label17.Text = "System Engineer";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(490, 1001);
            label18.Margin = new Padding(4, 0, 4, 0);
            label18.Name = "label18";
            label18.Size = new Size(148, 20);
            label18.TabIndex = 15;
            label18.Text = "Computer Technician";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(528, 1039);
            label19.Margin = new Padding(4, 0, 4, 0);
            label19.Name = "label19";
            label19.Size = new Size(106, 20);
            label19.TabIndex = 17;
            label19.Text = "Drive Engineer";
            // 
            // checkedListBox_QC
            // 
            checkedListBox_QC.FormattingEnabled = true;
            checkedListBox_QC.Items.AddRange(new object[] { "Safety PLC", "Op Cab/Gantry HMI Screens", "Op Cab/Gantry Machine Configuration", "Maxview Smart Landing", "Maxview Smart Move", "RCMS HMI Project", "RCMS HMI Screens", "RCMS Machine Configuration" });
            checkedListBox_QC.Location = new Point(341, 772);
            checkedListBox_QC.Margin = new Padding(3, 4, 3, 4);
            checkedListBox_QC.Name = "checkedListBox_QC";
            checkedListBox_QC.Size = new Size(255, 92);
            checkedListBox_QC.TabIndex = 33;
            checkedListBox_QC.ItemCheck += checkedListBox_QC_ItemClick;
            // 
            // checkedListBox_Req
            // 
            checkedListBox_Req.FormattingEnabled = true;
            checkedListBox_Req.Items.AddRange(new object[] { "Requistion Crane Director", "Requistion Drive Software", "Requistion HMI", "Requistion Machine Configuration", "Requistion PLC Software", "Requistion General Software", "Requistion Hardware", "Requistion Maxview", "Requistion Maxview 4D" });
            checkedListBox_Req.Location = new Point(652, 772);
            checkedListBox_Req.Margin = new Padding(3, 4, 3, 4);
            checkedListBox_Req.Name = "checkedListBox_Req";
            checkedListBox_Req.Size = new Size(255, 92);
            checkedListBox_Req.TabIndex = 23;
            checkedListBox_Req.ItemCheck += checkedListBox_Req_ItemClick;
            // 
            // checkedListBox_ASC
            // 
            checkedListBox_ASC.FormattingEnabled = true;
            checkedListBox_ASC.Items.AddRange(new object[] { "Crane Director", "Maxview ASC", "Maxview Clear Zone", "Maxview Clear path", "Maxview Chassis Guidance", "Maxview 4D", "Maxview+Smart+Move", "Maxview Machine Configuration", "RCMS HMI Project", "RCMS HMI Screens", "RCMS Machine Configuration", "Yard HMI Project", "Yard HMI File Server Machine Configuration", "Yard PLC", "Yard IO Project", "Safety PLC", "ROS HMI Screens", "ROS Machine Configuration", "ROS IO Project", "ROS PLC" });
            checkedListBox_ASC.Location = new Point(32, 772);
            checkedListBox_ASC.Margin = new Padding(3, 4, 3, 4);
            checkedListBox_ASC.Name = "checkedListBox_ASC";
            checkedListBox_ASC.Size = new Size(255, 92);
            checkedListBox_ASC.TabIndex = 24;
            checkedListBox_ASC.ItemCheck += checkedListBox_ASC_ItemClick;
            // 
            // comboBox_ProjMan
            // 
            comboBox_ProjMan.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox_ProjMan.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox_ProjMan.FormattingEnabled = true;
            comboBox_ProjMan.Location = new Point(145, 922);
            comboBox_ProjMan.Margin = new Padding(3, 4, 3, 4);
            comboBox_ProjMan.Name = "comboBox_ProjMan";
            comboBox_ProjMan.Size = new Size(276, 28);
            comboBox_ProjMan.TabIndex = 25;
            // 
            // comboBox_SysEng
            // 
            comboBox_SysEng.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox_SysEng.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox_SysEng.FormattingEnabled = true;
            comboBox_SysEng.Location = new Point(145, 960);
            comboBox_SysEng.Margin = new Padding(3, 4, 3, 4);
            comboBox_SysEng.Name = "comboBox_SysEng";
            comboBox_SysEng.Size = new Size(276, 28);
            comboBox_SysEng.TabIndex = 26;
            // 
            // comboBox_HrdwEng
            // 
            comboBox_HrdwEng.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox_HrdwEng.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox_HrdwEng.FormattingEnabled = true;
            comboBox_HrdwEng.Location = new Point(145, 998);
            comboBox_HrdwEng.Margin = new Padding(3, 4, 3, 4);
            comboBox_HrdwEng.Name = "comboBox_HrdwEng";
            comboBox_HrdwEng.Size = new Size(276, 28);
            comboBox_HrdwEng.TabIndex = 27;
            // 
            // comboBox_ControlEng
            // 
            comboBox_ControlEng.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox_ControlEng.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox_ControlEng.FormattingEnabled = true;
            comboBox_ControlEng.Location = new Point(145, 1035);
            comboBox_ControlEng.Margin = new Padding(3, 4, 3, 4);
            comboBox_ControlEng.Name = "comboBox_ControlEng";
            comboBox_ControlEng.Size = new Size(276, 28);
            comboBox_ControlEng.TabIndex = 28;
            // 
            // comboBox_HMIEng
            // 
            comboBox_HMIEng.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox_HMIEng.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox_HMIEng.FormattingEnabled = true;
            comboBox_HMIEng.Location = new Point(631, 922);
            comboBox_HMIEng.Margin = new Padding(3, 4, 3, 4);
            comboBox_HMIEng.Name = "comboBox_HMIEng";
            comboBox_HMIEng.Size = new Size(276, 28);
            comboBox_HMIEng.TabIndex = 29;
            // 
            // comboBox_AppEng
            // 
            comboBox_AppEng.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox_AppEng.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox_AppEng.FormattingEnabled = true;
            comboBox_AppEng.Location = new Point(631, 960);
            comboBox_AppEng.Margin = new Padding(3, 4, 3, 4);
            comboBox_AppEng.Name = "comboBox_AppEng";
            comboBox_AppEng.Size = new Size(276, 28);
            comboBox_AppEng.TabIndex = 30;
            // 
            // comboBox_DriveEng
            // 
            comboBox_DriveEng.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox_DriveEng.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox_DriveEng.FormattingEnabled = true;
            comboBox_DriveEng.Location = new Point(631, 1035);
            comboBox_DriveEng.Margin = new Padding(3, 4, 3, 4);
            comboBox_DriveEng.Name = "comboBox_DriveEng";
            comboBox_DriveEng.Size = new Size(276, 28);
            comboBox_DriveEng.TabIndex = 31;
            // 
            // comboBox_CompTech
            // 
            comboBox_CompTech.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox_CompTech.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboBox_CompTech.FormattingEnabled = true;
            comboBox_CompTech.Location = new Point(631, 998);
            comboBox_CompTech.Margin = new Padding(3, 4, 3, 4);
            comboBox_CompTech.Name = "comboBox_CompTech";
            comboBox_CompTech.Size = new Size(276, 28);
            comboBox_CompTech.TabIndex = 32;
            comboBox_CompTech.KeyPress += comboBox_CompTech_TextChanged;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(338, 576);
            label20.Name = "label20";
            label20.Size = new Size(149, 20);
            label20.TabIndex = 34;
            label20.Text = "General Component: ";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(15, 399);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(138, 20);
            label14.TabIndex = 5;
            label14.Text = "Project Description:";
            // 
            // checkedListBox_General
            // 
            checkedListBox_General.FormattingEnabled = true;
            checkedListBox_General.Items.AddRange(new object[] { "General Hardware", "Crane PLC", "General Software", "Drive Hardware", "Drive Software", "LCMS HMI Project", "LCMS HMI Screens", "LCMS Machine Configuration", "Elementaries" });
            checkedListBox_General.Location = new Point(489, 576);
            checkedListBox_General.Margin = new Padding(3, 4, 3, 4);
            checkedListBox_General.Name = "checkedListBox_General";
            checkedListBox_General.Size = new Size(255, 92);
            checkedListBox_General.TabIndex = 35;
            checkedListBox_General.ItemCheck += checkedListBox_General_ItemClick;
            // 
            // checkBox_General
            // 
            checkBox_General.AutoSize = true;
            checkBox_General.Location = new Point(386, 600);
            checkBox_General.Margin = new Padding(3, 4, 3, 4);
            checkBox_General.Name = "checkBox_General";
            checkBox_General.Size = new Size(93, 24);
            checkBox_General.TabIndex = 36;
            checkBox_General.Text = "Select All";
            checkBox_General.UseVisualStyleBackColor = true;
            checkBox_General.Click += checkBox_General_Checked;
            // 
            // radioButton_Yes
            // 
            radioButton_Yes.AutoSize = true;
            radioButton_Yes.Location = new Point(173, 604);
            radioButton_Yes.Margin = new Padding(3, 4, 3, 4);
            radioButton_Yes.Name = "radioButton_Yes";
            radioButton_Yes.Size = new Size(51, 24);
            radioButton_Yes.TabIndex = 37;
            radioButton_Yes.TabStop = true;
            radioButton_Yes.Text = "Yes";
            radioButton_Yes.UseVisualStyleBackColor = true;
            radioButton_Yes.CheckedChanged += radioButton_Yes_CheckedChanged;
            // 
            // radioButton_No
            // 
            radioButton_No.AutoSize = true;
            radioButton_No.Location = new Point(174, 636);
            radioButton_No.Margin = new Padding(3, 4, 3, 4);
            radioButton_No.Name = "radioButton_No";
            radioButton_No.Size = new Size(50, 24);
            radioButton_No.TabIndex = 38;
            radioButton_No.TabStop = true;
            radioButton_No.Text = "No";
            radioButton_No.UseVisualStyleBackColor = true;
            radioButton_No.CheckedChanged += radioButton_No_CheckedChanged;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(15, 576);
            label21.Name = "label21";
            label21.Size = new Size(288, 20);
            label21.TabIndex = 39;
            label21.Text = "Please select if project is requistion or not:";
            // 
            // get_users
            // 
            get_users.Location = new Point(145, 1111);
            get_users.Margin = new Padding(3, 4, 3, 4);
            get_users.Name = "get_users";
            get_users.Size = new Size(179, 52);
            get_users.TabIndex = 40;
            get_users.Text = "Get Users Emails";
            get_users.UseVisualStyleBackColor = true;
            get_users.Click += button1_Click;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(330, 1128);
            label22.Name = "label22";
            label22.Size = new Size(578, 20);
            label22.TabIndex = 41;
            label22.Text = "Note: You need to enter your Credentials and Click on Get Users to retrieve user emails";
            // 
            // email_list
            // 
            email_list.FormattingEnabled = true;
            email_list.ItemHeight = 20;
            email_list.Location = new Point(145, 1325);
            email_list.Margin = new Padding(3, 4, 3, 4);
            email_list.Name = "email_list";
            email_list.Size = new Size(330, 184);
            email_list.TabIndex = 42;
            // 
            // MH_tool
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1087, 1542);
            Controls.Add(email_list);
            Controls.Add(label22);
            Controls.Add(get_users);
            Controls.Add(label21);
            Controls.Add(radioButton_No);
            Controls.Add(radioButton_Yes);
            Controls.Add(checkBox_General);
            Controls.Add(checkedListBox_General);
            Controls.Add(label20);
            Controls.Add(comboBox_CompTech);
            Controls.Add(comboBox_DriveEng);
            Controls.Add(comboBox_AppEng);
            Controls.Add(comboBox_HMIEng);
            Controls.Add(comboBox_ControlEng);
            Controls.Add(comboBox_HrdwEng);
            Controls.Add(comboBox_SysEng);
            Controls.Add(comboBox_ProjMan);
            Controls.Add(checkedListBox_ASC);
            Controls.Add(checkedListBox_Req);
            Controls.Add(checkedListBox_QC);
            Controls.Add(label19);
            Controls.Add(label18);
            Controls.Add(label17);
            Controls.Add(progressBar1);
            Controls.Add(pictureBox1);
            Controls.Add(typeQC);
            Controls.Add(typeASC);
            Controls.Add(typeRequisit);
            Controls.Add(textBox7);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label6);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label16);
            Controls.Add(label10);
            Controls.Add(label13);
            Controls.Add(label14);
            Controls.Add(label15);
            Controls.Add(label9);
            Controls.Add(label12);
            Controls.Add(label2);
            Controls.Add(label11);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(button4);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "MH_tool";
            Text = "MH_tool";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button4;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox textBox3;
        private RadioButton typeRequisit;
        private RadioButton typeASC;
        private RadioButton typeQC;
        private Label label10;
        private PictureBox pictureBox1;
        private Label label11;
        private Label label12;
        private Label label13;
        private TextBox textBox7;
        private ProgressBar progressBar1;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private CheckedListBox checkedListBox_QC;
        private CheckedListBox checkedListBox_Req;
        private CheckedListBox checkedListBox_ASC;
        private ComboBox comboBox_ProjMan;
        private ComboBox comboBox_SysEng;
        private ComboBox comboBox_HrdwEng;
        private ComboBox comboBox_ControlEng;
        private ComboBox comboBox_HMIEng;
        private ComboBox comboBox_AppEng;
        private ComboBox comboBox_DriveEng;
        private ComboBox comboBox_CompTech;
        private Label label20;
        private Label label14;
        private CheckedListBox checkedListBox_General;
        private CheckBox checkBox_General;
        private RadioButton radioButton_Yes;
        private RadioButton radioButton_No;
        private Label label21;
        private Button get_users;
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

