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
using System.Text.RegularExpressions;

namespace tnerhbeauty
{
    public partial class add_product : Form
    { 
        DataClasses1DataContext db;
        product Product;
        bool updateid=false;
        public add_product()
        {
            InitializeComponent();
            db = new DataClasses1DataContext();
            Product = new product();
        }
        public add_product(int id)
        {
            InitializeComponent();
            db = new DataClasses1DataContext();
            Product = new product();
            Product = db.products.Where(s => s.id == id).FirstOrDefault();
            updateid=true;
        }
        private void add_marid_Load(object sender, EventArgs e)
        {
            getdata();
            //getdata();
            refrishgv_addmarid();
        }
        public void refrishgv_addmarid()
        {
            DataClasses1DataContext dbalamirad_almuzminas = new DataClasses1DataContext();
        }
        void getdata()
        {
            tx_name.Text = Product.name;
            tx_code.Text = Product.code;
            tx_price_buy.Text = Product.price_buy.ToString();
            tx_price_sale.Text = Product.price_sale.ToString();
            tx_price_sale_100.Text = Product.price_sale_100.ToString();
            tx_price_sale_75.Text = Product.price_sale_75.ToString();
            tx_price_sale_vip2.Text = Product.price_sale_vip2.ToString();
            tx_price_sale_vip1.Text = Product.price_sale_vip1.ToString();

            tx_price_1.Text = Product.price_1.ToString();
            tx_price_2.Text = Product.price_2.ToString();
            tx_price_3.Text = Product.price_3.ToString();
            tx_price_4.Text = Product.price_4.ToString();
            tx_price_5.Text = Product.price_5.ToString();
            tx_price_6.Text = Product.price_6.ToString();
            tx_price_7.Text = Product.price_7.ToString();
            tx_price_8.Text = Product.price_8.ToString();
            tx_price_9.Text = Product.price_9.ToString();
            tx_price_10.Text = Product.price_10.ToString();
           tx_min_mum.Text = Product.min_mum.ToString();
            ch_isstop.Checked = Product.is_stop;
            if (Product.id != 0)
            {
                lp_titel.Text = "تعديل بيانات صنف";               
                //bt_print.Visible = true;
                btn_delete.Visible = Session.User_setting().delete_product;
                btn_save.Visible = Session.User_setting().update_product;
            }
            else
            {
                lp_titel.Text = "اضافة صنف جديد ";
                btn_delete.Visible = false;
                btn_print.Visible = false;
                btn_save.Visible = Session.User_setting().add_product;
                btn_new.Visible = Session.User_setting().add_product;
            }
        }
        void setdata()
        {
            Product.name = tx_name.Text.Replace_text();
            Product.code = tx_code.Text.ToUpper();

            Product.price_buy = Session.Convertdecimal(tx_price_buy.Text);
            Product.price_sale = Session.Convertdecimal(tx_price_sale.Text);
            Product.price_sale_100 = Session.Convertdecimal(tx_price_sale_100.Text);
            Product.price_sale_75 = Session.Convertdecimal(tx_price_sale_75.Text);
            Product.price_sale_vip2 = Session.Convertdecimal(tx_price_sale_vip2.Text);
            Product.price_sale_vip1 = Session.Convertdecimal(tx_price_sale_vip1.Text);

            Product.price_1 = Session.Convertdecimal(tx_price_1.Text);
            Product.price_2 = Session.Convertdecimal(tx_price_2.Text);
            Product.price_3 = Session.Convertdecimal(tx_price_3.Text);
            Product.price_4 = Session.Convertdecimal(tx_price_4.Text);
            Product.price_5 = Session.Convertdecimal(tx_price_5.Text);
            Product.price_6 = Session.Convertdecimal(tx_price_6.Text);
            Product.price_7 = Session.Convertdecimal(tx_price_7.Text);
            Product.price_8 = Session.Convertdecimal(tx_price_8.Text);
            Product.price_9 = Session.Convertdecimal(tx_price_9.Text);
            Product.price_10 = Session.Convertdecimal(tx_price_10.Text);
            Product.min_mum = Session.Convertdecimal(tx_min_mum.Text);
            Product.is_stop = ch_isstop.Checked;
            Product.update_price = DateTime.Now.Date;
        }
        bool valid()
        {
            int error = 0;
            errorProvider1.Clear();
            if (Session.ConvertDouble(tx_price_sale.Text) <= 0)
            {
                errorProvider1.SetError(tx_price_sale, "Required");
                error++;
            }
            if (Session.ConvertDouble(tx_price_sale_100.Text) <= 0)
            {
                errorProvider1.SetError(tx_price_sale_100, "Required");
                error++;
            }
            if (Session.ConvertDouble(tx_price_sale_75.Text) <= 0)
            {
                errorProvider1.SetError(tx_price_sale_75, "Required");
                error++;
            }
            if (Session.ConvertDouble(tx_price_sale_vip2.Text) <= 0)
            {
                errorProvider1.SetError(tx_price_sale_vip2, "Required");
                error++;
            }
            if (Session.ConvertDouble(tx_price_sale_vip1.Text) <= 0)
            {
                errorProvider1.SetError(tx_price_sale_vip1, "Required");
                error++;
            }

            if (Session.ConvertDouble(tx_price_1.Text) <= 0)
            {
                errorProvider1.SetError(tx_price_1, "Required");
                error++;
            }

            if (Session.ConvertDouble(tx_price_2.Text) <= 0)
            {
                errorProvider1.SetError(tx_price_2, "Required");
                error++;
            }
            if (Session.ConvertDouble(tx_price_3.Text) <= 0)
            {
                errorProvider1.SetError(tx_price_3, "Required");
                error++;
            }
            if (Session.ConvertDouble(tx_price_4.Text) <= 0)
            {
                errorProvider1.SetError(tx_price_4, "Required");
                error++;
            }
            if (Session.ConvertDouble(tx_price_5.Text) <= 0)
            {
                errorProvider1.SetError(tx_price_5, "Required");
                error++;
            }
            if (Session.ConvertDouble(tx_price_6.Text) <= 0)
            {
                errorProvider1.SetError(tx_price_6, "Required");
                error++;
            }
            if (Session.ConvertDouble(tx_price_7.Text) <= 0)
            {
                errorProvider1.SetError(tx_price_7, "Required");
                error++;
            }
            if (Session.ConvertDouble(tx_price_8.Text) <= 0)
            {
                errorProvider1.SetError(tx_price_8, "Required");
                error++;
            }
            if (Session.ConvertDouble(tx_price_9.Text) <= 0)
            {
                errorProvider1.SetError(tx_price_9, "Required");
                error++;
            }
            if (Session.ConvertDouble(tx_price_10.Text) <= 0)
            {
                errorProvider1.SetError(tx_price_10, "Required");
                error++;
            }
            if (string.IsNullOrEmpty(tx_name.Text.Trim()))
            {
                errorProvider1.SetError(tx_name, "Required");
                error++;
            }
            if (string.IsNullOrEmpty(tx_code.Text.Trim()))
            {
                errorProvider1.SetError(tx_code, "Required");
                error++;
            }
            //if (!Regex.IsMatch(tx_code.Text, @"^[(a)(A)]{1}[(r)(R)]{1}[a-zA-Z0-9]{1}[0-9]{4}$"))
            //{
            //    errorProvider1.SetError(tx_code, "كود الصنف غير صحيح");
            //    error++;
            //}

            return error==0;
        }
        private void bt_new_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            updateid = false;
            Product = new product();
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
            if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                btn_print.PerformClick();
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
            if (Product.id == 0)
                db.products .InsertOnSubmit(Product);

            try
            {
                db.SubmitChanges();
            }
            catch (SqlException x)
            {
                if (x.Number == 2601||x.Number==2627)
                {
                    errorProvider1.SetError(tx_code, " لا يمكن تكرار  كود الصنف  ");
                    MyMessageBox.showMessage(" خطاء ", " لا يمكن تكرار كود الصنف  ", "", MessageBoxButtons.RetryCancel);
                }
                return;
            }
            if (updateid)
            {
                this.Close();
                return;
            }
            lb_mas.Text = "تم الحفظ بنجاح";
            btn_new.PerformClick();
        }
        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (MyMessageBox.showMessage("تاكيد", "هل متاكد من حذف السجل", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            try
            {
                db.products.DeleteOnSubmit(Product);
                db.SubmitChanges();
            }
            catch (SqlException x)
            {
                if (x.Number == 547)
                {
                    MyMessageBox.showMessage("خطاء", "لا يمكن حذف السجل المحدد ربما توجد عمليات مسجلة عليه", "", MessageBoxButtons.RetryCancel);
                }
                return;
            }
            this.Close();
        }
        private void bt_print_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext data = new DataClasses1DataContext();
            ReportDataSource[] ReportDataSource = new ReportDataSource[]
            {
             new ReportDataSource("ds_marid", data.Clients.Where(x=>x.id==Product.id)),
            };
            frm_show_report _Report = new frm_show_report(null, "sick_report", ReportDataSource,false);
            _Report.Show();
        }
        private void tx_price_buy_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (Regex.IsMatch((sender as TextBox).Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if (((e.KeyChar == '.') || char.IsDigit(e.KeyChar)) && (sender as TextBox).SelectionLength == (sender as TextBox).Text.Length)
            {
                e.Handled = false;
            }
            else
            if ((e.KeyChar == '.') && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}
