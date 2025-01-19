using ClosedXML.Excel;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using tnerhbeauty.Class;

namespace tnerhbeauty
{
    public partial class home : Form
    {
        DataClasses1DataContext db;
        public home()
        {
            InitializeComponent();
        }
        
        add_client Add_client;
        add_product Add_product;
        frmproduct Frm_Product;
        Frm_CompanyInfo Frm_CompanyInfo;
        all_client All_client;
        frm_InvoiceHeader InvoiceHeader;
        all_InvoiceHeader All_InvoiceHeader;
        all_prodcut_get All_prodcut_get;
        Formnew formnew;
        add_amount_client Add_amount_client;
        all_amount_client All_amount_client;
        all_amount_client_report All_amount_client_report;
        frm_InvoiceHeader_in InvoiceHeader_in;
        frm_InvoiceHeader_store Frm_InvoiceHeader_store;
        all_InvoiceHeader_in All_InvoiceHeader_In;
        all_InvoiceHeader_store All_InvoiceHeader_store;
        frm_store_log _frm_Store_Log;
       
        private void home_Load(object sender, EventArgs e)
        {           
            titel();
            menuStrip1.Renderer = new MyRenderer();
            get_setting();
        }
        public void get_setting()
        {

            ts_groub_login.Text = Session.User_login.user_name;

            ts_new_invoice_pay_cash.Visible = Session.User_setting().add_invoice_pay;
            ts_new_invoice_salle.Visible = Session.User_setting().add_invoice_sale;
            ts_new_invoice_transfer_to_store.Visible = Session.User_setting().add_invoice_to_stroe;
            ts_new_invoice_pay_wait.Visible = Session.User_setting().add_InvoiceHeader_wait;

            ts_all_invoice_pay_cash.Visible = Session.User_setting().show_invoice_pay;
            ts_all_invoice_salle.Visible = Session.User_setting().show_invoice_sale;
            ts_all_invoice_transfer_to_store.Visible = Session.User_setting().show_invoice_to_stroe;
            ts_all_invoice_wait.Visible = Session.User_setting().show_InvoiceHeader_wait;

            if (
               (
               Session.User_setting().add_invoice_pay ==false&&
                Session.User_setting().add_invoice_sale == false &&
                Session.User_setting().add_invoice_to_stroe == false &&
                Session.User_setting().add_InvoiceHeader_wait == false &&
                Session.User_setting().show_invoice_pay == false &&
                Session.User_setting().show_invoice_sale == false &&
                Session.User_setting().show_invoice_to_stroe == false&&
                Session.User_setting().show_InvoiceHeader_wait == false
                ) 
                )
                ts_groub_invoices.Visible = false;
            else ts_groub_invoices.Visible = true;

            ts_add_new_product.Visible = Session.User_setting().add_product;
            ts_show_all_product.Visible = Session.User_setting().show_product;
            ts_update_price_producut.Visible = Session.User_setting().update_price_producut;
            ts_update_price_producut_exal.Visible = Session.User_setting().update_price_producut_exal;

            if (
               (Session.User_setting().add_product == false &&
               Session.User_setting().show_product == false &&
               Session.User_setting().update_price_producut == false &&
               Session.User_setting().update_price_producut_exal == false &&
               Session.User_setting().blance_in_storses == false)
               )
                ts_groub_product.Visible = false;
            else ts_groub_product.Visible = true;

            ts_kashf_hesab_prodct.Visible = Session.User_setting().kashf_hesab_prodct;
            ts_blance_in_storses.Visible = Session.User_setting().blance_in_storses;
            ts_product_min_mum.Visible = Session.User_setting().blance_in_storses;
            ts_store_in_and_out.Visible = Session.User_setting().store_in_and_out;
            ts_report_mabeat_product.Visible = Session.User_setting().report_mabeat_product;

            if (
              (Session.User_setting().kashf_hesab_prodct == false &&
              Session.User_setting().blance_in_storses == false &&
              Session.User_setting().store_in_and_out == false &&
              Session.User_setting().report_mabeat_product == false)
              )
                ts_groub_report.Visible = false;
            else ts_groub_report.Visible = true;

            ts_add_new_client.Visible = Session.User_setting().add_client;
            ts_show_all_client.Visible = Session.User_setting().show_client;
            ts_kashf_hesab_client.Visible = Session.User_setting().kashf_hesab_client;
            ts_add_amount_client.Visible = Session.User_setting().add_amount_client;
            ts_all_amount_client.Visible = Session.User_setting().show_amount_client;
            if (
             (Session.User_setting().add_client == false &&
             Session.User_setting().show_client == false &&
             Session.User_setting().kashf_hesab_client == false &&
             Session.User_setting().add_amount_client == false&&
             Session.User_setting().show_amount_client == false)
             )
                ts_groub_client.Visible = false;
            else ts_groub_client.Visible = true;

            ts_add_fara.Visible = Session.User_setting().add_fara;
            ts_all_fara.Visible = Session.User_setting().show_fara;
            ts_add_store.Visible = Session.User_setting().add_store;
            ts_all_store.Visible = Session.User_setting().show_store;
            if (
             (Session.User_setting().add_fara == false &&
             Session.User_setting().show_fara == false &&
             Session.User_setting().add_store == false &&
             Session.User_setting().show_store == false)
             )
                ts_groub_stores.Visible = false;
            else ts_groub_stores.Visible = true;

            ts_add_user.Visible = Session.User_setting().add_user;
            ts_all_user.Visible = Session.User_setting().show_user;
            if (
            (Session.User_setting().add_user == false &&
            Session.User_setting().show_user == false )
            )
                ts_groub_user.Visible = false;
            else ts_groub_user.Visible = true;

            ts_add_setting.Visible = Session.User_setting().add_setting;
            ts_all_setting.Visible = Session.User_setting().show_setting;
            if (Session.User_setting().add_setting == false&&
           Session.User_setting().show_setting == false)
                ts_groub_setting.Visible = false;
            else ts_groub_setting.Visible = true;
        }
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer(ProfessionalColorTable table) : base(table) { }
            //protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            //{
            //    e.TextColor = Color.White;
            //    base.OnRenderItemText(e);
            //}
            //protected override void OnRenderItemBackground(ToolStripItemRenderEventArgs e)
            //{
            //    e.Item.BackColor = Color.Gold;
            //    base.OnRenderItemBackground(e);
            //}
            //protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            //{
            //    if (e.Item.Selected)
            //    {
            //        Brush brush = new SolidBrush(Color.Green);
            //        Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
            //        e.Graphics.FillRectangle(brush, rc);
            //    }
            //}
            public MyRenderer() : base(new MyColors()) { }
        }
        private class MyColors : ProfessionalColorTable
        {
            //hover
            public override Color MenuItemSelectedGradientBegin
            {
                get { return ColorTranslator.FromHtml("#252451"); }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return ColorTranslator.FromHtml("#7160E8"); }
            }
            //selcted
            public override Color MenuItemPressedGradientBegin
            {
                get { return ColorTranslator.FromHtml("#252451"); }
            }
            public override Color MenuItemPressedGradientEnd
            {
                get { return ColorTranslator.FromHtml("#7160E8"); }
            }
            public override Color MenuItemBorder
            {
                get { return ColorTranslator.FromHtml("#252451"); }
            }
            public override Color MenuBorder  //added for changing the menu border
            {
                get { return ColorTranslator.FromHtml("#252451"); }
            }
            //hoveritem
            public override Color MenuItemSelected
            {
                get { return ColorTranslator.FromHtml("#7160E8"); }
            }

            public override Color ToolStripDropDownBackground
            {
                get { return ColorTranslator.FromHtml("#252451"); }
            }
            public override Color ToolStripBorder
            {
                get { return Color.Yellow; }
            }
            public override Color ToolStripGradientBegin
            {
                get { return Color.Yellow; }
            }
            public override Color ToolStripGradientEnd
            {
                get { return Color.Yellow; }
            }
            public override Color ToolStripGradientMiddle
            {
                get { return Color.Yellow; }
            }
        }

        public void titel()
        {
            ts_server.Text = Properties.Settings.Default.server;
            company_info info = new company_info();
            db = new DataClasses1DataContext();           
            info = db.company_infos.FirstOrDefault();
            if (info != null)
            {
                lb_company.Text = info.hedar.ToUpper();
                this.Text = lb_company.Text;
                if (info.image != null)
                    Img_Company.Image = Class.Session.GetImageFromByteArray(info.image.ToArray());
            }
        }
       
        bool chehdatabase()
        {
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            DataClasses1DataContext data = new DataClasses1DataContext("Data Source =.\\SQLEXPRESS; AttachDbFilename=" + path + "\\dbbetterlife.mdf; Integrated Security = True");
            try
            {
                if (!File.Exists(path + "\\dbbetterlife.mdf"))
                {
                    try
                    {
                        data.CreateDatabase();
                    }
                    catch (SqlException ex)
                    {

                        data.DeleteDatabase();
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch
            {


            }
            if (!File.Exists(path + "\\dbbetterlife.mdf"))
                return false;
            else return true;
        }
        
      
        frm_store_log_stores Frm_store_log_stores;
        frm_store_log_in_out Frm_store_log_in_out;
        private void ts_new_invoice_pay_cash_Click(object sender, EventArgs e)
        {
            InvoiceHeader = null;
            pan_home.Controls.Remove(InvoiceHeader);
            if (InvoiceHeader == null)
            {
                InvoiceHeader = new frm_InvoiceHeader();
                InvoiceHeader.TopLevel = false;
                InvoiceHeader.TopMost = true;
                InvoiceHeader.FormBorderStyle = FormBorderStyle.None;
                InvoiceHeader.Dock = DockStyle.Fill;
                pan_home.Controls.Add(InvoiceHeader);
                InvoiceHeader.Show();
            }
            InvoiceHeader.BringToFront();
        }
        private void ts_new_invoice_salle_Click(object sender, EventArgs e)
        {
            InvoiceHeader_in = null;
            pan_home.Controls.Remove(InvoiceHeader_in);
            if (InvoiceHeader_in == null)
            {
                InvoiceHeader_in = new frm_InvoiceHeader_in();
                InvoiceHeader_in.TopLevel = false;
                InvoiceHeader_in.TopMost = true;
                InvoiceHeader_in.FormBorderStyle = FormBorderStyle.None;
                InvoiceHeader_in.Dock = DockStyle.Fill;
                pan_home.Controls.Add(InvoiceHeader_in);
                InvoiceHeader_in.Show();
            }
            InvoiceHeader_in.BringToFront();
        }
        private void ts_show_all_sick_Click(object sender, EventArgs e)
        {
            All_client = null;
            pan_home.Controls.Remove(All_client);
            if (All_client == null)
            {
                All_client = new all_client();
                All_client.TopLevel = false;
                All_client.TopMost = true;
                All_client.FormBorderStyle = FormBorderStyle.None;
                All_client.Dock = DockStyle.Fill;
                pan_home.Controls.Add(All_client);
                All_client.Show();
            }
            All_client.BringToFront();
        }
        private void ts_all_amount_client_Click(object sender, EventArgs e)
        {
            All_amount_client = null;
            pan_home.Controls.Remove(All_amount_client);
            if (All_amount_client == null)
            {
                All_amount_client = new all_amount_client();
                All_amount_client.TopLevel = false;
                All_amount_client.TopMost = true;
                All_amount_client.FormBorderStyle = FormBorderStyle.None;
                All_amount_client.Dock = DockStyle.Fill;
                pan_home.Controls.Add(All_amount_client);
                All_amount_client.Show();
            }
            All_amount_client.BringToFront();
        }
        private void ts_kashf_hesab_client_Click(object sender, EventArgs e)
        {
            All_amount_client_report = null;
            pan_home.Controls.Remove(All_amount_client_report);
            if (All_amount_client_report == null)
            {
                All_amount_client_report = new all_amount_client_report();
                All_amount_client_report.TopLevel = false;
                All_amount_client_report.TopMost = true;
                All_amount_client_report.FormBorderStyle = FormBorderStyle.None;
                All_amount_client_report.Dock = DockStyle.Fill;
                pan_home.Controls.Add(All_amount_client_report);
                All_amount_client_report.Show();
            }
            All_amount_client_report.BringToFront();
        }
        private void ts_show_all_product_Click(object sender, EventArgs e)
        {
            Frm_Product = null;
            pan_home.Controls.Remove(Frm_Product);
            if (Frm_Product == null)
            {
                Frm_Product = new frmproduct();
                Frm_Product.TopLevel = false;
                Frm_Product.TopMost = true;
                Frm_Product.FormBorderStyle = FormBorderStyle.None;
                Frm_Product.Dock = DockStyle.Fill;
                pan_home.Controls.Add(Frm_Product);
                Frm_Product.Show();
            }
            Frm_Product.BringToFront();
        }
        private void ts_update_price_producut_exal_Click(object sender, EventArgs e)
        {

            if (formnew == null)
            {
                formnew = new Formnew();
                formnew.TopLevel = false;
                formnew.TopMost = true;
                formnew.FormBorderStyle = FormBorderStyle.None;
                formnew.Dock = DockStyle.Fill;
                pan_home.Controls.Add(formnew);
                formnew.Show();
            }
            formnew.BringToFront();
        }
        private void ts_all_invoice_pay_cash_Click(object sender, EventArgs e)
        {
            All_InvoiceHeader = null;
            pan_home.Controls.Remove(All_InvoiceHeader);
            if (All_InvoiceHeader == null)
            {
                All_InvoiceHeader = new all_InvoiceHeader();
                All_InvoiceHeader.TopLevel = false;
                All_InvoiceHeader.TopMost = true;
                All_InvoiceHeader.FormBorderStyle = FormBorderStyle.None;
                All_InvoiceHeader.Dock = DockStyle.Fill;
                pan_home.Controls.Add(All_InvoiceHeader);
                All_InvoiceHeader.Show();
            }
            
            All_InvoiceHeader.BringToFront();
        }
        private void ts_all_invoice_salle_Click(object sender, EventArgs e)
        {
            All_InvoiceHeader_In = null;
            pan_home.Controls.Remove(All_InvoiceHeader_In);
            if (All_InvoiceHeader_In == null)
            {
                All_InvoiceHeader_In = new all_InvoiceHeader_in();
                All_InvoiceHeader_In.TopLevel = false;
                All_InvoiceHeader_In.TopMost = true;
                All_InvoiceHeader_In.FormBorderStyle = FormBorderStyle.None;
                All_InvoiceHeader_In.Dock = DockStyle.Fill;
                pan_home.Controls.Add(All_InvoiceHeader_In);
                All_InvoiceHeader_In.Show();
            }
             
            All_InvoiceHeader_In.BringToFront();
        }
        private void ts_new_invoice_transfer_to_store_Click(object sender, EventArgs e)
        {
            Frm_InvoiceHeader_store = null;
            pan_home.Controls.Remove(Frm_InvoiceHeader_store);
            if (Frm_InvoiceHeader_store == null)
            {
                Frm_InvoiceHeader_store = new frm_InvoiceHeader_store();
                Frm_InvoiceHeader_store.TopLevel = false;
                Frm_InvoiceHeader_store.TopMost = true;
                Frm_InvoiceHeader_store.FormBorderStyle = FormBorderStyle.None;
                Frm_InvoiceHeader_store.Dock = DockStyle.Fill;
                pan_home.Controls.Add(Frm_InvoiceHeader_store);
                Frm_InvoiceHeader_store.Show();
            }
            Frm_InvoiceHeader_store.BringToFront();
        }
        private void ts_kashf_hesab_prodct_Click(object sender, EventArgs e)
        {
            _frm_Store_Log = null;
            pan_home.Controls.Remove(_frm_Store_Log);
            if (_frm_Store_Log == null)
            {
                _frm_Store_Log = new frm_store_log();
                _frm_Store_Log.TopLevel = false;
                _frm_Store_Log.TopMost = true;
                _frm_Store_Log.FormBorderStyle = FormBorderStyle.None;
                _frm_Store_Log.Dock = DockStyle.Fill;
                pan_home.Controls.Add(_frm_Store_Log);
                _frm_Store_Log.Show();
            }
            _frm_Store_Log.BringToFront();
        }
        private void ts_blance_in_storses_Click(object sender, EventArgs e)
        {
            Frm_store_log_stores = null;
            pan_home.Controls.Remove(Frm_store_log_stores);
            if (Frm_store_log_stores == null)
            {
                Frm_store_log_stores = new frm_store_log_stores();
                Frm_store_log_stores.TopLevel = false;
                Frm_store_log_stores.TopMost = true;
                Frm_store_log_stores.FormBorderStyle = FormBorderStyle.None;
                Frm_store_log_stores.Dock = DockStyle.Fill;
                pan_home.Controls.Add(Frm_store_log_stores);
                Frm_store_log_stores.Show();
            }
            Frm_store_log_stores.BringToFront();
        }
        private void ts_store_in_and_out_Click(object sender, EventArgs e)
        {
            Frm_store_log_in_out = null;
            pan_home.Controls.Remove(Frm_store_log_in_out);
            if (Frm_store_log_in_out == null)
            {
                Frm_store_log_in_out = new frm_store_log_in_out();
                Frm_store_log_in_out.TopLevel = false;
                Frm_store_log_in_out.TopMost = true;
                Frm_store_log_in_out.FormBorderStyle = FormBorderStyle.None;
                Frm_store_log_in_out.Dock = DockStyle.Fill;
                pan_home.Controls.Add(Frm_store_log_in_out);
                Frm_store_log_in_out.Show();
            }
            Frm_store_log_in_out.BringToFront();
        }
        private void ts_CompanyInfo_Click(object sender, EventArgs e)
        {
            if (!Session._setting.update_company)
                return;
            if (Frm_CompanyInfo == null)
            {
                Frm_CompanyInfo = new Frm_CompanyInfo();
                Frm_CompanyInfo.TopLevel = false;
                Frm_CompanyInfo.TopMost = true;
                Frm_CompanyInfo.FormBorderStyle = FormBorderStyle.None;
                Frm_CompanyInfo.Dock = DockStyle.Fill;
                pan_home.Controls.Add(Frm_CompanyInfo);
                Frm_CompanyInfo.Show();
            }
            Frm_CompanyInfo.BringToFront();
        }     
        private void ts_add_new_client_Click(object sender, EventArgs e)
        {
            Add_client = null;
            pan_home.Controls.Remove(Add_client);
            if (Add_client == null)
            {
                Add_client = new add_client();
                Add_client.TopLevel = false;
                Add_client.TopMost = true;
                Add_client.FormBorderStyle = FormBorderStyle.None;
                Add_client.Dock = DockStyle.Fill;
                pan_home.Controls.Add(Add_client);
                Add_client.Show();
            }
            Add_client.BringToFront();
        }
        private void ts_report_mabeat_product_Click(object sender, EventArgs e)
        {
            All_prodcut_get = null;
            pan_home.Controls.Remove(All_prodcut_get);
            if (All_prodcut_get == null)
            {
                All_prodcut_get = new all_prodcut_get();
                All_prodcut_get.TopLevel = false;
                All_prodcut_get.TopMost = true;
                All_prodcut_get.FormBorderStyle = FormBorderStyle.None;
                All_prodcut_get.Dock = DockStyle.Fill;
                pan_home.Controls.Add(All_prodcut_get);
                All_prodcut_get.Show();
            }
            All_prodcut_get.BringToFront();
            
        }
        private void ts_add_amount_client_Click(object sender, EventArgs e)
        {
            Add_amount_client = null;
            pan_home.Controls.Remove(Add_amount_client);
            if (Add_amount_client == null)
            {
                Add_amount_client = new add_amount_client();
                Add_amount_client.TopLevel = false;
                Add_amount_client.TopMost = true;
                Add_amount_client.FormBorderStyle = FormBorderStyle.None;
                Add_amount_client.Dock = DockStyle.Fill;
                pan_home.Controls.Add(Add_amount_client);
                Add_amount_client.Show();
            }
            Add_amount_client.BringToFront();
        }
        private void ts_add_new_product_Click(object sender, EventArgs e)
        {
            Add_product = null;
            pan_home.Controls.Remove(Add_product);
            if (Add_product == null)
            {
                Add_product = new add_product();
                Add_product.TopLevel = false;
                Add_product.TopMost = true;
                Add_product.FormBorderStyle = FormBorderStyle.None;
                Add_product.Dock = DockStyle.Fill;
                pan_home.Controls.Add(Add_product);
                Add_product.Show();
            }
            Add_product.BringToFront();
        }
        private void ts_all_invoice_transfer_to_store_Click(object sender, EventArgs e)
        {
            All_InvoiceHeader_store = null;
            pan_home.Controls.Remove(All_InvoiceHeader_store);
            if (All_InvoiceHeader_store == null)
            {
                All_InvoiceHeader_store = new all_InvoiceHeader_store();
                All_InvoiceHeader_store.TopLevel = false;
                All_InvoiceHeader_store.TopMost = true;
                All_InvoiceHeader_store.FormBorderStyle = FormBorderStyle.None;
                All_InvoiceHeader_store.Dock = DockStyle.Fill;
                pan_home.Controls.Add(All_InvoiceHeader_store);
                All_InvoiceHeader_store.Show();
            }
            All_InvoiceHeader_store.BringToFront();
        }
        private void ts_update_price_producut_Click(object sender, EventArgs e)
        {
            update_all_prod formnew = new update_all_prod();
            formnew.ShowDialog();
        }
        add_store Add_Store;
        private void ts_add_store_Click(object sender, EventArgs e)
        {
            Add_Store = null;
            pan_home.Controls.Remove(Add_Store);
            if (Add_Store == null)
            {
                Add_Store = new add_store();
                Add_Store.TopLevel = false;
                Add_Store.TopMost = true;
                Add_Store.FormBorderStyle = FormBorderStyle.None;
                Add_Store.Dock = DockStyle.Fill;
                pan_home.Controls.Add(Add_Store);
                Add_Store.Show();
            }
            Add_Store.BringToFront();
        }
        all_store All_Store;
        private void ts_all_store_Click(object sender, EventArgs e)
        {
            All_Store = null;
            pan_home.Controls.Remove(All_Store);
            if (All_Store == null)
            {
                All_Store = new all_store();
                All_Store.TopLevel = false;
                All_Store.TopMost = true;
                All_Store.FormBorderStyle = FormBorderStyle.None;
                All_Store.Dock = DockStyle.Fill;
                pan_home.Controls.Add(All_Store);
                All_Store.Show();
            }
            All_Store.BringToFront();
        }
        add_fara Add_Fara;
        private void ts_add_fara_Click(object sender, EventArgs e)
        {
            Add_Fara = null;
            pan_home.Controls.Remove(Add_Fara);
            if (Add_Fara == null)
            {
                Add_Fara = new add_fara();
                Add_Fara.TopLevel = false;
                Add_Fara.TopMost = true;
                Add_Fara.FormBorderStyle = FormBorderStyle.None;
                Add_Fara.Dock = DockStyle.Fill;
                pan_home.Controls.Add(Add_Fara);
                Add_Fara.Show();
            }
            Add_Fara.BringToFront();
        }
        all_fara All_Fara;
        private void ts_all_fara_Click(object sender, EventArgs e)
        {
            All_Fara = null;
            pan_home.Controls.Remove(All_Fara);
            if (All_Fara == null)
            {
                All_Fara = new all_fara();
                All_Fara.TopLevel = false;
                All_Fara.TopMost = true;
                All_Fara.FormBorderStyle = FormBorderStyle.None;
                All_Fara.Dock = DockStyle.Fill;
                pan_home.Controls.Add(All_Fara);
                All_Fara.Show();
            }
            
            All_Fara.BringToFront();
        }
        add_user User;
        private void ts_add_user_Click(object sender, EventArgs e)
        {
            User = null;
            pan_home.Controls.Remove(User);
            if (User == null)
            {
                User = new add_user();
                User.TopLevel = false;
                User.TopMost = true;
                User.FormBorderStyle = FormBorderStyle.None;
                User.Dock = DockStyle.Fill;
                pan_home.Controls.Add(User);
                User.Show();
            }
            User.BringToFront();
        }
        all_user All_User;
        private void ts_all_user_Click(object sender, EventArgs e)
        {
            All_User = null;
            pan_home.Controls.Remove(All_User);
            if (All_User == null)
            {
                All_User = new all_user();
                All_User.TopLevel = false;
                All_User.TopMost = true;
                All_User.FormBorderStyle = FormBorderStyle.None;
                All_User.Dock = DockStyle.Fill;
                pan_home.Controls.Add(All_User);
                All_User.Show();
            }
            All_User.BringToFront();
        }
        private void ts_chang_pass_Click(object sender, EventArgs e)
        {
            ChchangePassword chchangePassword = new ChchangePassword();
            chchangePassword.ShowDialog();
        }
        private void ts_logout_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.id_user = 0;
            Properties.Settings.Default.Save();
            Application.Exit();
        }
        add_setting _add_Setting;
        private void ts_add_setting_Click(object sender, EventArgs e)
        {
            _add_Setting = null;
            pan_home.Controls.Remove(_add_Setting);
            if (_add_Setting == null)
            {
                _add_Setting = new add_setting();
                _add_Setting.TopLevel = false;
                _add_Setting.TopMost = true;
                _add_Setting.FormBorderStyle = FormBorderStyle.None;
                _add_Setting.Dock = DockStyle.Fill;
                pan_home.Controls.Add(_add_Setting);
                _add_Setting.Show();
            }
            _add_Setting.BringToFront();
        }
        all_setting _all_Setting;
        private void ts_all_setting_Click(object sender, EventArgs e)
        {
            _all_Setting = null;
            pan_home.Controls.Remove(_all_Setting);
            if (_all_Setting == null)
            {
                _all_Setting = new all_setting();
                _all_Setting.TopLevel = false;
                _all_Setting.TopMost = true;
                _all_Setting.FormBorderStyle = FormBorderStyle.None;
                _all_Setting.Dock = DockStyle.Fill;
                pan_home.Controls.Add(_all_Setting);
                _all_Setting.Show();
            }
            _all_Setting.BringToFront();
        }
        private void ts_setting_conntion_Click(object sender, EventArgs e)
        {
            frm_Connection h = new frm_Connection();
            h.ShowDialog();
        }

        private void ts_server_Click(object sender, EventArgs e)
        {
            //frm_Connection h = new frm_Connection();
            //h.ShowDialog();
        }
        frm_InvoiceHeader_add_wait _frm_InvoiceHeader_Add_Wait;
        private void ts_new_invoice_pay_wait_Click(object sender, EventArgs e)
        {
            _frm_InvoiceHeader_Add_Wait = null;
            pan_home.Controls.Remove(_frm_InvoiceHeader_Add_Wait);
            if (_frm_InvoiceHeader_Add_Wait == null)
            {
                _frm_InvoiceHeader_Add_Wait = new frm_InvoiceHeader_add_wait();
                _frm_InvoiceHeader_Add_Wait.TopLevel = false;
                _frm_InvoiceHeader_Add_Wait.TopMost = true;
                _frm_InvoiceHeader_Add_Wait.FormBorderStyle = FormBorderStyle.None;
                _frm_InvoiceHeader_Add_Wait.Dock = DockStyle.Fill;
                pan_home.Controls.Add(_frm_InvoiceHeader_Add_Wait);
                _frm_InvoiceHeader_Add_Wait.Show();
            }
            _frm_InvoiceHeader_Add_Wait.BringToFront();
        }
        all_InvoiceHeader_wait _all_InvoiceHeader_Wait;
        private void ts_all_invoice_wait_Click(object sender, EventArgs e)
        {
            _all_InvoiceHeader_Wait = null;
            pan_home.Controls.Remove(_all_InvoiceHeader_Wait);
            if (_all_InvoiceHeader_Wait == null)
            {
                _all_InvoiceHeader_Wait = new all_InvoiceHeader_wait();
                _all_InvoiceHeader_Wait.TopLevel = false;
                _all_InvoiceHeader_Wait.TopMost = true;
                _all_InvoiceHeader_Wait.FormBorderStyle = FormBorderStyle.None;
                _all_InvoiceHeader_Wait.Dock = DockStyle.Fill;
                pan_home.Controls.Add(_all_InvoiceHeader_Wait);
                _all_InvoiceHeader_Wait.Show();
            }
            _all_InvoiceHeader_Wait.BringToFront();
        }
        frm_product_min_mum _Product_Min_Mum;
        private void ts_product_min_mum_Click(object sender, EventArgs e)
        {
            _Product_Min_Mum = null;
            pan_home.Controls.Remove(_Product_Min_Mum);
            if (_Product_Min_Mum == null)
            {
                _Product_Min_Mum = new frm_product_min_mum();
                _Product_Min_Mum.TopLevel = false;
                _Product_Min_Mum.TopMost = true;
                _Product_Min_Mum.FormBorderStyle = FormBorderStyle.None;
                _Product_Min_Mum.Dock = DockStyle.Fill;
                pan_home.Controls.Add(_Product_Min_Mum);
                _Product_Min_Mum.Show();
            }
            _Product_Min_Mum.BringToFront();
        }
    }
}
