namespace tnerhbeauty
{
    partial class all_prodcut_get_sale
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(all_prodcut_get_sale));
            this.dt_date_from = new System.Windows.Forms.DateTimePicker();
            this.dt_date_to = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_search = new System.Windows.Forms.Button();
            this.lb_mas = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_print = new System.Windows.Forms.Button();
            this.lp_titel = new System.Windows.Forms.Label();
            this.bt_product = new System.Windows.Forms.Button();
            this.gv = new tnerhbeauty.Class.datagrid();
            this.button2 = new System.Windows.Forms.Button();
            this.tx_prodct = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            this.SuspendLayout();
            // 
            // dt_date_from
            // 
            this.dt_date_from.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.dt_date_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_date_from.Location = new System.Drawing.Point(351, 62);
            this.dt_date_from.Name = "dt_date_from";
            this.dt_date_from.RightToLeftLayout = true;
            this.dt_date_from.Size = new System.Drawing.Size(116, 25);
            this.dt_date_from.TabIndex = 2;
            // 
            // dt_date_to
            // 
            this.dt_date_to.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.dt_date_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_date_to.Location = new System.Drawing.Point(473, 62);
            this.dt_date_to.Name = "dt_date_to";
            this.dt_date_to.RightToLeftLayout = true;
            this.dt_date_to.Size = new System.Drawing.Size(116, 25);
            this.dt_date_to.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(470, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "الي تاريخ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(348, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "من تاريخ";
            // 
            // bt_search
            // 
            this.bt_search.BackColor = System.Drawing.Color.Purple;
            this.bt_search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_search.FlatAppearance.BorderSize = 0;
            this.bt_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_search.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.bt_search.ForeColor = System.Drawing.Color.White;
            this.bt_search.Location = new System.Drawing.Point(595, 58);
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
            this.lb_mas.Size = new System.Drawing.Size(851, 31);
            this.lb_mas.TabIndex = 64;
            this.lb_mas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(16, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 18);
            this.label4.TabIndex = 69;
            this.label4.Text = "بحث عن الصنف";
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
            this.btn_print.Location = new System.Drawing.Point(741, 58);
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
            this.lp_titel.Image = global::tnerhbeauty.Properties.Resources.trend;
            this.lp_titel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lp_titel.Location = new System.Drawing.Point(0, 0);
            this.lp_titel.Name = "lp_titel";
            this.lp_titel.Size = new System.Drawing.Size(851, 33);
            this.lp_titel.TabIndex = 66;
            this.lp_titel.Text = "حركة الاصناف ";
            this.lp_titel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.bt_product.Location = new System.Drawing.Point(319, 62);
            this.bt_product.Name = "bt_product";
            this.bt_product.Size = new System.Drawing.Size(25, 25);
            this.bt_product.TabIndex = 81;
            this.bt_product.UseVisualStyleBackColor = false;
            this.bt_product.Click += new System.EventHandler(this.bt_product_Click);
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
            this.gv.Location = new System.Drawing.Point(10, 99);
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
            this.gv.Size = new System.Drawing.Size(833, 499);
            this.gv.TabIndex = 67;
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
            this.button2.Location = new System.Drawing.Point(11, 62);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 25);
            this.button2.TabIndex = 82;
            this.button2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tx_prodct
            // 
            this.tx_prodct.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tx_prodct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tx_prodct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tx_prodct.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.tx_prodct.Location = new System.Drawing.Point(31, 62);
            this.tx_prodct.Name = "tx_prodct";
            this.tx_prodct.Padding = new System.Windows.Forms.Padding(3);
            this.tx_prodct.Size = new System.Drawing.Size(288, 25);
            this.tx_prodct.TabIndex = 140;
            this.tx_prodct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tx_prodct.Click += new System.EventHandler(this.bt_product_Click);
            // 
            // all_prodcut_get_sale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(851, 650);
            this.Controls.Add(this.tx_prodct);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bt_product);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gv);
            this.Controls.Add(this.lp_titel);
            this.Controls.Add(this.lb_mas);
            this.Controls.Add(this.bt_search);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dt_date_to);
            this.Controls.Add(this.dt_date_from);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "all_prodcut_get_sale";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.all_kushufat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dt_date_from;
        private System.Windows.Forms.DateTimePicker dt_date_to;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_search;
        private System.Windows.Forms.Label lb_mas;
        private System.Windows.Forms.Label lp_titel;
        private Class.datagrid gv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Button bt_product;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label tx_prodct;
    }
}