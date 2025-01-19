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
    public partial class frmMessageYesNo : Form
    {
        public frmMessageYesNo(string Message, string Caption, string _color)
        {
            InitializeComponent();
            lp_caption.Text = Caption;
            lplMessage.Text = Message;

        }
       
       
        private void btnOk_Click(object sender, EventArgs e)
        {
            
        }

        private void frmMessageOk_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }
        private void frmMessageYesNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                //button2.PerformClick();
                this.Close();
            }
        }
        private void frmMessageYesNo_MouseDown(object sender, MouseEventArgs e)
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
