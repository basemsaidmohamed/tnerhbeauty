using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tnerhbeauty
{
   public static class MyMessageBox
    {

       public static System.Windows.Forms.DialogResult showMessage(string caption,string message,string _color,System.Windows.Forms.MessageBoxButtons button)
       {
           System.Windows.Forms.DialogResult dlgResult = System.Windows.Forms.DialogResult.None;
           switch (button)
           {
               case System.Windows.Forms.MessageBoxButtons.OK:

                   using (frmMessageOk msgOk = new frmMessageOk(message, caption,_color))
                   {
                       dlgResult = msgOk.ShowDialog();
                   }
                   break;

               case System.Windows.Forms.MessageBoxButtons.YesNo:
                   using (frmMessageYesNo msgOk = new frmMessageYesNo(message, caption,_color))
                   {
                       dlgResult = msgOk.ShowDialog();
                   }
                   break;
               case System.Windows.Forms.MessageBoxButtons.RetryCancel:
                   using (frmMessageRetryCancel msgOk = new frmMessageRetryCancel(message, caption, _color))
                   {
                       dlgResult = msgOk.ShowDialog();
                   }
                   break;
           }
           return dlgResult;
       }
    }
}
