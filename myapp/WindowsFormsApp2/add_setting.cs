using Microsoft.Reporting.WinForms;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.DataFormats;
using System.Diagnostics;
using tnerhbeauty.rport;
using tnerhbeauty.Class;


namespace tnerhbeauty
{
    public partial class add_setting : Form
    { 
        DataClasses1DataContext db;
        setting _setting;
        bool updateid=false;
       
        public add_setting()
        {
            InitializeComponent();
            db = new DataClasses1DataContext();
            _setting = new setting();
        }
        public add_setting(int id)
        {
            InitializeComponent();
            db = new DataClasses1DataContext();
            _setting = new setting();
            _setting = db.settings.Where(s => s.id == id).FirstOrDefault();
           
            updateid =true;
        }
        
        private void add_marid_Load(object sender, EventArgs e)
        {
            getdata();
        }
        void getdata()
        {
            tx_name.Text = _setting.name;
            ch_show_invoice_pay.Checked = _setting.show_invoice_pay;
            ch_add_invoice_pay.Checked = _setting.add_invoice_pay;
            ch_update_invoice_pay.Checked = _setting.update_invoice_pay;
            ch_delete_invoice_pay.Checked = _setting.delete_invoice_pay;
            ch_show_invoice_sale.Checked = _setting.show_invoice_sale;
            ch_add_invoice_sale.Checked = _setting.add_invoice_sale;
            ch_update_invoice_sale.Checked = _setting.update_invoice_sale;
            ch_delete_invoice_sale.Checked = _setting.delete_invoice_sale;
            ch_show_invoice_to_stroe.Checked = _setting.show_invoice_to_stroe;
            ch_add_invoice_to_stroe.Checked = _setting.add_invoice_to_stroe;
            ch_update_invoice_to_stroe.Checked = _setting.update_invoice_to_stroe;
            ch_delete_invoice_to_stroe.Checked = _setting.delete_invoice_to_stroe;
            ch_show_product.Checked = _setting.show_product;
            ch_add_product.Checked = _setting.add_product;
            ch_update_product.Checked = _setting.update_product;
            ch_delete_product.Checked = _setting.delete_product;
            ch_update_price_producut.Checked = _setting.update_price_producut;
            ch_update_price_producut_exal.Checked = _setting.update_price_producut_exal;

            ch_kashf_hesab_prodct.Checked = _setting.kashf_hesab_prodct;
            ch_blance_in_storses.Checked = _setting.blance_in_storses;
            ch_store_in_and_out.Checked = _setting.store_in_and_out;
            ch_report_mabeat_product.Checked = _setting.report_mabeat_product;
            ch_show_client.Checked = _setting.show_client;
            ch_add_client.Checked = _setting.add_client;
            ch_update_client.Checked = _setting.update_client;
            ch_delete_client.Checked = _setting.delete_client;
            ch_show_amount_client.Checked = _setting.show_amount_client;
            ch_add_amount_client.Checked = _setting.add_amount_client;
            ch_update_amount_client.Checked = _setting.update_amount_client;
            ch_delete_amount_client.Checked = _setting.delete_amount_client;
            ch_kashf_hesab_client.Checked = _setting.kashf_hesab_client;
            ch_show_fara.Checked = _setting.show_fara;
            ch_add_fara.Checked = _setting.add_fara;
            ch_update_fara.Checked = _setting.update_fara;
            ch_delete_fara.Checked = _setting.delete_fara;
            ch_show_store.Checked = _setting.show_store;
            ch_add_store.Checked = _setting.add_store;
            ch_update_store.Checked = _setting.update_store;
            ch_delete_store.Checked = _setting.delete_store;
            ch_show_user.Checked = _setting.show_user;
            ch_add_user.Checked = _setting.add_user;
            ch_update_user.Checked = _setting.update_user;
            ch_delete_user.Checked = _setting.delete_user;
            ch_show_setting.Checked = _setting.show_setting;
            ch_add_setting.Checked = _setting.add_setting;
            ch_update_setting.Checked = _setting.update_setting;
            ch_delete_setting.Checked = _setting.delete_setting;
            ch_update_company.Checked = _setting.update_company;
            ch_show_InvoiceHeader_wait.Checked = _setting.show_InvoiceHeader_wait;
            ch_add_InvoiceHeader_wait.Checked = _setting.add_InvoiceHeader_wait;
            ch_update_InvoiceHeader_wait.Checked = _setting.update_InvoiceHeader_wait;
            ch_delete_InvoiceHeader_wait.Checked = _setting.delete_InvoiceHeader_wait;

            if (_setting.id != 0)             
            {                                 
                lp_titel.Text = "تعديل نموذج صلاحيات";
                btn_delete.Visible = Session.User_setting().delete_setting;
                btn_save.Visible = Session.User_setting().update_setting;
            }
            else
            {
                lp_titel.Text = "اضافة نموذج صلاحيات جديد ";                
                btn_save.Visible = Session.User_setting().add_setting;
                btn_new.Visible = Session.User_setting().add_setting;
            }
        }
        void setdata()
        {
            _setting.name = tx_name.Text.Replace_text();
            _setting.show_invoice_pay = ch_show_invoice_pay.Checked;
            _setting.add_invoice_pay = ch_add_invoice_pay.Checked;
            _setting.update_invoice_pay = ch_update_invoice_pay.Checked;
            _setting.delete_invoice_pay = ch_delete_invoice_pay.Checked;
            _setting.show_invoice_sale = ch_show_invoice_sale.Checked;
            _setting.add_invoice_sale = ch_add_invoice_sale.Checked;
            _setting.update_invoice_sale = ch_update_invoice_sale.Checked;
            _setting.delete_invoice_sale = ch_delete_invoice_sale.Checked;
            _setting.show_invoice_to_stroe = ch_show_invoice_to_stroe.Checked;
            _setting.add_invoice_to_stroe = ch_add_invoice_to_stroe.Checked;
            _setting.update_invoice_to_stroe = ch_update_invoice_to_stroe.Checked;
            _setting.delete_invoice_to_stroe = ch_delete_invoice_to_stroe.Checked;
            _setting.show_product = ch_show_product.Checked;
            _setting.add_product = ch_add_product.Checked;
            _setting.update_product = ch_update_product.Checked;
            _setting.delete_product = ch_delete_product.Checked;
            _setting.update_price_producut = ch_update_price_producut.Checked;
            _setting.update_price_producut_exal = ch_update_price_producut_exal.Checked;

            _setting.kashf_hesab_prodct = ch_kashf_hesab_prodct.Checked;
            _setting.blance_in_storses = ch_blance_in_storses.Checked;
            _setting.store_in_and_out = ch_store_in_and_out.Checked;
            _setting.report_mabeat_product = ch_report_mabeat_product.Checked;
            _setting.show_client = ch_show_client.Checked;
            _setting.add_client = ch_add_client.Checked;
            _setting.update_client = ch_update_client.Checked;
            _setting.delete_client = ch_delete_client.Checked;
            _setting.show_amount_client = ch_show_amount_client.Checked;
            _setting.add_amount_client = ch_add_amount_client.Checked;
            _setting.update_amount_client = ch_update_amount_client.Checked;
            _setting.delete_amount_client = ch_delete_amount_client.Checked;
            _setting.kashf_hesab_client = ch_kashf_hesab_client.Checked;
            _setting.show_fara = ch_show_fara.Checked;
            _setting.add_fara = ch_add_fara.Checked;
            _setting.update_fara = ch_update_fara.Checked;
            _setting.delete_fara = ch_delete_fara.Checked;
            _setting.show_store = ch_show_store.Checked;
            _setting.add_store = ch_add_store.Checked;
            _setting.update_store = ch_update_store.Checked;
            _setting.delete_store = ch_delete_store.Checked;
            _setting.show_user = ch_show_user.Checked;
            _setting.add_user = ch_add_user.Checked;
            _setting.update_user = ch_update_user.Checked;
            _setting.delete_user = ch_delete_user.Checked;
            _setting.show_setting = ch_show_setting.Checked;
            _setting.add_setting = ch_add_setting.Checked;
            _setting.update_setting = ch_update_setting.Checked;
            _setting.delete_setting = ch_delete_setting.Checked;
            _setting.update_company= ch_update_company.Checked;

            _setting.show_InvoiceHeader_wait = ch_show_InvoiceHeader_wait.Checked;
            _setting.add_InvoiceHeader_wait = ch_add_InvoiceHeader_wait.Checked;
            _setting.update_InvoiceHeader_wait = ch_update_InvoiceHeader_wait.Checked;
            _setting.delete_InvoiceHeader_wait = ch_delete_InvoiceHeader_wait.Checked;
           

            _setting.id_user = Session.User_login.id;
            _setting.DateServer = Session.GetDate();
        }
        bool valid()
        {
            errorProvider1.Clear();
            int error = 0;
            if (string.IsNullOrEmpty(tx_name.Text.Trim()))
            {
                errorProvider1.SetError(tx_name, "يجب ادخال الاسم");
                error++;
            }
            return error==0;
        }
        private void bt_new_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            updateid = false;
            _setting = new setting();
            getdata();
            tx_name.Focus();
        }
        private void add_marid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                btn_save.PerformClick();
            }
            if (e.KeyCode == Keys.F2)
            {
                btn_new.PerformClick();
            }
            if (e.KeyCode == Keys.Escape && updateid)
            {
               this.Close();
            }
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
                if (ActiveControl is TextBox)
                {
                    TextBox tx = (TextBox)ActiveControl;
                    tx.SelectAll();
                }
            }
        }
        private void bt_save_Click(object sender, EventArgs e)
        {
            if (!valid())
                return;
            setdata();
            if (_setting.id == 0)
                db.settings .InsertOnSubmit(_setting);

            try
            {
                db.SubmitChanges();
            }

            catch (SqlException x)
            {
                if (x.Number == 2627)
                {
                    MyMessageBox.showMessage("error ", "يوجد صلاحية اخري مسجل بنفس الاسم ", "", MessageBoxButtons.RetryCancel);
                    
                }
                else
                MyMessageBox.showMessage("error ", " لم يتم الحفظ ", "", MessageBoxButtons.RetryCancel);
                return;
            }
            Session._setting = null;
            Session.User_setting();
            var mainForm = Application.OpenForms.OfType<home>().Single();
            mainForm.get_setting();

            if (updateid)
            {
                this.Close();
                return;
            }
            lb_mas.Text = "Saved successfully";
            btn_new.PerformClick();
           
            
        }
        private void bt_delete_Click(object sender, EventArgs e)
        {

            if (MyMessageBox.showMessage("تاكيد", "هل متاكد من حذف السجل", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            try
            {
                db.settings.DeleteOnSubmit(_setting);
                db.SubmitChanges();
            }
            catch (SqlException x)
            {
                if (x.Number == 547)
                {
                    MyMessageBox.showMessage("خطاء", "لا يمكن حذف السجل المحدد ربما توجد عمليات مسجلة عليه", "", MessageBoxButtons.RetryCancel);
                }
                else
                    MyMessageBox.showMessage("error ", " لم يتم الحذف  ", "", MessageBoxButtons.RetryCancel);
                return;
            }
            this.Close();
        }       
    }
}
