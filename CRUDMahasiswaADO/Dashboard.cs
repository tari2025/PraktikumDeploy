using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CRUDMahasiswaADO
{
    public partial class Dashboard : Form
    {
        DAL dbLogic = new DAL();
        bool isInitializing = true;
        DataTable dt;
        int button = 0;

        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            dtpTanggalMasuk.MinDate = new DateTime(2000, 1, 1);
            dtpTanggalMasuk.Format = DateTimePickerFormat.Custom;
            dtpTanggalMasuk.CustomFormat = "yyyy";
            dtpTanggalMasuk.ShowUpDown = true;
            dtpTanggalMasuk.MaxDate = DateTime.Now;

            cmbTipe.DropDownStyle = ComboBoxStyle.DropDownList;

            var items = new List<KeyValuePair<string, SeriesChartType>>
            {
                new KeyValuePair<string, SeriesChartType>("Kolom", SeriesChartType.Column),
                new KeyValuePair<string, SeriesChartType>("Pie", SeriesChartType.Pie)
            };

            isInitializing = true;
            cmbTipe.DataSource = items;
            cmbTipe.DisplayMember = "Key";
            cmbTipe.ValueMember = "Value";
            cmbTipe.SelectedIndex = 0;
            isInitializing = false;

            loadDataChart();
        }

        public void loadDataChart()
        {
            try
            {
                chartProdi.Series.Clear();
                chartProdi.Titles.Clear();
                chartProdi.Legends.Clear();
                chartProdi.ChartAreas.Clear();

                ChartArea ca = new ChartArea("MainArea");
                ca.AxisX.Title = "Program Studi";
                ca.AxisY.Title = "Jumlah Mahasiswa";
                ca.AxisX.LabelStyle.Angle = -45;
                ca.BackColor = Color.Transparent;
                chartProdi.ChartAreas.Add(ca);

                if (button == 1)
                    dt = dbLogic.GetDataChartByTahun(dtpTanggalMasuk.Value);
                else
                    dt = dbLogic.GetAllDataChart();

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada data untuk ditampilkan", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SeriesChartType tipe = (SeriesChartType)cmbTipe.SelectedValue;

                Series s = new Series("Mahasiswa");
                s.ChartType = tipe;
                s.IsValueShownAsLabel = true;
                s.Label = "#VAL";

                foreach (DataRow row in dt.Rows)
                {
                    string prodi = row["NamaProdi"].ToString();
                    int jumlah = Convert.ToInt32(row["JmlMhs"]); // PAKAI JmlMhs
                    s.Points.AddXY(prodi, jumlah);
                }

                chartProdi.Series.Add(s);

                Title title = new Title(
                    "Jumlah Mahasiswa per Program Studi",
                    Docking.Top,
                    new Font("Arial", 14, FontStyle.Bold),
                    Color.DarkBlue);
                chartProdi.Titles.Add(title);

                Legend legend = new Legend("MainLegend");
                legend.Docking = Docking.Right;
                chartProdi.Legends.Add(legend);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load chart: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTipe_SelectedValueChanged(object sender, EventArgs e)
        {
            if (isInitializing) return;
            loadDataChart();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            button = 1;
            loadDataChart();
            MessageBox.Show("Data berhasil dimuat!", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            button = 0;
            loadDataChart();
            MessageBox.Show("Data berhasil direset!", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDataMahasiswa_Click(object sender, EventArgs e)
        {
            FormMahasiswa frm = new FormMahasiswa();
            frm.Show();
            this.Hide();
        }

        private void btnRekapData_Click(object sender, EventArgs e)
        {
            RekapData frm = new RekapData();
            frm.ShowDialog();
        }
    }
}