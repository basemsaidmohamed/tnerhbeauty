namespace tnerhbeauty
{
    partial class update_all_prod
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(update_all_prod));
            this.lp_titel = new System.Windows.Forms.Label();
            this.lb_mas = new System.Windows.Forms.Label();
            this.btn_update_price = new System.Windows.Forms.Button();
            this.dr_up_or_down = new System.Windows.Forms.ComboBox();
            this.dr_naspa_or_maunt = new System.Windows.Forms.ComboBox();
            this.tx_nspa = new System.Windows.Forms.NumericUpDown();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lp_heder = new System.Windows.Forms.Label();
            this.dr_price = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.tx_nspa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lp_titel
            // 
            this.lp_titel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lp_titel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lp_titel.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold);
            this.lp_titel.ForeColor = System.Drawing.Color.White;
            this.lp_titel.Image = global::tnerhbeauty.Properties.Resources.price_list;
            this.lp_titel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lp_titel.Location = new System.Drawing.Point(0, 0);
            this.lp_titel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lp_titel.Name = "lp_titel";
            this.lp_titel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lp_titel.Size = new System.Drawing.Size(465, 35);
            this.lp_titel.TabIndex = 52;
            this.lp_titel.Text = "تعديل اسعار الاصناف";
            this.lp_titel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_mas
            // 
            this.lb_mas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lb_mas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lb_mas.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_mas.ForeColor = System.Drawing.Color.Red;
            this.lb_mas.Location = new System.Drawing.Point(0, 265);
            this.lb_mas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_mas.Name = "lb_mas";
            this.lb_mas.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lb_mas.Size = new System.Drawing.Size(465, 34);
            this.lb_mas.TabIndex = 53;
            this.lb_mas.Text = "سيتم نعديل كافة الاصناف بالكامل ..!";
            this.lb_mas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_update_price
            // 
            this.btn_update_price.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_update_price.BackColor = System.Drawing.Color.Purple;
            this.btn_update_price.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_update_price.FlatAppearance.BorderSize = 0;
            this.btn_update_price.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_update_price.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_update_price.ForeColor = System.Drawing.Color.White;
            this.btn_update_price.Location = new System.Drawing.Point(355, 223);
            this.btn_update_price.Name = "btn_update_price";
            this.btn_update_price.Size = new System.Drawing.Size(86, 29);
            this.btn_update_price.TabIndex = 106;
            this.btn_update_price.Text = "حفظ";
            this.btn_update_price.UseVisualStyleBackColor = false;
            this.btn_update_price.Click += new System.EventHandler(this.btn_update_price_Click);
            // 
            // dr_up_or_down
            // 
            this.dr_up_or_down.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dr_up_or_down.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dr_up_or_down.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dr_up_or_down.FormattingEnabled = true;
            this.dr_up_or_down.Items.AddRange(new object[] {
            "زبادة السعر",
            "خفض السعر"});
            this.dr_up_or_down.Location = new System.Drawing.Point(138, 79);
            this.dr_up_or_down.Margin = new System.Windows.Forms.Padding(0);
            this.dr_up_or_down.Name = "dr_up_or_down";
            this.dr_up_or_down.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dr_up_or_down.Size = new System.Drawing.Size(192, 25);
            this.dr_up_or_down.TabIndex = 104;
            // 
            // dr_naspa_or_maunt
            // 
            this.dr_naspa_or_maunt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dr_naspa_or_maunt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dr_naspa_or_maunt.Font = new System.Drawing.Font("Tahoma", 9.45F);
            this.dr_naspa_or_maunt.FormattingEnabled = true;
            this.dr_naspa_or_maunt.Items.AddRange(new object[] {
            "نسبة %",
            "مبلغ"});
            this.dr_naspa_or_maunt.Location = new System.Drawing.Point(139, 117);
            this.dr_naspa_or_maunt.Margin = new System.Windows.Forms.Padding(0);
            this.dr_naspa_or_maunt.Name = "dr_naspa_or_maunt";
            this.dr_naspa_or_maunt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dr_naspa_or_maunt.Size = new System.Drawing.Size(192, 24);
            this.dr_naspa_or_maunt.TabIndex = 129;
            // 
            // tx_nspa
            // 
            this.tx_nspa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tx_nspa.DecimalPlaces = 2;
            this.tx_nspa.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tx_nspa.InterceptArrowKeys = false;
            this.tx_nspa.Location = new System.Drawing.Point(139, 154);
            this.tx_nspa.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.tx_nspa.Name = "tx_nspa";
            this.tx_nspa.Size = new System.Drawing.Size(192, 23);
            this.tx_nspa.TabIndex = 130;
            this.tx_nspa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tx_nspa.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.RightToLeft = true;
            // 
            // lp_heder
            // 
            this.lp_heder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lp_heder.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lp_heder.ForeColor = System.Drawing.Color.Red;
            this.lp_heder.Location = new System.Drawing.Point(11, 41);
            this.lp_heder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lp_heder.Name = "lp_heder";
            this.lp_heder.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lp_heder.Size = new System.Drawing.Size(444, 22);
            this.lp_heder.TabIndex = 131;
            this.lp_heder.Text = "سيتم تعديل جميع  اسعار كل الاصناف ....!";
            this.lp_heder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dr_price
            // 
            this.dr_price.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dr_price.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dr_price.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dr_price.Font = new System.Drawing.Font("Tahoma", 9.45F);
            this.dr_price.FormattingEnabled = true;
            this.dr_price.Location = new System.Drawing.Point(136, 189);
            this.dr_price.Margin = new System.Windows.Forms.Padding(0);
            this.dr_price.Name = "dr_price";
            this.dr_price.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dr_price.Size = new System.Drawing.Size(194, 24);
            this.dr_price.TabIndex = 132;
            this.dr_price.SelectionChangeCommitted += new System.EventHandler(this.dr_price_SelectionChangeCommitted);
            // 
            // update_all_prod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(465, 299);
            this.Controls.Add(this.dr_price);
            this.Controls.Add(this.lp_heder);
            this.Controls.Add(this.tx_nspa);
            this.Controls.Add(this.dr_naspa_or_maunt);
            this.Controls.Add(this.btn_update_price);
            this.Controls.Add(this.dr_up_or_down);
            this.Controls.Add(this.lb_mas);
            this.Controls.Add(this.lp_titel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "update_all_prod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تعديل اسعار الاصناف";
            this.Load += new System.EventHandler(this.update_all_prod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tx_nspa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lp_titel;
        private System.Windows.Forms.Label lb_mas;
        private System.Windows.Forms.Button btn_update_price;
        private System.Windows.Forms.ComboBox dr_up_or_down;
        private System.Windows.Forms.ComboBox dr_naspa_or_maunt;
        private System.Windows.Forms.NumericUpDown tx_nspa;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lp_heder;
        private System.Windows.Forms.ComboBox dr_price;
    }
}