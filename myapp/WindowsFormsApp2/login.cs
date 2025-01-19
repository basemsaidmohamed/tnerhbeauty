using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using tnerhbeauty.Class;
using tnerhbeauty.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace tnerhbeauty
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();           
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private  void login_Load(object sender, EventArgs e)
        {
            label3.Text = "Version : "+Application.ProductVersion;
            this.ActiveControl = tx_user_name;
            DataClasses1DataContext db = new DataClasses1DataContext();
            int id_user = Properties.Settings.Default.id_user;
            try
            {
                if (id_user != 0)
                    Session.User_login = db.user_Views.Where(x => x.id == id_user).FirstOrDefault();
                if (Session.User_login != null)
                {
                    home h = new home();
                    h.ShowDialog();
                    this.Close();
                }
            }
            catch {; };
            dr_data.SelectedIndex = -1;
        }
        private void bt_login_Click(object sender, EventArgs e)
        {
            if (dr_data.SelectedIndex == -1)
            {
                MyMessageBox.showMessage("خطاء", "برجاء اختيار المحافظة", "", MessageBoxButtons.RetryCancel);
                return;
            }
            string data = "";
            if (dr_data.SelectedIndex == 1)
                data = "x";
            string ConnectionString = String.Format(@"Data Source=41.38.119.3;Initial Catalog={0}DBBETTERLIFESERVER;User ID=ba;Password=ba;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False", data);
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConnectionStringsSection connectionStringsSection = (ConnectionStringsSection)configuration.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["tnerhbeauty.Properties.Settings.DBBETTERLIFE_MDF"].ConnectionString = ConnectionString;
            configuration.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
            Settings.Default.server = dr_data.Text;
            Settings.Default.Save();
            Settings.Default.Reload();
           
            try
            {
                if (Session._User_login(tx_user_name.Text, tx_pass.Text))
                {
                    this.Hide();
                    if (tx_pass.Text == "xxxxxx")
                    {
                        ChchangePassword chchangePassword = new ChchangePassword();
                        chchangePassword.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        if (ch_remper.Checked)
                            Properties.Settings.Default.id_user = Session.User_login.id;
                        else
                            Properties.Settings.Default.id_user = 0;

                        Properties.Settings.Default.Save();
                        home h = new home();
                        h.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    MyMessageBox.showMessage("خطاء", "اسم المستخدم او كلمة المرور خطاء", "", MessageBoxButtons.RetryCancel);
                    return;
                }
            }catch { MyMessageBox.showMessage("خطاء", "حدث خطاء اثناء الاتصال", "", MessageBoxButtons.RetryCancel); };
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frm_Connection h = new frm_Connection();
            h.ShowDialog();
        }
       

        
    }
}
