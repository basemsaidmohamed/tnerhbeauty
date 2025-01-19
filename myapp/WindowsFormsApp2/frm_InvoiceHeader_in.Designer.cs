namespace tnerhbeauty
{
    partial class frm_InvoiceHeader_in
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
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_InvoiceHeader_in));
            this.lb_mas = new System.Windows.Forms.Label();
            this.btn_new = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tx_ItemName = new System.Windows.Forms.TextBox();
            this.tx_ItemQty = new System.Windows.Forms.TextBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ch_not_celar_ItemQty = new System.Windows.Forms.CheckBox();
            this.ch_kilo = new System.Windows.Forms.CheckBox();
            this.tx_Notes = new System.Windows.Forms.RichTextBox();
            this.tx_DateAdd = new System.Windows.Forms.DateTimePicker();
            this.btn_add_grid = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ch_auto_insert = new System.Windows.Forms.CheckBox();
            this.gv_InvoiceDetails = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.deleteitem = new System.Windows.Forms.DataGridViewImageColumn();
            this.label14 = new System.Windows.Forms.Label();
            this.dr_store_from = new System.Windows.Forms.ComboBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.lp_titel = new System.Windows.Forms.Label();
            this.gvSerchProduct = new tnerhbeauty.Class.datagrid();
            this.lb_balance = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_InvoiceDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSerchProduct)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            label9.Location = new System.Drawing.Point(737, 391);
            label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(92, 21);
            label9.TabIndex = 119;
            label9.Text = "تاريخ الفاتورة";
            // 
            // label10
            // 
            label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            label10.Location = new System.Drawing.Point(550, 391);
            label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(61, 21);
            label10.TabIndex = 120;
            label10.Text = "ملاحظات";
            // 
            // lb_mas
            // 
            this.lb_mas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lb_mas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lb_mas.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.lb_mas.ForeColor = System.Drawing.Color.White;
            this.lb_mas.Location = new System.Drawing.Point(0, 468);
            this.lb_mas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_mas.Name = "lb_mas";
            this.lb_mas.Size = new System.Drawing.Size(827, 33);
            this.lb_mas.TabIndex = 53;
            this.lb_mas.Text = "F11 = اضافة ;  F12 = SAVE ; F2  NEW  ;  DELETE = DELETE ; CTRL + P = PRINT";
            this.lb_mas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_new
            // 
            this.btn_new.BackColor = System.Drawing.Color.Green;
            this.btn_new.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_new.FlatAppearance.BorderSize = 0;
            this.btn_new.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_new.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_new.ForeColor = System.Drawing.Color.White;
            this.btn_new.Location = new System.Drawing.Point(224, 3);
            this.btn_new.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(102, 29);
            this.btn_new.TabIndex = 55;
            this.btn_new.Text = "جديد";
            this.btn_new.UseVisualStyleBackColor = false;
            this.btn_new.Visible = false;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.Purple;
            this.btn_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_save.FlatAppearance.BorderSize = 0;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(334, 3);
            this.btn_save.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(102, 29);
            this.btn_save.TabIndex = 54;
            this.btn_save.Text = "حفظ";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Visible = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.RightToLeft = true;
            // 
            // tx_ItemName
            // 
            this.tx_ItemName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tx_ItemName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.errorProvider1.SetIconAlignment(this.tx_ItemName, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.tx_ItemName.Location = new System.Drawing.Point(324, 68);
            this.tx_ItemName.Margin = new System.Windows.Forms.Padding(0);
            this.tx_ItemName.Name = "tx_ItemName";
            this.tx_ItemName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tx_ItemName.Size = new System.Drawing.Size(490, 30);
            this.tx_ItemName.TabIndex = 0;
            this.tx_ItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tx_ItemName.TextChanged += new System.EventHandler(this.tx_ItemName_TextChanged);
            this.tx_ItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tx_ItemName_KeyDown);
            // 
            // tx_ItemQty
            // 
            this.tx_ItemQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tx_ItemQty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorProvider1.SetIconAlignment(this.tx_ItemQty, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.tx_ItemQty.Location = new System.Drawing.Point(221, 68);
            this.tx_ItemQty.Name = "tx_ItemQty";
            this.tx_ItemQty.Size = new System.Drawing.Size(100, 30);
            this.tx_ItemQty.TabIndex = 106;
            this.tx_ItemQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tx_ItemQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tx_ItemQty_KeyDown);
            this.tx_ItemQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tx_ItemQty_KeyPress);
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.Crimson;
            this.btn_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_delete.FlatAppearance.BorderSize = 0;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_delete.ForeColor = System.Drawing.Color.White;
            this.btn_delete.Location = new System.Drawing.Point(114, 3);
            this.btn_delete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(102, 29);
            this.btn_delete.TabIndex = 72;
            this.btn_delete.Text = "حذف";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Visible = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_print.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_print.FlatAppearance.BorderSize = 0;
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_print.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_print.ForeColor = System.Drawing.Color.White;
            this.btn_print.Location = new System.Drawing.Point(4, 3);
            this.btn_print.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(102, 29);
            this.btn_print.TabIndex = 79;
            this.btn_print.Text = "طباعة";
            this.btn_print.UseVisualStyleBackColor = false;
            this.btn_print.Visible = false;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.Color.Red;
            // 
            // ch_not_celar_ItemQty
            // 
            this.ch_not_celar_ItemQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ch_not_celar_ItemQty.AutoSize = true;
            this.ch_not_celar_ItemQty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ch_not_celar_ItemQty.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch_not_celar_ItemQty.ForeColor = System.Drawing.Color.DimGray;
            this.ch_not_celar_ItemQty.Location = new System.Drawing.Point(200, 75);
            this.ch_not_celar_ItemQty.Name = "ch_not_celar_ItemQty";
            this.ch_not_celar_ItemQty.Size = new System.Drawing.Size(15, 14);
            this.ch_not_celar_ItemQty.TabIndex = 129;
            this.toolTip1.SetToolTip(this.ch_not_celar_ItemQty, "احتفظ بالكمية بعد اضافة الصنف");
            this.ch_not_celar_ItemQty.UseVisualStyleBackColor = true;
            this.ch_not_celar_ItemQty.CheckedChanged += new System.EventHandler(this.ch_not_celar_ItemQty_CheckedChanged);
            // 
            // ch_kilo
            // 
            this.ch_kilo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ch_kilo.AutoSize = true;
            this.ch_kilo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ch_kilo.Font = new System.Drawing.Font("Arial", 8.139131F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch_kilo.ForeColor = System.Drawing.Color.DimGray;
            this.ch_kilo.Location = new System.Drawing.Point(229, 44);
            this.ch_kilo.Name = "ch_kilo";
            this.ch_kilo.Size = new System.Drawing.Size(86, 20);
            this.ch_kilo.TabIndex = 131;
            this.ch_kilo.Text = "الكمية بالجرام";
            this.toolTip1.SetToolTip(this.ch_kilo, "تحويل الكمية الي جرام تلقائي");
            this.ch_kilo.UseVisualStyleBackColor = true;
            this.ch_kilo.CheckedChanged += new System.EventHandler(this.ch_kilo_CheckedChanged);
            // 
            // tx_Notes
            // 
            this.tx_Notes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tx_Notes.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tx_Notes.Location = new System.Drawing.Point(250, 388);
            this.tx_Notes.Name = "tx_Notes";
            this.tx_Notes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tx_Notes.Size = new System.Drawing.Size(293, 23);
            this.tx_Notes.TabIndex = 87;
            this.tx_Notes.Text = "";
            // 
            // tx_DateAdd
            // 
            this.tx_DateAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tx_DateAdd.CalendarFont = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tx_DateAdd.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.tx_DateAdd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tx_DateAdd.Location = new System.Drawing.Point(609, 388);
            this.tx_DateAdd.Name = "tx_DateAdd";
            this.tx_DateAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tx_DateAdd.RightToLeftLayout = true;
            this.tx_DateAdd.Size = new System.Drawing.Size(121, 28);
            this.tx_DateAdd.TabIndex = 88;
            // 
            // btn_add_grid
            // 
            this.btn_add_grid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add_grid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_add_grid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_add_grid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_add_grid.FlatAppearance.BorderSize = 0;
            this.btn_add_grid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add_grid.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_add_grid.ForeColor = System.Drawing.Color.White;
            this.btn_add_grid.Location = new System.Drawing.Point(12, 68);
            this.btn_add_grid.Name = "btn_add_grid";
            this.btn_add_grid.Size = new System.Drawing.Size(56, 26);
            this.btn_add_grid.TabIndex = 94;
            this.btn_add_grid.Text = "اضافة";
            this.btn_add_grid.UseVisualStyleBackColor = false;
            this.btn_add_grid.Click += new System.EventHandler(this.btn_add_grid_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.139131F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(764, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 16);
            this.label4.TabIndex = 103;
            this.label4.Text = "الصنف";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // ch_auto_insert
            // 
            this.ch_auto_insert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ch_auto_insert.AutoSize = true;
            this.ch_auto_insert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ch_auto_insert.Font = new System.Drawing.Font("Arial", 8.139131F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch_auto_insert.ForeColor = System.Drawing.Color.DimGray;
            this.ch_auto_insert.Location = new System.Drawing.Point(327, 44);
            this.ch_auto_insert.Name = "ch_auto_insert";
            this.ch_auto_insert.Size = new System.Drawing.Size(167, 20);
            this.ch_auto_insert.TabIndex = 122;
            this.ch_auto_insert.Text = "اضف الصنف تلقائي بعد الاختيار";
            this.ch_auto_insert.UseVisualStyleBackColor = true;
            this.ch_auto_insert.CheckedChanged += new System.EventHandler(this.ch_auto_insert_CheckedChanged);
            // 
            // gv_InvoiceDetails
            // 
            this.gv_InvoiceDetails.AllowUserToAddRows = false;
            this.gv_InvoiceDetails.AllowUserToResizeRows = false;
            this.gv_InvoiceDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gv_InvoiceDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gv_InvoiceDetails.BackgroundColor = System.Drawing.Color.White;
            this.gv_InvoiceDetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gv_InvoiceDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(96)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(96)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gv_InvoiceDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gv_InvoiceDetails.ColumnHeadersHeight = 28;
            this.gv_InvoiceDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.deleteitem});
            this.gv_InvoiceDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gv_InvoiceDetails.EnableHeadersVisualStyles = false;
            this.gv_InvoiceDetails.Location = new System.Drawing.Point(11, 109);
            this.gv_InvoiceDetails.Margin = new System.Windows.Forms.Padding(4);
            this.gv_InvoiceDetails.MultiSelect = false;
            this.gv_InvoiceDetails.Name = "gv_InvoiceDetails";
            this.gv_InvoiceDetails.ReadOnly = true;
            this.gv_InvoiceDetails.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gv_InvoiceDetails.RowHeadersVisible = false;
            this.gv_InvoiceDetails.RowHeadersWidth = 45;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.gv_InvoiceDetails.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gv_InvoiceDetails.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gv_InvoiceDetails.RowTemplate.Height = 30;
            this.gv_InvoiceDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gv_InvoiceDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv_InvoiceDetails.Size = new System.Drawing.Size(803, 272);
            this.gv_InvoiceDetails.TabIndex = 90;
            this.gv_InvoiceDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Gv_CellClick);
            this.gv_InvoiceDetails.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.gv_InvoiceDetails_UserDeletingRow);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Column1.DisplayStyleForCurrentCellOnly = true;
            this.Column1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Column1.HeaderText = "اسم الصنف";
            this.Column1.MaxDropDownItems = 1;
            this.Column1.MinimumWidth = 490;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 490;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Column2.DisplayStyleForCurrentCellOnly = true;
            this.Column2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Column2.HeaderText = "المخزن";
            this.Column2.MaxDropDownItems = 1;
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 120;
            // 
            // deleteitem
            // 
            this.deleteitem.HeaderText = "حذف";
            this.deleteitem.Image = global::tnerhbeauty.Properties.Resources.trash_25px;
            this.deleteitem.MinimumWidth = 39;
            this.deleteitem.Name = "deleteitem";
            this.deleteitem.ReadOnly = true;
            this.deleteitem.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label14.Font = new System.Drawing.Font("Arial", 8.139131F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DimGray;
            this.label14.Location = new System.Drawing.Point(114, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 16);
            this.label14.TabIndex = 146;
            this.label14.Text = "المخزن";
            this.label14.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // dr_store_from
            // 
            this.dr_store_from.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dr_store_from.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dr_store_from.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dr_store_from.Font = new System.Drawing.Font("Arial", 12F);
            this.dr_store_from.FormattingEnabled = true;
            this.dr_store_from.Location = new System.Drawing.Point(74, 68);
            this.dr_store_from.Name = "dr_store_from";
            this.dr_store_from.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dr_store_from.Size = new System.Drawing.Size(121, 30);
            this.dr_store_from.TabIndex = 145;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "حذف";
            this.dataGridViewImageColumn1.Image = global::tnerhbeauty.Properties.Resources.trash_25px;
            this.dataGridViewImageColumn1.MinimumWidth = 39;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 689;
            // 
            // lp_titel
            // 
            this.lp_titel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lp_titel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lp_titel.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold);
            this.lp_titel.ForeColor = System.Drawing.Color.White;
            this.lp_titel.Image = global::tnerhbeauty.Properties.Resources.history_time_clock_10192;
            this.lp_titel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lp_titel.Location = new System.Drawing.Point(0, 0);
            this.lp_titel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lp_titel.Name = "lp_titel";
            this.lp_titel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lp_titel.Size = new System.Drawing.Size(827, 36);
            this.lp_titel.TabIndex = 52;
            this.lp_titel.Text = "بيان اسعار";
            this.lp_titel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gvSerchProduct
            // 
            this.gvSerchProduct.AllowUserToAddRows = false;
            this.gvSerchProduct.AllowUserToDeleteRows = false;
            this.gvSerchProduct.AllowUserToResizeColumns = false;
            this.gvSerchProduct.AllowUserToResizeRows = false;
            this.gvSerchProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gvSerchProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvSerchProduct.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gvSerchProduct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvSerchProduct.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gvSerchProduct.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(96)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(96)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvSerchProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvSerchProduct.ColumnHeadersHeight = 30;
            this.gvSerchProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvSerchProduct.ColumnHeadersVisible = false;
            this.gvSerchProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gvSerchProduct.EnableHeadersVisualStyles = false;
            this.gvSerchProduct.GridColor = System.Drawing.Color.Black;
            this.gvSerchProduct.Location = new System.Drawing.Point(324, 95);
            this.gvSerchProduct.Margin = new System.Windows.Forms.Padding(0);
            this.gvSerchProduct.MaximumSize = new System.Drawing.Size(490, 600);
            this.gvSerchProduct.MinimumSize = new System.Drawing.Size(490, 0);
            this.gvSerchProduct.MultiSelect = false;
            this.gvSerchProduct.Name = "gvSerchProduct";
            this.gvSerchProduct.ReadOnly = true;
            this.gvSerchProduct.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gvSerchProduct.RowHeadersVisible = false;
            this.gvSerchProduct.RowHeadersWidth = 49;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            this.gvSerchProduct.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gvSerchProduct.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gvSerchProduct.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gvSerchProduct.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            this.gvSerchProduct.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.gvSerchProduct.RowTemplate.Height = 30;
            this.gvSerchProduct.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.gvSerchProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvSerchProduct.Size = new System.Drawing.Size(490, 10);
            this.gvSerchProduct.TabIndex = 3;
            this.gvSerchProduct.Visible = false;
            this.gvSerchProduct.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvSerchProduct_CellDoubleClick);
            this.gvSerchProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvSerchProduct_KeyDown);
            // 
            // lb_balance
            // 
            this.lb_balance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_balance.BackColor = System.Drawing.Color.Transparent;
            this.lb_balance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_balance.Font = new System.Drawing.Font("Arial", 8.139131F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_balance.ForeColor = System.Drawing.Color.DimGray;
            this.lb_balance.Location = new System.Drawing.Point(624, 39);
            this.lb_balance.Name = "lb_balance";
            this.lb_balance.Size = new System.Drawing.Size(135, 25);
            this.lb_balance.TabIndex = 147;
            this.lb_balance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btn_new, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_delete, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_print, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_save, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(375, 419);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(440, 35);
            this.tableLayoutPanel1.TabIndex = 150;
            // 
            // frm_InvoiceHeader_in
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(827, 501);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lb_balance);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dr_store_from);
            this.Controls.Add(this.ch_kilo);
            this.Controls.Add(this.ch_not_celar_ItemQty);
            this.Controls.Add(this.ch_auto_insert);
            this.Controls.Add(this.tx_ItemQty);
            this.Controls.Add(this.gvSerchProduct);
            this.Controls.Add(this.tx_ItemName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_add_grid);
            this.Controls.Add(this.gv_InvoiceDetails);
            this.Controls.Add(this.tx_DateAdd);
            this.Controls.Add(this.tx_Notes);
            this.Controls.Add(this.lb_mas);
            this.Controls.Add(this.lp_titel);
            this.Controls.Add(label10);
            this.Controls.Add(label9);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frm_InvoiceHeader_in";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فاتورة";
            this.Load += new System.EventHandler(this.frm_kushufat_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_kushufat_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_InvoiceDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSerchProduct)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lp_titel;
        private System.Windows.Forms.Label lb_mas;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ErrorProvider errorProvider1;
      
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.RichTextBox tx_Notes;
        private System.Windows.Forms.DateTimePicker tx_DateAdd;
        private System.Windows.Forms.Button btn_add_grid;
        private System.Windows.Forms.Label label4;
        private Class.datagrid gvSerchProduct;
        private System.Windows.Forms.TextBox tx_ItemName;
        private System.Windows.Forms.TextBox tx_ItemQty;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.CheckBox ch_auto_insert;
        private System.Windows.Forms.DataGridView gv_InvoiceDetails;
        private System.Windows.Forms.CheckBox ch_not_celar_ItemQty;
        private System.Windows.Forms.CheckBox ch_kilo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox dr_store_from;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column2;
        private System.Windows.Forms.DataGridViewImageColumn deleteitem;
        private System.Windows.Forms.Label lb_balance;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}