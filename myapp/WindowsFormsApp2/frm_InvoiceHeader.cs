
using Microsoft.Reporting.WinForms;
using System;

using System.Collections.Generic;

using System.Data;

using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using System.Text.RegularExpressions;

using System.Windows.Forms;

using tnerhbeauty.Class;
using tnerhbeauty.rport;


namespace tnerhbeauty
{
   
    public partial class frm_InvoiceHeader : Form
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        const int WM_PARENTNOTIFY = 0x210;
        const int WM_LBUTTONDOWN = 0x201;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN || (m.Msg == WM_PARENTNOTIFY &&
                (int)m.WParam == WM_LBUTTONDOWN))
                if (!tx_ItemName.ClientRectangle.Contains(tx_ItemName.PointToClient(Cursor.Position)) && !gvSerchProduct.ClientRectangle.Contains(gvSerchProduct.PointToClient(Cursor.Position)))
                {
                    gvSerchProduct.Hide();
                    if (Producselct == null || Producselct.fullname != tx_ItemName.Text)
                    {
                        tx_Price.Text = "";
                        tx_TotalPrice_ditals.Text = "";
                        tx_ItemName.Text = "";
                        tx_total_item.Text = "";
                        lb_balance.Text = "";
                        Producselct = null;
                    }
                }
            base.WndProc(ref m);
        }
        product_serch_View Producselct;
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
        decimal kilo=1;
        int client_save;
        static List<InvoiceDetail> InvoiceDetail_old;
        List<int> list = new List<int>();
        
        public frm_InvoiceHeader()
        {
            InitializeComponent();
            Initialize_class();
            GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(this, true, null);
        }
        public frm_InvoiceHeader(int id)
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
            InvoiceDetail_old = new List<InvoiceDetail>();
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
            list = storesUser.Select(x => x.id).Distinct().ToList();
            dr_store.IntializeData(storesUser, "store_name", "id");
        }
        private void frm_kushufat_Load(object sender, EventArgs e)
        {
            gvSerchProduct.DataSource = new List<product_serch_View>();

            gvSerchProduct.Columns[nameof(product_serch_View.name)].HeaderText = "اسم الصنف";
            gvSerchProduct.Columns[nameof(product_serch_View.price_sale)].HeaderText = "السعر";
            gvSerchProduct.Columns[nameof(product_serch_View.Balance)].HeaderText = "الكمية";
            gvSerchProduct.Columns[nameof(product_serch_View.store_name)].HeaderText = "المخزن";
            gvSerchProduct.Columns[nameof(product_serch_View.code)].HeaderText = "كود الصنف";

            gvSerchProduct.Columns[nameof(product_serch_View.name)].Width = 200;
            gvSerchProduct.Columns[nameof(product_serch_View.id)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.price_sale_100)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.price_sale_75)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.price_sale_vip2)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.price_sale_vip1)].Visible = false;

            gvSerchProduct.Columns[nameof(product_serch_View.price_1)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.price_2)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.price_3)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.price_4)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.price_5)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.price_6)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.price_7)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.price_8)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.price_9)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.price_10)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.is_stop)].Visible = false;
            //gvSerchProduct.Columns[nameof(product_serch_View.Balance)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.update_price)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.fullname)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.store_id)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.min_mum)].Visible = false;
            gvSerchProduct.AutoSize = true;
        
            ch_kilo.Checked = Properties.Settings.Default.ch_kilo;
            ch_auto_insert.Checked = Properties.Settings.Default.ch_auto_insert;
            ch_not_celar_ItemQty.Checked = Properties.Settings.Default.ch_not_celar_ItemQty;
            
            dr_price.IntializeData(Session.list_price, "name_row", "id");
            dr_discunt_item.SelectedIndex = Properties.Settings.Default.dr_discunt_item;
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

            gv_InvoiceDetails.Columns["deleteitem"].DisplayIndex = gv_InvoiceDetails.Columns.Count - 1;
            gv_InvoiceDetails.Columns["deleteitem"].Width = 38;

            gv_InvoiceDetails.CurrentCell = null;
            
        }
        void getdata()
        {
            Celar_add_proudct();
            tx_Balance.Text = "";
            tx_Balance_type.Text = "";
            tx_name_cient.Text = "";
            dr_store.SelectedIndex = -1;
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
                InvoiceDetail_old = bs.Cast<InvoiceDetail>().GroupBy(x => new { x.ItemID, x.store_id }).Select(cl => new InvoiceDetail
                {
                    ItemID = cl.First().ItemID,
                    ItemQty = (decimal?)cl.Sum(x => x.ItemQty) ?? 0,
                    store_id = cl.First().store_id,
                }).ToList();

                get_client();

                lp_titel.Text = "تعديل بيان اسعار";
                tx_DateAdd.Value = invoiceHeader.DateAdd;
                btn_print.Visible = true;
                updateid = true;
                btn_delete.Visible = Session.User_setting().delete_invoice_pay;                
                btn_save.Visible = Session.User_setting().update_invoice_pay;
            }
            else
            {
                ch_is_agel.Checked = Properties.Settings.Default.ch_is_agel;
                client_save = Properties.Settings.Default.id_client;
                if (client_save != 0)
                {
                    tx_id_cient.Text = client_save.ToString();
                    get_client();
                    if (tx_name_cient.Text == "")
                    {
                        Properties.Settings.Default.id_client = 0;
                        Properties.Settings.Default.Save();
                    }
                }
                lp_titel.Text = "بيان اسعار جديد";
                btn_delete.Visible = false;
                btn_print.Visible = false;

                btn_save.Visible = Session.User_setting().add_invoice_pay;
                btn_new.Visible = Session.User_setting().add_invoice_pay;
            }

            tx_ItemName.Focus();
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
            //if (dr_store.SelectedIndex == -1)
            //{
            //    errorProvider1.SetError(dr_store, "يجب اختيار مخزن");
            //    error++;
            //}
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

            if (invoiceHeader.id == 0)
            {
                db.InvoiceHeaders.InsertOnSubmit(invoiceHeader);
            }
            else
            {
                amount_Client = db_amount_client.amount_clients.Where(x => x.Source_Id == invoiceHeader.id).SingleOrDefault();
                db_amount_client.amount_clients.DeleteOnSubmit(amount_Client);
                db_store_Log.store_logs.DeleteAllOnSubmit(db_store_Log.store_logs.Where(x => x.Source_Id == invoiceHeader.id).ToList());
            }
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
                    nots = _nots + " " + tx_name_cient.Text,
                    DateAdd = invoiceHeader.DateAdd,
                    Source_Id = invoiceHeader.id,
                    id_type = invoiceHeader.id_invoice_type,
                    store_id = Session.ConvertInt(item.Cells[nameof(invoiceDetail.store_id)].Value.ToString()),
                    id_fara = invoiceHeader.id_fara,
                    id_user = invoiceHeader.id_user,
                });
            }
            db_store_Log.store_logs.InsertAllOnSubmit(list_store_Log);
            db_store_Log.SubmitChanges();
            if (updateid)
            {
                this.Close();
                return;
            }
            btn_new.PerformClick();
            lb_mas.Text = "تم حفظ البيانات بنجاح";
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
        private void btn_new_Click(object sender, EventArgs e)
        {
            Initialize_class();
            getdata();
            updateid = false;
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (MyMessageBox.showMessage("هل انت متاكد", "هل تريد حذف هذا البيان  .... ؟ ", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            db.InvoiceHeaders.DeleteOnSubmit(invoiceHeader);
            db.SubmitChanges();
            db_amount_client = new DataClasses1DataContext();
            amount_client amount_Client = db_amount_client.amount_clients.Where(x => x.Source_Id == invoiceHeader.id).FirstOrDefault();
            if (amount_Client != null)
            {
                db_amount_client.amount_clients.DeleteOnSubmit(amount_Client);
                db_amount_client.SubmitChanges();
            }
            this.Close();
        }
        private void btn_print_Click(object sender, EventArgs e)
        {
            List<ReportParameter> para = new List<ReportParameter>();
            string s = invoiceHeader.is_agel == true ? "اجل" : "نقدي";
            para.Add(new ReportParameter("P_titel", "بيان اسعار"+" "+s));
            DataClasses1DataContext data = new DataClasses1DataContext();
            ReportDataSource[] ReportDataSource = new ReportDataSource[]
            {
             new ReportDataSource("invoice", data.InvoiceHeaderViews.Where(x=>x.id==invoiceHeader.id).ToList()),
             new ReportDataSource("InvoiceDetails", data.InvoiceDetails_rep_Views.Where(x=>x.InvoiceHeaderID==invoiceHeader.id).ToList()),
            };
            frm_show_report _Report = new frm_show_report(para, "invoice", ReportDataSource, true);
            _Report.Show();
        }
        private void frm_kushufat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                btn_save.PerformClick();
            }
            if (e.KeyCode == Keys.F11)
            {
                btn_add_grid.PerformClick();
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
        }
        private void tx_ItemName_TextChanged(object sender, EventArgs e)
        {
            if (tx_id_cient.Text == "0" || dr_price.SelectedIndex == -1)
            {
                btn_find_client.PerformClick();
                return;

            }
            if (tx_ItemName.Text != "")
            {
                var data = from pr in db.product_serch_Views.OrderBy(x => x.name).Where(x => (x.Balance > 0) && (dr_store.SelectedIndex == -1 ?list.Contains((int)x.store_id): x.store_id == (int?)dr_store.SelectedValue ) && (x.name.Contains(tx_ItemName.Text.Replace_text()) || (x.code.Contains(tx_ItemName.Text))) && x.is_stop == false).OrderByDescending(x => x.name.StartsWith(tx_ItemName.Text.Replace_text())).Take(20).ToList().GroupBy(x => new { x.id, x.store_id })
                //var data = from pr in db.product_serch_Views.OrderBy(x => x.name).Where(x => (x.Balance > 0) && list.Contains((int)x.store_id) && (x.name.Contains(tx_ItemName.Text.Replace_text()) || (x.code.Contains(tx_ItemName.Text))) && x.is_stop == false).OrderByDescending(x => x.name.StartsWith(tx_ItemName.Text.Replace_text())).Take(20).ToList().GroupBy(x => new { x.id, x.store_id })
                               //var data = from pr in db.product_serch_Views.OrderBy(x => x.name).Where(x =>  (x.name.Contains(tx_ItemName.Text.Replace_text()) || (x.code.Contains(tx_ItemName.Text))) && x.is_stop == false).OrderByDescending(x => x.name.StartsWith(tx_ItemName.Text.Replace_text())).ToList().GroupBy(x =>new { x.id })
                 select new product_serch_View
                 {
                     id = pr.First().id,
                     name = pr.First().name,
                     fullname = pr.First().fullname,
                     price_sale = (decimal)pr.First().GetType().GetProperty(dr_price.SelectedValue.ToString()).GetValue(pr.First(), null),
                     code = pr.First().code,
                     Balance = pr.First().Balance,
                     store_name = pr.First().store_name,
                     store_id = pr.First().store_id,
                 };
                gvSerchProduct.DataSource = data.ToList();
                gvSerchProduct.Columns[nameof(product_serch_View.name)].Width = 200;
               if(dr_store.SelectedIndex != -1)
                    gvSerchProduct.Columns[nameof(product_serch_View.store_name)].Visible =false;
               else
                    gvSerchProduct.Columns[nameof(product_serch_View.store_name)].Visible = true;

                //gvSerchProduct.DataSource = db.product_serch_Views.OrderBy(x => x.name).Where(x => x.name.Contains(tx_ItemName.Text.Replace_text())|| (x.code.Contains(tx_ItemName.Text))).OrderByDescending(x => x.name.StartsWith(tx_ItemName.Text.Replace_text())).ToList();
                if (gvSerchProduct.Rows.Count == 0)
                    gvSerchProduct.Visible = false;
                else
                    gvSerchProduct.Visible = true;
            }
            else gvSerchProduct.Visible = false;
        }
        void Celar_add_proudct()
        {
           if( ch_not_celar_ItemQty.Checked == false)
            tx_ItemQty.Text = "";
            tx_Price.Text = "";
            tx_TotalPrice_ditals.Text = "";
            tx_ItemName.Text = "";
            tx_discunt_item.Text = "";
            tx_total_item.Text = "";
            lb_balance.Text = "";
            gv_InvoiceDetails.CurrentCell = null;
            Producselct = null;
            tx_ItemName.Focus();
        }
        private void ClickGridEnter()
        {
            if (tx_id_cient.Text == "0" || dr_price.SelectedIndex == -1)
            {
                gvSerchProduct.Visible = false;
                return;
            }
            if (gvSerchProduct.CurrentCell != null)
            {
                int index = gvSerchProduct.CurrentCell.RowIndex;
                Producselct = new product_serch_View();
                Producselct = (product_serch_View)gvSerchProduct.Rows[index].DataBoundItem;
                tx_Price.Text = Producselct.price_sale.ToString();
                tx_ItemName.Text = Producselct.fullname;
                lb_balance.Text = Producselct.Balance.ToString();
                dr_store.SelectedValue = Producselct.store_id;
                gvSerchProduct.Visible = false;
                tx_ItemQty_TextChanged(null, null);
                tx_ItemQty.Focus();
                tx_ItemQty.SelectAll();
                if (ch_auto_insert.Checked)
                {
                    btn_add_grid.PerformClick();
                }
            }
        }
        private void gvSerchProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ClickGridEnter();
        }
        private void tx_ItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                SendKeys.Send("{END}");
            if (e.KeyCode == Keys.Escape)
            {
                tx_ItemName.Text = "";
            }
            if (tx_ItemName.Text == "")
                return;
            if (gvSerchProduct.Rows.Count == 0)
                return;

            if (gvSerchProduct.CurrentCell == null)
                gvSerchProduct.CurrentCell = gvSerchProduct[1, 0]; ;

            if (e.KeyCode == Keys.Down)
            {
                int index = gvSerchProduct.CurrentCell.RowIndex;
                if (index != gvSerchProduct.Rows.Count - 1)
                {
                    if (gvSerchProduct.CurrentCell == null)
                        gvSerchProduct.CurrentCell = gvSerchProduct.Rows[0].Cells[nameof(product_serch_View.name)];
                    gvSerchProduct.CurrentCell = gvSerchProduct.Rows[index + 1].Cells[nameof(product_serch_View.name)];
                }
                SendKeys.Send("{END}");
            }
            else if (e.KeyCode == Keys.Up)
            {
                int index = gvSerchProduct.CurrentCell.RowIndex;
                if (index != 0)
                {
                    if (gvSerchProduct.CurrentCell == null)
                        gvSerchProduct.CurrentCell = gvSerchProduct.Rows[0].Cells[nameof(product_serch_View.name)];
                    gvSerchProduct.CurrentCell = gvSerchProduct.Rows[index - 1].Cells[nameof(product_serch_View.name)];
                }
                SendKeys.Send("{END}");
            }
            else if (e.KeyCode == Keys.Enter && gvSerchProduct.CurrentCell != null)
            {
                ClickGridEnter();
            }
        }
        private void gvSerchProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && gvSerchProduct.CurrentCell != null)
            {
                ClickGridEnter();
            }
        }
        private bool ValidAddGrid()
        {
            int err = 0;
            //if (tx_ItemQty.Text == "" || tx_ItemQty.Text == "0")
            //    tx_ItemQty.Text = "1";
            errorProvider1.Clear();
            if (dr_store.SelectedIndex == -1)
            {
                errorProvider1.SetError(dr_store, "يجب اختيار مخزن");
                err += 1;
            }

            if (Session.Convertdecimal(tx_ItemQty.Text) == 0)
            {
                errorProvider1.SetError(tx_ItemQty, "يجب ادخال كمية صحيحة");
                tx_ItemQty.Text = "";
                err += 1;
            }
            
            if (Producselct == null || Producselct.id == 0)
            {
                errorProvider1.SetError(tx_ItemName, "يجب اختيار صنف ");
                err +=1;
            }
            if (tx_Price.Text == "")
            {
                errorProvider1.SetError(tx_Price, "يجب اضافة سعر");
                err += 1;
            }
            if (string.IsNullOrEmpty(tx_total_item.Text.Trim()) || Session.ConvertDouble(tx_total_item.Text) <= 0)
            {
                errorProvider1.SetError(tx_total_item, "يجب ان تكون القيمة اكبر من صفر");
                err += 1;
            }
            
            return (err == 0);
        }
        private void btn_add_grid_Click(object sender, EventArgs e)
        {
            if (ValidAddGrid() == false)
                return;

            var Qty_old = InvoiceDetail_old.Where(x => x.ItemID == Producselct.id && x.store_id == Producselct.store_id ).Sum(x => x.ItemQty);
            var Qty = bs.Cast<InvoiceDetail>().Where(x => x.ItemID == Producselct.id && x.store_id == Producselct.store_id ).Sum(x => x.ItemQty);
            if (Session.Convertdecimal(tx_ItemQty.Text) / kilo +( Qty ) > Producselct.Balance + Qty_old)
            { 
                tx_ItemQty.SelectAll();
                tx_ItemQty.Focus();
                errorProvider1.SetError(tx_ItemQty, "الكمية المباعة اكبر من رصيد المخزن");
                return;
            }
            bs.Insert(0, new InvoiceDetail
            {
                InvoiceHeaderID = invoiceHeader.id,
                ItemID = Producselct.id,
                ItemQty = Convert.ToDecimal((Session.Convertdecimal(tx_ItemQty.Text) / kilo).ToString("0.000")),
                Price = Session.Convertdecimal(tx_Price.Text),
                TotalPrice = Session.Convertdecimal(tx_TotalPrice_ditals.Text),
                Discount = dr_discunt_item.SelectedIndex == 1 ? Session.Convertdecimal(tx_discunt_item.Text) : Session.Convertdecimal(tx_TotalPrice_ditals.Text) * Session.Convertdecimal(tx_discunt_item.Text) / 100,
                Total = Session.Convertdecimal(tx_total_item.Text),
                store_id = (int)Producselct.store_id
            });
            Celar_add_proudct();
            Get_total();
        }
        private void tx_ItemQty_TextChanged(object sender, EventArgs e)
        {
            decimal dis=0;
            if (dr_discunt_item.SelectedIndex == -1)
                dr_discunt_item.SelectedIndex=0;
            
                if(dr_discunt_item.SelectedIndex==0)
                dis = Session.Convertdecimal(tx_TotalPrice_ditals.Text) * Session.Convertdecimal(tx_discunt_item.Text) / 100;
                if (dr_discunt_item.SelectedIndex == 1)
                    dis =  Session.Convertdecimal(tx_discunt_item.Text);
            
                 
            tx_TotalPrice_ditals.Text = ((Session.Convertdecimal(tx_ItemQty.Text)/kilo * Session.Convertdecimal(tx_Price.Text))).ToString("0.00");
            tx_total_item.Text = (Session.Convertdecimal(tx_TotalPrice_ditals.Text) - dis).ToString("0.00");
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
        private void Gv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridViewColumn = gv_InvoiceDetails.Columns["deleteitem"];
            if (e.ColumnIndex == gv_InvoiceDetails.Columns.IndexOf(dataGridViewColumn) && e.RowIndex != -1)
            {
                if (MyMessageBox.showMessage("تاكيد", "هل متاكد من حذف السجل المحدد", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bs.RemoveAt(e.RowIndex);
                    Get_total();
                }
                else
                {
                    gv_InvoiceDetails.CurrentCell = null;
                    tx_ItemName.Focus();
                }
            }
        }
        private void tx_ItemQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void tx_ItemQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Session.ConvertDouble(tx_ItemQty.Text) > 0)
                {
                    tx_discunt_item.Focus();
                    tx_discunt_item.SelectAll();
                }
            }
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
        private void gv_InvoiceDetails_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MyMessageBox.showMessage("تاكيد", "هل متاكد من حذف السجل المحدد", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                e.Cancel = false;
                gv_InvoiceDetails.CurrentCell = null;
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void gv_InvoiceDetails_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
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
        private void tx_discunt_item_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Session.ConvertDouble(tx_ItemQty.Text) > 0)
                    btn_add_grid.PerformClick();
            }
        }
        private void tx_Price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Session.ConvertDouble(tx_Price.Text) > 0)
                {
                    tx_ItemQty.Focus();
                    tx_ItemQty.SelectAll();
                }
            }
        }
        private void ch_auto_insert_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_auto_insert.Checked)
            {
                ch_auto_insert.ForeColor = Color.Green;
            }
            else ch_auto_insert.ForeColor = Color.DimGray;
            Properties.Settings.Default.ch_auto_insert = ch_auto_insert.Checked;
            Properties.Settings.Default.Save();
            ck_txqty();
        }
        private void ch_kilo_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_kilo.Checked)
            {
                kilo = 1000;
                ch_kilo.ForeColor = Color.Green;
            }
            else 
            {
                kilo = 1; 
                ch_kilo.ForeColor = Color.DimGray;
            }
            Properties.Settings.Default.ch_kilo = ch_kilo.Checked;
            Properties.Settings.Default.Save();
            ck_txqty();
        }
        private void ch_not_celar_ItemQty_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_not_celar_ItemQty.Checked)
            {
                ch_not_celar_ItemQty.ForeColor = Color.Green;
            }
            else ch_not_celar_ItemQty.ForeColor = Color.DimGray;
            Properties.Settings.Default.ch_not_celar_ItemQty = ch_not_celar_ItemQty.Checked;
            Properties.Settings.Default.Save();
            ck_txqty();
        }
        private void ck_txqty()
        {
            if (tx_ItemName.Text == "")
                tx_ItemName.Focus();
            else
            {
                tx_ItemQty.Focus();
                tx_ItemQty.SelectAll();
            }
            tx_ItemQty_TextChanged(null, null);
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
        private void dr_discunt_item_SelectedIndexChanged(object sender, EventArgs e)
        {
            ck_txqty();
            Properties.Settings.Default.dr_discunt_item = dr_discunt_item.SelectedIndex;
            Properties.Settings.Default.Save();
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

        private void bt_celar_store_Click(object sender, EventArgs e)
        {
            dr_store.SelectedIndex = -1;
        }
    }
}
