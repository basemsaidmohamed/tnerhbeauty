
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
    public partial class Frm_CompanyInfo : Form
    {
        public Frm_CompanyInfo()
        {
            InitializeComponent();
        }
        private void frm_CompanyInfo_Load(object sender, EventArgs e)
        {
           
            GetData();
            this.ActiveControl = tx_hedar;
        }
         void Save()
        {
           if (string.IsNullOrEmpty(tx_Name.Text.Trim()))
            {
                errorProvider1.SetError(tx_Name, "برجاء ادخال بيان اسم الشركة");
                return;
            }
            DataClasses1DataContext db = new DataClasses1DataContext();
            company_info info = db.company_infos.FirstOrDefault();
            if (info == null)
            {
                info = new company_info(); 
                db.company_infos.InsertOnSubmit(info);
            }

            info.name = tx_Name.Text.ToUpper().Trim();
            info.tel = tx_Phone.Text;
            info.Specialized_in = tx_Specialized_in.Text;
            info.adress = tx_Address.Text;
            info.hedar = tx_hedar.Text.Trim().ToUpper();
            info.footer=tx_footer.Text;
            if (Img_Company.Image != null)
                info.image = Session.GetByteFromImage(Img_Company.Image);
            else info.image = null;
            db.SubmitChanges();
            lb_mas.Text = "تم الحفظ بنجاح";
        }
        void GetData()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            company_info info = db.company_infos.FirstOrDefault();
            if (info == null)
                return;
            tx_Name.Text = info.name;
            tx_Phone.Text = info.tel;
            tx_Specialized_in.Text = info.Specialized_in;
            tx_Address.Text = info.adress;
            tx_hedar.Text=info.hedar;
            tx_footer.Text = info.footer;   
            if (info.image != null)
                Img_Company.Image = Session.GetImageFromByteArray(info.image.ToArray());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Save();
            tx_hedar.Focus();
            tx_hedar.SelectAll();
            var mainForm = Application.OpenForms.OfType<home>().Single();
            mainForm.lb_company.Text= tx_hedar.Text.ToUpper();
            //if (Img_Company.Image != null)
                mainForm.Img_Company.Image = Img_Company.Image;

            Session.companyInfo = null;
        }
        private void img_prodct_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Title = "اختار صورة للصنف";
                    ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        Img_Company.Image = Image.FromFile(ofd.FileName);
                        Img_Company.Visible = true;
                        Img_Company.ErrorImage = null;
                    }
                }
            }
            catch
            {
            }
        }
        private void Frm_CompanyInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                bt_save.PerformClick();
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
        private void bt_re_pic_Click(object sender, EventArgs e)
        {
            if (Img_Company.Image == null)
                return;
            Image img = Img_Company.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            Img_Company.Image = img;
        }
        private void bt_clear_pic_Click(object sender, EventArgs e)
        {
            Img_Company.Image = null;
        }
    }
}
