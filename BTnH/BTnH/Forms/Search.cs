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
using System.Globalization;

namespace BTnH
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void Search_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Node cTNode;
            string sLastName;
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            int index = txtSearchField.Text.IndexOf(' ');
            if (index > 0)
            {
                sLastName = txtSearchField.Text.Substring(index + 1, txtSearchField.Text.Length - (index + 1));
                txtSearchField.Text = txtSearchField.Text.Substring(0, index);
                cTNode = cHT.cSearchUser(textInfo.ToLower(txtSearchField.Text), textInfo.ToLower(sLastName));

                showIDControl1.idLabel.Text = cTNode.uGetID().ToString();
                showIDControl1.nameLabel.Text = textInfo.ToTitleCase(cTNode.sGetFullName());
                showIDControl1.addLabel.Text = textInfo.ToTitleCase(cTNode.sGetAddress());
                showIDControl1.phoneLabel.Text = cTNode.sGetEmail();
                showIDControl1.pictureBox.Load(cTNode.sGetPicture());
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
