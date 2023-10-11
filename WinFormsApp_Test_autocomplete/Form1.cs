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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinFormsApp_Test_autocomplete
{
    public partial class Form1 : Form
    {
        List<object> comboBox_CompTech_ItemsCopy = new List<object>();
        public Form1()
        {
            InitializeComponent();
        }
        private void comboBox_CompTech_TextChanged(object sender, KeyPressEventArgs e)
        {
           if (char.IsLetterOrDigit(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {// Handle printable characters (letters, numbers, symbols, punctuation).
                List<object> autoComplete_suggestions = new List<object>();
                foreach (object item in comboBox_CompTech_ItemsCopy)
                {// Filter items that start with the user's input (case-insensitive).
                    if (item.ToString().Contains(comboBox_CompTech.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        autoComplete_suggestions.Add(item);
                    }
                }
                comboBox_CompTech.Items.Clear();
                comboBox_CompTech.Items.AddRange(autoComplete_suggestions.ToArray());
                comboBox_CompTech.SelectionStart = comboBox_CompTech.Text.Length; // Keep the user's input selected.
                comboBox_CompTech.DroppedDown = true; // Show the dropdown with autoComplete_suggestions.
            }                                                    
            else if (string.IsNullOrEmpty(comboBox_CompTech.Text))
            {//Hide the dropdown when there's no input.
                comboBox_CompTech.Items.Clear();
                comboBox_CompTech.Items.AddRange(comboBox_CompTech_ItemsCopy.ToArray());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (get_users_email())
            {
                MessageBox.Show("Email List has been update successfully! Proceed?", "Succes!");
            }
        }
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
                                {  // Iterate through all child nodes of the <th> element
                                    foreach (HtmlNode childNode in thNode)
                                    { // Extract the content of child nodes (text or HTML)
                                        string elementContent = childNode.InnerHtml; // or .InnerText for plain text                                       
                                        if (elementContent.Contains("&#64;"))
                                        {
                                            elementContent = elementContent.Replace("&#64;", "@");
                                            string Comp = elementContent;
                                            comboBox_CompTech_ItemsCopy.Add(elementContent);
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
    }
}