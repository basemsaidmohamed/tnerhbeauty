namespace tnerhbeauty
{
    partial class frmMessageRetryCancel
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
            this.lp_caption = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.lplMessage = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lp_caption
            // 
            this.lp_caption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(48)))), ((int)(((byte)(44)))));
            this.lp_caption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lp_caption.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.lp_caption.ForeColor = System.Drawing.Color.White;
            this.lp_caption.Location = new System.Drawing.Point(1, 0);
            this.lp_caption.Name = "lp_caption";
            this.lp_caption.Size = new System.Drawing.Size(648, 24);
            this.lp_caption.TabIndex = 2;
            this.lp_caption.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lp_caption.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMessageRetryCancel_MouseDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(48)))), ((int)(((byte)(44)))));
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(1, 122);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(648, 32);
            this.panel1.TabIndex = 3;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMessageRetryCancel_MouseDown);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.White;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.btnOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(48)))), ((int)(((byte)(44)))));
            this.btnOk.Location = new System.Drawing.Point(551, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(87, 24);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "موافق";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lplMessage
            // 
            this.lplMessage.BackColor = System.Drawing.Color.White;
            this.lplMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lplMessage.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.lplMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(48)))), ((int)(((byte)(44)))));
            this.lplMessage.Location = new System.Drawing.Point(1, 24);
            this.lplMessage.Name = "lplMessage";
            this.lplMessage.Size = new System.Drawing.Size(648, 98);
            this.lplMessage.TabIndex = 5;
            this.lplMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lplMessage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMessageRetryCancel_MouseDown);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(48)))), ((int)(((byte)(44)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Image = global::tnerhbeauty.Properties.Resources.close;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 24);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // frmMessageRetryCancel
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(48)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(650, 154);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lplMessage);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lp_caption);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMessageRetryCancel";
            this.Opacity = 0.95D;
            this.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "confirm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmMessageOk_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMessageRetryCancel_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMessageRetryCancel_MouseDown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lp_caption;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lplMessage;
        private System.Windows.Forms.Button button1;

    }
}