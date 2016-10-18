namespace BTnH
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.manualRadioButton = new System.Windows.Forms.RadioButton();
            this.autoRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.editButton = new System.Windows.Forms.Button();
            this.showIDControl1 = new BTnH.showIDControl();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "New";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(659, 27);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(102, 28);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(424, 292);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(102, 28);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.searchTextBox.ForeColor = System.Drawing.Color.LightGray;
            this.searchTextBox.Location = new System.Drawing.Point(379, 27);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(264, 28);
            this.searchTextBox.TabIndex = 4;
            this.searchTextBox.Text = "Name to search";
            this.searchTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseClick);
            this.searchTextBox.Enter += new System.EventHandler(this.textBox1_Enter);
            this.searchTextBox.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(180, 291);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(102, 30);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // manualRadioButton
            // 
            this.manualRadioButton.AutoSize = true;
            this.manualRadioButton.Location = new System.Drawing.Point(136, 48);
            this.manualRadioButton.Name = "manualRadioButton";
            this.manualRadioButton.Size = new System.Drawing.Size(110, 21);
            this.manualRadioButton.TabIndex = 6;
            this.manualRadioButton.Text = "Manual Input";
            this.manualRadioButton.UseVisualStyleBackColor = true;
            // 
            // autoRadioButton
            // 
            this.autoRadioButton.AutoSize = true;
            this.autoRadioButton.Checked = true;
            this.autoRadioButton.Location = new System.Drawing.Point(136, 21);
            this.autoRadioButton.Name = "autoRadioButton";
            this.autoRadioButton.Size = new System.Drawing.Size(126, 21);
            this.autoRadioButton.TabIndex = 7;
            this.autoRadioButton.TabStop = true;
            this.autoRadioButton.Text = "Automatic Input";
            this.autoRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.manualRadioButton);
            this.groupBox1.Controls.Add(this.autoRadioButton);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 84);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(303, 291);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(102, 30);
            this.editButton.TabIndex = 9;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // showIDControl1
            // 
            this.showIDControl1.AutoSize = true;
            this.showIDControl1.Location = new System.Drawing.Point(12, 100);
            this.showIDControl1.Name = "showIDControl1";
            this.showIDControl1.Size = new System.Drawing.Size(677, 185);
            this.showIDControl1.TabIndex = 3;
            this.showIDControl1.Load += new System.EventHandler(this.showIDControl1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 339);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.showIDControl1);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.searchButton);
            this.Name = "Form1";
            this.Text = "Directorio";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button deleteButton;
        private showIDControl showIDControl1;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.RadioButton manualRadioButton;
        private System.Windows.Forms.RadioButton autoRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button editButton;
    }
}

