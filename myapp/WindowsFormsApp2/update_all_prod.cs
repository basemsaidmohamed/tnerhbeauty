using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tnerhbeauty.Class;

namespace tnerhbeauty
{
    public partial class update_all_prod : Form
    {
        public update_all_prod()
        {
            InitializeComponent();
        }
        bool valid()
        {
            int error = 0;
            errorProvider1.Clear();
            if (dr_naspa_or_maunt.SelectedIndex==-1)
            {
                errorProvider1.SetError(dr_naspa_or_maunt, "اختيار اجباري");               
                error++;
            }
            
            if (dr_up_or_down.SelectedIndex == -1)
            {
                errorProvider1.SetError(dr_up_or_down, "اختيار اجباري");
                error++;
            }
            
            if (tx_nspa.Value==0 )
            {
                errorProvider1.SetError(tx_nspa, "يجب ادخال قيمة");
                error++;
            }
            
            return error == 0;
        }
        private void btn_update_price_Click(object sender, EventArgs e)
        {
           

            if (!valid())
                return;

            if (MyMessageBox.showMessage("تاكيد", "سيتم تعديل جميع الاصناف بالكامل", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                MyMessageBox.showMessage("رسالة", "تم الغاء العملية ", "", MessageBoxButtons.RetryCancel);
                return;
            }

            string blus = "";
            if (dr_up_or_down.SelectedIndex == 0)
                blus = "+";
            else blus = "-";

            DataClasses1DataContext db = new DataClasses1DataContext();
            //نقص مع نسبة
            if (dr_up_or_down.SelectedIndex == 1 && dr_naspa_or_maunt.SelectedIndex == 0)
                if (dr_price.SelectedIndex == -1)
                    db.ExecuteCommand("UPDATE product SET  update_price = GETDATE()" +
                        ", price_sale = ROUND(((price_sale * 100 /(100+" + tx_nspa.Value + ")))/5,0)*5" +
                        ", price_sale_100 = ROUND(((price_sale_100 * 100 /(100+" + tx_nspa.Value + ")))/5,0)*5" +
                        ", price_sale_75 = ROUND(((price_sale_75 * 100 /(100+" + tx_nspa.Value + ")))/5,0)*5" +
                        ", price_sale_vip2 = ROUND(((price_sale_vip2 * 100 /(100+" + tx_nspa.Value + ")))/5,0)*5" +
                        ", price_sale_vip1 = ROUND(((price_sale_vip1 * 100 /(100+" + tx_nspa.Value + ")))/5,0)*5" +
                        ", price_1  = ROUND(((price_1  * 100 /(100+" + tx_nspa.Value + ")))/5,0)*5" +
                        ", price_2  = ROUND(((price_2  * 100 /(100+" + tx_nspa.Value + ")))/5,0)*5" +
                        ", price_3  = ROUND(((price_3  * 100 /(100+" + tx_nspa.Value + ")))/5,0)*5" +
                        ", price_4  = ROUND(((price_4  * 100 /(100+" + tx_nspa.Value + ")))/5,0)*5" +
                        ", price_5  = ROUND(((price_5  * 100 /(100+" + tx_nspa.Value + ")))/5,0)*5" +
                        ", price_6  = ROUND(((price_6  * 100 /(100+" + tx_nspa.Value + ")))/5,0)*5" +
                        ", price_7  = ROUND(((price_7  * 100 /(100+" + tx_nspa.Value + ")))/5,0)*5" +
                        ", price_8  = ROUND(((price_8  * 100 /(100+" + tx_nspa.Value + ")))/5,0)*5" +
                        ", price_9  = ROUND(((price_9  * 100 /(100+" + tx_nspa.Value + ")))/5,0)*5" +
                        ", price_10 = ROUND(((price_10 * 100 /(100+" + tx_nspa.Value + ")))/5,0)*5", "");
                else
                    db.ExecuteCommand("UPDATE product SET  update_price = GETDATE(), " + dr_price.SelectedValue + " = ROUND(((" + dr_price.SelectedValue + " * 100 /(100+" + tx_nspa.Value + ")))/5,0)*5", "");

            else
            {
                if (dr_naspa_or_maunt.SelectedIndex == 0)
                {
                    if (dr_price.SelectedIndex == -1)
                        db.ExecuteCommand("UPDATE product SET  update_price = GETDATE()" +
                            ", price_sale = ROUND((price_sale + (price_sale * " + tx_nspa.Value + " / 100))/5,0)*5" +
                            ", price_sale_100 = ROUND((price_sale_100 + (price_sale_100 * " + tx_nspa.Value + " / 100))/5,0)*5" +
                            ", price_sale_75 = ROUND((price_sale_75 + (price_sale_75 * " + tx_nspa.Value + " / 100))/5,0)*5" +
                            ", price_sale_vip2 = ROUND((price_sale_vip2 + (price_sale_vip2 * " + tx_nspa.Value + " / 100))/5,0)*5" +
                            ", price_sale_vip1 = ROUND((price_sale_vip1 + (price_sale_vip1 * " + tx_nspa.Value + " / 100))/5,0)*5"+
                            ", price_1  = ROUND((price_1  + (price_1  * " + tx_nspa.Value + " / 100))/5,0)*5" +
                            ", price_2  = ROUND((price_2  + (price_2  * " + tx_nspa.Value + " / 100))/5,0)*5" +
                            ", price_3  = ROUND((price_3  + (price_3  * " + tx_nspa.Value + " / 100))/5,0)*5" +
                            ", price_4  = ROUND((price_4  + (price_4  * " + tx_nspa.Value + " / 100))/5,0)*5" +
                            ", price_5  = ROUND((price_5  + (price_5  * " + tx_nspa.Value + " / 100))/5,0)*5" +
                            ", price_6  = ROUND((price_6  + (price_6  * " + tx_nspa.Value + " / 100))/5,0)*5" +
                            ", price_7  = ROUND((price_7  + (price_7  * " + tx_nspa.Value + " / 100))/5,0)*5" +
                            ", price_8  = ROUND((price_8  + (price_8  * " + tx_nspa.Value + " / 100))/5,0)*5" +
                            ", price_9  = ROUND((price_9  + (price_9  * " + tx_nspa.Value + " / 100))/5,0)*5" +
                            ", price_10 = ROUND((price_10 + (price_10 * " + tx_nspa.Value + " / 100))/5,0)*5", "");
                    else
                        db.ExecuteCommand("UPDATE product SET  update_price = GETDATE(), " + dr_price.SelectedValue + " = ROUND((" + dr_price.SelectedValue + " + (" + dr_price.SelectedValue + " * " + tx_nspa.Value + " / 100))/5,0)*5", "");
                }
                else
                {
                    if (dr_price.SelectedIndex == -1)
                        db.ExecuteCommand("UPDATE product SET  update_price = GETDATE()" +
                            ", price_sale =ROUND((price_sale " + blus + " " + tx_nspa.Value + " )/5,0)*5" +
                            ", price_sale_100 =ROUND((price_sale_100 " + blus + " " + tx_nspa.Value + " )/5,0)*5" +
                            ", price_sale_75 =ROUND((price_sale_75 " + blus + " " + tx_nspa.Value + " )/5,0)*5" +
                            ", price_sale_vip2 =ROUND((price_sale_vip2 " + blus + " " + tx_nspa.Value + " )/5,0)*5" +
                            ", price_sale_vip1 =ROUND((price_sale_vip1 " + blus + " " + tx_nspa.Value + " )/5,0)*5" +
                            ", price_1  =ROUND((price_1  " + blus + " " + tx_nspa.Value + " )/5,0)*5" +
                            ", price_2  =ROUND((price_2  " + blus + " " + tx_nspa.Value + " )/5,0)*5" +
                            ", price_3  =ROUND((price_3  " + blus + " " + tx_nspa.Value + " )/5,0)*5" +
                            ", price_4  =ROUND((price_4  " + blus + " " + tx_nspa.Value + " )/5,0)*5" +
                            ", price_5  =ROUND((price_5  " + blus + " " + tx_nspa.Value + " )/5,0)*5" +
                            ", price_6  =ROUND((price_6  " + blus + " " + tx_nspa.Value + " )/5,0)*5" +
                            ", price_7  =ROUND((price_7  " + blus + " " + tx_nspa.Value + " )/5,0)*5" +
                            ", price_8  =ROUND((price_8  " + blus + " " + tx_nspa.Value + " )/5,0)*5" +
                            ", price_9  =ROUND((price_9  " + blus + " " + tx_nspa.Value + " )/5,0)*5" +
                            ", price_10 =ROUND((price_10 " + blus + " " + tx_nspa.Value + " )/5,0)*5" , "");
                    else
                        db.ExecuteCommand("UPDATE product SET  update_price = GETDATE(), " + dr_price.SelectedValue + " =ROUND((" + dr_price.SelectedValue + " " + blus + " " + tx_nspa.Value + " )/5,0)*5", "");

                }
            }
            db.SubmitChanges();
            MyMessageBox.showMessage("معلومات", "تم تحديث الاسعار بنجاح", "", MessageBoxButtons.OK);
        }

        private void update_all_prod_Load(object sender, EventArgs e)
        {
            dr_price.IntializeData(Session.list_price, "name_row", "id");
            dr_price.SelectedIndex = -1;
        }        
        private void dr_price_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lp_heder.Text = "سيتم تعديل  " + dr_price.Text + " ....!";
        }
    }
}
