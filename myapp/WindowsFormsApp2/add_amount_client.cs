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
    public partial class add_amount_client : Form
    { 
        DataClasses1DataContext db;
        amount_client Amount_client;
        bool updateid=false;
        public add_amount_client()
        {
            InitializeComponent();
            db = new DataClasses1DataContext();
            Amount_client = new amount_client();
        }
        public add_amount_client(int id)
        {
            InitializeComponent();
            db = new DataClasses1DataContext();
            Amount_client = new amount_client();
            Amount_client = db.amount_clients.Where(s => s.id == id).FirstOrDefault();
            updateid=true;
        }
        int Id_clinet = 0;
        public add_amount_client(int id,int idclinet)
        {
            InitializeComponent();
            db = new DataClasses1DataContext();
            Amount_client = new amount_client();
            Id_clinet = idclinet;
        }
        private void add_marid_Load(object sender, EventArgs e)
        {
            dr_type.IntializeData(Session.Amount_client_type.Where(x =>x.type== "add_amount_client").ToList());
            getdata();
        }
        
        void getdata()
        {

            tx_id_cient.Text = Amount_client.id_client.ToString();
            tx_amount.Value = 0 ;
            tx_nots.Text = Amount_client.nots;
           
            if (Amount_client.id != 0)
            {
                lp_titel.Text = "تعديل بيانات دفعة";

                var selctmarid = db.Clients.Where(x => x.id == Amount_client.id_client).FirstOrDefault().name;
                if (selctmarid != null)
                    tx_name.Text = selctmarid;

                //tx_name.Text = "";
                //btn_print.Visible = true;
                btn_delete.Visible = Session.User_setting().delete_amount_client;
                btn_save.Visible = Session.User_setting().update_amount_client;
                dr_type.SelectedValue = Amount_client.id_type;
                tx_DateAdd.Value = Amount_client.DateAdd;
                if (Amount_client.amount_in != 0)
                    tx_amount.Value = Amount_client.amount_in;
                else tx_amount.Value = Amount_client.amount_out;
            }
            else
            {
                lp_titel.Text = "اضافة دفعة جديدة ";
                dr_type.SelectedIndex = -1;
                tx_id_cient.Text = "";
                tx_name.Text = "";
                btn_save.Visible = Session.User_setting().add_amount_client;
                btn_new.Visible = Session.User_setting().add_amount_client;
            }
            if(Id_clinet!=0)
            {
                var selctmarid = db.Clients.Where(x => x.id == Id_clinet).FirstOrDefault().name;
                if (selctmarid != null)
                {
                    tx_id_cient.Text = Id_clinet.ToString();
                    tx_name.Text = selctmarid;
                }
            }
        }
        void setdata()
        {
            Amount_client.id_type =Session.ConvertInt(dr_type.SelectedValue.ToString());
            Amount_client.id_client =Session.ConvertInt( tx_id_cient.Text);
            Amount_client.amount_in = Session.ConvertInt(dr_type.SelectedValue.ToString()) == 1? tx_amount.Value:0;
            Amount_client.amount_out = Session.ConvertInt(dr_type.SelectedValue.ToString()) == 2 ? tx_amount.Value : 0;
            Amount_client.nots =tx_nots.Text.Replace_text();
            Amount_client.DateAdd = tx_DateAdd.Value;
            Amount_client.id_user = Session.User_login.id;
            Amount_client.id_fara = Session.User_login.id_fara;           
            Amount_client.DateServer = Session.GetDate();
            //if (Amount_client.id==0)
            //    Amount_client.dateadd=DateTime.Now;

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
            if (Session.ConvertInt(tx_id_cient.Text)==0)
            {
                errorProvider1.SetError(tx_name, "يجب ادخال التليفون");
                error++;
            }
            if (string.IsNullOrEmpty(tx_amount.Text.Trim()) || Session.ConvertDouble(tx_amount.Text) <= 0)
            {
                errorProvider1.SetError(tx_amount, "يجب اضافة اصناف للفاتورة");
                error++;
            }
            if (dr_type.SelectedIndex==-1)
            {
                errorProvider1.SetError(dr_type, "برجاء اختيار قائمة الاسعار");
                error++;
            }
            return error==0;
        }
        private void bt_new_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            updateid = false;
            Amount_client = new amount_client();
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
            if (Amount_client.id == 0)
                db.amount_clients .InsertOnSubmit(Amount_client);

            
                db.SubmitChanges();
            
            if (updateid)
            {
                this.Close();
                return;
            }
           
            btn_new.PerformClick();
            lb_mas.Text = "Saved successfully";
        }
        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (MyMessageBox.showMessage("تاكيد", "هل متاكد من حذف السجل", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            db.amount_clients.DeleteOnSubmit(Amount_client);
            db.SubmitChanges();
            this.Close();
        }
        private void bt_print_Click(object sender, EventArgs e)
        {
            //DataClasses1DataContext data = new DataClasses1DataContext();
            //ReportDataSource[] ReportDataSource = new ReportDataSource[]
            //{
            // new ReportDataSource("amount_client", data.Clients.Where(x=>x.id==Amount_client.id)),
            //};
            //frm_show_report _Report = new frm_show_report(null, "amount_client", ReportDataSource,false);
            //_Report.Show();
        }

        private void bt_aladawia_Click(object sender, EventArgs e)
        {
            selct_sick _selct_Sick = new selct_sick();
            _selct_Sick.ShowDialog();
            if (_selct_Sick.retrnval() == 0)
            {
                tx_id_cient.Text = "0";
                tx_name.Text = "";
                return;
            }
            tx_id_cient.Text = _selct_Sick.retrnval().ToString();
            Client selctmarid = db.Clients.Where(x => x.id ==Session.ConvertInt( tx_id_cient.Text)).FirstOrDefault();
            if (selctmarid != null)
                tx_name.Text = selctmarid.name;
        }

        private void tx_name_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            selct_sick _selct_Sick = new selct_sick();
            _selct_Sick.ShowDialog();
            if (_selct_Sick.retrnval() == 0)
            {
                tx_id_cient.Text = "0";
                tx_name.Text = "";
                return;
            }
            tx_id_cient.Text = _selct_Sick.retrnval().ToString();
            Client selctmarid = db.Clients.Where(x => x.id == Session.ConvertInt(tx_id_cient.Text)).FirstOrDefault();
            if (selctmarid != null)
                tx_name.Text = selctmarid.name;
        }
    }
}
