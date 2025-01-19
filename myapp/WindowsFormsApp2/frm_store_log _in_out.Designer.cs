namespace tnerhbeauty
{
    partial class frm_store_log_in_out
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_store_log_in_out));
            this.dt_date_from = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_mas = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.bt_product = new System.Windows.Forms.Button();
            this.lp_titel = new System.Windows.Forms.Label();
            this.btn_print = new System.Windows.Forms.Button();
            this.tx_prodct = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_Balance_sabk = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lp_total = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lp_amunt_in = new System.Windows.Forms.Label();
            this.lp_amunt_out = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dr_store = new System.Windows.Forms.ComboBox();
            this.ch_store = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ch_zero = new System.Windows.Forms.CheckBox();
            this.gv = new tnerhbeauty.Class.datagrid();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            this.SuspendLayout();
            // 
            // dt_date_from
            // 
            this.dt_date_from.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.dt_date_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_date_from.Location = new System.Drawing.Point(288, 60);
            this.dt_date_from.Name = "dt_date_from";
            this.dt_date_from.RightToLeftLayout = true;
            this.dt_date_from.Size = new System.Drawing.Size(120, 25);
            this.dt_date_from.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(285, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "من تاريخ";
            // 
            // lb_mas
            // 
            this.lb_mas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lb_mas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lb_mas.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.lb_mas.ForeColor = System.Drawing.Color.White;
            this.lb_mas.Location = new System.Drawing.Point(0, 619);
            this.lb_mas.Name = "lb_mas";
            this.lb_mas.Size = new System.Drawing.Size(1297, 31);
            this.lb_mas.TabIndex = 64;
            this.lb_mas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(18, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 18);
            this.label4.TabIndex = 69;
            this.label4.Text = "الصنف";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button2.BackgroundImage = global::tnerhbeauty.Properties.Resources.close;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(13, 60);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 25);
            this.button2.TabIndex = 71;
            this.button2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // bt_product
            // 
            this.bt_product.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt_product.BackgroundImage = global::tnerhbeauty.Properties.Resources.cubes;
            this.bt_product.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_product.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_product.FlatAppearance.BorderSize = 0;
            this.bt_product.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bt_product.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bt_product.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_product.Location = new System.Drawing.Point(257, 60);
            this.bt_product.Name = "bt_product";
            this.bt_product.Size = new System.Drawing.Size(25, 25);
            this.bt_product.TabIndex = 70;
            this.bt_product.UseVisualStyleBackColor = false;
            this.bt_product.Click += new System.EventHandler(this.bt_product_Click);
            // 
            // lp_titel
            // 
            this.lp_titel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lp_titel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lp_titel.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lp_titel.ForeColor = System.Drawing.Color.White;
            this.lp_titel.Image = global::tnerhbeauty.Properties.Resources.search_page;
            this.lp_titel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lp_titel.Location = new System.Drawing.Point(0, 0);
            this.lp_titel.Name = "lp_titel";
            this.lp_titel.Size = new System.Drawing.Size(1297, 33);
            this.lp_titel.TabIndex = 66;
            this.lp_titel.Text = "حركة الاصناف الواردة والصادرة";
            this.lp_titel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_print
            // 
            this.btn_print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_print.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_print.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_print.FlatAppearance.BorderSize = 0;
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_print.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_print.ForeColor = System.Drawing.Color.White;
            this.btn_print.Location = new System.Drawing.Point(1187, 50);
            this.btn_print.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(102, 29);
            this.btn_print.TabIndex = 80;
            this.btn_print.Text = "طباعة";
            this.btn_print.UseVisualStyleBackColor = false;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // tx_prodct
            // 
            this.tx_prodct.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tx_prodct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tx_prodct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tx_prodct.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.tx_prodct.Location = new System.Drawing.Point(37, 60);
            this.tx_prodct.Name = "tx_prodct";
            this.tx_prodct.Padding = new System.Windows.Forms.Padding(3);
            this.tx_prodct.Size = new System.Drawing.Size(220, 25);
            this.tx_prodct.TabIndex = 140;
            this.tx_prodct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tx_prodct.Click += new System.EventHandler(this.bt_product_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 182F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 197F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.27563F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 182F));
            this.tableLayoutPanel1.Controls.Add(this.lb_Balance_sabk, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lp_total, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lp_amunt_in, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lp_amunt_out, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 553);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.61905F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.38095F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(806, 63);
            this.tableLayoutPanel1.TabIndex = 141;
            // 
            // lb_Balance_sabk
            // 
            this.lb_Balance_sabk.AutoSize = true;
            this.lb_Balance_sabk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Balance_sabk.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Balance_sabk.Location = new System.Drawing.Point(627, 30);
            this.lb_Balance_sabk.Name = "lb_Balance_sabk";
            this.lb_Balance_sabk.Size = new System.Drawing.Size(176, 33);
            this.lb_Balance_sabk.TabIndex = 91;
            this.lb_Balance_sabk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(430, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 30);
            this.label6.TabIndex = 87;
            this.label6.Text = "اجمالي الوارد";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lp_total
            // 
            this.lp_total.AutoSize = true;
            this.lp_total.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lp_total.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lp_total.Location = new System.Drawing.Point(3, 30);
            this.lp_total.Name = "lp_total";
            this.lp_total.Size = new System.Drawing.Size(176, 33);
            this.lp_total.TabIndex = 89;
            this.lp_total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 30);
            this.label1.TabIndex = 90;
            this.label1.Text = "الرصيد";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(185, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(239, 30);
            this.label5.TabIndex = 88;
            this.label5.Text = "اجمالي المنصرف";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lp_amunt_in
            // 
            this.lp_amunt_in.AutoSize = true;
            this.lp_amunt_in.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lp_amunt_in.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lp_amunt_in.Location = new System.Drawing.Point(430, 30);
            this.lp_amunt_in.Name = "lp_amunt_in";
            this.lp_amunt_in.Size = new System.Drawing.Size(191, 33);
            this.lp_amunt_in.TabIndex = 85;
            this.lp_amunt_in.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lp_amunt_out
            // 
            this.lp_amunt_out.AutoSize = true;
            this.lp_amunt_out.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lp_amunt_out.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lp_amunt_out.Location = new System.Drawing.Point(185, 30);
            this.lp_amunt_out.Name = "lp_amunt_out";
            this.lp_amunt_out.Size = new System.Drawing.Size(239, 33);
            this.lp_amunt_out.TabIndex = 86;
            this.lp_amunt_out.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(627, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 30);
            this.label3.TabIndex = 89;
            this.label3.Text = "الرصيد سابق";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Purple;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(894, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 29);
            this.button1.TabIndex = 142;
            this.button1.Text = "بحث";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Window;
            this.button3.BackgroundImage = global::tnerhbeauty.Properties.Resources.close;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(571, 61);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(24, 22);
            this.button3.TabIndex = 147;
            this.button3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dr_store
            // 
            this.dr_store.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dr_store.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dr_store.Font = new System.Drawing.Font("Arial", 12F);
            this.dr_store.FormattingEnabled = true;
            this.dr_store.Location = new System.Drawing.Point(414, 59);
            this.dr_store.Name = "dr_store";
            this.dr_store.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dr_store.Size = new System.Drawing.Size(153, 26);
            this.dr_store.TabIndex = 146;
            // 
            // ch_store
            // 
            this.ch_store.AutoSize = true;
            this.ch_store.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ch_store.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ch_store.Location = new System.Drawing.Point(601, 58);
            this.ch_store.Name = "ch_store";
            this.ch_store.Size = new System.Drawing.Size(136, 22);
            this.ch_store.TabIndex = 148;
            this.ch_store.Text = "عرض رصيد  المخازن";
            this.ch_store.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(411, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 18);
            this.label7.TabIndex = 149;
            this.label7.Text = "المخزن";
            // 
            // ch_zero
            // 
            this.ch_zero.AutoSize = true;
            this.ch_zero.Checked = true;
            this.ch_zero.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ch_zero.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ch_zero.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.ch_zero.Location = new System.Drawing.Point(743, 58);
            this.ch_zero.Name = "ch_zero";
            this.ch_zero.Size = new System.Drawing.Size(143, 22);
            this.ch_zero.TabIndex = 150;
            this.ch_zero.Text = "اخفاء الارصدة الصفرية";
            this.ch_zero.UseVisualStyleBackColor = true;
            // 
            // gv
            // 
            this.gv.AllowUserToAddRows = false;
            this.gv.AllowUserToDeleteRows = false;
            this.gv.AllowUserToResizeColumns = false;
            this.gv.AllowUserToResizeRows = false;
            this.gv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(96)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(96)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gv.ColumnHeadersHeight = 30;
            this.gv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gv.EnableHeadersVisualStyles = false;
            this.gv.GridColor = System.Drawing.Color.Black;
            this.gv.Location = new System.Drawing.Point(10, 101);
            this.gv.Margin = new System.Windows.Forms.Padding(0);
            this.gv.Name = "gv";
            this.gv.ReadOnly = true;
            this.gv.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            this.gv.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gv.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gv.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gv.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            this.gv.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.gv.RowTemplate.Height = 30;
            this.gv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv.Size = new System.Drawing.Size(1279, 449);
            this.gv.TabIndex = 67;
            // 
            // frm_store_log_in_out
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1297, 650);
            this.Controls.Add(this.ch_zero);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ch_store);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dr_store);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tx_prodct);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bt_product);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gv);
            this.Controls.Add(this.lp_titel);
            this.Controls.Add(this.lb_mas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dt_date_from);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_store_log_in_out";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.all_kushufat_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dt_date_from;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_mas;
        private System.Windows.Forms.Label lp_titel;
        private Class.datagrid gv;
       
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button bt_product;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Label tx_prodct;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lb_Balance_sabk;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lp_total;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lp_amunt_in;
        private System.Windows.Forms.Label lp_amunt_out;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox dr_store;
        private System.Windows.Forms.CheckBox ch_store;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox ch_zero;
    }
}