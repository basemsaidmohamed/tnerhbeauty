namespace tnerhbeauty
{
    partial class frm_Connection
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
            this.rd_server = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rd_local = new System.Windows.Forms.RadioButton();
            this.tx_ip_adress = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_new = new System.Windows.Forms.Button();
            this.btn_test = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tx_pass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pan_server = new System.Windows.Forms.Panel();
            this.pan_password = new System.Windows.Forms.Panel();
            this.lp_mas_error = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pan_server.SuspendLayout();
            this.pan_password.SuspendLayout();
            this.SuspendLayout();
            // 
            // rd_server
            // 
            this.rd_server.AutoSize = true;
            this.rd_server.Checked = true;
            this.rd_server.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rd_server.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_server.Location = new System.Drawing.Point(17, 18);
            this.rd_server.Name = "rd_server";
            this.rd_server.Size = new System.Drawing.Size(109, 22);
            this.rd_server.TabIndex = 0;
            this.rd_server.TabStop = true;
            this.rd_server.Text = "IP SERVER ";
            this.rd_server.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.rd_local);
            this.panel1.Controls.Add(this.rd_server);
            this.panel1.Location = new System.Drawing.Point(190, 134);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(363, 56);
            this.panel1.TabIndex = 1;
            // 
            // rd_local
            // 
            this.rd_local.AutoSize = true;
            this.rd_local.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rd_local.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_local.Location = new System.Drawing.Point(258, 18);
            this.rd_local.Name = "rd_local";
            this.rd_local.Size = new System.Drawing.Size(87, 22);
            this.rd_local.TabIndex = 1;
            this.rd_local.Text = "سيرفر محلي";
            this.rd_local.UseVisualStyleBackColor = true;
            this.rd_local.CheckedChanged += new System.EventHandler(this.rd_local_CheckedChanged);
            // 
            // tx_ip_adress
            // 
            this.tx_ip_adress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tx_ip_adress.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tx_ip_adress.Location = new System.Drawing.Point(190, 206);
            this.tx_ip_adress.MaxLength = 15;
            this.tx_ip_adress.Name = "tx_ip_adress";
            this.tx_ip_adress.Size = new System.Drawing.Size(363, 33);
            this.tx_ip_adress.TabIndex = 2;
            // 
            // btn_save
            // 
            this.btn_save.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_save.BackColor = System.Drawing.Color.Purple;
            this.btn_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_save.FlatAppearance.BorderSize = 0;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(462, 266);
            this.btn_save.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(90, 32);
            this.btn_save.TabIndex = 39;
            this.btn_save.Text = "حفظ";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Visible = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_new
            // 
            this.btn_new.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_new.BackColor = System.Drawing.Color.Green;
            this.btn_new.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_new.FlatAppearance.BorderSize = 0;
            this.btn_new.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_new.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_new.ForeColor = System.Drawing.Color.White;
            this.btn_new.Location = new System.Drawing.Point(189, 266);
            this.btn_new.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(90, 32);
            this.btn_new.TabIndex = 40;
            this.btn_new.Text = "اختبار جديد";
            this.btn_new.UseVisualStyleBackColor = false;
            this.btn_new.Visible = false;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // btn_test
            // 
            this.btn_test.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_test.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_test.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_test.FlatAppearance.BorderSize = 0;
            this.btn_test.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_test.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_test.ForeColor = System.Drawing.Color.White;
            this.btn_test.Location = new System.Drawing.Point(319, 266);
            this.btn_test.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(105, 32);
            this.btn_test.TabIndex = 81;
            this.btn_test.Text = "اختبار الاتصال";
            this.btn_test.UseVisualStyleBackColor = false;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(31, 102);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(641, 27);
            this.label1.TabIndex = 83;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Location = new System.Drawing.Point(342, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 82;
            this.pictureBox1.TabStop = false;
            // 
            // tx_pass
            // 
            this.tx_pass.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tx_pass.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tx_pass.Location = new System.Drawing.Point(281, 41);
            this.tx_pass.Name = "tx_pass";
            this.tx_pass.PasswordChar = '*';
            this.tx_pass.Size = new System.Drawing.Size(209, 30);
            this.tx_pass.TabIndex = 84;
            this.tx_pass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tx_pass.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 85;
            this.label2.Text = "PassWord";
            // 
            // pan_server
            // 
            this.pan_server.Controls.Add(this.pictureBox1);
            this.pan_server.Controls.Add(this.panel1);
            this.pan_server.Controls.Add(this.tx_ip_adress);
            this.pan_server.Controls.Add(this.label1);
            this.pan_server.Controls.Add(this.btn_new);
            this.pan_server.Controls.Add(this.btn_save);
            this.pan_server.Controls.Add(this.btn_test);
            this.pan_server.Dock = System.Windows.Forms.DockStyle.Top;
            this.pan_server.Location = new System.Drawing.Point(0, 0);
            this.pan_server.Name = "pan_server";
            this.pan_server.Size = new System.Drawing.Size(746, 305);
            this.pan_server.TabIndex = 86;
            this.pan_server.Visible = false;
            // 
            // pan_password
            // 
            this.pan_password.Controls.Add(this.lp_mas_error);
            this.pan_password.Controls.Add(this.btn_login);
            this.pan_password.Controls.Add(this.tx_pass);
            this.pan_password.Controls.Add(this.label2);
            this.pan_password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_password.Location = new System.Drawing.Point(0, 305);
            this.pan_password.Name = "pan_password";
            this.pan_password.Size = new System.Drawing.Size(746, 163);
            this.pan_password.TabIndex = 84;
            // 
            // lp_mas_error
            // 
            this.lp_mas_error.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lp_mas_error.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lp_mas_error.ForeColor = System.Drawing.Color.Red;
            this.lp_mas_error.Location = new System.Drawing.Point(57, 13);
            this.lp_mas_error.Name = "lp_mas_error";
            this.lp_mas_error.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lp_mas_error.Size = new System.Drawing.Size(628, 23);
            this.lp_mas_error.TabIndex = 87;
            this.lp_mas_error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_login
            // 
            this.btn_login.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_login.BackColor = System.Drawing.Color.Green;
            this.btn_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_login.FlatAppearance.BorderSize = 0;
            this.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_login.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_login.ForeColor = System.Drawing.Color.White;
            this.btn_login.Location = new System.Drawing.Point(334, 88);
            this.btn_login.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(90, 32);
            this.btn_login.TabIndex = 86;
            this.btn_login.Text = "دخول";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // frm_Connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(746, 468);
            this.Controls.Add(this.pan_password);
            this.Controls.Add(this.pan_server);
            this.Name = "frm_Connection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اعدادات الاتصال بالسيرفر";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pan_server.ResumeLayout(false);
            this.pan_server.PerformLayout();
            this.pan_password.ResumeLayout(false);
            this.pan_password.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rd_server;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rd_local;
        private System.Windows.Forms.TextBox tx_ip_adress;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tx_pass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pan_server;
        private System.Windows.Forms.Panel pan_password;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Label lp_mas_error;
    }
}