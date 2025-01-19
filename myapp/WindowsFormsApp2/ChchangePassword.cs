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
    public partial class ChchangePassword : Form
    {
        public ChchangePassword()
        {
            InitializeComponent();
        }
        bool valid()
        {
            errorProvider1.Clear();
            int error = 0;
            if (tx_pass_old.Text != Session.User_login.password)
            {
                errorProvider1.SetError(tx_pass_old, "كلمة المرور القديمة غير صحيحة");
                error++;
            }
            if (tx_pass.Text == "xxxxxx")
            {
                errorProvider1.SetError(tx_pass, "يجب استخدام كلمة مرور اخري");
                error++;
            }
            if (string.IsNullOrEmpty(tx_pass_old.Text))
            {
                errorProvider1.SetError(tx_pass_old, "يجب ادخال كلمة المرور القديمة");
                error++;
            }
            if (string.IsNullOrEmpty(tx_pass.Text))
            {
                errorProvider1.SetError(tx_pass, "يجب كتابة كلمة المرور الجديدة");
                error++;
            }
            if (string.IsNullOrEmpty(tx_re_pass.Text) )
            {
                errorProvider1.SetError(tx_re_pass, "يجب اعادة كتابة كلمة المرور الجديدة");
                error++;
            }
            if (tx_pass.Text != tx_re_pass.Text)
            {                
                errorProvider1.SetError(tx_re_pass, "كلمة المرور غير متطابق");
                error++;
            }
            
            return error == 0;
        }
        private void bt_login_Click(object sender, EventArgs e)
        {
            if (!valid())
                return;
            DataClasses1DataContext db = new DataClasses1DataContext();
            user u = new user();
            u = db.users.Where(x => x.id == Session.User_login.id).FirstOrDefault();
            u.password = tx_pass.Text;
            db.SubmitChanges();
            Session.User_login = db.user_Views.Where(x => x.id == Session.User_login.id).FirstOrDefault();
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChchangePassword_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
