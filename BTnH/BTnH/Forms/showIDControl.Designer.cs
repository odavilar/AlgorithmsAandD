namespace BTnH
{
    partial class showIDControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.idText = new System.Windows.Forms.TextBox();
            this.nameText = new System.Windows.Forms.TextBox();
            this.addText = new System.Windows.Forms.TextBox();
            this.phoneText = new System.Windows.Forms.TextBox();
            this.mobileText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(30, 40);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(120, 117);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "ID: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Phone:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(170, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Mobile:";
            // 
            // idText
            // 
            this.idText.Location = new System.Drawing.Point(260, 30);
            this.idText.Name = "idText";
            this.idText.ReadOnly = true;
            this.idText.Size = new System.Drawing.Size(159, 22);
            this.idText.TabIndex = 10;
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(260, 58);
            this.nameText.Name = "nameText";
            this.nameText.ReadOnly = true;
            this.nameText.Size = new System.Drawing.Size(321, 22);
            this.nameText.TabIndex = 11;
            // 
            // addText
            // 
            this.addText.Location = new System.Drawing.Point(260, 86);
            this.addText.Name = "addText";
            this.addText.ReadOnly = true;
            this.addText.Size = new System.Drawing.Size(321, 22);
            this.addText.TabIndex = 12;
            // 
            // phoneText
            // 
            this.phoneText.Location = new System.Drawing.Point(260, 114);
            this.phoneText.Name = "phoneText";
            this.phoneText.ReadOnly = true;
            this.phoneText.Size = new System.Drawing.Size(321, 22);
            this.phoneText.TabIndex = 13;
            // 
            // mobileText
            // 
            this.mobileText.Location = new System.Drawing.Point(260, 142);
            this.mobileText.Name = "mobileText";
            this.mobileText.ReadOnly = true;
            this.mobileText.Size = new System.Drawing.Size(321, 22);
            this.mobileText.TabIndex = 14;
            // 
            // showIDControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.mobileText);
            this.Controls.Add(this.phoneText);
            this.Controls.Add(this.addText);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.idText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox);
            this.Name = "showIDControl";
            this.Size = new System.Drawing.Size(670, 189);
            this.Load += new System.EventHandler(this.showIDControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox idText;
        public System.Windows.Forms.TextBox nameText;
        public System.Windows.Forms.TextBox addText;
        public System.Windows.Forms.TextBox phoneText;
        public System.Windows.Forms.TextBox mobileText;
    }
}
