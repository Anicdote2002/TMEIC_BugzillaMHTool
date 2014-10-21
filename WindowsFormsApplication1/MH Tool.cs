using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Collections.Specialized;
using System.Web;
using System.Xml;

namespace WindowsFormsApplication1
{
    public partial class MH_tool : Form
    {
        public MH_tool()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            this.progressBar1.Value = 0;
          

            if (CreateProject())
            {
                if (MessageBox.Show("A new project has been created.\r\n\r\n Select yes to open a the new project in your browser and no to close this message", "Visit", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(@"https://tmeic.bugopolis.com/mh/editproducts.cgi?action=edit&product=" + Encoder(textBox3.Text));
                }
            }
            else this.progressBar1.Value = 0;
        }

       

        private bool CreateProject()
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string projectname = textBox3.Text;
            string projectManager = textBox4.Text;
            string HWengineer = textBox5.Text;
            string SWengineer = textBox6.Text;
            string projectDescription = textBox7.Text;
            string HMI_Engineer = textBox8.Text;
            string AppEngineer = textBox9.Text;
            
            //Load XML Document
            try
            { 
                System.Xml.XmlDocument DocTest = new System.Xml.XmlDocument();
                DocTest.Load(@"ProjectEmail.xml");
            }
            catch
            {
                MessageBox.Show("Please make sure that the ProjectEmail.xml file is located in the same file as this tool when it is run.", "Error");
                return false;
            }
            System.Xml.XmlDocument Doc = new System.Xml.XmlDocument();
            Doc.Load(@"ProjectEmail.xml");

            XmlNode curNode = Doc.SelectSingleNode("Configuration/FieldEngineerManager");
            if (curNode == null)
            {
                MessageBox.Show("Problem with ProjectEmail.xml/Configuration/FieldEngineerManager");
                return false;
            }
            string FE_Manager = curNode.InnerText;

            curNode = Doc.SelectSingleNode("Configuration/HardwareManager");
            if (curNode == null)
            {
                MessageBox.Show("Problem with ProjectEmail.xml/Configuration/HardwareManager");
                return false;
            }
            string HW_Manager = curNode.InnerText;

            curNode = Doc.SelectSingleNode("Configuration/SoftwareManager");
            if (curNode == null)
            {
                MessageBox.Show("Problem with ProjectEmail.xml/Configuration/SoftwareManager");
                return false;
            }
            string SW_Manager = curNode.InnerText;

            curNode = Doc.SelectSingleNode("Configuration/CrainDirectorOwner");
            if (curNode == null)
            {
                MessageBox.Show("Problem with ProjectEmail.xml/Configuration/CrainDirectorOwner");
                return false;
            }
            string Crane_Dir_Owner = curNode.InnerText;

            curNode = Doc.SelectSingleNode("Configuration/WarrantyUser");
            if (curNode == null)
            {
                MessageBox.Show("Problem with ProjectEmail.xml/Configuration/WarrantyUser");
                return false;
            }
            string Warranty_User = curNode.InnerText;

            curNode = Doc.SelectSingleNode("Configuration/MPROwner");
            if (curNode == null)
            {
                MessageBox.Show("Problem with ProjectEmail.xml/Configuration/MPROwner");
                return false;
            }
            string MPR_Owner = curNode.InnerText;

            curNode = Doc.SelectSingleNode("Configuration/MaxViewRT");
            if (curNode == null)
            {
                MessageBox.Show("Problem with ProjectEmail.xml/Configuration/MaxViewRT");
                return false;
            }
            string MaxviewRT_Owner = curNode.InnerText;

            curNode = Doc.SelectSingleNode("Configuration/VOIPOwner");
            if (curNode == null)
            {
                MessageBox.Show("Problem with ProjectEmail.xml/Configuration/VOIPOwner");
                return false;
            }
            string VOIP_Owner = curNode.InnerText;

            curNode = Doc.SelectSingleNode("Configuration/SPLCOwner");
            if (curNode == null)
            {
                MessageBox.Show("Problem with ProjectEmail.xml/Configuration/SPLCOwner");
                return false;
            }
            string SPLC_Owner = curNode.InnerText;

            curNode = Doc.SelectSingleNode("Configuration/MaxviewQCOwner");
            if (curNode == null)
            {
                MessageBox.Show("Problem with ProjectEmail.xml/Configuration/MaxviewQCOwner");
                return false;
            }
            string Maxview_QC_Owner = curNode.InnerText;


            try
            {
               
                // Encoding Project Name and Description
                projectname = Encoder(projectname);
                projectDescription = Encoder(projectDescription);
                
                // Checking username formate
                if (!username.Contains("@") || !projectManager.Contains("@") || !HWengineer.Contains("@") || !SWengineer.Contains("@") || !AppEngineer.Contains("@") || !HMI_Engineer.Contains("@") || !FE_Manager.Contains("@") || !HW_Manager.Contains("@") || !SW_Manager.Contains("@") || !Crane_Dir_Owner.Contains("@") || !Warranty_User.Contains("@") || !MPR_Owner.Contains("@")|| !MaxviewRT_Owner.Contains("@") || !VOIP_Owner.Contains("@") || !SPLC_Owner.Contains("@") || !Maxview_QC_Owner.Contains("@")
                 )
                {
                    MessageBox.Show("Make sure that the entered usernames and those in the ProjectEmail.xml file are of the form 'first.last@tmeic.com' or are correct", "Friendly reminder!");
                    return false; 
                } 
                // Replace @ with %40 and make sure it is lower case
                username = username.Replace("@", "%40").ToLower();
                projectManager = projectManager.Replace("@", "%40").ToLower();
                HWengineer = HWengineer.Replace("@", "%40").ToLower();
                SWengineer = SWengineer.Replace("@", "%40").ToLower();
                AppEngineer = AppEngineer.Replace("@", "%40").ToLower();
                HMI_Engineer = HMI_Engineer.Replace("@", "%40").ToLower();

                FE_Manager = FE_Manager.Replace("@", "%40").ToLower();
                HW_Manager = HW_Manager.Replace("@", "%40").ToLower();
                SW_Manager = SW_Manager.Replace("@", "%40").ToLower();
                Crane_Dir_Owner = Crane_Dir_Owner.Replace("@", "%40").ToLower();
                Warranty_User = Warranty_User.Replace("@", "%40").ToLower();
                MPR_Owner = MPR_Owner.Replace("@", "%40").ToLower();
                MaxviewRT_Owner = MaxviewRT_Owner.Replace("@", "%40").ToLower();
                VOIP_Owner = VOIP_Owner.Replace("@", "%40").ToLower();
                SPLC_Owner = SPLC_Owner.Replace("@", "%40").ToLower();
                Maxview_QC_Owner = Maxview_QC_Owner.Replace("@", "%40").ToLower();

            

                if (HMI_Engineer == "" || AppEngineer == "" || username == "" || password == "" || projectname == "" || projectManager == "" || HWengineer == "" || SWengineer == "" || projectDescription == "" || (typeASC.Checked == typeRetro.Checked && typeQC.Checked == typeASC.Checked))
                {
                    // do something
                    MessageBox.Show("Please fill out all the fields", "Friendly reminder!");
                    return false;
                }                

                this.progressBar1.Increment(10);
                using (WebClient wb = new WebClient())
                {
                    // Create New project and Add first component:
                    // First component is General/Systems because every project type has it.
                    string getToken = wb.UploadString("https://tmeic.bugopolis.com/mh/editproducts.cgi?action=add&classification=MH%20Projects", "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&GoAheadAndLogIn=Log+in");
                    if (getToken.Contains("<title>Invalid Username Or Password</title>"))
                    {
                        MessageBox.Show("Invalid Username Or Password.", "Warning!");
                        return false;
                    }
                    if (getToken.Contains("<title>Authorization Required</title>"))
                    {
                        MessageBox.Show("This utility requires Administrative rights.", "Authorization Required");
                        return false;
                    }
                    // Including all emails in the CC list to validate them before the project is created in Bugzilla
                    string token = FindToken(getToken);
                    string component = "General%2FSystems";
                    string componentComment = "Other+System+or+multicomponent+issues";
                    string response = wb.UploadString("https://tmeic.bugopolis.com/mh/editproducts.cgi?action=add&classification=MH%20Projects", "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&product=" + projectname + "&description=" + projectDescription + "&is_active=1&allows_unconfirmed=on&version=unspecified&createseries=1&component=" + component + "&comp_desc=" + componentComment + "&initialowner=" + SWengineer + "&initialcc=" + HWengineer + "%2C+" + projectManager + "%2C+" + SWengineer + "%2C+" + AppEngineer + "%2C+" + HMI_Engineer + "%2C+" + FE_Manager + "%2C+" + HW_Manager + "%2C+" + SW_Manager + "%2C+" + Crane_Dir_Owner + "%2C+" + Warranty_User + "%2C+" + MPR_Owner + "%2C+" + MaxviewRT_Owner + "%2C+" + VOIP_Owner + "%2C+" + SPLC_Owner + "%2C+" + Maxview_QC_Owner + "%2C+" + "&action=new&token=" + token + "&classification=MH+Projects");

                    if (response.Contains("<title>Match Failed</title>"))
                    {
                        MessageBox.Show("Failed to match one or more of the input engineer emails. Please make sure each entry is correct. Check the ProjectEmail.xml as well.", "Error!");
                        return false;
                    }
                    if (response.Contains("<title>Confirm Match</title>"))
                    {
                        MessageBox.Show("Failed to match entered engineer email. Please make sure each entry is correct. Check the ProjectEmail.xml as well.", "Error");
                        return false;
                    }

                    // Editing CC list for first component to remove some of the people added.  
                    component = "ASC+Drive+Software";
                    componentComment = "Drive+configruation";
                    getToken = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=edit&product=" + projectname + "&component=General%2FSystems", "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&GoAheadAndLogIn=Log+in");
                    token = FindToken(getToken);
                    response = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=edit&product=" + projectname + "&component=General%2FSystems", "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&component=General%2FSystems&description=Other+System+or+multicomponent+issues&initialowner=" + SWengineer + "&initialcc=" + SWengineer + "%2C+" + HWengineer + "%2C+" + AppEngineer + "%2C+" + HW_Manager + "%2C+" + SW_Manager + "%2C+" + projectManager + "%2C+" + FE_Manager + "&isactive=1&action=update&componentold=General%2FSystems&product=" + projectname + "&token=" + token);
                        



                    this.progressBar1.Increment(10);
                    // Add component: Hardware  ------------ Every project gets Hardware and Genral/Systems/ 
                    component = "Hardware";
                    componentComment = "General+hardware+related+issues";
                    getToken = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&GoAheadAndLogIn=Log+in");
                    if (getToken.Contains("<title>Product Access Denied</title>"))
                    {
                        MessageBox.Show("Something When wrong");
                        return false;
                    }
                    token = FindToken(getToken);
                    response = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&component=" + component + "&description=" + componentComment + "&initialowner=" + HWengineer + "&initialcc=" + AppEngineer + "%2C+" + HWengineer + "%2C+" + HW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                    this.progressBar1.Increment(10);
                    
                    // Add component: FCN/WMR 
                    component = "FCN/WMR";
                    componentComment = "FCNs+(or+bugs+that+result+in+FCNs)+and+WMRs";
                    getToken = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&GoAheadAndLogIn=Log+in");
                    token = FindToken(getToken);
                    response = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&component=" + component + "&description=" + componentComment + "&initialowner=" + Warranty_User + "&initialcc=" + Warranty_User + "%2C+" + FE_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                    
                    // Components created if the Project is an ACS Job
                    if (typeASC.Checked == true)
                    {
                        // Add component: ASC Drive Software 
                        component = "ASC+Drive+Software";
                        componentComment = "Drive+configruation";
                        getToken = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SWengineer + "&initialcc=" + SWengineer + "%2C+" + SW_Manager + "%2C+" + AppEngineer + "%2C+" + projectManager + "&action=new&token=" + token);
                        
                        // Add component: ASC PLC Software 
                        component = "ASC+PLC+Software";
                        componentComment = "Crane+master+control+software";
                        getToken = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SWengineer + "&initialcc=" + SWengineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                       
                        this.progressBar1.Increment(10);
                        // Add component: CraneDirector 
                        component = "CraneDirector";
                        componentComment = "ASC+instruction+manager+and+TOS+interface";
                        getToken = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&component=" + component + "&description=" + componentComment + "&initialowner=" + Crane_Dir_Owner + "&initialcc=" + Crane_Dir_Owner + "%2C+" + projectManager + "%2C+" + SW_Manager + "&action=new&token=" + token);
                        
                        // Add component: LCMS HMI 
                        component = "LCMS+HMI";
                        componentComment = "Local+CMS+HMI+project+%26+computer+issues";
                        getToken = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&component=" + component + "&description=" + componentComment + "&initialowner=" + HMI_Engineer + "&initialcc=" + HMI_Engineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                        
                        this.progressBar1.Increment(10);
                        // Add component: Maxspeed Performance Report 
                        component = "Maxspeed+Performance+Report";
                        componentComment = "UMI%2C+Retry%2C+and+system+performance+reporting+tool";
                        getToken = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&component=" + component + "&description=" + componentComment + "&initialowner=" + MPR_Owner + "&initialcc=" + MPR_Owner + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                       
                        // Add component: Maxview ASC 
                        component = "Maxview+ASC";
                        componentComment = "Maxview+software+for+ASC";
                        getToken = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&component=" + component + "&description=" + componentComment + "&initialowner=" + MaxviewRT_Owner + "&initialcc=" + MaxviewRT_Owner + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                        
                        this.progressBar1.Increment(10);
                        // Add component: CraneDirector 
                        component = "Maxview+Clear+Zone";
                        componentComment = "Maxview+for+transfer+zone";
                        getToken = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&component=" + component + "&description=" + componentComment + "&initialowner=" + MaxviewRT_Owner + "&initialcc=" + MaxviewRT_Owner + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                        
                        // Add component: RCMS HMI 
                        component = "RCMS+HMI";
                        componentComment = "RCMS+HMI+screens+and+computer+issues";
                        getToken = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&component=" + component + "&description=" + componentComment + "&initialowner=" + HMI_Engineer + "&initialcc=" + HMI_Engineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                        
                        this.progressBar1.Increment(10);
                        // Add component: VOIP Software  
                        component = "VOIP+Software";
                        componentComment = "Voice+over+IP";
                        getToken = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&component=" + component + "&description=" + componentComment + "&initialowner=" + VOIP_Owner + "&initialcc=" + VOIP_Owner + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                        
                        // Add component: Yard HMI 
                        component = "Yard+HMI";
                        componentComment = "Yard+HMI+project%2C+including+ROS+screen+files";
                        getToken = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&component=" + component + "&description=" + componentComment + "&initialowner=" + HMI_Engineer + "&initialcc=" + HMI_Engineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                        
                        this.progressBar1.Increment(10);
                        // Add component: Yard PLC  
                        component = "Yard+PLC";
                        componentComment = "Primary+yard+PLC+software";
                        getToken = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SWengineer + "&initialcc=" + SWengineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                        
                        this.progressBar1.Increment(10);
                        // Add component: Yard Safety PLC 
                        component = "Yard+Safety+PLC";
                        componentComment = "Safety+PLC+software+-+PILZ";
                        getToken = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SPLC_Owner + "&initialcc=" + SPLC_Owner + "%2C+" + SWengineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                        
                    }

                    // Components created if the Project is a Quay Cane job
                    if (typeQC.Checked == true)
                    {
                        // Add component: Cab HMI 
                        component = "Cab+HMI";
                        componentComment = "HMI+viewer+computer+in+the+cab";
                        getToken = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&component=" + component + "&description=" + componentComment + "&initialowner=" + HMI_Engineer + "&initialcc=" + HMI_Engineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                       
                        this.progressBar1.Increment(15);
                        // Add component: Drive Software 
                        component = "Drive+Software";
                        componentComment = "Drive+Configuration";
                        getToken = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SWengineer + "&initialcc=" + SWengineer + "%2C+" + SW_Manager + "%2C+" + AppEngineer + "%2C+" + projectManager + "&action=new&token=" + token);
                        
                        this.progressBar1.Increment(10);
                        // Add component: LCMS HMI 
                        component = "LCMS+HMI";
                        componentComment = "Local+CMS+HMI+project+%26+computer+issues";
                        getToken = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&component=" + component + "&description=" + componentComment + "&initialowner=" + HMI_Engineer + "&initialcc=" + HMI_Engineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                        
                        this.progressBar1.Increment(10);
                        // Add component: Maxview Smart Landing 
                        component = "Maxview+Smart+Landing";
                        componentComment = "STS+Crane+Maxview+Smart+Landing+issues";
                        getToken = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&component=" + component + "&description=" + componentComment + "&initialowner=" + Maxview_QC_Owner + "&initialcc=" + Maxview_QC_Owner + "%2C+" + SW_Manager + "%2C+" + MaxviewRT_Owner + "%2C+" + projectManager + "&action=new&token=" + token);
                        
                        this.progressBar1.Increment(10);
                        // Add component: PLC Software 
                        component = "PLC+Software";
                        componentComment = "UMI%2C+Retry%2C+and+system+performance+reporting+tool";
                        getToken = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SWengineer + "&initialcc=" + SWengineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                        
                        this.progressBar1.Increment(15);
                        // Add component: RCMS HMI 
                        component = "RCMS+HMI";
                        componentComment = "RCMS+HMI+screens%2C+project+configuration%2C+remote+computer+general+issues";
                        getToken = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&component=" + component + "&description=" + componentComment + "&initialowner=" + HMI_Engineer + "&initialcc=" + HMI_Engineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                        
                    }

                    // Components created if the Project is a Smart Landing Retorfit
                    if (typeRetro.Checked == true)
                    {
                        // Add component: Maxview PLC Software 
                        component = "Maxview+PLC+Software";
                        componentComment = " PLC+code+added+to+existing+crane+control+for+Maxview+sytem";
                        getToken = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SWengineer + "&initialcc=" + SWengineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                        
                        this.progressBar1.Increment(60);
                        // Add component: MaxviewRT Software 
                        component = "MaxviewRT+Software";
                        componentComment = "MaxviewRT";
                        getToken = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString("https://tmeic.bugopolis.com/mh/editcomponents.cgi?action=add&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&component=" + component + "&description=" + componentComment + "&initialowner=" + MaxviewRT_Owner + "&initialcc=" + MaxviewRT_Owner + "%2C+" + SW_Manager + "%2C+" + SWengineer + "%2C+" + projectManager + "&action=new&token=" + token);
                        
                    }
                
                getToken = wb.UploadString("https://tmeic.bugopolis.com/mh/editproducts.cgi?action=editgroupcontrols&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&GoAheadAndLogIn=Log+in");
                token = FindToken(getToken);
                response = wb.UploadString("https://tmeic.bugopolis.com/mh/editproducts.cgi?action=editgroupcontrols&product=" + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&action=updategroupcontrols&product="+projectname+"&token="+token+"&membercontrol_21=0&othercontrol_21=0&membercontrol_17=0&othercontrol_17=0&membercontrol_15=0&othercontrol_15=0&entry_16=1&membercontrol_16=3&othercontrol_16=3&membercontrol_22=0&othercontrol_22=0&submit=submit");
                

                }

                
                this.progressBar1.Increment(10);
                return true;
                
            }
            catch(Exception e)
            {
                MessageBox.Show("Failed to complete! Check Bugzilla to see if any part of the project was created. \r\n\r\n Exception thrown: " + e, "Error!");
                return false;
            }
            
        }

        private string FindToken(string PageHTML)
        {
            // This function retrieves the unique token which is created every time a page is opened so that it can be submitted with the new component.
            int first = PageHTML.IndexOf("name=\"token\" value=\"") + "name=\"token\" value=\"".Length;            
            return PageHTML.Substring(first, 10);
        }
        private string Encoder(string projectDescription )
        {
            // The encoding needed is not exactly ASCII encoding so this does it for us.
            // -   == -
            // _   == _
            // .   == . 
            // *   == * 

            // Must be the first one.
            projectDescription = projectDescription.Replace("%", "%25");// %25 == %

            projectDescription = projectDescription.Replace(">", "%3E"); // %3E == >
            projectDescription = projectDescription.Replace("<", "%3C"); // %3C == <
            projectDescription = projectDescription.Replace("(", "%28");// %28 == (
            projectDescription = projectDescription.Replace(")", "%29");// %29 == )
            projectDescription = projectDescription.Replace("[", "%5B");// %5B == [
            projectDescription = projectDescription.Replace("]", "%5D");// %5D == ]
            projectDescription = projectDescription.Replace("{", "%7B");// %7B == { 
            projectDescription = projectDescription.Replace("}", "%7D");// %7D == }
            projectDescription = projectDescription.Replace(",", "%2C");// %2C == ,
            projectDescription = projectDescription.Replace(":", "%3A");// %3A == :
            projectDescription = projectDescription.Replace(";", "%3B");// %3B == ;
            projectDescription = projectDescription.Replace("\"", "%22");// %22 == "
            projectDescription = projectDescription.Replace("`", "%60");// %60 == `
            projectDescription = projectDescription.Replace("~", "%7E");// %7E == ~
            projectDescription = projectDescription.Replace("\\", "%5C");// %5C == \
            projectDescription = projectDescription.Replace("/", "%2F");// %2F == /
            projectDescription = projectDescription.Replace("|", "%7C");// %7C == |
            projectDescription = projectDescription.Replace("@", "%40");// %40 == @
            projectDescription = projectDescription.Replace("#", "%23");// %23 == # 
            projectDescription = projectDescription.Replace("?", "%3F"); // %3F == ?
            projectDescription = projectDescription.Replace("+", "%2B");// %2B == +  
            projectDescription = projectDescription.Replace("!", "%21");// %21 == ! 
            projectDescription = projectDescription.Replace("$", "%24");// %24 == $            
            projectDescription = projectDescription.Replace("^", "%5E");// %5E == ^
            projectDescription = projectDescription.Replace("&", "%26");// %26 == &
            projectDescription = projectDescription.Replace("=", "%3D");// %3D == = 
            // Must be at the end 
            projectDescription = projectDescription.Replace(" ", "+");// +   == (space)

            return projectDescription;
        }

        
        
    }
}
