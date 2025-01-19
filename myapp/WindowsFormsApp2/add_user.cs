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
    public partial class add_user : Form
    { 
        DataClasses1DataContext db;
        user User;
        bool updateid=false;
        List<fara> faras ;
        public add_user()
        {
            InitializeComponent();
            db = new DataClasses1DataContext();
            User = new user();
            faras = new List<fara>();
            faras = db.faras.ToList();
            dr_id_fara.IntializeData(faras.Where(x => x.is_stop == false).ToList(), "name_fara", "id");
            dr_setting.IntializeData(db.settings.ToList(), "name", "id");
        }
        public add_user(int id)
        {
            InitializeComponent();
            db = new DataClasses1DataContext();
            User = new user();
            User = db.users.Where(s => s.id == id).FirstOrDefault();
            faras = new List<fara>();
            faras = db.faras.ToList();
            dr_id_fara.IntializeData(faras.ToList(), "name_fara", "id");
            dr_setting.IntializeData(db.settings.ToList(), "name", "id");
            updateid =true;
        }
        private void add_marid_Load(object sender, EventArgs e)
        {
            dr_id_fara.SelectedIndex = -1;
            getdata();
        }
        void getdata()
        {
            tx_name.Text = User.user_name;
            tx_tel.Text = User.tel;
            tx_adress.Text = User.adress;
            dr_id_fara.SelectedValue = User.id_fara;
            dr_setting.SelectedValue = User.id_setting;
            ch_isstop.Checked = User.is_stop;
            if (User.id != 0)
            {
                lp_titel.Text = "تعديل بيانات موظف";               
                btn_delete.Visible = Session.User_setting().delete_user;
                btn_save.Visible = Session.User_setting().update_user;
            }
            else
            {
                lp_titel.Text = "اضافة موظف جديد ";              
                dr_id_fara.SelectedIndex = -1;
                dr_setting.SelectedIndex = -1;
                btn_save.Visible = Session.User_setting().add_user;
                btn_new.Visible = Session.User_setting().add_user;
            }
        }
        void setdata()
        {
            User.user_name = tx_name.Text.Replace_text();
            User.tel = tx_tel.Text;
            User.adress = tx_adress.Text.Replace_text();
            
            if (User.id == 0)
                User.password = "xxxxxx";
            if(ch_rest_pass.Checked)
                User.password = "xxxxxx";
            User.id_fara =Session.ConvertInt(dr_id_fara.SelectedValue.ToString());
            User.id_setting = Session.ConvertInt(dr_setting.SelectedValue.ToString());
            User.is_stop = ch_isstop.Checked;
            User.id_user = Session.User_login.id;
            User.DateServer = Session.GetDate();
        }
        bool valid()
        {
            errorProvider1.Clear();
            int error = 0;
            if (dr_setting.SelectedIndex == -1)
            {
                errorProvider1.SetError(dr_setting, "برجاء اختيار الصلاحيات");
                error++;
            }
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
                errorProvider1.SetError(dr_id_fara, "برجاء اختيار الفرع");
                error++;
            }
            return error==0;
        }
        private void bt_new_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            updateid = false;
            User = new user();
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
            if (User.id == 0)
                db.users .InsertOnSubmit(User);

            try
            {
                db.SubmitChanges();
            }
            catch (SqlException x)
            {
                if (x.Number == 2627)
                {
                    MyMessageBox.showMessage("error ", "يوجد موظف اخر مسجل بنفس الاسم او رقم التليفون", "", MessageBoxButtons.RetryCancel);
                }
                else
                MyMessageBox.showMessage("error ", "لم يتم الحفظ", "", MessageBoxButtons.RetryCancel);
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
                db.users.DeleteOnSubmit(User);
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
        private void ch_rest_pass_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_rest_pass.Checked)
                lb_mas.Text = "سيتم اعاده الباسورد الي الوضع الافتراضي";
            else lb_mas.Text = "";
        }
    }
}
