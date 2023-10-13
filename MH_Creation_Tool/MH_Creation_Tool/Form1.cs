//Name: MH Tool.Designer.cs
//Author:
//Date:
//Modified:
/*----
 * Alexander Summerton - 11/14/2022 - Added token extraction to project creation function, depreciated XML Edit and Test Cookies event functions
 * Aniruddh Chauhan - 10/03/2023 - Enhanced Features
 */

using System;
using System.Windows.Forms;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using System.Collections.Specialized;
using System.Web;
using System.Xml;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Security.Policy;
using HtmlAgilityPack;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace WindowsFormsApplication1
{
    public partial class MH_tool : Form
    {
        List<object> comboBox_ItemsCopy = new List<object>();
        public MH_tool()
        {
            InitializeComponent();
            checkedListBox_ASC.CheckOnClick = true;
            checkedListBox_QC.CheckOnClick = true;
            checkedListBox_Req.CheckOnClick = true;
            checkedListBox_General.CheckOnClick = true;
            checkedListBox_ASC.Enabled = false;
            checkedListBox_QC.Enabled = false;
            checkedListBox_General.Enabled = false;
            checkedListBox_Req.Enabled = false;
            typeASC.Enabled = false;
            typeQC.Enabled = false;
            typeRequisit.Enabled = false;
            checkBox_General.Enabled = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.progressBar1.Value = 0;
            if (CreateProject())
            {
                if (MessageBox.Show("A new project has been created.\r\n\r\n Select yes to open a the new project in your browser and no to close this message", "Visit", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(@"https://tools.tmeic.com/mh/editproducts.cgi?action=edit&product=" + Encoder(textBox3.Text));
                }
            }
            else this.progressBar1.Value = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (get_users_email())
            {
                MessageBox.Show("Email List has been update successfully! Proceed?", "Succes!");
            }
        }
        private void comboBox_ProjMan_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {// Handle printable characters (letters, numbers, symbols, punctuation).
                List<object> autoComplete_suggestions = new List<object>();
                foreach (object item in comboBox_ItemsCopy)
                {// Filter items that start with the user's input (case-insensitive).               
                    if (item.ToString().Contains(comboBox_ProjMan.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        autoComplete_suggestions.Add(item);
                    }
                }
                comboBox_ProjMan.Items.Clear();
                comboBox_ProjMan.Items.AddRange(autoComplete_suggestions.ToArray());
                comboBox_ProjMan.SelectionStart = comboBox_ProjMan.Text.Length; // Keep the user's input selected.
                comboBox_ProjMan.DroppedDown = true; // Show the dropdown with autoComplete_suggestions.
            }
            else if (string.IsNullOrEmpty(comboBox_ProjMan.Text))
            {//Hide the dropdown when there's no input.
                comboBox_ProjMan.Items.Clear();
                comboBox_ProjMan.Items.AddRange(comboBox_ItemsCopy.ToArray());
            }
        }



        private void comboBox_CompTech_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {// Handle printable characters (letters, numbers, symbols, punctuation).
                //List<object> autoComplete_suggestions = new List<object>();
                //foreach (object item in comboBox_ItemsCopy)
                //{// Filter items that start with the user's input (case-insensitive).               
                //    if (item.ToString().Contains(comboBox_CompTech.Text, StringComparison.OrdinalIgnoreCase))
                //    {
                //        autoComplete_suggestions.Add(item);
                //    }
                //}
                //comboBox_CompTech.Items.Clear();
                //comboBox_CompTech.Items.AddRange(autoComplete_suggestions.ToArray());
                //comboBox_CompTech.SelectionStart = comboBox_CompTech.Text.Length; // Keep the user's input selected.
                //comboBox_CompTech.DroppedDown = true; // Show the dropdown with autoComplete_suggestions.
                comboBox_get_emails(comboBox_CompTech);
            }
            else if (string.IsNullOrEmpty(comboBox_CompTech.Text))
            {//Hide the dropdown when there's no input.
             //comboBox_CompTech.Items.Clear();
             //comboBox_CompTech.Items.AddRange(comboBox_ItemsCopy.ToArray());
                comboBox_clear_emails(comboBox_CompTech);
            }
        }


        private void comboBox_get_emails(System.Windows.Forms.ComboBox combobox)
        {

            List<object> autoComplete_suggestions = new List<object>();
            foreach (object item in comboBox_ItemsCopy)
            {// Filter items that start with the user's input (case-insensitive).               
                if (item.ToString().Contains(combobox.Text, StringComparison.OrdinalIgnoreCase))
                {
                    autoComplete_suggestions.Add(item);
                }
            }
            combobox.Items.Clear();
            combobox.Items.AddRange(autoComplete_suggestions.ToArray());
            combobox.SelectionStart = combobox.Text.Length; // Keep the user's input selected.
            combobox.DroppedDown = true; // Show the dropdown with autoComplete_suggestions

        }
        private void comboBox_clear_emails(System.Windows.Forms.ComboBox combobox)
        {
            combobox.Items.Clear();
            combobox.Items.AddRange(comboBox_ItemsCopy.ToArray());


        }





        //private void SetupAutoComplete(System.Windows.Forms.ComboBox comboBox)
        //{
        //    comboBox.TextChanged += (sender, e) =>
        //    {
        //        if (char.IsLetterOrDigit(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar))
        //        {
        //            List<object> autoCompleteSuggestions = new List<object>();
        //            foreach (object item in comboBox_ItemsCopy)
        //            {
        //                if (item.ToString().Contains(comboBox.Text, StringComparison.OrdinalIgnoreCase))
        //                {
        //                    autoCompleteSuggestions.Add(item);
        //                }
        //            }
        //            comboBox.Items.Clear();
        //            comboBox.Items.AddRange(autoCompleteSuggestions.ToArray());
        //            comboBox.SelectionStart = comboBox.Text.Length;
        //            comboBox.DroppedDown = true;
        //        }
        //        else if (string.IsNullOrEmpty(comboBox.Text))
        //        {
        //            comboBox.Items.Clear();
        //            comboBox.Items.AddRange(comboBox_ItemsCopy.ToArray());
        //        }
        //    };
        //}

        private bool get_users_email()
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string url = "https://tools.tmeic.com/mh/editusers.cgi?action=list&matchvalue=login_name&matchstr=&matchtype=substr&groupid=1&is_enabled=1";
            string loginToken;
            string email_cookies;
            string response;
            try
            {
                if (!username.Contains("@"))
                {
                    MessageBox.Show("Make sure that the entered usernames and those in the ProjectEmail.xml file are of the form 'first.last@tmeic.com' or are correct", "Friendly reminder!");
                    return false;
                }
                username = username.Replace("@", "%40").ToLower();  // Replace @ with %40 and make sure it is lower case
                if (username == "" || password == "")
                {
                    MessageBox.Show("Please fill out all the fields", "Friendly reminder!");
                    return false;
                }
                using (WebClient web = new WebClient())
                {
                    if (password == "")
                    {
                        MessageBox.Show("You must enter your Bugzilla credentials to test the cookies.", "Error!");
                        return false;
                    }
                    try
                    {
                        try   //Load XML Document
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
                        curNode = Doc.SelectSingleNode("Configuration/Cookies");
                        if (curNode == null)
                        {
                            MessageBox.Show("Problem with ProjectEmail.xml/Configuration/Cookies");
                            return false;
                        }
                        email_cookies = curNode.InnerText;
                        curNode = Doc.SelectSingleNode("Configuration/LoginToken");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An exception was thrown while reading the ProjectEmail.xml. Please insure that it is in the same folder as the project creation utility. ", "Error!");
                        return false;
                    }
                    try
                    {
                        web.Headers.Add(HttpRequestHeader.Cookie, email_cookies);
                        CredentialCache credentialCache = new CredentialCache();
                        credentialCache.Add(new System.Uri(url), "Basic", new NetworkCredential(username, password, "tools.tmeic.com"));
                        try
                        {
                            web.Credentials = credentialCache;
                            web.BaseAddress = url;
                            string token_page = web.DownloadString(url);  //retrieve a login webpage as a string                          
                            string _buggzilla_login = "Bugzilla_login_token";
                            int position = 0;
                            for (int i = 0; i < token_page.Length; i++)//iterate through the string until finding the login token
                            {
                                bool done_flag = false; //flag to track if the vlaue is found and terminate the for loop
                                for (int j = 0; j < _buggzilla_login.Length; j++)
                                {//for every character, begin a substring search
                                    if (_buggzilla_login[j] != token_page[i + j])
                                    {//sequentially check each character against the phrase "Bugzilla_login_token", if there is a mis-match, break and start over from next character
                                        break;
                                    }
                                    else if (j == _buggzilla_login.Length - 1)
                                    {//if all cards match, position becomes i;
                                        position = i;
                                        done_flag = true; //set the finish flag to false
                                        break;
                                    }
                                }
                                if (done_flag) { break; }//if the token position was found, break and end the position finding loop.
                            }
                            string _value = "value"; //jump position to first instance of value after the token is found.
                            for (int i = position; i < token_page.Length; i++)//iterate through the string until finding the login token
                            {
                                bool done_flag = false; //flag to track if the value is found and terminate the for loop
                                for (int j = 0; j < _value.Length; j++)
                                {//for every character, begin a substring search
                                    if (_value[j] != token_page[i + j])
                                    {//sequentially check each character against the phrase "Bugzilla_login_token", if there is a mis-match, break and start from next character
                                        break;
                                    }
                                    else if (j == _value.Length - 1)
                                    {//if all cards match, position becomes i;
                                        position = i + j + 3; //set the position to four characters pasts the "e" in value, the first character of the login token
                                        done_flag = true;
                                        break;
                                    }
                                }
                                if (done_flag) { break; }//if the token position was found, break and end the position finding loop.
                            }
                            StringBuilder loginToken_temp = new StringBuilder();
                            while (token_page[position] != 34)
                            {
                                loginToken_temp.Append(token_page[position]);
                                position++;
                            }
                            loginToken = loginToken_temp.ToString();
                            response = web.UploadString(url, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                            if (response.Contains("<title>Untrusted Authentication Request</title>"))
                            {
                                MessageBox.Show("Bugzilla returned the Untrusted Authentication Request page. The Cookies or Login Tokens are invalid", "Failed!");
                                return false;
                            }
                            else if (response.Contains("<title>Invalid Username Or Password</title>"))
                            {
                                MessageBox.Show("Invalid Username Or Password.");
                                return false;
                            }
                            else if (response.Contains("<title>Authorization Required</title>"))
                            {
                                MessageBox.Show("Authorization Required. You are not an Admin!");
                                return false;
                            }
                            else if (response.Contains("<title>Select user</title>"))
                            {
                                MessageBox.Show("Select User Emails");
                                HtmlAgilityPack.HtmlDocument html_doc = new HtmlAgilityPack.HtmlDocument();
                                html_doc.LoadHtml(response);
                                HtmlAgilityPack.HtmlNodeCollection thNode = html_doc.DocumentNode.SelectNodes("//table[@id='admin_table']//td//a");
                                if (thNode != null)
                                {// Iterate through all child nodes of the <th> element
                                    foreach (HtmlNode childNode in thNode)
                                    { // Extract the content of child nodes (text or HTML)
                                        string elementContent = childNode.InnerHtml; // or .InnerText for plain text                                       
                                        if (elementContent.Contains("&#64;"))
                                        {
                                            elementContent = elementContent.Replace("&#64;", "@");
                                            comboBox_ItemsCopy.Add(elementContent);
                                            comboBox_SysEng.Items.Add(elementContent);
                                        }
                                    }
                                }
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("Unexpected response");
                                return false;
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Exception thrown. Operation failed");
                            return false;
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Failed to complete!" + e, "Error");
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to complete! Check Bugzilla to see if any part of the project was created. \r\n\r\n Exception thrown: " + e, "Error!");
                return false;
            }
        }

        private bool CreateProject()
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string projectname = textBox3.Text;
            string projectManager = comboBox_ProjMan.Text;
            string HWengineer = comboBox_HrdwEng.Text;
            string SWengineer = comboBox_SysEng.Text;
            string projectDescription = textBox7.Text;
            string HMI_Engineer = comboBox_HMIEng.Text;
            string AppEngineer = comboBox_AppEng.Text;
            string SysEngineer = comboBox_ControlEng.Text;
            string CompTech = comboBox_CompTech.Text;
            string DrvEngineer = comboBox_DriveEng.Text;

            string FE_Manager;
            string HW_Manager;
            string SW_Manager;
            string Crane_Dir_Owner;
            string Warranty_User;
            string MPR_Owner;
            string MaxviewRT_Owner;
            string VOIP_Owner;
            string SPLC_Owner;
            string Maxview_QC_Owner;

            string loginToken;
            string cookies;
            string urlAddProject = @"https://tools.tmeic.com/mh/editproducts.cgi?action=add&classification=MH%20Projects";
            string urlAddProduct = @"https://tools.tmeic.com/mh/editcomponents.cgi?action=add&product=";
            string urlEditGroupControl = @"https://tools.tmeic.com/mh/editproducts.cgi?action=editgroupcontrols&product=";
            //Local Variables added by Alexander Summerotn 11-7-11
            //Mergiing of button2_click
            string response;
            string url = "https://tools.tmeic.com/mh/editproducts.cgi?action=add&classification=MH%20Projects";

            //  if (checkedListBox_ASC.GetItemChecked(8) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
            if (password == "")
            {
                MessageBox.Show("You must enter your Bugzilla credentials to test the cookies.", "Error!");
                return false;
            }
            try
            {
                try   //Load XML Document
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
                FE_Manager = curNode.InnerText; // FE_Manager string now stores the Field Manager email



                curNode = Doc.SelectSingleNode("Configuration/HardwareManager");
                if (curNode == null)
                {
                    MessageBox.Show("Problem with ProjectEmail.xml/Configuration/HardwareManager");
                    return false;
                }
                HW_Manager = curNode.InnerText;




                curNode = Doc.SelectSingleNode("Configuration/SoftwareManager");
                if (curNode == null)
                {
                    MessageBox.Show("Problem with ProjectEmail.xml/Configuration/SoftwareManager");
                    return false;
                }
                SW_Manager = curNode.InnerText;



                curNode = Doc.SelectSingleNode("Configuration/CrainDirectorOwner");
                if (curNode == null)
                {
                    MessageBox.Show("Problem with ProjectEmail.xml/Configuration/CrainDirectorOwner");
                    return false;
                }
                Crane_Dir_Owner = curNode.InnerText;



                curNode = Doc.SelectSingleNode("Configuration/WarrantyUser");
                if (curNode == null)
                {
                    MessageBox.Show("Problem with ProjectEmail.xml/Configuration/WarrantyUser");
                    return false;
                }
                Warranty_User = curNode.InnerText;



                curNode = Doc.SelectSingleNode("Configuration/MPROwner");
                if (curNode == null)
                {
                    MessageBox.Show("Problem with ProjectEmail.xml/Configuration/MPROwner");
                    return false;
                }
                MPR_Owner = curNode.InnerText;



                curNode = Doc.SelectSingleNode("Configuration/MaxViewRT");
                if (curNode == null)
                {
                    MessageBox.Show("Problem with ProjectEmail.xml/Configuration/MaxViewRT");
                    return false;
                }
                MaxviewRT_Owner = curNode.InnerText;



                curNode = Doc.SelectSingleNode("Configuration/VOIPOwner");
                if (curNode == null)
                {
                    MessageBox.Show("Problem with ProjectEmail.xml/Configuration/VOIPOwner");
                    return false;
                }
                VOIP_Owner = curNode.InnerText;



                curNode = Doc.SelectSingleNode("Configuration/SPLCOwner");
                if (curNode == null)
                {
                    MessageBox.Show("Problem with ProjectEmail.xml/Configuration/SPLCOwner");
                    return false;
                }
                SPLC_Owner = curNode.InnerText;



                curNode = Doc.SelectSingleNode("Configuration/MaxviewQCOwner");
                if (curNode == null)
                {
                    MessageBox.Show("Problem with ProjectEmail.xml/Configuration/MaxviewQCOwner");
                    return false;
                }
                Maxview_QC_Owner = curNode.InnerText;



                curNode = Doc.SelectSingleNode("Configuration/Cookies");
                if (curNode == null)
                {
                    MessageBox.Show("Problem with ProjectEmail.xml/Configuration/Cookies");
                    return false;
                }
                cookies = curNode.InnerText;

                /*curNode = Doc.SelectSingleNode("Configuration/LoginToken");
                
                if (curNode == null)
                {
                    MessageBox.Show("Problem with ProjectEmail.xml/Configuration/LoginToken");
                    return false;
                }
                loginToken = curNode.InnerText;               
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show("An exception was thrown while reading the ProjectEmail.xml. Please insure that it is in the same folder as the project creation utility. ", "Error!");
                return false;
            }

            try
            {

                // Encoding Project Name and Description
                projectname = Encoder(projectname);
                projectDescription = Encoder(projectDescription);

                // Checking username formate
                if (!username.Contains("@") || !projectManager.Contains("@") || !HWengineer.Contains("@") || !SWengineer.Contains("@") || !AppEngineer.Contains("@") || !HMI_Engineer.Contains("@") || !FE_Manager.Contains("@") || !HW_Manager.Contains("@") || !SW_Manager.Contains("@") || !Crane_Dir_Owner.Contains("@") || !Warranty_User.Contains("@") || !MPR_Owner.Contains("@") || !MaxviewRT_Owner.Contains("@") || !VOIP_Owner.Contains("@") || !SPLC_Owner.Contains("@") || !Maxview_QC_Owner.Contains("@")
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
                SysEngineer = SysEngineer.Replace("@", "%40").ToLower();
                CompTech = CompTech.Replace("@", "%40").ToLower();
                DrvEngineer = DrvEngineer.Replace("@", "%40").ToLower();

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

                if (HMI_Engineer == "" || AppEngineer == "" || username == "" || password == "" || projectname == "" || projectManager == "" || DrvEngineer == "" || HWengineer == "" || SWengineer == "" || SysEngineer == "" || CompTech == "" || projectDescription == "")
                {
                    // do something
                    MessageBox.Show("Please fill out all the fields", "Friendly reminder!");
                    return false;
                }

                this.progressBar1.Increment(10);

                using (WebClient wb = new WebClient())
                {
                    string token;
                    string component;
                    string componentComment;
                    //string response;
                    string getToken;
                    try
                    {
                        // Create New project and Add first component:
                        // First component is General/Systems because every project type has it.
                        wb.Headers.Add(HttpRequestHeader.Cookie, cookies);
                        /*-----------------Coded Added by Alexander Summerton
                         * adapted from  button2_click to present function
                         * This code pulls a Bugzilla login page, extracts the login token from the login page, then uses it as the login for project creation
                         */
                        CredentialCache credentialCache = new CredentialCache();
                        credentialCache.Add(new System.Uri(url), "Basic", new NetworkCredential(username, password, "tools.tmeic.com"));

                        try
                        {
                            wb.Credentials = credentialCache;
                            wb.BaseAddress = url;
                            //retrieve a login webpage as a string
                            string token_page = wb.DownloadString(url);
                            // Console.WriteLine(token_page);
                            string _buggzilla_login = "Bugzilla_login_token";
                            int position = 0;
                            for (int i = 0; i < token_page.Length; i++)//iterate through the string until finding the login token
                            {
                                bool done_flag = false; //flag to track if the vlaue is found and terminate the for loop
                                for (int j = 0; j < _buggzilla_login.Length; j++)
                                {//for every character, begin a substring search
                                    if (_buggzilla_login[j] != token_page[i + j])
                                    {//sequentially check each character against the phrase "Bugzilla_login_token", if there is a mis-match, break and start over from next character
                                        break;
                                    }
                                    else if (j == _buggzilla_login.Length - 1)
                                    {//if all cards match, position becomes i;
                                        position = i;
                                        done_flag = true; //set the finish flag to false
                                        break;
                                    }
                                }
                                if (done_flag) { break; }//if the token position was found, break and end the position finding loop.
                            }
                            //jump position to first instance of value after the token is found.
                            string _value = "value";
                            for (int i = position; i < token_page.Length; i++)//iterate through the string until finding the login token
                            {
                                bool done_flag = false; //flag to track if the value is found and terminate the for loop
                                for (int j = 0; j < _value.Length; j++)
                                {//for every character, begin a substring search
                                    if (_value[j] != token_page[i + j])
                                    {//sequentially check each character against the phrase "Bugzilla_login_token", if there is a mis-match, break and start from next character
                                        break;
                                    }
                                    else if (j == _value.Length - 1)
                                    {//if all cards match, position becomes i;
                                        position = i + j + 3; //set the position to four characters pasts the "e" in value, the first character of the login token
                                        done_flag = true;
                                        break;
                                    }
                                }
                                if (done_flag) { break; }//if the token position was found, break and end the position finding loop.
                            }
                            StringBuilder loginToken_temp = new StringBuilder();
                            while (token_page[position] != 34)
                            {  //the page is returned with the token ending with " (quotation marks).  34 is ASCII code.  while that character is not hit, keep appending the login token to loginToken_temp
                                //a temp String_builder is used since strings are "immutable" in C#, that is, once set their value cannot be changed.
                                loginToken_temp.Append(token_page[position]);
                                position++;
                            }
                            loginToken = loginToken_temp.ToString(); // once the terminal character is found, set the login token to the extracted string
                            //attempt a Login-push.  If there is a mismatch, Dialogue box will appear and indicate failure and abort project creation.
                            //otherwise, login is successful and 
                            response = wb.UploadString(url, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                            if (response.Contains("<title>Add Product</title>")) { }
                            //    MessageBox.Show("Successfully sent command. Cookies and Tokens are still valid.", "Success! ");
                            else if (response.Contains("<title>Confirm Match</title>"))
                            {
                                MessageBox.Show("Failed to match entered eng" +
                                    "ineer email. Please make sure each entry is correct. Check the ProjectEmail.xml as well.", "Error");
                                return false;
                            }
                            else if (response.Contains("<title>Untrusted Authentication Request</title>"))
                            {
                                MessageBox.Show("Bugzilla returned the Untrusted Authentication Request page. The Cookies or Login Tokens are invalid", "Failed!");
                                return false;
                            }
                            else if (response.Contains("<title>Invalid Username Or Password</title>"))
                            {
                                MessageBox.Show("Invalid Username Or Password.");
                                return false;
                            }
                            else if (response.Contains("<title>Match Failed</title>"))
                            {
                                MessageBox.Show("Failed to match one or more of the input engineer emails. Please make sure each entry is correct. Check the ProjectEmail.xml as well.", "Error!");
                                return false;
                            }
                            else if (response.Contains("<title>Authorization Required</title>"))
                            {
                                MessageBox.Show("Authorization Required. You are not an Admin!");
                                return false;
                            }
                            else
                            {
                                MessageBox.Show("Unexpected response. Unsure of success.  Ending Project Creation");
                                return false;
                            }

                        }
                        catch
                        {
                            MessageBox.Show("Exception thrown. Operation failed");
                            return false;

                        }
                        /*----- End code added by Alexander Summerton-----*/
                        getToken = wb.UploadString(urlAddProject, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        Console.WriteLine(getToken);
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
                        if (getToken.Contains("<title>Untrusted Authentication Request</title>"))
                        {
                            MessageBox.Show("Bugzilla returned the Untrusted Authentication Request page. Failed to create project.");
                            return false;
                        }
                        // Including all emails in the CC list to validate them before the project is created in Bugzilla
                        token = FindToken(getToken);
                        Console.WriteLine(token);
                        component = "General%2FSystems";
                        componentComment = "Other+System+or+multicomponent+issues";
                        response = wb.UploadString(urlAddProject, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&product=" + projectname + "&description=" + projectDescription
                                                   + "&is_active=1&allows_unconfirmed=on&version=unspecified&createseries=1&component=" + component + "&comp_desc=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + CompTech
                                                   + "%2C+" + DrvEngineer + "%2C+" + SWengineer + "%2C+" + HWengineer + "%2C+" + projectManager + "%2C+" + AppEngineer + "%2C+" + HMI_Engineer + "%2C+" + FE_Manager + "%2C+" + HW_Manager + "%2C+"
                                                   + SW_Manager + "%2C+" + Crane_Dir_Owner + "%2C+" + Warranty_User + "%2C+" + MPR_Owner + "%2C+" + MaxviewRT_Owner + "%2C+" + SPLC_Owner + "%2C+" + Maxview_QC_Owner + "%2C+" + "&action=new&token="
                                                   + token + "&classification=MH+Projects");

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
                        if (response.Contains("<title>Untrusted Authentication Request</title>"))
                        {
                            MessageBox.Show("Bugzilla returned the Untrusted Authentication Request page. Failed to create project.");
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Exception thrown while creating project", "Error");
                        return false;
                    }
                    try
                    {
                        // Editing CC list for first component to remove some of the people added.  
                        component = "ASC+Drive+Software";
                        componentComment = "Drive+Configuration+Software";
                        getToken = wb.UploadString("https://tools.tmeic.com/mh/editcomponents.cgi?action=edit&product=" + projectname + "&component=General%2FSystems", "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString("https://tools.tmeic.com/mh/editcomponents.cgi?action=edit&product=" + projectname + "&component=General%2FSystems", "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=General%2FSystems&description=Other+System+or+multicomponent+issues&initialowner=" + DrvEngineer + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + CompTech + "%2C+" + HWengineer + "%2C+" + AppEngineer + "%2C+" + HW_Manager + "%2C+" + SW_Manager + "%2C+" + projectManager + "%2C+" + FE_Manager + "&isactive=1&action=update&componentold=General%2FSystems&product=" + projectname + "&token=" + token);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Exception thrown while creating project", "Error");
                    }

                    // Begins the creation of all components common to any MH project if this is not a Requisition Project
                    if (typeRequisit.Checked == false)
                    {

                        if (checkBox_General.Checked == true)
                        {
                            this.progressBar1.Increment(10);
                            // Add component: Hardware  ------------ Every project gets Hardware 
                            component = "General+Hardware";
                            componentComment = "General+hardware+related+issues+including+elementary+drawings,+panels,+Circuits,+etc.";
                            getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                            if (getToken.Contains("<title>Product Access Denied</title>"))
                            {
                                MessageBox.Show("Something Went wrong");
                                return false;
                            }
                            token = FindToken(getToken);
                            response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + HWengineer + "&initialcc=" + SysEngineer + "%2C+" + AppEngineer + "%2C+" + HWengineer + "%2C+" + HW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                            this.progressBar1.Increment(10);

                            // Add component: Crane PLC 
                            component = "Crane+PLC";
                            componentComment = "Crane+PLC+Software";
                            getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                            token = FindToken(getToken);
                            response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SWengineer + "&initialcc=" + SysEngineer + "%2C+" + FE_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                            // Add component: General Software 
                            component = "General+Software";
                            componentComment = "Anything+software+related+not+dealing+with+the+PLC+or+HMI+project";
                            getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                            token = FindToken(getToken);
                            response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + FE_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                            // Add component: Drive Hardware 
                            component = "Drive+Hardware";
                            componentComment = "Issues+related+to+Drive+Hardware";
                            getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                            token = FindToken(getToken);
                            response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + HWengineer + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + SW_Manager + "%2C+" + AppEngineer + "%2C+" + projectManager + "&action=new&token=" + token);

                            // Add component: Drive Software 
                            component = "Drive+Software";
                            componentComment = "Issues+related+to+Drive+Software+files";
                            getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                            token = FindToken(getToken);
                            response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + DrvEngineer + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + HW_Manager + "%2C+" + SW_Manager + "%2C+" + AppEngineer + "%2C+" + projectManager + "&action=new&token=" + token);

                            // Add component: LCMS HMI Project 
                            component = "LCMS+HMI+Project";
                            componentComment = "General+HMI+project+related+issues+including+points,+alarms,+events,+scripts,+devices,+ports,+users,+roles,+resources,+database+logger,+documentation,+drawings+index,+and+HMI+config+files";
                            getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                            token = FindToken(getToken);
                            response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + HMI_Engineer + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + FE_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                            // Add component: LCMS HMI Screens 
                            component = "LCMS+HMI+Screens";
                            componentComment = "General+HMI+screens+related+issues";
                            getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                            token = FindToken(getToken);
                            response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + HMI_Engineer + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + FE_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                            // Add component: LCMS Machine Configuration 
                            component = "LCMS+Machine+Configuration";
                            componentComment = "General+machine+configuration+related+issues+including+OS,+Hardware+drivers,+applications+and+software+licenses";
                            getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                            token = FindToken(getToken);
                            response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + CompTech + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + FE_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                            // Add component: Elementaries 
                            component = "Elementaries";
                            componentComment = "General+issues+involving+elementary+drawings";
                            getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                            token = FindToken(getToken);
                            response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + HWengineer + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + AppEngineer + "%2C+" + HW_Manager + "%2C+" + FE_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                        }
                        else if (checkBox_General.Checked == false)
                        {
                            if (checkedListBox_General.GetItemChecked(0))
                            {
                                this.progressBar1.Increment(10);
                                // Add component: Hardware  ------------ Every project gets Hardware 
                                component = "General+Hardware";
                                componentComment = "General+hardware+related+issues+including+elementary+drawings,+panels,+Circuits,+etc.";
                                getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                                if (getToken.Contains("<title>Product Access Denied</title>"))
                                {
                                    MessageBox.Show("Something Went wrong");
                                    return false;
                                }
                                token = FindToken(getToken);
                                response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + HWengineer + "&initialcc=" + SysEngineer + "%2C+" + AppEngineer + "%2C+" + HWengineer + "%2C+" + HW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                            }
                            if (checkedListBox_General.GetItemChecked(1))
                            {
                                this.progressBar1.Increment(10);
                                // Add component: Crane PLC 
                                component = "Crane+PLC";
                                componentComment = "Crane+PLC+Software";
                                getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                                token = FindToken(getToken);
                                response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SWengineer + "&initialcc=" + SysEngineer + "%2C+" + FE_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                            }
                            if (checkedListBox_General.GetItemChecked(2))
                            {
                                // Add component: General Software 
                                this.progressBar1.Increment(10);
                                component = "General+Software";
                                componentComment = "Anything+software+related+not+dealing+with+the+PLC+or+HMI+project";
                                getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                                token = FindToken(getToken);
                                response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + FE_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                            }
                            if (checkedListBox_General.GetItemChecked(3))
                            {
                                // Add component: Drive Hardware 
                                this.progressBar1.Increment(10);
                                component = "Drive+Hardware";
                                componentComment = "Issues+related+to+Drive+Hardware";
                                getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                                token = FindToken(getToken);
                                response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + HWengineer + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + SW_Manager + "%2C+" + AppEngineer + "%2C+" + projectManager + "&action=new&token=" + token);
                            }
                            if (checkedListBox_General.GetItemChecked(4))
                            {
                                // Add component: Drive Software 
                                this.progressBar1.Increment(10);
                                component = "Drive+Software";
                                componentComment = "Issues+related+to+Drive+Software+files";
                                getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                                token = FindToken(getToken);
                                response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + DrvEngineer + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + HW_Manager + "%2C+" + SW_Manager + "%2C+" + AppEngineer + "%2C+" + projectManager + "&action=new&token=" + token);
                            }
                            if (checkedListBox_General.GetItemChecked(5))
                            {
                                // Add component: LCMS HMI Project 
                                this.progressBar1.Increment(10);
                                component = "LCMS+HMI+Project";
                                componentComment = "General+HMI+project+related+issues+including+points,+alarms,+events,+scripts,+devices,+ports,+users,+roles,+resources,+database+logger,+documentation,+drawings+index,+and+HMI+config+files";
                                getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                                token = FindToken(getToken);
                                response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + HMI_Engineer + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + FE_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                            }
                            if (checkedListBox_General.GetItemChecked(6))
                            {
                                // Add component: LCMS HMI Screens 
                                this.progressBar1.Increment(10);
                                component = "LCMS+HMI+Screens";
                                componentComment = "General+HMI+screens+related+issues";
                                getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                                token = FindToken(getToken);
                                response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + HMI_Engineer + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + FE_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                            }
                            if (checkedListBox_General.GetItemChecked(7))
                            {
                                // Add component: LCMS Machine Configuration 
                                this.progressBar1.Increment(10);
                                component = "LCMS+Machine+Configuration";
                                componentComment = "General+machine+configuration+related+issues+including+OS,+Hardware+drivers,+applications+and+software+licenses";
                                getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                                token = FindToken(getToken);
                                response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + CompTech + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + FE_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                            }
                            if (checkedListBox_General.GetItemChecked(8))
                            {
                                // Add component: Elementaries 
                                this.progressBar1.Increment(10);
                                component = "Elementaries";
                                componentComment = "General+issues+involving+elementary+drawings";
                                getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                                token = FindToken(getToken);
                                response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + HWengineer + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + AppEngineer + "%2C+" + HW_Manager + "%2C+" + FE_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                            }
                        }
                    }

                    // ----------------------------------------------------------------
                    // Components created if the Project is an ASC/CRMG Job
                    if (typeASC.Checked == true)
                    {
                        this.progressBar1.Increment(10);
                        // Add component: CraneDirector 
                        component = "CraneDirector";
                        componentComment = "ASC+instruction+manager+and+TOS+interface";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + Crane_Dir_Owner + "%2C+" + projectManager + "%2C+" + SW_Manager + "&action=new&token=" + token);

                        this.progressBar1.Increment(10);
                        // Add component: Maxspeed Performance Report -- MRC: This needs to be removed
                        //component = "Maxspeed+Performance+Report?";
                        //componentComment = "UMI%2C+Retry%2C+and+system+performance+reporting+tool";
                        //getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token="+loginToken+ "&GoAheadAndLogIn=Log+in");
                        //token = FindToken(getToken);
                        //response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token="+loginToken+ "&component=" + component + "&description=" + componentComment + "&initialowner=" + MPR_Owner + "&initialcc=" + MPR_Owner + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                        // Add component: Maxview ASC 
                        component = "Maxview+ASC";
                        componentComment = "Maxview+software+for+ASC";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + MaxviewRT_Owner + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                        this.progressBar1.Increment(10);
                        // Add component: Maxview Clear Zone 
                        component = "Maxview+Clear+Zone";
                        componentComment = "Maxview+software+for+transfer+zone";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + MaxviewRT_Owner + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                        // Add component: Maxview Clear Path 
                        component = "Maxview+Clear+Path";
                        componentComment = "Maxview+software+for+anticollision";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + MaxviewRT_Owner + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                        // Add component: Maxview Chassis Guidance 
                        component = "Maxview+Chassis+Guidance";
                        componentComment = "Maxview+software+for+Chassis+Guidance";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + MaxviewRT_Owner + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                        // Add component: Maxview 4D
                        component = "Maxview+4D";
                        componentComment = "Maxview+4D+software";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + MaxviewRT_Owner + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                        // Add component: Maxview Smart Move 
                        component = "Maxview+Smart+Move";
                        componentComment = "Maxview+software+for+smart+move";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + MaxviewRT_Owner + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                        // Add component: MAXVIEW Machine Configuration 
                        component = "MAXVIEW+Machine+Configuration";
                        componentComment = "General+machine+configuration+related+issues+including+OS,+Hardware+drivers,+applications+and+software+licenses";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + CompTech + "&initialcc=" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                        // Add component: RCMS HMI Project
                        component = "RCMS+HMI+Project";
                        componentComment = "General+HMI+project+related+issues+including+points,+alarms,+events,+scripts,+devices,+ports,+users,+roles,+resources,+database+logger,+documentation,+drawings+index,+and+HMI+config+files";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                        // Add component: RCMS HMI Screens
                        component = "RCMS+HMI+Screens";
                        componentComment = "General+HMI+screens+related+issues";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + HMI_Engineer + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                        // Add component: RCMS Machine Configuration 
                        component = "RCMS+Machine+Configuration";
                        componentComment = "General+machine+configuration+related+issues+including+OS,+Hardware+drivers,+applications+and+software+licenses";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + CompTech + "&initialcc=" + SysEngineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                        this.progressBar1.Increment(10);
                        // Add component: VOIP Software  --- MRC: This needs to be removed
                        //component = "VOIP+Software";
                        //componentComment = "Voice+over+IP";
                        //getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token="+loginToken+ "&GoAheadAndLogIn=Log+in");
                        //token = FindToken(getToken);
                        //response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token="+loginToken+ "&component=" + component + "&description=" + componentComment + "&initialowner=" + VOIP_Owner + "&initialcc=" + VOIP_Owner + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                        // Add component: Yard HMI Project
                        component = "Yard+HMI+Project";
                        componentComment = "General+HMI+project+related+issues+including+points,+alarms,+events,+scripts,+devices,+ports,+users,+roles,+resources,+database+logger,+documentation,+drawings+index,+and+HMI+config+files";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + HMI_Engineer + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                        // Add component: Yard HMI/File Server Machine Configuration
                        component = "Yard+HMI+File+Server+Machine+Configuration";
                        componentComment = "General+machine+configuration+related+issues+including+OS,+Hardware+drivers,+applications+and+software+licenses";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                        this.progressBar1.Increment(10);
                        // Add component: Yard PLC  
                        component = "Yard+PLC";
                        componentComment = "Primary+yard+PLC+software";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SWengineer + "&initialcc=" + SysEngineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                        // Add component: Yard IO Project
                        component = "Yard+IO+Project";
                        componentComment = "Yard+IO+project+software";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SWengineer + "&initialcc=" + SysEngineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                        this.progressBar1.Increment(10);
                        // Add component: Safety PLC 
                        component = "Safety+PLC";
                        componentComment = "Safety+PLC+software";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SPLC_Owner + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                        // Add component: ROS HMI Screens
                        component = "ROS+HMI+Screens";
                        componentComment = "General+HMI+screens+related+issues";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + HMI_Engineer + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                        // Add component: ROS Machine Configuration 
                        component = "ROS+Machine+Configuration";
                        componentComment = "General+machine+configuration+related+issues+including+OS,+Hardware+drivers,+applications+and+software+licenses";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + CompTech + "&initialcc=" + SysEngineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                        // Add component: ROS IO Project
                        component = "ROS+IO+Project";
                        componentComment = "ROS+IO+project+software";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SWengineer + "&initialcc=" + SysEngineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                        // Add component: ROS PLC
                        component = "ROS+PLC";
                        componentComment = "ROS+PLC+Software";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SWengineer + "&initialcc=" + SysEngineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                    }

                    // Components created if the Project is a STS/QC job
                    if (typeQC.Checked == true)
                    {
                        //for (int i = 0; i < checkedListBox_QC.Items.Count; i++)
                        //{
                        //    checkedListBox_QC.SetItemChecked(i, true);
                        //}

                        checkedListBox_QC.Refresh();
                        this.progressBar1.Increment(15);

                        // Add component: Safety PLC 
                        component = "Safety+PLC";
                        componentComment = "Safety+PLC+software";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SPLC_Owner + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                        // Add component: Op.Cab/Gantry HMI 
                        component = "Op+Cab/+Gantry+HMI+Screens";
                        componentComment = "General+HMI+screen+related+issues";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + HMI_Engineer + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                        this.progressBar1.Increment(15);
                        // Add component: Op.Cab/Gantry Machine Configuration
                        component = "Op+Cab/+Gantry+Machine+Configuration";
                        componentComment = "General+machine+configuration+related+issues+including+OS,+Hardware+drivers,+applications+and+software+licenses";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + CompTech + "&initialcc=" + SysEngineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                        this.progressBar1.Increment(15);
                        // Add component: Maxview Smart Landing 
                        component = "Maxview+Smart+Landing";
                        componentComment = "STS+Crane+Maxview+Smart+Landing+issues";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + Maxview_QC_Owner + "%2C+" + SW_Manager + "%2C+" + MaxviewRT_Owner + "%2C+" + projectManager + "&action=new&token=" + token);

                        // Add component: Maxview Smart Move 
                        component = "Maxview+Smart+Move";
                        componentComment = "Maxview+software+for+smart+move";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + MaxviewRT_Owner + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                        this.progressBar1.Increment(15);
                        // Add component: RCMS HMI Project
                        component = "RCMS+HMI+Project";
                        componentComment = "General+HMI+project+related+issues+including+points,+alarms,+events,+scripts,+devices,+ports,+users,+roles,+resources,+database+logger,+documentation,+drawings+index,+and+HMI+config+files";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + HMI_Engineer + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                        this.progressBar1.Increment(15);
                        // Add component: RCMS HMI Screens
                        component = "RCMS+HMI+Screens";
                        componentComment = "General+HMI+screens+related+issues";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + HMI_Engineer + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                        this.progressBar1.Increment(15);
                        // Add component: RCMS Machine Configuration 
                        component = "RCMS+Machine+Configuration";
                        componentComment = "General+machine+configuration+related+issues+including+OS,+Hardware+drivers,+applications+and+software+licenses";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + CompTech + "&initialcc=" + SysEngineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                        this.progressBar1.Increment(10);

                    }

                    // Components created if the Project is created as "Requisition Only" first.
                    if (typeRequisit.Checked == true)
                    {
                        // Add component: Requisition Crane Director 
                        component = "Requisition+Crane+Director";
                        componentComment = " Use+this+prior+to+initial+Software+Release";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + projectManager + "&action=new&token=" + token);

                        this.progressBar1.Increment(10);
                        // Add component: Requisition Drive Software 
                        component = "Requisition+Drive+Software";
                        componentComment = " Use+this+prior+to+initial+Software+Release";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + DrvEngineer + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + projectManager + "&action=new&token=" + token);

                        this.progressBar1.Increment(10);
                        // Add component: Requisition HMI 
                        component = "Requisition+HMI";
                        componentComment = " Use+this+prior+to+initial+Software+Release";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + projectManager + "&action=new&token=" + token);

                        this.progressBar1.Increment(10);
                        // Add component: Requisition Machine Configuration 
                        component = "Requisition+Machine+Configuration";
                        componentComment = " Use+this+prior+to+initial+Software+Release";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + CompTech + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + projectManager + "&action=new&token=" + token);

                        this.progressBar1.Increment(10);
                        // Add component: Requisition PLC Software 
                        component = "Requisition+PLC+Software";
                        componentComment = " Use+this+prior+to+initial+Software+Release";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + projectManager + "&action=new&token=" + token);

                        this.progressBar1.Increment(10);
                        // Add component: Requisition General Software 
                        component = "Requisition+General+Software";
                        componentComment = " Use+this+prior+to+initial+Software+Release";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + projectManager + "&action=new&token=" + token);

                        this.progressBar1.Increment(10);
                        // Add component: Requisition Hardware 
                        component = "Requisition+Hardware";
                        componentComment = " Use+this+prior+to+initial+Software+Release";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + projectManager + "&action=new&token=" + token);

                        this.progressBar1.Increment(10);
                        // Add component: Requisition Maxview 
                        component = "Requisition+Maxview";
                        componentComment = " Use+this+prior+to+initial+Software+Release";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + projectManager + "&action=new&token=" + token);

                        this.progressBar1.Increment(10);
                        // Add component: Requisition Maxview 4D 
                        component = "Requisition+Maxview+4D";
                        componentComment = " Use+this+prior+to+initial+Software+Release";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + projectManager + "&action=new&token=" + token);

                    }
                    /////////////////////////////////////////////////////////////////////////////////////////////////
                    ////                               ASC Individual Components                                 ////
                    /////////////////////////////////////////////////////////////////////////////////////////////////
                    if (checkedListBox_ASC.GetItemChecked(0) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        this.progressBar1.Increment(10);
                        // Add component: CraneDirector 0
                        component = "CraneDirector";
                        componentComment = "ASC+instruction+manager+and+TOS+interface";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + Crane_Dir_Owner + "%2C+" + projectManager + "%2C+" + SW_Manager + "&action=new&token=" + token);

                    }
                    if (checkedListBox_ASC.GetItemChecked(1) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {

                        //"Maxview ASC" 1
                        this.progressBar1.Increment(10);
                        component = "Maxview+ASC";
                        componentComment = "Maxview+software+for+ASC";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + MaxviewRT_Owner + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    if (checkedListBox_ASC.GetItemChecked(2) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        this.progressBar1.Increment(10);
                        // Add component: Maxview Clear Zone 2
                        component = "Maxview+Clear+Zone";
                        componentComment = "Maxview+software+for+transfer+zone";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + MaxviewRT_Owner + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    if (checkedListBox_ASC.GetItemChecked(3) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        //"Maxview+Clear+Path 3
                        this.progressBar1.Increment(10);
                        component = "Maxview+Clear+Path";
                        componentComment = "Maxview+software+for+anticollision";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + MaxviewRT_Owner + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                    }
                    if (checkedListBox_ASC.GetItemChecked(4) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        //Maxview Chassis Guidance 4
                        this.progressBar1.Increment(10);
                        component = "Maxview+Chassis+Guidance";
                        componentComment = "Maxview+software+for+Chassis+Guidance";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + MaxviewRT_Owner + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    if (checkedListBox_ASC.GetItemChecked(5) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        //"Maxview 4D", 5
                        // Add component: Maxview 4D
                        this.progressBar1.Increment(10);
                        component = "Maxview+4D";
                        componentComment = "Maxview+4D+software";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + MaxviewRT_Owner + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    if (checkedListBox_ASC.GetItemChecked(6) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        // Add component: Maxview Smart Move 6
                        this.progressBar1.Increment(10);
                        component = "Maxview+Smart+Move";
                        componentComment = "Maxview+software+for+smart+move";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + MaxviewRT_Owner + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    if (checkedListBox_ASC.GetItemChecked(7) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        //Maxview Machine Configuration" 7
                        // Add component: MAXVIEW Machine Configuration 
                        this.progressBar1.Increment(10);
                        component = "MAXVIEW+Machine+Configuration";
                        componentComment = "General+machine+configuration+related+issues+including+OS,+Hardware+drivers,+applications+and+software+licenses";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + CompTech + "&initialcc=" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    {
                        //RCMS HMI Project 8
                        // Add component: RCMS HMI Project
                        this.progressBar1.Increment(10);
                        component = "RCMS+HMI+Project";
                        componentComment = "General+HMI+project+related+issues+including+points,+alarms,+events,+scripts,+devices,+ports,+users,+roles,+resources,+database+logger,+documentation,+drawings+index,+and+HMI+config+files";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    if (checkedListBox_ASC.GetItemChecked(9) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        //"RCMS HMI Screens 9
                        this.progressBar1.Increment(10);
                        // Add component: RCMS HMI Screens
                        component = "RCMS+HMI+Screens";
                        componentComment = "General+HMI+screens+related+issues";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + HMI_Engineer + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    if (checkedListBox_ASC.GetItemChecked(10) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        //RCMS Machine Configuration 10
                        // Add component: RCMS Machine Configuration 
                        this.progressBar1.Increment(10);
                        component = "RCMS+Machine+Configuration";
                        componentComment = "General+machine+configuration+related+issues+including+OS,+Hardware+drivers,+applications+and+software+licenses";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + CompTech + "&initialcc=" + SysEngineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    if (checkedListBox_ASC.GetItemChecked(11) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        //Yard HMI Project 11
                        // Add component: Yard HMI Project
                        this.progressBar1.Increment(10);
                        component = "Yard+HMI+Project";
                        componentComment = "General+HMI+project+related+issues+including+points,+alarms,+events,+scripts,+devices,+ports,+users,+roles,+resources,+database+logger,+documentation,+drawings+index,+and+HMI+config+files";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + HMI_Engineer + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    if (checkedListBox_ASC.GetItemChecked(12) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        //Yard HMI File Server Machine Configuration 12
                        // Add component: Yard HMI/File Server Machine Configuration
                        this.progressBar1.Increment(10);
                        component = "Yard+HMI+File+Server+Machine+Configuration";
                        componentComment = "General+machine+configuration+related+issues+including+OS,+Hardware+drivers,+applications+and+software+licenses";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                    }
                    if (checkedListBox_ASC.GetItemChecked(13) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        //Yard PLC 13
                        // Add component: Yard PLC  
                        this.progressBar1.Increment(10);
                        component = "Yard+PLC";
                        componentComment = "Primary+yard+PLC+software";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SWengineer + "&initialcc=" + SysEngineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    if (checkedListBox_ASC.GetItemChecked(14) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        //Yard IO Project 14
                        // Add component: Yard IO Project
                        this.progressBar1.Increment(10);
                        component = "Yard+IO+Project";
                        componentComment = "Yard+IO+project+software";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SWengineer + "&initialcc=" + SysEngineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    if (checkedListBox_ASC.GetItemChecked(15) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        //Safety PLC 15
                        // Add component: Safety PLC 
                        this.progressBar1.Increment(10);
                        component = "Safety+PLC";
                        componentComment = "Safety+PLC+software";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SPLC_Owner + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                    }
                    if (checkedListBox_ASC.GetItemChecked(16) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        //ROS HMI Screens 16
                        // Add component: RCMS HMI Screens
                        this.progressBar1.Increment(10);
                        component = "RCMS+HMI+Screens";
                        componentComment = "General+HMI+screens+related+issues";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + HMI_Engineer + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                    }
                    if (checkedListBox_ASC.GetItemChecked(17) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        //"ROS Machine Configuration" 17
                        // Add component: ROS Machine Configuration 
                        this.progressBar1.Increment(10);
                        component = "ROS+Machine+Configuration";
                        componentComment = "General+machine+configuration+related+issues+including+OS,+Hardware+drivers,+applications+and+software+licenses";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + CompTech + "&initialcc=" + SysEngineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);

                    }
                    if (checkedListBox_ASC.GetItemChecked(18) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        //"ROS IO Project" 18
                        // Add component: ROS IO Project
                        this.progressBar1.Increment(10);
                        component = "ROS+IO+Project";
                        componentComment = "ROS+IO+project+software";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SWengineer + "&initialcc=" + SysEngineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    if (checkedListBox_ASC.GetItemChecked(19) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        //"ROS PLC 19
                        this.progressBar1.Increment(10);
                        component = "ROS+PLC";
                        componentComment = "ROS+PLC+Software";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SWengineer + "&initialcc=" + SysEngineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    /////////////////////////////////////////////////////////////////////////////////////////////////
                    ////                                QC Individual Components                                 ////
                    /////////////////////////////////////////////////////////////////////////////////////////////////
                    if (checkedListBox_QC.GetItemChecked(0) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        this.progressBar1.Increment(10);
                        component = "Safety+PLC";
                        componentComment = "Safety+PLC+software";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SPLC_Owner + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    if (checkedListBox_QC.GetItemChecked(1) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        this.progressBar1.Increment(10);
                        component = "Op+Cab/+Gantry+HMI+Screens";
                        componentComment = "General+HMI+screen+related+issues";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + HMI_Engineer + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                    }

                    if (checkedListBox_QC.GetItemChecked(2) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        // Add component: Op.Cab/Gantry Machine Configuration
                        this.progressBar1.Increment(10);
                        component = "Op+Cab/+Gantry+Machine+Configuration";
                        componentComment = "General+machine+configuration+related+issues+including+OS,+Hardware+drivers,+applications+and+software+licenses";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + CompTech + "&initialcc=" + SysEngineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    if (checkedListBox_QC.GetItemChecked(3) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        this.progressBar1.Increment(10);
                        component = "Maxview+Smart+Landing";
                        componentComment = "STS+Crane+Maxview+Smart+Landing+issues";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + Maxview_QC_Owner + "%2C+" + SW_Manager + "%2C+" + MaxviewRT_Owner + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    if (checkedListBox_QC.GetItemChecked(4) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        this.progressBar1.Increment(10);
                        component = "Maxview+Smart+Move";
                        componentComment = "Maxview+software+for+smart+move";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + MaxviewRT_Owner + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    if (checkedListBox_QC.GetItemChecked(5) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        // Add component: RCMS HMI Project
                        this.progressBar1.Increment(10);
                        component = "RCMS+HMI+Project";
                        componentComment = "General+HMI+project+related+issues+including+points,+alarms,+events,+scripts,+devices,+ports,+users,+roles,+resources,+database+logger,+documentation,+drawings+index,+and+HMI+config+files";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + HMI_Engineer + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    if (checkedListBox_QC.GetItemChecked(6) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        // Add component: RCMS HMI Screens
                        this.progressBar1.Increment(10);
                        component = "RCMS+HMI+Screens";
                        componentComment = "General+HMI+screens+related+issues";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + HMI_Engineer + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    if (checkedListBox_QC.GetItemChecked(7) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        // Add component: RCMS Machine Configuration 
                        this.progressBar1.Increment(10);
                        component = "RCMS+Machine+Configuration";
                        componentComment = "General+machine+configuration+related+issues+including+OS,+Hardware+drivers,+applications+and+software+licenses";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + CompTech + "&initialcc=" + SysEngineer + "%2C+" + SW_Manager + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    /////////////////////////////////////////////////////////////////////////////////////////////////
                    ////                             Requistion Individual Components                            ////
                    /////////////////////////////////////////////////////////////////////////////////////////////////
                    ///
                    if (checkedListBox_Req.GetItemChecked(0) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        // Add component: Requisition Crane Director 
                        this.progressBar1.Increment(10);
                        component = "Requisition+Crane+Director";
                        componentComment = " Use+this+prior+to+initial+Software+Release";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    if (checkedListBox_Req.GetItemChecked(1) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        this.progressBar1.Increment(10);
                        // Add component: Requisition Drive Software 
                        component = "Requisition+Drive+Software";
                        componentComment = " Use+this+prior+to+initial+Software+Release";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + DrvEngineer + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    if (checkedListBox_Req.GetItemChecked(2) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        this.progressBar1.Increment(10);
                        // Add component: Requisition HMI 
                        component = "Requisition+HMI";
                        componentComment = " Use+this+prior+to+initial+Software+Release";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    if (checkedListBox_Req.GetItemChecked(3) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        this.progressBar1.Increment(10);
                        // Add component: Requisition Machine Configuration 
                        component = "Requisition+Machine+Configuration";
                        componentComment = " Use+this+prior+to+initial+Software+Release";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + CompTech + "&initialcc=" + SysEngineer + "%2C+" + SWengineer + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    if (checkedListBox_Req.GetItemChecked(4) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        this.progressBar1.Increment(10);
                        // Add component: Requisition PLC Software 
                        component = "Requisition+PLC+Software";
                        componentComment = " Use+this+prior+to+initial+Software+Release";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    if (checkedListBox_Req.GetItemChecked(5) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        this.progressBar1.Increment(10);
                        // Add component: Requisition General Software 
                        component = "Requisition+General+Software";
                        componentComment = " Use+this+prior+to+initial+Software+Release";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    if (checkedListBox_Req.GetItemChecked(6) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        this.progressBar1.Increment(10);
                        // Add component: Requisition Hardware 
                        component = "Requisition+Hardware";
                        componentComment = " Use+this+prior+to+initial+Software+Release";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    if (checkedListBox_Req.GetItemChecked(7) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        this.progressBar1.Increment(10);
                        // Add component: Requisition Maxview 
                        component = "Requisition+Maxview";
                        componentComment = " Use+this+prior+to+initial+Software+Release";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    if (checkedListBox_Req.GetItemChecked(8) && (typeASC.Checked == false) && (typeQC.Checked == false) && (typeRequisit.Checked == false))
                    {
                        this.progressBar1.Increment(10);
                        // Add component: Requisition Maxview 4D 
                        component = "Requisition+Maxview+4D";
                        componentComment = " Use+this+prior+to+initial+Software+Release";
                        getToken = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                        token = FindToken(getToken);
                        response = wb.UploadString(urlAddProduct + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&component=" + component + "&description=" + componentComment + "&initialowner=" + SysEngineer + "&initialcc=" + SWengineer + "%2C+" + projectManager + "&action=new&token=" + token);
                    }
                    getToken = wb.UploadString(urlEditGroupControl + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");
                    token = FindToken(getToken);
                    response = wb.UploadString(urlEditGroupControl + projectname, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&action=updategroupcontrols&product=" + projectname + "&token=" + token + "&membercontrol_21=0&othercontrol_21=0&membercontrol_17=0&othercontrol_17=0&membercontrol_15=0&othercontrol_15=0&entry_16=1&membercontrol_16=3&othercontrol_16=3&membercontrol_22=0&othercontrol_22=0&submit=submit");
                }
                this.progressBar1.Increment(10);
                return true;
            }
            catch (Exception e)
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
        private string Encoder(string projectDescription)
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
            projectDescription = projectDescription.Replace(" ", "+");// +   == (space)  // Must be at the end 
            return projectDescription;
        }
        [DllImport("wininet.dll", SetLastError = true)]
        public static extern bool InternetGetCookieEx(
            string url,
            string cookieName,
            StringBuilder cookieData,
            ref int size,
            Int32 dwFlags,
            IntPtr lpReserved);
        private const Int32 InternetCookieHttponly = 0x2000;
        /// <summary>
        /// Gets the URI cookie container.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns></returns>
        public static CookieContainer GetUriCookieContainer(Uri uri)
        {
            CookieContainer cookies = null;
            // Determine the size of the cookie
            int datasize = 8192 * 16;
            StringBuilder cookieData = new StringBuilder(datasize);
            if (!InternetGetCookieEx(uri.ToString(), null, cookieData, ref datasize, InternetCookieHttponly, IntPtr.Zero))
            {
                if (datasize < 0)
                    return null;
                // Allocate stringbuilder large enough to hold the cookie
                cookieData = new StringBuilder(datasize);
                if (!InternetGetCookieEx(
                    uri.ToString(),
                    null, cookieData,
                    ref datasize,
                    InternetCookieHttponly,
                    IntPtr.Zero))
                    return null;
            }
            if (cookieData.Length > 0)
            {
                cookies = new CookieContainer();
                cookies.SetCookies(uri, cookieData.ToString().Replace(';', ','));
            }
            return cookies;
        }
        private void checkBox_General_Checked(object sender, EventArgs e)
        {
            //Toggle all items if Select All is checked
            if ((checkBox_General.Checked) == true && (typeRequisit.Checked == false))
            {
                for (int i = 0; i < checkedListBox_General.Items.Count; i++)
                {
                    checkedListBox_General.SetItemChecked(i, true);
                }
            }
            else if (checkBox_General.Checked == false)
            {
                for (int i = 0; i < checkedListBox_General.Items.Count; i++)
                {
                    checkedListBox_General.SetItemChecked(i, false);
                }
            } // if an individual item has been checked, Check = false for typeASC
            checkedListBox_ASC.Refresh();
            checkedListBox_QC.Refresh();
            checkedListBox_General.Refresh();
        }
        private void typeASC_CheckedChanged(object sender, EventArgs e)
        {
            //Toggle all items if ASC is checked
            if (typeASC.Checked == true)
            {
                typeQC.Checked = false;
                for (int i = 0; i < checkedListBox_ASC.Items.Count; i++)
                {
                    checkedListBox_ASC.SetItemChecked(i, true);
                }
                for (int i = 0; i < checkedListBox_QC.Items.Count; i++)
                {
                    checkedListBox_QC.SetItemChecked(i, false);
                }
            }
            checkedListBox_ASC.Refresh();
            checkedListBox_QC.Refresh();
            checkedListBox_Req.Refresh(); // if an individual item has been checked, Check = false for typeASC
            checkedListBox_General.Refresh();
        }
        private void typeQC_CheckedChanged(object sender, EventArgs e)
        {
            if (typeQC.Checked == true)
            {
                typeASC.Checked = false;
                for (int i = 0; i < checkedListBox_QC.Items.Count; i++)
                {
                    checkedListBox_QC.SetItemChecked(i, true);
                }
                for (int i = 0; i < checkedListBox_ASC.Items.Count; i++)
                {
                    checkedListBox_ASC.SetItemChecked(i, false);
                }
            }
            checkedListBox_ASC.Refresh();
            checkedListBox_QC.Refresh();
            checkedListBox_Req.Refresh();
            checkedListBox_General.Refresh();
        }
        private void typeRequisit_CheckedChanged(object sender, EventArgs e)
        {
            if (typeRequisit.Checked == true)
            {
                for (int i = 0; i < checkedListBox_Req.Items.Count; i++)
                {
                    checkedListBox_Req.SetItemChecked(i, true);
                }
            }
            checkedListBox_ASC.Refresh();
            checkedListBox_QC.Refresh();
            checkedListBox_Req.Refresh();
            checkedListBox_General.Refresh();
        }
        private void checkedListBox_ASC_ItemClick(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < checkedListBox_ASC.Items.Count; i++)
            {
                if (e.NewValue == CheckState.Unchecked)
                {
                    typeASC.Checked = false;
                    typeASC.Refresh();
                    break;
                }
            }
        }
        private void checkedListBox_QC_ItemClick(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < checkedListBox_QC.Items.Count; i++)
            {
                if (e.NewValue == CheckState.Unchecked)
                {
                    typeQC.Checked = false;
                    typeQC.Refresh();
                    break;
                }
            }
        }
        private void checkedListBox_Req_ItemClick(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < checkedListBox_Req.Items.Count; i++)
            {
                if (e.NewValue == CheckState.Unchecked)
                {
                    typeRequisit.Checked = false;
                    typeRequisit.Refresh();
                    break;
                }
            }
        }
        private void checkedListBox_General_ItemClick(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < checkedListBox_General.Items.Count; i++)
            {
                if (e.NewValue == CheckState.Unchecked)
                {
                    checkBox_General.Checked = false;
                    checkBox_General.Refresh();
                    break;
                }
            }
        }
        bool check_Req_Item()
        {
            for (int i = 0; i < checkedListBox_Req.Items.Count; i++)
            {
                if (checkedListBox_Req.GetItemChecked(i) == true)
                {
                    return true;
                }
            }
            return false;
        }
        bool check_General_Item()
        {
            for (int i = 0; i < checkedListBox_General.Items.Count; i++)
            {
                if (checkedListBox_General.GetItemChecked(i) == true)
                {
                    return true;
                }
            }
            return false;
        }
        private void radioButton_Yes_CheckedChanged(object sender, EventArgs e)
        {
            checkedListBox_ASC.Enabled = false;
            checkedListBox_QC.Enabled = false;
            checkedListBox_General.Enabled = false;
            checkedListBox_Req.Enabled = true;
            typeASC.Enabled = false;
            typeQC.Enabled = false;
            typeRequisit.Enabled = true;
            checkBox_General.Enabled = false;
            for (int i = 0; i < checkedListBox_QC.Items.Count; i++)
            {
                checkedListBox_QC.SetItemChecked(i, false);
            }
            for (int i = 0; i < checkedListBox_ASC.Items.Count; i++)
            {
                checkedListBox_ASC.SetItemChecked(i, false);
            }
            for (int i = 0; i < checkedListBox_General.Items.Count; i++)
            {
                checkedListBox_General.SetItemChecked(i, false);
            }
        }
        private void radioButton_No_CheckedChanged(object sender, EventArgs e)
        {
            checkedListBox_ASC.Enabled = true;
            checkedListBox_QC.Enabled = true;
            checkedListBox_General.Enabled = true;
            checkedListBox_Req.Enabled = false;
            typeASC.Enabled = true;
            typeQC.Enabled = true;
            typeRequisit.Enabled = false;
            checkBox_General.Enabled = true;
            for (int i = 0; i < checkedListBox_Req.Items.Count; i++)
            {
                checkedListBox_Req.SetItemChecked(i, false);
            }
        }


    }

    public static class StringExtensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            if (source == null) return false;
            return source.IndexOf(toCheck, comp) >= 0;
        }
    }
}








//if (HMI_Engineer == "" || AppEngineer == "" || username == "" || password == "" || projectname == "" || projectManager == "" || DrvEngineer == "" || HWengineer == "" || SWengineer == "" || SysEngineer == "" || CompTech == "" || projectDescription == "" || (typeASC.Checked == typeRequisit.Checked && typeQC.Checked == typeASC.Checked))
/*
        * private void button1_Click(object sender, EventArgs e)
       {
           try
           {
               Process.Start("notepad.exe", "ProjectEmail.xml");
           }
           catch
           {
               MessageBox.Show("Unable to open the ProjectEmail.xml from here.  Please make sure it exists in the same directory as the tool.", "Error");
           }

       }*/

/*
private void button2_Click(object sender, EventArgs e)
{
    string cookies;
    string loginToken;
    string username = textBox1.Text;
    string password = textBox2.Text;
    string response;
    string url = "https://tools.tmeic.com/mh/editproducts.cgi?action=add&classification=MH%20Projects";
    username = username.Replace("@", "%40");

    if (password == "")
    {
        MessageBox.Show("You must enter your Bugzilla credentials to test the cookies.", "Error!");
        return;
    }


    try
    {
        //Load XML Document
        try
        {
            System.Xml.XmlDocument DocTest = new System.Xml.XmlDocument();
            DocTest.Load(@"ProjectEmail.xml");
        }
        catch
        {
            MessageBox.Show("Please make sure that the ProjectEmail.xml file is located in the same file as this tool when it is run.", "Error");
            return;
        }
        System.Xml.XmlDocument Doc = new System.Xml.XmlDocument();
        Doc.Load(@"ProjectEmail.xml");

        XmlNode curNode = Doc.SelectSingleNode("Configuration/Cookies");
        if (curNode == null)
        {
            MessageBox.Show("Problem with ProjectEmail.xml/Configuration/Cookies");
            return;
        }
        cookies = curNode.InnerText;

        curNode = Doc.SelectSingleNode("Configuration/LoginToken");
        if (curNode == null)
        {
            MessageBox.Show("Problem with ProjectEmail.xml/Configuration/LoginToken");
            return;
        }
        loginToken = curNode.InnerText;
    }
    catch (Exception ex)
    {
        MessageBox.Show("An exception was thrown while reading the ProjectEmail.xml. Please insure that it is in the same folder as the project creation utility. ", "Error!");
        return;
    }

    using (WebClient wb = new WebClient())
    {
        try
        {
            wb.Headers.Add(HttpRequestHeader.Cookie, cookies);

            CredentialCache credentialCache = new CredentialCache();
            credentialCache.Add(new System.Uri(url), "Basic", new NetworkCredential(username, password, "tools.tmeic.com"));


            wb.Credentials = credentialCache;
            wb.BaseAddress = url;

            response = wb.UploadString(url, "POST", "Bugzilla_login=" + username + "&Bugzilla_password=" + password + "&Bugzilla_login_token=" + loginToken + "&GoAheadAndLogIn=Log+in");

            if (response.Contains("<title>Match Failed</title>"))
                MessageBox.Show("Failed to match one or more of the input engineer emails. Please make sure each entry is correct. Check the ProjectEmail.xml as well.", "Error!");
            else if (response.Contains("<title>Confirm Match</title>"))
                MessageBox.Show("Failed to match entered engineer email. Please make sure each entry is correct. Check the ProjectEmail.xml as well.", "Error");
            else if (response.Contains("<title>Untrusted Authentication Request</title>"))
                MessageBox.Show("Bugzilla returned the Untrusted Authentication Request page. The Cookies or Login Tokens are invalid","Failed!");
            else if (response.Contains("<title>Invalid Username Or Password</title>"))
                MessageBox.Show("Invalid Username Or Password.");
            else if (response.Contains("<title>Add Product</title>"))
                MessageBox.Show("Successfully sent command. Cookies and Tokens are still valid.", "Success! ");                    
            else if (response.Contains("<title>Authorization Required</title>"))
                MessageBox.Show("Authorization Required. You are not an Admin!");
            else
                MessageBox.Show("Unexpected response. Unsure of success.");
        }
        catch
        {
            MessageBox.Show("Exception thrown. Operation failed");
        }
    }
}
 //Toggle all items if Select All is checked
            if ((checkBox_General.Checked) == true && (typeRequisit.Checked == false))
            {
                for (int i = 0; i < checkedListBox_General.Items.Count; i++)
                {
                    checkedListBox_General.SetItemChecked(i, true);
                }
                //checkedListBox_Req.Enabled = false;
                //checkedListBox_QC.Enabled = true;
                //checkedListBox_General.Enabled = true;
                //checkedListBox_ASC.Enabled = true;
              
            }
            else if ((checkBox_General.Checked) == true && (typeRequisit.Checked == true))
            {
                for (int i = 0; i < checkedListBox_General.Items.Count; i++)
                {
                    checkedListBox_General.SetItemChecked(i, true);
                }
                for (int i = 0; i < checkedListBox_Req.Items.Count; i++)
                {
                    checkedListBox_Req.SetItemChecked(i, false);
                }
                //checkedListBox_Req.Enabled = false;
                //checkedListBox_QC.Enabled = true;
                //checkedListBox_General.Enabled = true;
                //checkedListBox_ASC.Enabled = true;
            }
            ///Delete 
            else if (checkBox_General.Checked == false)
            {
                for (int i = 0; i < checkedListBox_General.Items.Count; i++)
                {
                    checkedListBox_General.SetItemChecked(i, false);
                }
            }

            checkedListBox_ASC.Refresh();
            checkedListBox_QC.Refresh();
            checkedListBox_Req.Refresh(); // if an individual item has been checked, Check = false for typeASC
            checkedListBox_General.Refresh();




for (int i = 0; i < checkedListBox_QC.Items.Count; i++)
                {
                    checkedListBox_QC.SetItemChecked(i, false);
                }
                for (int i = 0; i < checkedListBox_ASC.Items.Count; i++)
                {
                    checkedListBox_ASC.SetItemChecked(i, false);
                }
                for (int i = 0; i < checkedListBox_General.Items.Count; i++)
                {
                    checkedListBox_General.SetItemChecked(i, false);
                }
*/



//private void comboBox_SysEng_TextChanged(object sender, KeyPressEventArgs e)
//{
//    if (char.IsLetterOrDigit(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar))
//    {// Handle printable characters (letters, numbers, symbols, punctuation).
//        List<object> autoComplete_suggestions = new List<object>();
//        foreach (object item in comboBox_ItemsCopy)
//        {// Filter items that start with the user's input (case-insensitive).               
//            if (item.ToString().Contains(comboBox_SysEng.Text, StringComparison.OrdinalIgnoreCase))
//            {
//                autoComplete_suggestions.Add(item);
//            }
//        }
//        comboBox_SysEng.Items.Clear();
//        comboBox_SysEng.Items.AddRange(autoComplete_suggestions.ToArray());
//        comboBox_SysEng.SelectionStart = comboBox_SysEng.Text.Length; // Keep the user's input selected.
//        comboBox_SysEng.DroppedDown = true; // Show the dropdown with autoComplete_suggestions.
//    }
//    else if (string.IsNullOrEmpty(comboBox_SysEng.Text))
//    {//Hide the dropdown when there's no input.
//        comboBox_SysEng.Items.Clear();
//        comboBox_SysEng.Items.AddRange(comboBox_ItemsCopy.ToArray());
//    }
//}
//private void comboBox_HrdwEng_TextChanged(object sender, KeyPressEventArgs e)
//{
//    if (char.IsLetterOrDigit(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar))
//    {// Handle printable characters (letters, numbers, symbols, punctuation).
//        List<object> autoComplete_suggestions = new List<object>();
//        foreach (object item in comboBox_ItemsCopy)
//        {// Filter items that start with the user's input (case-insensitive).               
//            if (item.ToString().Contains(comboBox_HrdwEng.Text, StringComparison.OrdinalIgnoreCase))
//            {
//                autoComplete_suggestions.Add(item);
//            }
//        }
//        comboBox_HrdwEng.Items.Clear();
//        comboBox_HrdwEng.Items.AddRange(autoComplete_suggestions.ToArray());
//        comboBox_HrdwEng.SelectionStart = comboBox_HrdwEng.Text.Length; // Keep the user's input selected.
//        comboBox_HrdwEng.DroppedDown = true; // Show the dropdown with autoComplete_suggestions.
//    }
//    else if (string.IsNullOrEmpty(comboBox_HrdwEng.Text))
//    {//Hide the dropdown when there's no input.
//        comboBox_HrdwEng.Items.Clear();
//        comboBox_HrdwEng.Items.AddRange(comboBox_ItemsCopy.ToArray());
//    }
//}

//private void comboBox_ControlEng_TextChanged(object sender, KeyPressEventArgs e)
//{
//    if (char.IsLetterOrDigit(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar))
//    {// Handle printable characters (letters, numbers, symbols, punctuation).
//        List<object> autoComplete_suggestions = new List<object>();
//        foreach (object item in comboBox_ItemsCopy)
//        {// Filter items that start with the user's input (case-insensitive).               
//            if (item.ToString().Contains(comboBox_ControlEng.Text, StringComparison.OrdinalIgnoreCase))
//            {
//                autoComplete_suggestions.Add(item);
//            }
//        }
//        comboBox_ControlEng.Items.Clear();
//        comboBox_ControlEng.Items.AddRange(autoComplete_suggestions.ToArray());
//        comboBox_ControlEng.SelectionStart = comboBox_ControlEng.Text.Length; // Keep the user's input selected.
//        comboBox_ControlEng.DroppedDown = true; // Show the dropdown with autoComplete_suggestions.
//    }
//    else if (string.IsNullOrEmpty(comboBox_ControlEng.Text))
//    {//Hide the dropdown when there's no input.
//        comboBox_ControlEng.Items.Clear();
//        comboBox_ControlEng.Items.AddRange(comboBox_ItemsCopy.ToArray());
//    }
//}
//private void comboBox_HMIEng_TextChanged(object sender, KeyPressEventArgs e)
//{
//    if (char.IsLetterOrDigit(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar))
//    {// Handle printable characters (letters, numbers, symbols, punctuation).
//        List<object> autoComplete_suggestions = new List<object>();
//        foreach (object item in comboBox_ItemsCopy)
//        {// Filter items that start with the user's input (case-insensitive).               
//            if (item.ToString().Contains(comboBox_HMIEng.Text, StringComparison.OrdinalIgnoreCase))
//            {
//                autoComplete_suggestions.Add(item);
//            }
//        }
//        comboBox_HMIEng.Items.Clear();
//        comboBox_HMIEng.Items.AddRange(autoComplete_suggestions.ToArray());
//        comboBox_HMIEng.SelectionStart = comboBox_HMIEng.Text.Length; // Keep the user's input selected.
//        comboBox_HMIEng.DroppedDown = true; // Show the dropdown with autoComplete_suggestions.
//    }
//    else if (string.IsNullOrEmpty(comboBox_HMIEng.Text))
//    {//Hide the dropdown when there's no input.
//        comboBox_HMIEng.Items.Clear();
//        comboBox_HMIEng.Items.AddRange(comboBox_ItemsCopy.ToArray());
//    }
//}