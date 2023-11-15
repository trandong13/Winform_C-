using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Diagnostics.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Hoa_Don.report
{
    public partial class xemHoaDon : Form
    {
        List<Receipt> _list;
        string _ngay;
        string _tong;
        public xemHoaDon(List<Receipt> dataSource, string ngay, string tong)
        {
            InitializeComponent();
            _list = dataSource;
            _ngay = ngay;
            _tong = tong;
        }

        private void xemHoaDon_Load(object sender, EventArgs e)
        {
            ReceiptBindingSource.DataSource = _list;
            Microsoft.Reporting.WinForms.ReportParameter[] para = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("Ngay",_ngay),
                new Microsoft.Reporting.WinForms.ReportParameter("TongTien", _tong),
            };
            this.reportViewer1.LocalReport.SetParameters(para);
            this.reportViewer1.RefreshReport();
        }
    }
}
