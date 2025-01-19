using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace tnerhbeauty.Class
{
    public class datagrid: DataGridView
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        public  datagrid()
        {
            GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(this, true, null);
            CurrentCell = null;
           
        }
        protected override void OnCreateControl()
        {     
           

            RowTemplate.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
            RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(76, 194, 255);
            RowTemplate.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 30, 30);

            RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(76, 194, 255);

            ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(113, 96, 232);
            ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(113, 96, 232);
            ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
            ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(255, 255, 255);

            BackgroundColor = Color.FromArgb(255, 255, 255);
            GridColor = Color.Black;

         
          

            RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //AllowUserToAddRows = false;
            //AllowUserToDeleteRows = false;
            AllowUserToResizeColumns = false;
            AllowUserToResizeRows = false;
            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            //ColumnHeadersVisible = false;
            Cursor = Cursors.Hand;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            RowTemplate.Height = 30;
            ColumnHeadersHeight = 30;        
            Margin = new Padding(0);
            //ScrollBars = ScrollBars.Both;
            MouseWheel += new MouseEventHandler(mousewheel);
            //EnableHeadersVisualStyles = false;
            //AutoGenerateColumns = false;



            BorderStyle = BorderStyle.Fixed3D;
            RowHeadersVisible = false;
            //AutoSize = true;


           

            base.OnCreateControl();
        }
        public void mousewheel(object sender, MouseEventArgs e)
        {
            int currentIndex = this.FirstDisplayedScrollingRowIndex;
            int scrollLines = SystemInformation.MouseWheelScrollLines;
            if (e.Delta > 0 && FirstDisplayedScrollingRowIndex > 0)
            {
                this.FirstDisplayedScrollingRowIndex = Math.Max(0, currentIndex - scrollLines);
            }
            else if (e.Delta < 0)
            {
                if (this.Rows.Count > (currentIndex + scrollLines))
                    this.FirstDisplayedScrollingRowIndex = currentIndex + scrollLines;
            }
        }
    }
    
   
}
