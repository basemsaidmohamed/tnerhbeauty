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
using System.Data.SqlTypes;

namespace tnerhbeauty
{
    public partial class add_fara : Form
    { 
        DataClasses1DataContext db;
        fara _fara;
        bool updateid=false;
       
        public add_fara()
        {
            InitializeComponent();
            db = new DataClasses1DataContext();
            _fara = new fara();
           
        }
        public add_fara(int id)
        {
            InitializeComponent();
            db = new DataClasses1DataContext();
            _fara = new fara();
            _fara = db.faras.Where(s => s.id == id).FirstOrDefault();
           
            updateid =true;
        }
        
        private void add_marid_Load(object sender, EventArgs e)
        {
            getdata();
           
        }
        void getdata()
        {
            tx_name.Text = _fara.name_fara;
            tx_tel.Text = _fara.tel;
            tx_adress.Text = _fara.adress;
            ch_isstop.Checked = _fara.is_stop;
            if (_fara.id != 0)
            {
                lp_titel.Text = "تعديل بيانات فرع";
                btn_delete.Visible = Session.User_setting().delete_fara;               
                btn_save.Visible = Session.User_setting().update_fara;
            }
            else
            {
                lp_titel.Text = "اضافة فرع جديد ";                               
                btn_save.Visible = Session.User_setting().add_fara;
                btn_new.Visible = Session.User_setting().add_fara;
            }
        }
        void setdata()
        {
            _fara.name_fara = tx_name.Text.Replace_text();
            _fara.tel = tx_tel.Text;
            _fara.adress = tx_adress.Text.Replace_text();
            _fara.is_stop = ch_isstop.Checked;
            _fara.id_user = Session.User_login.id;
            _fara.DateServer=Session.GetDate();
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
            _fara = new fara();
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
            if (_fara.id == 0)
                db.faras .InsertOnSubmit(_fara);

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
                db.faras.DeleteOnSubmit(_fara);
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
