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
    public partial class add_store : Form
    { 
        DataClasses1DataContext db;
        store Store;
        bool updateid=false;
        List<fara> faras ;
        public add_store()
        {
            InitializeComponent();
            db = new DataClasses1DataContext();
            Store = new store();
            faras = new List<fara>();
            faras = db.faras.ToList();
            dr_id_fara.IntializeData(faras.Where(x => x.is_stop == false).ToList(), "name_fara", "id");
        }
        public add_store(int id)
        {
            InitializeComponent();
            db = new DataClasses1DataContext();
            Store = new store();
            Store = db.stores.Where(s => s.id == id).FirstOrDefault();
            faras = new List<fara>();
            faras = db.faras.ToList();
            dr_id_fara.IntializeData(faras.ToList(), "name_fara", "id");
            updateid =true;
        }
        
        private void add_marid_Load(object sender, EventArgs e)
        {
           
           
            dr_id_fara.SelectedIndex = -1;
            getdata();
        }
        void getdata()
        {
            tx_name.Text = Store.store_name;
            tx_tel.Text = Store.tel;
            tx_adress.Text = Store.adress;
            dr_id_fara.SelectedValue = Store.id_fara;
            ch_isstop.Checked = Store.is_stop;
            if (Store.id != 0)
            {
                lp_titel.Text = "تعديل بيانات مخزن";               
                btn_delete.Visible = Session.User_setting().delete_store;               
                btn_save.Visible = Session.User_setting().update_store;
            }
            else
            {
                lp_titel.Text = "اضافة مخزن جديد ";               
                dr_id_fara.SelectedIndex = -1;
                btn_save.Visible = Session.User_setting().add_store;
                btn_new.Visible = Session.User_setting().add_store;
            }
        }
        void setdata()
        {
            Store.store_name = tx_name.Text.Replace_text();
            Store.tel = tx_tel.Text;
            Store.adress = tx_adress.Text.Replace_text();
            Store.id_fara =Session.ConvertInt( dr_id_fara.SelectedValue.ToString());
            Store.is_stop = ch_isstop.Checked;
            Store.id_user = Session.User_login.id;
            Store.DateServer = Session.GetDate();
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
            if (dr_id_fara.SelectedIndex==-1)
            {
                errorProvider1.SetError(dr_id_fara, "برجاء اختيار   الفرع");
                error++;
            }
            return error==0;
        }
        private void bt_new_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            updateid = false;
            Store = new store();
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
            if (Store.id == 0)
                db.stores .InsertOnSubmit(Store);

            try
            {
                db.SubmitChanges();
            }
            catch (SqlException x)
            {
                if (x.Number == 2627)
                {
                    MyMessageBox.showMessage("error ", "يوجد محزن اخر مسجل بنفس الاسم ", "", MessageBoxButtons.RetryCancel);
                    
                }
                else
                MyMessageBox.showMessage("error ", " لم يتم الحفظ ", "", MessageBoxButtons.RetryCancel);
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
                db.stores.DeleteOnSubmit(Store);
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
