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
            User cUsuario = new User();
            JObject json;
            Random rand = new Random();
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            using (WebClient wc = new WebClient())
            {
                var result = wc.DownloadString("http://api.randomuser.me/?exc=login,gender,registered,dob,phone,cell&nat=us,gb");
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
                cUsuario.name.title = title;
                cUsuario.name.first = first;
                cUsuario.name.last = last;
                cUsuario.location.street = street;
                cUsuario.location.city = city;
                cUsuario.location.state = state;
                cUsuario.location.postcode = postcode;
                cUsuario.picture = picture;
                cUsuario.email = email;
                cUsuario.id = rand.Next(100000,500000);
            }

            showIDControl1.idLabel.Text = cUsuario.id.ToString();
            showIDControl1.nameLabel.Text = textInfo.ToTitleCase(cUsuario.getName());
            showIDControl1.addLabel.Text = textInfo.ToTitleCase(cUsuario.getAddress());
            showIDControl1.emailLabel.Text = cUsuario.email;
            showIDControl1.pictureBox.Load(cUsuario.picture);
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
    }
}
