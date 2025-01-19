namespace tnerhbeauty
{
    partial class add_fara
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
            System.Windows.Forms.Label adressLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label telLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(add_fara));
            this.tx_adress = new System.Windows.Forms.TextBox();
            this.maridBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tx_name = new System.Windows.Forms.TextBox();
            this.tx_tel = new System.Windows.Forms.TextBox();
            this.lb_mas = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btn_new = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.ch_isstop = new System.Windows.Forms.CheckBox();
            this.lp_titel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_print = new System.Windows.Forms.Button();
            adressLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            telLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.maridBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // adressLabel
            // 
            adressLabel.AutoSize = true;
            adressLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            adressLabel.Location = new System.Drawing.Point(80, 146);
            adressLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            adressLabel.Name = "adressLabel";
            adressLabel.Size = new System.Drawing.Size(47, 19);
            adressLabel.TabIndex = 1;
            adressLabel.Text = "العنوان";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nameLabel.Location = new System.Drawing.Point(62, 59);
            nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(62, 19);
            nameLabel.TabIndex = 17;
            nameLabel.Text = "اسم الفرغ";
            // 
            // telLabel
            // 
            telLabel.AutoSize = true;
            telLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            telLabel.Location = new System.Drawing.Point(85, 94);
            telLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            telLabel.Name = "telLabel";
            telLabel.Size = new System.Drawing.Size(42, 19);
            telLabel.TabIndex = 23;
            telLabel.Text = "تليفون";
            // 
            // tx_adress
            // 
            this.tx_adress.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.maridBindingSource, "adress", true));
            this.tx_adress.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tx_adress.Location = new System.Drawing.Point(139, 120);
            this.tx_adress.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tx_adress.Multiline = true;
            this.tx_adress.Name = "tx_adress";
            this.tx_adress.Size = new System.Drawing.Size(467, 67);
            this.tx_adress.TabIndex = 10;
            // 
            // maridBindingSource
            // 
            this.maridBindingSource.DataSource = typeof(tnerhbeauty.Client);
            // 
            // tx_name
            // 
            this.tx_name.BackColor = System.Drawing.Color.White;
            this.tx_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.maridBindingSource, "name", true));
            this.tx_name.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tx_name.Location = new System.Drawing.Point(139, 56);
            this.tx_name.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tx_name.Name = "tx_name";
            this.tx_name.Size = new System.Drawing.Size(467, 23);
            this.tx_name.TabIndex = 0;
            // 
            // tx_tel
            // 
            this.tx_tel.BackColor = System.Drawing.Color.White;
            this.tx_tel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.maridBindingSource, "name", true));
            this.tx_tel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tx_tel.Location = new System.Drawing.Point(139, 91);
            this.tx_tel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tx_tel.MaxLength = 40;
            this.tx_tel.Name = "tx_tel";
            this.tx_tel.Size = new System.Drawing.Size(467, 23);
            this.tx_tel.TabIndex = 1;
            // 
            // lb_mas
            // 
            this.lb_mas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lb_mas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lb_mas.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_mas.ForeColor = System.Drawing.Color.White;
            this.lb_mas.Location = new System.Drawing.Point(0, 327);
            this.lb_mas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_mas.Name = "lb_mas";
            this.lb_mas.Size = new System.Drawing.Size(684, 34);
            this.lb_mas.TabIndex = 37;
            this.lb_mas.Text = "F12 = SAVE ; F2  NEW  ;  DELETE = DELETE ; CTRL +P = PRINT";
            this.lb_mas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_save.BackColor = System.Drawing.Color.Purple;
            this.btn_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_save.FlatAppearance.BorderSize = 0;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(272, 3);
            this.btn_save.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(86, 29);
            this.btn_save.TabIndex = 12;
            this.btn_save.Text = "حفظ";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Visible = false;
            this.btn_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // btn_new
            // 
            this.btn_new.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_new.BackColor = System.Drawing.Color.Green;
            this.btn_new.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_new.FlatAppearance.BorderSize = 0;
            this.btn_new.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_new.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_new.ForeColor = System.Drawing.Color.White;
            this.btn_new.Location = new System.Drawing.Point(182, 3);
            this.btn_new.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(86, 29);
            this.btn_new.TabIndex = 38;
            this.btn_new.Text = "جديد";
            this.btn_new.UseVisualStyleBackColor = false;
            this.btn_new.Visible = false;
            this.btn_new.Click += new System.EventHandler(this.bt_new_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_delete.BackColor = System.Drawing.Color.Crimson;
            this.btn_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_delete.FlatAppearance.BorderSize = 0;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_delete.ForeColor = System.Drawing.Color.White;
            this.btn_delete.Location = new System.Drawing.Point(92, 3);
            this.btn_delete.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(86, 29);
            this.btn_delete.TabIndex = 40;
            this.btn_delete.Text = "حذف";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Visible = false;
            this.btn_delete.Click += new System.EventHandler(this.bt_delete_Click);
            // 
            // ch_isstop
            // 
            this.ch_isstop.AutoSize = true;
            this.ch_isstop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ch_isstop.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch_isstop.Location = new System.Drawing.Point(140, 193);
            this.ch_isstop.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ch_isstop.Name = "ch_isstop";
            this.ch_isstop.Size = new System.Drawing.Size(101, 23);
            this.ch_isstop.TabIndex = 54;
            this.ch_isstop.Text = "ايقاف التعامل ";
            this.ch_isstop.UseVisualStyleBackColor = true;
            // 
            // lp_titel
            // 
            this.lp_titel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lp_titel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lp_titel.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold);
            this.lp_titel.ForeColor = System.Drawing.Color.White;
            this.lp_titel.Image = global::tnerhbeauty.Properties.Resources.add_user;
            this.lp_titel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lp_titel.Location = new System.Drawing.Point(0, 0);
            this.lp_titel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lp_titel.Name = "lp_titel";
            this.lp_titel.Size = new System.Drawing.Size(684, 35);
            this.lp_titel.TabIndex = 51;
            this.lp_titel.Text = "فرع جديد";
            this.lp_titel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btn_print, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_save, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_new, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_delete, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 283);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(360, 35);
            this.tableLayoutPanel1.TabIndex = 151;
            // 
            // btn_print
            // 
            this.btn_print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_print.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_print.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_print.FlatAppearance.BorderSize = 0;
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_print.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_print.ForeColor = System.Drawing.Color.White;
            this.btn_print.Location = new System.Drawing.Point(2, 3);
            this.btn_print.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(86, 29);
            this.btn_print.TabIndex = 80;
            this.btn_print.Text = "طباعة";
            this.btn_print.UseVisualStyleBackColor = false;
            this.btn_print.Visible = false;
            // 
            // add_fara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ch_isstop);
            this.Controls.Add(this.lp_titel);
            this.Controls.Add(this.lb_mas);
            this.Controls.Add(this.tx_tel);
            this.Controls.Add(adressLabel);
            this.Controls.Add(this.tx_adress);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.tx_name);
            this.Controls.Add(telLabel);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "add_fara";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الفروع";
            this.Load += new System.EventHandler(this.add_marid_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.add_marid_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.maridBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource maridBindingSource;
        private System.Windows.Forms.TextBox tx_adress;
        private System.Windows.Forms.TextBox tx_name;
        private System.Windows.Forms.TextBox tx_tel;
        private System.Windows.Forms.Label lb_mas;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Label lp_titel;
        private System.Windows.Forms.CheckBox ch_isstop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_print;
    }
}