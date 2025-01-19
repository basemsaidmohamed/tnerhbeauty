using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tnerhbeauty
{
    public partial class frmMessageOk : Form
    {
        public frmMessageOk(string Message, string Caption,string _color)
        {
            InitializeComponent();
            lp_caption.Text = Caption;
            lplMessage.Text = Message;
            //Timer tmr = new Timer();
            //tmr.Tick += delegate
            //{
            //    if(this.Opacity>0.0)
            //    {
            //        this.Opacity -= 0.025;
            //    }
            //    else
            //    {
            //        tmr.Stop();
            //        this.Close();
            //    }
            //};
            //tmr.Interval = (int)TimeSpan.FromSeconds(1).TotalMilliseconds;
            //tmr.Start();
        }
       
       
        private void btnOk_Click(object sender, EventArgs e)
        {
            
        }

        private void frmMessageOk_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

      

        private void frmMessageOk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnOk.PerformClick();
                //this.Close();

            }
        }

        private void frmMessageOk_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control btn = (Control)sender;
                btn.Capture = false;
                Message msg = Message.Create(this.Handle, 0XA1, new IntPtr(2), IntPtr.Zero);
                this.WndProc(ref msg);
            }
        }
       


       
    }
}
