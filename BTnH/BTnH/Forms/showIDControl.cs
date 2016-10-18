using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTnH
{
    public partial class showIDControl : UserControl
    {
        public showIDControl()
        {
            InitializeComponent();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void showIDControl_Load(object sender, EventArgs e)
        {

        }

        public bool boIsAllFilled()
        {
            if (this.addText.Text != "" && this.mobileText.Text != "" && this.nameText.Text != "" && this.phoneText.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void vClearAllFields()
        {
            this.nameText.Text = "";
            this.addText.Text = "";
            this.phoneText.Text = "";
            this.mobileText.Text = "";
            this.idText.Text = "";
            this.pictureBox.Image = null;
        }

        public void vUnlockAllFields()
        {
            this.nameText.ReadOnly = false;
            this.addText.ReadOnly = false;
            this.phoneText.ReadOnly = false;
            this.mobileText.ReadOnly = false;
        }

        public void vLockAllFields()
        {
            this.nameText.ReadOnly = true;
            this.addText.ReadOnly = true;
            this.phoneText.ReadOnly = true;
            this.mobileText.ReadOnly = true;
        }
    }
}