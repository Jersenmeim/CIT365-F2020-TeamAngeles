namespace MegaDesk_Meim
{
    partial class AddQuote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddQuote));
            this.back = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.NameField = new System.Windows.Forms.TextBox();
            this.WidthField = new System.Windows.Forms.TextBox();
            this.DepthField = new System.Windows.Forms.TextBox();
            this.MaterialField = new System.Windows.Forms.ComboBox();
            this.RushOrderOption = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Drawer = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // back
            // 
            this.back.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.back.Location = new System.Drawing.Point(85, 323);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(67, 26);
            this.back.TabIndex = 8;
            this.back.Text = "Cancel";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(12, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 15);
            this.label1.TabIndex = 2;
            this.label1.Tag = "";
            this.label1.Text = "&Rush Order Option:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(12, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 2;
            this.label2.Tag = "";
            this.label2.Text = "&Material:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(12, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 15);
            this.label3.TabIndex = 2;
            this.label3.Tag = "";
            this.label3.Text = "&Number of Drawers:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 15);
            this.label4.TabIndex = 2;
            this.label4.Tag = "";
            this.label4.Text = "Desk &Depth (inch):";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.label1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(12, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 15);
            this.label5.TabIndex = 2;
            this.label5.Tag = "";
            this.label5.Text = "Desk &Width (inch):";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.label1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(12, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 15);
            this.label6.TabIndex = 2;
            this.label6.Tag = "";
            this.label6.Text = "&Customer Name:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.Click += new System.EventHandler(this.label1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(12, 323);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 26);
            this.button2.TabIndex = 7;
            this.button2.Text = "Confirm";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // NameField
            // 
            this.NameField.Location = new System.Drawing.Point(147, 33);
            this.NameField.Name = "NameField";
            this.NameField.Size = new System.Drawing.Size(120, 23);
            this.NameField.TabIndex = 1;
            this.NameField.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.NameField.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // WidthField
            // 
            this.WidthField.Location = new System.Drawing.Point(147, 62);
            this.WidthField.Name = "WidthField";
            this.WidthField.Size = new System.Drawing.Size(120, 23);
            this.WidthField.TabIndex = 2;
            this.WidthField.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.WidthField.Validating += new System.ComponentModel.CancelEventHandler(this.textBox2_Validating);
            // 
            // DepthField
            // 
            this.DepthField.Location = new System.Drawing.Point(147, 91);
            this.DepthField.Name = "DepthField";
            this.DepthField.Size = new System.Drawing.Size(120, 23);
            this.DepthField.TabIndex = 3;
            this.DepthField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            this.DepthField.Validating += new System.ComponentModel.CancelEventHandler(this.textBox3_Validating);
            // 
            // MaterialField
            // 
            this.MaterialField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MaterialField.FormattingEnabled = true;
            this.MaterialField.Items.AddRange(new object[] {
            "Laminate",
            "Oak",
            "Rosewood",
            "Veneer",
            "Pine"});
            this.MaterialField.Location = new System.Drawing.Point(147, 149);
            this.MaterialField.Name = "MaterialField";
            this.MaterialField.Size = new System.Drawing.Size(120, 23);
            this.MaterialField.TabIndex = 5;
            // 
            // RushOrderOption
            // 
            this.RushOrderOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RushOrderOption.FormattingEnabled = true;
            this.RushOrderOption.Items.AddRange(new object[] {
            "Normal",
            "3 Days",
            "5 Days",
            "7 Days"});
            this.RushOrderOption.Location = new System.Drawing.Point(147, 178);
            this.RushOrderOption.Name = "RushOrderOption";
            this.RushOrderOption.Size = new System.Drawing.Size(120, 23);
            this.RushOrderOption.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label7.Location = new System.Drawing.Point(12, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(251, 15);
            this.label7.TabIndex = 5;
            this.label7.Tag = "";
            this.label7.Text = "Note: The Normal Production Time is 14 days. ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // Drawer
            // 
            this.Drawer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Drawer.FormattingEnabled = true;
            this.Drawer.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.Drawer.Location = new System.Drawing.Point(147, 120);
            this.Drawer.Name = "Drawer";
            this.Drawer.Size = new System.Drawing.Size(120, 23);
            this.Drawer.TabIndex = 4;
            this.Drawer.SelectedIndexChanged += new System.EventHandler(this.Drawer_SelectedIndexChanged);
            // 
            // AddQuote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.back;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.RushOrderOption);
            this.Controls.Add(this.MaterialField);
            this.Controls.Add(this.Drawer);
            this.Controls.Add(this.DepthField);
            this.Controls.Add(this.WidthField);
            this.Controls.Add(this.NameField);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.back);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddQuote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Quote";
            this.Load += new System.EventHandler(this.AddQuote_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox WidthField;
        private System.Windows.Forms.TextBox DepthField;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox MaterialField;
        public System.Windows.Forms.ComboBox Drawer;
        public System.Windows.Forms.ComboBox RushOrderOption;
        public System.Windows.Forms.TextBox NameField;
    }
}