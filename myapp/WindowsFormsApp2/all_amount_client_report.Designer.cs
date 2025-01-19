namespace tnerhbeauty
{
    partial class all_amount_client_report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(all_amount_client_report));
            this.dt_date_from = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_search = new System.Windows.Forms.Button();
            this.lb_mas = new System.Windows.Forms.Label();
            this.btn_print = new System.Windows.Forms.Button();
            this.lp_titel = new System.Windows.Forms.Label();
            this.bt_serch_client = new System.Windows.Forms.Button();
            this.gv = new tnerhbeauty.Class.datagrid();
            this.label4 = new System.Windows.Forms.Label();
            this.lp_total = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lp_amunt_out = new System.Windows.Forms.Label();
            this.lp_amunt_in = new System.Windows.Forms.Label();
            this.tx_name = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_Balance_sabk = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dt_date_from
            // 
            this.dt_date_from.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.dt_date_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_date_from.Location = new System.Drawing.Point(347, 68);
            this.dt_date_from.Name = "dt_date_from";
            this.dt_date_from.RightToLeftLayout = true;
            this.dt_date_from.Size = new System.Drawing.Size(122, 25);
            this.dt_date_from.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(344, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "من تاريخ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(12, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "اسم العميل";
            // 
            // bt_search
            // 
            this.bt_search.BackColor = System.Drawing.Color.Purple;
            this.bt_search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_search.FlatAppearance.BorderSize = 0;
            this.bt_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_search.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.bt_search.ForeColor = System.Drawing.Color.White;
            this.bt_search.Location = new System.Drawing.Point(475, 68);
            this.bt_search.Name = "bt_search";
            this.bt_search.Size = new System.Drawing.Size(86, 29);
            this.bt_search.TabIndex = 55;
            this.bt_search.Text = "بحث";
            this.bt_search.UseVisualStyleBackColor = false;
            this.bt_search.Click += new System.EventHandler(this.bt_search_Click);
            // 
            // lb_mas
            // 
            this.lb_mas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lb_mas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lb_mas.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.lb_mas.ForeColor = System.Drawing.Color.White;
            this.lb_mas.Location = new System.Drawing.Point(0, 619);
            this.lb_mas.Name = "lb_mas";
            this.lb_mas.Size = new System.Drawing.Size(1106, 31);
            this.lb_mas.TabIndex = 64;
            this.lb_mas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.btn_print.Location = new System.Drawing.Point(996, 64);
            this.btn_print.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(102, 29);
            this.btn_print.TabIndex = 80;
            this.btn_print.Text = "طباعة";
            this.btn_print.UseVisualStyleBackColor = false;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // lp_titel
            // 
            this.lp_titel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lp_titel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lp_titel.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lp_titel.ForeColor = System.Drawing.Color.White;
            this.lp_titel.Image = global::tnerhbeauty.Properties.Resources.invoice;
            this.lp_titel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lp_titel.Location = new System.Drawing.Point(0, 0);
            this.lp_titel.Name = "lp_titel";
            this.lp_titel.Size = new System.Drawing.Size(1106, 33);
            this.lp_titel.TabIndex = 66;
            this.lp_titel.Text = "كشف حساب العملاء";
            this.lp_titel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bt_serch_client
            // 
            this.bt_serch_client.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt_serch_client.BackgroundImage = global::tnerhbeauty.Properties.Resources.find_users;
            this.bt_serch_client.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bt_serch_client.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_serch_client.FlatAppearance.BorderSize = 0;
            this.bt_serch_client.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bt_serch_client.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bt_serch_client.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_serch_client.Location = new System.Drawing.Point(306, 67);
            this.bt_serch_client.Margin = new System.Windows.Forms.Padding(0);
            this.bt_serch_client.Name = "bt_serch_client";
            this.bt_serch_client.Size = new System.Drawing.Size(25, 25);
            this.bt_serch_client.TabIndex = 60;
            this.bt_serch_client.UseVisualStyleBackColor = false;
            this.bt_serch_client.Click += new System.EventHandler(this.bt_serch_client_Click);
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
            this.gv.Location = new System.Drawing.Point(10, 107);
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
            this.gv.Size = new System.Drawing.Size(1088, 443);
            this.gv.TabIndex = 67;
            this.gv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_kushf_with_marid_CellDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 30);
            this.label4.TabIndex = 90;
            this.label4.Text = "الرصيد";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lp_total
            // 
            this.lp_total.AutoSize = true;
            this.lp_total.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lp_total.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lp_total.Location = new System.Drawing.Point(3, 30);
            this.lp_total.Name = "lp_total";
            this.lp_total.Size = new System.Drawing.Size(144, 33);
            this.lp_total.TabIndex = 89;
            this.lp_total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(153, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(248, 30);
            this.label5.TabIndex = 88;
            this.label5.Text = "اجمالي المنصرف الي العميل";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(407, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 30);
            this.label6.TabIndex = 87;
            this.label6.Text = "اجمالي الوارد من العميل";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lp_amunt_out
            // 
            this.lp_amunt_out.AutoSize = true;
            this.lp_amunt_out.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lp_amunt_out.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lp_amunt_out.Location = new System.Drawing.Point(153, 30);
            this.lp_amunt_out.Name = "lp_amunt_out";
            this.lp_amunt_out.Size = new System.Drawing.Size(248, 33);
            this.lp_amunt_out.TabIndex = 86;
            this.lp_amunt_out.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lp_amunt_in
            // 
            this.lp_amunt_in.AutoSize = true;
            this.lp_amunt_in.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lp_amunt_in.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lp_amunt_in.Location = new System.Drawing.Point(407, 30);
            this.lp_amunt_in.Name = "lp_amunt_in";
            this.lp_amunt_in.Size = new System.Drawing.Size(186, 33);
            this.lp_amunt_in.TabIndex = 85;
            this.lp_amunt_in.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tx_name
            // 
            this.tx_name.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tx_name.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tx_name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tx_name.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.tx_name.Location = new System.Drawing.Point(11, 67);
            this.tx_name.Name = "tx_name";
            this.tx_name.Padding = new System.Windows.Forms.Padding(3);
            this.tx_name.Size = new System.Drawing.Size(295, 25);
            this.tx_name.TabIndex = 137;
            this.tx_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tx_name.Click += new System.EventHandler(this.bt_serch_client_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 192F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.27563F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Controls.Add(this.lb_Balance_sabk, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lp_total, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lp_amunt_in, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lp_amunt_out, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(11, 553);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.61905F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.38095F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(742, 63);
            this.tableLayoutPanel1.TabIndex = 138;
            // 
            // lb_Balance_sabk
            // 
            this.lb_Balance_sabk.AutoSize = true;
            this.lb_Balance_sabk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Balance_sabk.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Balance_sabk.Location = new System.Drawing.Point(599, 30);
            this.lb_Balance_sabk.Name = "lb_Balance_sabk";
            this.lb_Balance_sabk.Size = new System.Drawing.Size(140, 33);
            this.lb_Balance_sabk.TabIndex = 91;
            this.lb_Balance_sabk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(599, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 30);
            this.label1.TabIndex = 89;
            this.label1.Text = "الرصيد سابق";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // all_amount_client_report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1106, 650);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.gv);
            this.Controls.Add(this.lp_titel);
            this.Controls.Add(this.lb_mas);
            this.Controls.Add(this.bt_serch_client);
            this.Controls.Add(this.bt_search);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dt_date_from);
            this.Controls.Add(this.tx_name);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "all_amount_client_report";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "0";
            this.Load += new System.EventHandler(this.all_kushufat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dt_date_from;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bt_search;
        private System.Windows.Forms.Button bt_serch_client;
        private System.Windows.Forms.Label lb_mas;
        private System.Windows.Forms.Label lp_titel;
        private Class.datagrid gv;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lp_total;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lp_amunt_out;
        private System.Windows.Forms.Label lp_amunt_in;
        private System.Windows.Forms.Label tx_name;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_Balance_sabk;
    }
}