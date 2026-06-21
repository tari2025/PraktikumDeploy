using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace CRUDMahasiswaADO
{
    public partial class FormReport : Form
    {
        private string prodi;
        private int tahun;

        // Constructor dengan parameter
        public FormReport(string prodi, int tahun)
        {
            InitializeComponent();
            this.prodi = prodi;
            this.tahun = tahun;
            this.Load += FormReport_Load;
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            DataSet ds = null;

            try
            {
                ds = GetData();

                //MessageBox.Show("Jumlah Data: " + ds.Tables[0].Rows.Count);

                if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada data untuk ditampilkan");
                    return;
                }

                ReportDocument report = new ReportDocument();

                string reportPath = System.IO.Path.Combine(
                Application.StartupPath,
                "FormCrystalReport.rpt"
            );

                //MessageBox.Show("Path Report:\n" + reportPath);
               
                report.Load(reportPath);
                MessageBox.Show(
                "Report Path:\n" + reportPath +
                "\n\nFile Exists = " +
                System.IO.File.Exists(reportPath)
            );
                report.SetDataSource(ds.Tables[0]);

                crystalReportViewer1.ReportSource = report;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error:\n\n" + ex.ToString(),
                    "Crystal Report Error"
                );
            }
        }

        private DataSet GetData()
        {
            string connectionString = "Data Source=LAPTOP-6B5BO8RM\\SA;Initial Catalog=DBAkademikADO;Integrated Security=True";
            DataSet ds = new DataSet();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Report", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@inProdi", prodi);
                    cmd.Parameters.AddWithValue("@inTglMasuk", tahun.ToString());

                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds, "MahasiswaData");
                    }
                }
            }
            return ds;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}