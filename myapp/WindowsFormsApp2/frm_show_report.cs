using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;

namespace tnerhbeauty.rport
{
    public partial class frm_show_report : Form
    {

        public frm_show_report(List<ReportParameter> para, string name_repor, ReportDataSource[] dataSource,bool add_heder_para)
        {
            InitializeComponent();
            //this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\" + name_repor + ".rdlc";
            reportViewer1.LocalReport.ReportEmbeddedResource = nameof(tnerhbeauty) + "."+ name_repor + ".rdlc";


            if (para == null)
            {
                para = new List<ReportParameter>();
            }
            if (add_heder_para)
            {
                try
                {
                    para.Add(new ReportParameter("p_name", Class.Session.CompanyInfo.name));
                    para.Add(new ReportParameter("p_tel", Class.Session.CompanyInfo.tel));
                    para.Add(new ReportParameter("p_Specialized_in", Class.Session.CompanyInfo.Specialized_in));
                    para.Add(new ReportParameter("p_hedar", Class.Session.CompanyInfo.hedar));
                    para.Add(new ReportParameter("p_footer", Class.Session.CompanyInfo.footer));
                    para.Add(new ReportParameter("p_adress", Class.Session.CompanyInfo.adress));
                    para.Add(new ReportParameter("p_nots", Class.Session.CompanyInfo.nots));
                }
                catch { }
            }
            
            if(para.Count > 0) 
            this.reportViewer1.LocalReport.SetParameters(para);
            reropt_setting();
            this.reportViewer1.LocalReport.DataSources.Clear();
            foreach (ReportDataSource data in dataSource)
                this.reportViewer1.LocalReport.DataSources.Add(data);
           
            //for (int i = 0; i < dataSource.Length; i++)
            //    this.reportViewer1.LocalReport.DataSources.Add(dataSource[i]);
        }
        private void reropt_setting()
        {
            var ps = new System.Drawing.Printing.PageSettings();
            ps.PaperSize = new System.Drawing.Printing.PaperSize("A4(297 x 210 mm)", 827, 1169);
            ps.PaperSize.RawKind = (int)PaperKind.A4;

            //ps.Landscape = true;
            ps.Margins.Top = 3;
            ps.Margins.Bottom = 3;
            ps.Margins.Left = 0;
            ps.Margins.Right = 0;
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.SetPageSettings(ps);
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.PageWidth;

        }
        private void frm_show_report_Load(object sender, EventArgs e)
        { 
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }
    }
}
