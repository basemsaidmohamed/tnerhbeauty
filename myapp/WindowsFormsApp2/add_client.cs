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
    public partial class add_client : Form
    { 
        DataClasses1DataContext db;
        Client client;
        bool updateid=false;
        public add_client()
        {
            InitializeComponent();
            db = new DataClasses1DataContext();
            client = new Client();
           
        }
        public add_client(int id)
        {
            InitializeComponent();
            db = new DataClasses1DataContext();
            client = new Client();
            client = db.Clients.Where(s => s.id == id).FirstOrDefault();
            updateid=true;
        }
        private void add_marid_Load(object sender, EventArgs e)
        {
            dr_price.IntializeData(Session.list_price, "name_row","id");
            dr_price.SelectedIndex = -1;
            getdata();
            
        }
        
        void getdata()
        {
            tx_name.Text = client.name;
            tx_tel.Text = client.tel;
            tx_adress.Text = client.adress;
            tx_nots.Text = client.nots;
            ch_isstop.Checked = client.is_stop;
            if (client.id != 0)
            {
                lp_titel.Text = "تعديل بيانات عميل";
                btn_print.Visible = true;
                dr_price.SelectedValue = client.list_price;

                btn_delete.Visible = Session.User_setting().delete_client;                
                btn_save.Visible = Session.User_setting().update_client;
            }
            else
            {
                lp_titel.Text = "اضافة عميل جديد ";
                btn_delete.Visible = false;
                btn_print.Visible = false;
                dr_price.SelectedIndex = -1;
                btn_save.Visible = Session.User_setting().add_client;
                btn_new.Visible = Session.User_setting().add_client;
            }
        }
        void setdata()
        {
            client.name = tx_name.Text.Replace_text();
            client.tel = tx_tel.Text;
            client.adress = tx_adress.Text.Replace_text();
            client.nots = tx_nots.Text.Replace_text();
            client.is_stop = ch_isstop.Checked;
            client.list_price = dr_price.SelectedValue.ToString();
            client.id_user = Session.User_login.id;
            client.id_fara = Session.User_login.id_fara;
            client.DateServer = Session.GetDate();
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
            if (string.IsNullOrEmpty(tx_tel.Text.Trim()))
            {
                errorProvider1.SetError(tx_tel, "يجب ادخال التليفون");
                error++;
            }
            if (dr_price.SelectedIndex==-1)
            {
                errorProvider1.SetError(dr_price, "برجاء اختيار قائمة الاسعار");
                error++;
            }
            return error==0;
        }
        private void bt_new_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            updateid = false;
            client = new Client();
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
            if (client.id == 0)
                db.Clients .InsertOnSubmit(client);

            try
            {
                db.SubmitChanges();
            }
            catch (SqlException x)
            {
                if (x.Number == 2601)
                {
                    MyMessageBox.showMessage("error ", "يوجد عميل اخر مسجل بنفس الاسم ورقم الهاتف", "", MessageBoxButtons.RetryCancel);
                    errorProvider1.SetError(tx_name, "لا يمكن تكرار الاسم ورقم الهاتف");
                    errorProvider1.SetError(tx_tel, "لا يمكن تكرار الاسم ورقم الهاتف");
                }
                return;
            }
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
                db.Clients.DeleteOnSubmit(client);
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
             new ReportDataSource("ds_marid", data.Clients.Where(x=>x.id==client.id)),
            };
            frm_show_report _Report = new frm_show_report(null, "sick_report", ReportDataSource,false);
            _Report.Show();
        }
       
    }
}
