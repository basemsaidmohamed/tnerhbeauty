namespace tnerhbeauty
{
    partial class add_amount_client
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
            System.Windows.Forms.Label notsLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(add_amount_client));
            this.tx_nots = new System.Windows.Forms.TextBox();
            this.maridBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lb_mas = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btn_new = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dr_type = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tx_id_cient = new System.Windows.Forms.Label();
            this.tx_amount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tx_DateAdd = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.bt_aladawia = new System.Windows.Forms.Button();
            this.lp_titel = new System.Windows.Forms.Label();
            this.tx_name = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            notsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.maridBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tx_amount)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notsLabel
            // 
            notsLabel.AutoSize = true;
            notsLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            notsLabel.Location = new System.Drawing.Point(82, 211);
            notsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            notsLabel.Name = "notsLabel";
            notsLabel.Size = new System.Drawing.Size(55, 19);
            notsLabel.TabIndex = 19;
            notsLabel.Text = "ملاحظات";
            // 
            // tx_nots
            // 
            this.tx_nots.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.maridBindingSource, "nots", true));
            this.tx_nots.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tx_nots.Location = new System.Drawing.Point(143, 189);
            this.tx_nots.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tx_nots.Multiline = true;
            this.tx_nots.Name = "tx_nots";
            this.tx_nots.Size = new System.Drawing.Size(467, 61);
            this.tx_nots.TabIndex = 3;
            // 
            // maridBindingSource
            // 
            this.maridBindingSource.DataSource = typeof(tnerhbeauty.Client);
            // 
            // lb_mas
            // 
            this.lb_mas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lb_mas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lb_mas.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_mas.ForeColor = System.Drawing.Color.White;
            this.lb_mas.Location = new System.Drawing.Point(0, 318);
            this.lb_mas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_mas.Name = "lb_mas";
            this.lb_mas.Size = new System.Drawing.Size(695, 34);
            this.lb_mas.TabIndex = 37;
            this.lb_mas.Text = "F12 = SAVE ; F2  NEW  ;  DELETE = DELETE ; CTRL +P = PRINT";
            this.lb_mas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_save
            // 
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
            this.btn_save.TabIndex = 4;
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
            // btn_print
            // 
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
            this.btn_print.Click += new System.EventHandler(this.bt_print_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(72, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 19);
            this.label3.TabIndex = 82;
            this.label3.Text = "اسم العميل";
            // 
            // dr_type
            // 
            this.dr_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dr_type.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.dr_type.FormattingEnabled = true;
            this.dr_type.Location = new System.Drawing.Point(143, 56);
            this.dr_type.Name = "dr_type";
            this.dr_type.Size = new System.Drawing.Size(467, 26);
            this.dr_type.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(68, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 19);
            this.label1.TabIndex = 85;
            this.label1.Text = "نوع العملية";
            // 
            // tx_id_cient
            // 
            this.tx_id_cient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tx_id_cient.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tx_id_cient.Cursor = System.Windows.Forms.Cursors.No;
            this.tx_id_cient.Location = new System.Drawing.Point(617, 61);
            this.tx_id_cient.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tx_id_cient.Name = "tx_id_cient";
            this.tx_id_cient.Size = new System.Drawing.Size(45, 21);
            this.tx_id_cient.TabIndex = 86;
            this.tx_id_cient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tx_id_cient.Visible = false;
            // 
            // tx_amount
            // 
            this.tx_amount.DecimalPlaces = 2;
            this.tx_amount.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.tx_amount.InterceptArrowKeys = false;
            this.tx_amount.Location = new System.Drawing.Point(143, 123);
            this.tx_amount.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.tx_amount.Name = "tx_amount";
            this.tx_amount.Size = new System.Drawing.Size(467, 25);
            this.tx_amount.TabIndex = 2;
            this.tx_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(97, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 19);
            this.label2.TabIndex = 132;
            this.label2.Text = "المبلغ";
            // 
            // tx_DateAdd
            // 
            this.tx_DateAdd.CalendarFont = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tx_DateAdd.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.tx_DateAdd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tx_DateAdd.Location = new System.Drawing.Point(143, 156);
            this.tx_DateAdd.Name = "tx_DateAdd";
            this.tx_DateAdd.RightToLeftLayout = true;
            this.tx_DateAdd.Size = new System.Drawing.Size(467, 25);
            this.tx_DateAdd.TabIndex = 133;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(65, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 19);
            this.label4.TabIndex = 134;
            this.label4.Text = "تاريخ الدفعة";
            // 
            // bt_aladawia
            // 
            this.bt_aladawia.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt_aladawia.BackgroundImage = global::tnerhbeauty.Properties.Resources.find_users;
            this.bt_aladawia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_aladawia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_aladawia.FlatAppearance.BorderSize = 0;
            this.bt_aladawia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bt_aladawia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bt_aladawia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_aladawia.Location = new System.Drawing.Point(585, 90);
            this.bt_aladawia.Name = "bt_aladawia";
            this.bt_aladawia.Size = new System.Drawing.Size(25, 25);
            this.bt_aladawia.TabIndex = 83;
            this.bt_aladawia.UseVisualStyleBackColor = false;
            this.bt_aladawia.Click += new System.EventHandler(this.bt_aladawia_Click);
            // 
            // lp_titel
            // 
            this.lp_titel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lp_titel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lp_titel.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold);
            this.lp_titel.ForeColor = System.Drawing.Color.White;
            this.lp_titel.Image = global::tnerhbeauty.Properties.Resources.payment_method;
            this.lp_titel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lp_titel.Location = new System.Drawing.Point(0, 0);
            this.lp_titel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lp_titel.Name = "lp_titel";
            this.lp_titel.Size = new System.Drawing.Size(695, 35);
            this.lp_titel.TabIndex = 51;
            this.lp_titel.Text = "اضافة دفعة جديدة";
            this.lp_titel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tx_name
            // 
            this.tx_name.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tx_name.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tx_name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tx_name.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.tx_name.Location = new System.Drawing.Point(143, 89);
            this.tx_name.Name = "tx_name";
            this.tx_name.Padding = new System.Windows.Forms.Padding(3);
            this.tx_name.Size = new System.Drawing.Size(467, 26);
            this.tx_name.TabIndex = 135;
            this.tx_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tx_name.Click += new System.EventHandler(this.label5_Click);
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
            this.tableLayoutPanel1.Controls.Add(this.btn_save, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_new, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_delete, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_print, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(17, 280);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(360, 35);
            this.tableLayoutPanel1.TabIndex = 154;
            // 
            // add_amount_client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(695, 352);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tx_DateAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tx_amount);
            this.Controls.Add(this.tx_id_cient);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dr_type);
            this.Controls.Add(this.bt_aladawia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lp_titel);
            this.Controls.Add(this.lb_mas);
            this.Controls.Add(notsLabel);
            this.Controls.Add(this.tx_nots);
            this.Controls.Add(this.tx_name);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "add_amount_client";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "دفعات نقدية";
            this.Load += new System.EventHandler(this.add_marid_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.add_marid_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.maridBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tx_amount)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource maridBindingSource;
        private System.Windows.Forms.TextBox tx_nots;
        private System.Windows.Forms.Label lb_mas;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Label lp_titel;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox dr_type;
        private System.Windows.Forms.Button bt_aladawia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label tx_id_cient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown tx_amount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker tx_DateAdd;
        private System.Windows.Forms.Label tx_name;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}