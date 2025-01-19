using ClosedXML.Excel;
using Microsoft.Reporting.WinForms;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using tnerhbeauty.Class;
using tnerhbeauty.rport;


namespace tnerhbeauty
{
   
    public partial class frm_InvoiceHeader_update_wait : Form
    {
       
       
        DataClasses1DataContext db;
        DataClasses1DataContext DBDetails;
        DataClasses1DataContext db_amount_client;
        DataClasses1DataContext db_store_Log;
        InvoiceHeader invoiceHeader;
        bool updateid = false;
        InvoiceDetail invoiceDetail;
        BindingSource bs;
        static List<product_serch_View> dataprodcut;
        static List<store> stores;
        static List<store> storesUser;

        int client_save;
        //static List<InvoiceDetail> InvoiceDetail_old;
        public frm_InvoiceHeader_update_wait()
        {
            InitializeComponent();
            Initialize_class();
            
        }
        public frm_InvoiceHeader_update_wait(int id)
        {
            InitializeComponent();
            Initialize_class();
            invoiceHeader = db.InvoiceHeaders.Where(s => s.id == id).FirstOrDefault();
            if (invoiceHeader == null)
                invoiceHeader = new InvoiceHeader();
        }
        void Initialize_class()
        {
            db = new DataClasses1DataContext();
            DBDetails = new DataClasses1DataContext();
            invoiceHeader = new InvoiceHeader();
            bs = new BindingSource();
        }
        void get_dataprodct()
        {
            dataprodcut = Session.getallprodct.ToList();
            if (dataprodcut.Count == 0)
            {
                MyMessageBox.showMessage("لا يوجد اصناف مسجلة", "يجب اضافة اصناف اولا", "", MessageBoxButtons.RetryCancel);
            }
        }
        void get_store()
        {
            stores = db.stores.ToList();
            storesUser = stores.Where(x => x.is_stop == false && x.id_fara == Session.User_login.id_fara).ToList();
            
        }
        private void frm_kushufat_Load(object sender, EventArgs e)
        {
           

            dr_price.IntializeData(Session.list_price, "name_row", "id");
            
            get_dataprodct();
            get_store();
            getdata();
            Initialize_gv_InvoiceDetails();
        }
        void Initialize_gv_InvoiceDetails()
        {
            Column1.DataSource = dataprodcut;
            Column1.DataPropertyName = "ItemID";
            Column1.DisplayMember = "fullname";
            Column1.ValueMember = "id";
            
            Column2.DataSource = stores.ToList();
            Column2.DataPropertyName = "store_id";
            Column2.DisplayMember = "store_name";
            Column2.ValueMember = "id";
            
            gv_InvoiceDetails.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            gv_InvoiceDetails.AutoGenerateColumns = false;
            gv_InvoiceDetails.Columns[nameof(invoiceDetail.id)].Visible = false;
            gv_InvoiceDetails.Columns[nameof(invoiceDetail.InvoiceHeaderID)].Visible = false;
            gv_InvoiceDetails.Columns[nameof(invoiceDetail.ItemID)].Visible = false;
            gv_InvoiceDetails.Columns[nameof(invoiceDetail.store_id)].Visible = false;
            gv_InvoiceDetails.Columns[nameof(invoiceDetail.ItemQty)].HeaderText = "الكمية";
            gv_InvoiceDetails.Columns[nameof(invoiceDetail.Price)].HeaderText = "السعر";
            gv_InvoiceDetails.Columns[nameof(invoiceDetail.TotalPrice)].HeaderText = "الاجمالي";
            gv_InvoiceDetails.Columns[nameof(invoiceDetail.Discount)].HeaderText = "خصم ";
            gv_InvoiceDetails.Columns[nameof(invoiceDetail.Total)].HeaderText = "الصافي";
            gv_InvoiceDetails.Columns[Column2.Name].HeaderText = "المخزن";
            gv_InvoiceDetails.Columns[Column2.Name].DisplayIndex = gv_InvoiceDetails.Columns.Count - 2;
            gv_InvoiceDetails.CurrentCell = null;
            gv_InvoiceDetails.ReadOnly = false;
            gv_InvoiceDetails.Columns[Column1.Name].ReadOnly = true;
            gv_InvoiceDetails.Columns[Column2.Name].ReadOnly = true;
            gv_InvoiceDetails.Columns[nameof(invoiceDetail.Total)].ReadOnly = true;
            gv_InvoiceDetails.Columns[nameof(invoiceDetail.TotalPrice)].ReadOnly = true;
            gv_InvoiceDetails.Columns[nameof(invoiceDetail.ItemQty)].ReadOnly = true;
        }
        void getdata()
        {
            tx_Balance.Text = "";
            tx_Balance_type.Text = "";
            tx_name_cient.Text = "";
            
            bs.DataSource = DBDetails.InvoiceDetails.Where(x => x.InvoiceHeaderID == invoiceHeader.id);           
            gv_InvoiceDetails.DataSource = bs;

            tx_id_cient.Text = invoiceHeader.id_cient.ToString();

            dr_Discount_type.SelectedIndex = invoiceHeader.Discount_type;
            tx_Discount_percent.Text= invoiceHeader.Discount_percent.ToString();
            tx_Discount.Text = invoiceHeader.Discount.ToString("0.00");

            dr_Extra_type.SelectedIndex =invoiceHeader.Extra_type;
            tx_Extra_percent.Text = invoiceHeader.Extra_percent.ToString();
            tx_Extra.Text = invoiceHeader.Extra.ToString("0.00");

            tx_Total_product.Text = invoiceHeader.Total_product.ToString();
            tx_Net.Text = invoiceHeader.Net.ToString("0.00");
            tx_Notes.Text = invoiceHeader.Notes;
            dr_price.SelectedIndex = -1;
            ch_is_agel.Checked = invoiceHeader.is_agel;
            
            if (invoiceHeader.id != 0)
            {
                get_client();
                lp_titel.Text = "تحويل الي فاتورة مبيعات";
                tx_DateAdd.Value = invoiceHeader.DateAdd;
                updateid = true;
                btn_save.Visible = Session.User_setting().update_invoice_pay;
            }
        }
        void get_client()
        {
            client_View m = db.client_Views.Where(x => x.id ==Session.ConvertInt( tx_id_cient.Text)).FirstOrDefault();
            if (m != null)
            {
                tx_name_cient.Text = m.name;
                dr_price.SelectedValue = m.list_price;
                tx_Balance.Text = m.Balance.ToString();
                tx_Balance_type.Text = m.Balance_type;
            }
            else
            {
                tx_name_cient.Text = "";
                dr_price.SelectedValue ="";
                tx_Balance.Text = "";
                tx_Balance_type.Text ="";
            }
        }
        void setdata()
        {
            invoiceHeader.id_cient =Convert.ToInt32(tx_id_cient.Text);

            invoiceHeader.Discount_type = dr_Discount_type.SelectedIndex;
            invoiceHeader.Discount_percent = Session.Convertdecimal(tx_Discount_percent.Text);
            invoiceHeader.Discount =Session.Convertdecimal(tx_Discount.Text);

            invoiceHeader.Extra_type = dr_Extra_type.SelectedIndex;
            invoiceHeader.Extra_percent =Session.Convertdecimal( tx_Extra_percent.Text);
            invoiceHeader.Extra =Session.Convertdecimal( tx_Extra.Text);

            invoiceHeader.Total_product=Session.Convertdecimal( tx_Total_product.Text);
            invoiceHeader.Net = Session.Convertdecimal(tx_Net.Text);
            invoiceHeader.Notes=tx_Notes.Text.Replace_text();
            invoiceHeader.DateAdd = tx_DateAdd.Value;
            invoiceHeader.is_agel=ch_is_agel.Checked;
            invoiceHeader.id_invoice_type = 1;
            invoiceHeader.id_user = Session.User_login.id;
            invoiceHeader.id_fara = Session.User_login.id_fara;
            invoiceHeader.DateServer = Session.GetDate();
        }
        bool valid()
        {
            gv_InvoiceDetails.CurrentCell = null;
            errorProvider1.Clear();
            int error = 0;
            if (string.IsNullOrEmpty(tx_name_cient.Text.Trim()))
            {
                errorProvider1.SetError(tx_name_cient, "يجب اختار العميل");
                error++;
            }
            if (string.IsNullOrEmpty(tx_Total_product.Text.Trim()) || Session.ConvertDouble( tx_Total_product.Text) <= 0)
            {
                errorProvider1.SetError(tx_Total_product, "يجب اضافة اصناف للفاتورة");
                error++;
            }
            if (string.IsNullOrEmpty(tx_Net.Text.Trim()) || Session.ConvertDouble(tx_Net.Text)<= 0)
            {
                errorProvider1.SetError(tx_Net, "يجب ان تكون القيمة اكبر من صفر");
                error++;
            }

            for (int i = 0; i < gv_InvoiceDetails.Rows.Count; i++)
            {
                if ((decimal)gv_InvoiceDetails.Rows[i].Cells[nameof(invoiceDetail.Price)].Value <= 0)
                {
                    gv_InvoiceDetails.Rows[i].Cells[nameof(invoiceDetail.Price)].Style.BackColor = Color.Red;
                    gv_InvoiceDetails.Rows[i].Cells[nameof(invoiceDetail.Price)].ToolTipText = "يجب ان تكون القيمة اكبر من صفر";
                    error++;
                }
                if ((decimal)gv_InvoiceDetails.Rows[i].Cells[nameof(invoiceDetail.Total)].Value <= 0)
                {
                    gv_InvoiceDetails.Rows[i].Cells[nameof(invoiceDetail.Total)].Style.BackColor = Color.Red;
                    gv_InvoiceDetails.Rows[i].Cells[nameof(invoiceDetail.Total)].ToolTipText = "يجب ان تكون القيمة اكبر من صفر";
                    error++;
                }
                if ((decimal)gv_InvoiceDetails.Rows[i].Cells[nameof(invoiceDetail.TotalPrice)].Value <= 0)
                {
                    gv_InvoiceDetails.Rows[i].Cells[nameof(invoiceDetail.TotalPrice)].Style.BackColor = Color.Red;
                    gv_InvoiceDetails.Rows[i].Cells[nameof(invoiceDetail.TotalPrice)].ToolTipText = "يجب ان تكون القيمة اكبر من صفر";
                    error++;
                }
                if ((decimal)gv_InvoiceDetails.Rows[i].Cells[nameof(invoiceDetail.Discount)].Value < 0)
                {
                    gv_InvoiceDetails.Rows[i].Cells[nameof(invoiceDetail.Discount)].Style.BackColor = Color.Red;
                    gv_InvoiceDetails.Rows[i].Cells[nameof(invoiceDetail.Discount)].ToolTipText = "يجب ان تكون القيمة لاتقل عن صفر";
                    error++;
                }
            }
            return error == 0;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!valid())
                return;
            string StError = "";
            int CountError = 0;
            var list = bs.Cast<InvoiceDetail>().GroupBy(x => new { x.ItemID, x.store_id }).Select(cl => new InvoiceDetail
            {
                ItemID = cl.First().ItemID,
                ItemQty = (decimal?)cl.Sum(x => x.ItemQty) ?? 0,
                store_id = cl.First().store_id,
            }).ToList();
            foreach (InvoiceDetail item in list)
            {
                var _prod = db.store_log_Views.Where(x => (x.ItemID == item.ItemID) && (x.store_id == item.store_id) && (x.Source_Id != invoiceHeader.id))
                    .GroupBy(x => new { x.ItemID, x.store_id }).Select(cl => new store_log_View
                    {
                        store_id = cl.First().store_id,
                        ItemID = cl.First().ItemID,
                        code = cl.First().code,
                        product_name = cl.First().product_name,
                        Balance = (decimal?)cl.Sum(x => x.Balance) ?? 0,
                        store_name = cl.First().store_name,
                    }).FirstOrDefault();

                if (_prod != null)
                {
                    if (item.ItemQty > _prod.Balance)
                    {
                        CountError++;
                        StError += _prod.product_name + " " + _prod.store_name + " " + "اكبر كمية بيع" + " " + _prod.Balance + "\n";
                    }
                }
                else
                {
                    StError += " توجد اصناف ليس لديها رصيد حتي تاريخ الفاتورة" + "\n";
                    CountError++;
                }
            }
            if (CountError > 0)
            {
                MyMessageBox.showMessage("تاكيد", StError, "", MessageBoxButtons.RetryCancel);
                    return;
            }
           
            
            amount_client amount_Client = new amount_client();
            db_amount_client = new DataClasses1DataContext();

            List<store_log> list_store_Log = new List<store_log>();
            db_store_Log = new DataClasses1DataContext();

            
                amount_Client = new amount_client();
                db_store_Log.store_logs.DeleteAllOnSubmit(db_store_Log.store_logs.Where(x => x.Source_Id == invoiceHeader.id).ToList());
            
            setdata();
            try
            {
                db.SubmitChanges();
            }
            catch
            {
                MyMessageBox.showMessage("خطاء", "حدث خطاء ما .. ربما حدث نغير في البيانات .. برجاء اعادة المحاولة وقت لاحق", "", MessageBoxButtons.RetryCancel);
                return;
            }

            db_store_Log.SubmitChanges();

            for (int i = 0; i < gv_InvoiceDetails.Rows.Count; i++)
                gv_InvoiceDetails.Rows[i].Cells[nameof(invoiceDetail.InvoiceHeaderID)].Value = invoiceHeader.id;
            DBDetails.SubmitChanges();

            string _nots = ch_is_agel.Checked ? "بيان اسعار اجل" : "بيان اسعار نقدي ";
            amount_Client.id_type = 3;
            amount_Client.id_client = Session.ConvertInt(invoiceHeader.id_cient.ToString());
            amount_Client.amount_in = invoiceHeader.is_agel? 0: invoiceHeader.Net;
            amount_Client.amount_out = invoiceHeader.Net;
            amount_Client.nots = _nots;
            amount_Client.DateAdd = invoiceHeader.DateAdd;
            amount_Client.Source_Id = invoiceHeader.id;
            amount_Client.id_fara = invoiceHeader.id_fara;
            amount_Client.id_user = invoiceHeader.id_user;
            amount_Client.DateServer = Session.GetDate();
            db_amount_client.amount_clients.InsertOnSubmit(amount_Client);
            db_amount_client.SubmitChanges();

            foreach (DataGridViewRow item in gv_InvoiceDetails.Rows)
            {
                list_store_Log.Add(new store_log
                {
                    ItemID = Session.ConvertInt(item.Cells[nameof(invoiceDetail.ItemID)].Value.ToString()),
                    ItemQty_out = Session.Convertdecimal(item.Cells[nameof(invoiceDetail.ItemQty)].Value.ToString()),
                    nots =  _nots + " " + tx_name_cient.Text,
                    DateAdd = invoiceHeader.DateAdd,
                    Source_Id = invoiceHeader.id,
                    id_type = invoiceHeader.id_invoice_type,
                    store_id= Session.ConvertInt(item.Cells[nameof(invoiceDetail.store_id)].Value.ToString()),
                    id_fara = invoiceHeader.id_fara,
                    id_user = invoiceHeader.id_user,
            });
            }
            db_store_Log.store_logs.InsertAllOnSubmit(list_store_Log);
            db_store_Log.SubmitChanges();
            this.Close();
        }
        private void btn_find_client_Click(object sender, EventArgs e)
        {
            selct_sick _selct_Sick = new selct_sick();
            _selct_Sick.ShowDialog();
            if (_selct_Sick.retrnval() == 0)
                return;            
            tx_id_cient.Text = _selct_Sick.retrnval().ToString();
            get_client();
        }
        private void frm_kushufat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                btn_save.PerformClick();
            }
            if (e.KeyCode == Keys.Escape && updateid)
            {
                this.Close();
            }
        }
        void Get_total()
        {
            tx_Total_product.Text = Session.Convertdecimal(gv_InvoiceDetails.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDouble(t.Cells[nameof(invoiceDetail.Total)].Value)).ToString()).ToString("0.00");
            decimal total_product = Session.Convertdecimal(tx_Total_product.Text);

            if (dr_Extra_type.SelectedIndex == 0)
                tx_Extra.Text = (total_product * Session.Convertdecimal(tx_Extra_percent.Text) / 100).ToString("0.00");
            else
                tx_Extra.Text =Session.Convertdecimal(tx_Extra_percent.Text).ToString("0.00");

            if (dr_Discount_type.SelectedIndex == 0)
                tx_Discount.Text = (total_product * Session.Convertdecimal(tx_Discount_percent.Text) / 100).ToString("0.00");
            else
                tx_Discount.Text =Session.Convertdecimal( tx_Discount_percent.Text).ToString("0.00");

            decimal Discount = Session.Convertdecimal(tx_Discount.Text);
            decimal Extra = Session.Convertdecimal(tx_Extra.Text);
           
            tx_Net.Text =Math.Round(( (total_product + Extra - Discount) /1)*1).ToString("0.00");
        }
        
        
        
        private void tx_Discount_KeyPress(object sender, KeyPressEventArgs e)
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
            if ((e.KeyChar == '.') && (sender as TextBox).Text.IndexOf('.') > -1 )
            {
                e.Handled = true;
            }
        }
        private void tx_Discount_TextChanged(object sender, EventArgs e)
        {
            Get_total();
        }
        
       
        private void tx_Extra_percent_TextChanged(object sender, EventArgs e)
        {
            //if (dr_Extra_type.SelectedIndex == 0)
            //    tx_Extra.Text = (Session.Convertdecimal(tx_Total_product.Text) * Session.Convertdecimal(tx_Extra_percent.Text) / 100).ToString("0.00");
            //else
            //    tx_Extra.Text = Session.Convertdecimal(tx_Extra_percent.Text).ToString("0.00");
            Get_total();
        }
        private void tx_Discount_percent_TextChanged(object sender, EventArgs e)
        {
            //if (dr_Discount_type.SelectedIndex == 0)
            //    tx_Discount.Text = (Session.Convertdecimal(tx_Total_product.Text) * Session.Convertdecimal(tx_Discount_percent.Text) / 100).ToString("0.00");
            //else
            //    tx_Discount.Text =Session.Convertdecimal( tx_Discount_percent.Text).ToString("0.00");
            Get_total();
        }
       
        
        private void client_save_Click(object sender, EventArgs e)
        {
            if (Session.ConvertInt(tx_id_cient.Text) != 0)
            {
                Properties.Settings.Default.id_client = Session.ConvertInt(tx_id_cient.Text);
                Properties.Settings.Default.Save();
                lb_mas.Text = "تم تثبيت العميل عند البداء";
            }
            else
                lb_mas.Text = "يجب اضافة عميل اولا";
        }
        private void btn_client_un_save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.id_client = 0;
            Properties.Settings.Default.Save();
            lb_mas.Text = " تم ازالة تثبيت العميل عند البداء";
        }
        private void ch_is_agel_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_is_agel.Checked)
            {
                tx_Net.BackColor = Color.Red;
                ch_is_agel.BackColor = Color.Red;
                toolTip1.SetToolTip(bt_save_is_agel, "جعل الفاتورة اجل دائما عند انشاء بيان جديد");
            }
            else
            { 
                tx_Net.BackColor = Color.Green;
                ch_is_agel.BackColor = Color.Green;
                toolTip1.SetToolTip(bt_save_is_agel, "جعل الفاتورة نقدي دائما عند انشاء بيان جديد");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ch_is_agel = ch_is_agel.Checked;
            Properties.Settings.Default.Save();
            lb_mas.Text = toolTip1.GetToolTip(bt_save_is_agel);
        }
        
        
        private void gv_InvoiceDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            decimal ItemGvDiscount = Session.Convertdecimal(gv_InvoiceDetails.Rows[e.RowIndex].Cells[nameof(invoiceDetail.Discount)].Value.ToString());
            decimal ItemQty = Session.Convertdecimal(gv_InvoiceDetails.Rows[e.RowIndex].Cells[nameof(invoiceDetail.ItemQty)].Value.ToString());
            decimal price_sale = Session.Convertdecimal(gv_InvoiceDetails.Rows[e.RowIndex].Cells[nameof(invoiceDetail.Price)].Value.ToString());
            gv_InvoiceDetails.Rows[e.RowIndex].Cells[nameof(invoiceDetail.Price)].Value = price_sale;
            gv_InvoiceDetails.Rows[e.RowIndex].Cells[nameof(invoiceDetail.TotalPrice)].Value = (price_sale * ItemQty);
            gv_InvoiceDetails.Rows[e.RowIndex].Cells[nameof(invoiceDetail.Total)].Value = (price_sale * ItemQty) - ItemGvDiscount;
            Get_total();
        }
        private void gv_InvoiceDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            gv_InvoiceDetails.CancelEdit();
            e.Cancel = true;
        }
        private void dr_price_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(gv_InvoiceDetails.RowCount!=0)
            if (MyMessageBox.showMessage("تاكيد", "هل تريد تحديث  اسعار الاصناف المدرجة بناء علي قائمة الاسعار " + dr_price.Text + " ", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                for (int i = 0; i < gv_InvoiceDetails.Rows.Count; i++)
                {
                    int ItemID = Session.ConvertInt(gv_InvoiceDetails.Rows[i].Cells[nameof(invoiceDetail.ItemID)].Value.ToString());
                    decimal ItemGvDiscount = Session.Convertdecimal(gv_InvoiceDetails.Rows[i].Cells[nameof(invoiceDetail.Discount)].Value.ToString());
                    decimal ItemQty = Session.Convertdecimal(gv_InvoiceDetails.Rows[i].Cells[nameof(invoiceDetail.ItemQty)].Value.ToString());
                    product product = db.products.Where(x => x.id == ItemID).First();
                    decimal price_sale = Session.Convertdecimal(product.GetType().GetProperty(dr_price.SelectedValue.ToString()).GetValue(product, null).ToString());
                    gv_InvoiceDetails.Rows[i].Cells[nameof(invoiceDetail.Price)].Value = price_sale;
                    gv_InvoiceDetails.Rows[i].Cells[nameof(invoiceDetail.TotalPrice)].Value = (price_sale * ItemQty);
                    gv_InvoiceDetails.Rows[i].Cells[nameof(invoiceDetail.Total)].Value = (price_sale * ItemQty) - ItemGvDiscount;
                }
                Get_total();
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

        }

        private void btn_new_Click(object sender, EventArgs e)
        {

        }
    }
}
