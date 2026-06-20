using System;
using System.Data;
using System.Windows.Forms;

namespace CRUDMahasiswaADO
{
    public partial class RekapData : Form
    {
        DAL dbLogic = new DAL();

        DataTable dtMahasiswa;
        DataTable dtProdi;

        public RekapData()
        {
            InitializeComponent();
        }

        private void RekapData_Load(object sender, EventArgs e)
        {
            dtpTanggalMasuk.Format = DateTimePickerFormat.Custom;
            dtpTanggalMasuk.CustomFormat = "yyyy";
            dtpTanggalMasuk.ShowUpDown = true;
            dtpTanggalMasuk.MinDate = new DateTime(2000, 1, 1);
            dtpTanggalMasuk.MaxDate = DateTime.Now;

            cmbProdi.DropDownStyle = ComboBoxStyle.DropDownList;

            btnCetak.Enabled = false;

            try
            {
                dtProdi = dbLogic.GetProdi();

                cmbProdi.DataSource = dtProdi;
                cmbProdi.DisplayMember = "NamaProdi";
                cmbProdi.ValueMember = "NamaProdi";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load data prodi: " + ex.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string prodi = cmbProdi.SelectedValue.ToString();
                DateTime tglMasuk = dtpTanggalMasuk.Value;

                dtMahasiswa = dbLogic.GetDataRekap(prodi, tglMasuk);

                dataGridView1.DataSource = dtMahasiswa;

                if (dtMahasiswa.Rows.Count > 0)
                {
                    btnCetak.Enabled = true;
                }
                else
                {
                    btnCetak.Enabled = false;
                    MessageBox.Show("Data tidak ditemukan");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load data: " + ex.Message);
            }
        }

        private void btnCetak_Click(object sender, EventArgs e)
        {
            try
            {
                string prodi = cmbProdi.SelectedValue.ToString();
                DateTime tglMasuk = dtpTanggalMasuk.Value;

                FormReport frm = new FormReport(prodi, tglMasuk.Year);
                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Cetak: " + ex.Message);
            }
        }
    }
}