using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Globalization;

namespace BTnH
{
    public partial class Form1 : Form
    {
        private TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Node cUsuario;
            JObject json = null;
            bool boIsJsonOk = true;
            if (autoRadioButton.Checked)
            {
                showIDControl1.vLockAllFields();

                using (WebClient wc = new WebClient())
                {
                    try
                    {
                        boIsJsonOk = true;
                        var result = wc.DownloadString("http://api.randomuser.me/?exc=login,gender,registered,dob&nat=us,gb");
                        json = JObject.Parse(result);
                    }
                    catch(WebException)
                    {
                        boIsJsonOk = false;
                    }
                    catch
                    {
                        boIsJsonOk = false;
                    }
                }

                if (boIsJsonOk && json != null)
                {
                    string title = (string)json["results"][0]["name"]["title"];
                    string first = (string)json["results"][0]["name"]["first"];
                    string last = (string)json["results"][0]["name"]["last"];
                    string street = (string)json["results"][0]["location"]["street"];
                    string city = (string)json["results"][0]["location"]["city"];
                    string state = (string)json["results"][0]["location"]["state"];
                    string postcode = (string)json["results"][0]["location"]["postcode"];
                    string picture = (string)json["results"][0]["picture"]["large"];
                    string email = (string)json["results"][0]["email"];
                    string phone = (string)json["results"][0]["phone"];
                    string cell = (string)json["results"][0]["cell"];

                    cUsuario = new Node(first, last, street + ", " + city + ", " + state + ", " + postcode, phone, cell);
                    cUsuario.vSetPicture(picture);
                    cUsuario.vSetEmail(email);

                    cHT.vAdd(cUsuario);

                    showIDControl1.idText.Text = cUsuario.uGetID().ToString();
                    showIDControl1.nameText.Text = textInfo.ToTitleCase(cUsuario.sGetFullName());
                    showIDControl1.addText.Text = textInfo.ToTitleCase(cUsuario.sGetAddress());
                    showIDControl1.phoneText.Text = cUsuario.sGetPhone();
                    showIDControl1.mobileText.Text = cUsuario.sGetMobile();
                    showIDControl1.pictureBox.Load(cUsuario.sGetPicture());
                }
                else
                {
                    MessageBox.Show("Fail creating an Automatic Input.", "Error!");
                }
            }

            if(manualRadioButton.Checked)
            {
                showIDControl1.vClearAllFields();
                showIDControl1.vUnlockAllFields();
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ListRecords ListRecordsWindow = new ListRecords();
            ListRecordsWindow.Show();
        }

        private void showIDControl1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            searchTextBox.Text = "";
            searchTextBox.ForeColor = Color.Black;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (searchTextBox.Text == "")
            {
                searchTextBox.Text = "Name to search";
                searchTextBox.ForeColor = Color.LightGray;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(showIDControl1.nameText.ReadOnly == false)
            {
                if(showIDControl1.boIsAllFilled())
                {
                    string sFirstName;
                    string sLastName;
                    TextBox nameTextBox = showIDControl1.nameText;
                    int index = nameTextBox.Text.IndexOf(' ');
                    if (index > 0)
                    {
                        sLastName = nameTextBox.Text.Substring(index + 1, nameTextBox.Text.Length - (index + 1));
                        sFirstName = nameTextBox.Text.Substring(0, index);
                        cHT.vAdd(new Node(textInfo.ToLower(sFirstName), textInfo.ToLower(sLastName), textInfo.ToLower(showIDControl1.addText.Text), showIDControl1.phoneText.Text, showIDControl1.mobileText.Text));
                        showIDControl1.vLockAllFields();
                        MessageBox.Show("Record Saved!.", "Success!");
                    }
                    else
                    {
                        MessageBox.Show("Name must be in the format: FirstName LastName.", "Error!");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill all fields.", "Error!");
                }
            }
            else
            {
                MessageBox.Show("First create new Manual Input.", "Error!");
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Node cTNode;
            string sID = searchTextBox.Text;
            string sFirstName;
            string sLastName;

            if (sID != "" && sID != "Name to search")
            {
                int index = sID.IndexOf(' ');
                if (index > 0)
                {
                    sLastName = sID.Substring(index + 1, sID.Length - (index + 1));
                    sFirstName = sID.Substring(0, index);
                    cTNode = cHT.cSearchUser(textInfo.ToLower(sFirstName), textInfo.ToLower(sLastName));
                    if (cTNode != null)
                    {
                        showIDControl1.vLockAllFields();
                        showIDControl1.idText.Text = cTNode.uGetID().ToString();
                        showIDControl1.addText.Text = textInfo.ToTitleCase(cTNode.sGetAddress());
                        showIDControl1.nameText.Text = textInfo.ToTitleCase(cTNode.sGetFullName());
                        showIDControl1.mobileText.Text = cTNode.sGetMobile();
                        showIDControl1.phoneText.Text = cTNode.sGetPhone();
                        if(cTNode.sGetPicture() != "")
                        {
                            showIDControl1.pictureBox.Load(cTNode.sGetPicture());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Record Not Found!.", "Error!");
                    }
                }
                else
                {
                    MessageBox.Show("Name must be in the format: FirstName LastName.", "Error!");
                }
            }
            else
            {
                MessageBox.Show("Name must be in the format: FirstName LastName.", "Error!");
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (showIDControl1.idText.Text != "")
            {
                showIDControl1.vUnlockEditableFields();
            }
            else
            {
                MessageBox.Show("No entry has been selected.", "Error!");
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            uint u32ID;

            if(showIDControl1.idText.Text != "")
            {
                if (showIDControl1.boIsAllFilled())
                {
                    if (UInt32.TryParse(showIDControl1.idText.Text, out u32ID))
                    {
                        cHT.vDelete(u32ID);
                        showIDControl1.vClearAllFields();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Entry.", "Error!");
                }
            }
            else
            {
                MessageBox.Show("Invalid Entry.", "Error!");
            }
        }
    }

    public static class cHT
    {
        public static HashTable HT = new HashTable();

        public static void vAdd(Node cNode)
        {
            HT.Add(cNode);
        }

        public static Node cSearchUser(string sName, string sLastName)
        {
            return HT.cSearchUser(sName, sLastName);
        }

        public static void vDelete(uint u32ID)
        {
            HT.Delete(u32ID);
        }
    }
}
