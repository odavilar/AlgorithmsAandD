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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Node cUsuario;
            JObject json;
            Random rand = new Random();
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            using (WebClient wc = new WebClient())
            {
                var result = wc.DownloadString("http://api.randomuser.me/?exc=login,gender,registered,dob&nat=us,gb");
                json = JObject.Parse(result);

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

                cHT.Add(cUsuario);
            }

            showIDControl1.idLabel.Text = cUsuario.uGetID().ToString();
            showIDControl1.nameLabel.Text = textInfo.ToTitleCase(cUsuario.sGetFullName());
            showIDControl1.addLabel.Text = textInfo.ToTitleCase(cUsuario.sGetAddress());
            showIDControl1.phoneLabel.Text = cUsuario.sGetEmail();
            showIDControl1.pictureBox.Load(cUsuario.sGetPicture());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Search searchWindow = new Search();
            searchWindow.Show();
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
    }

    public static class cHT
    {
        public static HashTable HT = new HashTable();

        public static void Add(Node cNode)
        {
            HT.Add(cNode);
        }

        public static Node cSearchUser(string sName, string sLastName)
        {
            return HT.cSearchUser(sName, sLastName);
        }
    }
}
