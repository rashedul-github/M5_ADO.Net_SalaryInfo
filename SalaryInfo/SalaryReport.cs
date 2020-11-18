using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryInfo
{
    public partial class SalaryReport : Form
    {
        public SalaryReport()
        {
            InitializeComponent();
        }

        public string Date {get;set;}
        private void SalaryReport_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter($"SELECT * FROM salarySheet WHERE [Date]='{this.Date}'",
                ConfigurationManager.ConnectionStrings["sal"].ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "salarySheet");

            SalaryRpt rpt = new SalaryRpt();
            rpt.SetDataSource(ds);
            rpt.SetParameterValue("date", this.Date);
            this.crystalReportViewer1.ReportSource = rpt;
            this.crystalReportViewer1.Refresh();
        }
    }
}
