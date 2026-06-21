using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CRUDMahasiswaADO
{
    public partial class FormMahasiswa : Form
    {
        private DAL dbLogic = new DAL();
        private BindingSource bindingSource = new BindingSource();

        public FormMahasiswa()
        {
            InitializeComponent();
        }

        private void FormMahasiswa_Load(object sender, EventArgs e)
        {

            LoadData();
            LoadProdiCombo();
            bindingNavigator1.BindingSource = bindingSource;
            ClearForm();

            btnRekapData.Enabled = true;
            btnRekapData.Visible = true;

            btnImportExcel.Enabled = true;
            btnImportDatabase.Enabled = true;
            btnImportExcel.Visible = true;
            btnImportDatabase.Visible = true;
        }
        private void LoadProdiCombo()
        {
            try
            {
                DataTable dtProdi = dbLogic.getProdi();

                cmbProdi.DataSource = dtProdi;
                cmbProdi.DisplayMember = "NamaProdi";
                cmbProdi.ValueMember = "KodeProdi";
                cmbProdi.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load prodi: " + ex.Message);
            }
        }
        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Pilih File Excel";
            ofd.Filter = "Excel Files (*.xlsx)|*.xlsx";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dbLogic.ImportExcel(ofd.FileName);

                    MessageBox.Show(
                        "Data Excel berhasil diimport!",
                        "Sukses",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadData();   // refresh DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void LoadData()
        {
            try
            {
                bindingSource.DataSource = dbLogic.GetMhs();
                dataGridView1.DataSource = bindingSource;
                HitungTotal();
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormatDataGridView()
        {
            if (dataGridView1.Columns.Count > 0)
            {
                if (dataGridView1.Columns["Foto"] != null)
                    dataGridView1.Columns["Foto"].Visible = false;

                if (dataGridView1.Columns["NIM"] != null)
                    dataGridView1.Columns["NIM"].Width = 120;
                if (dataGridView1.Columns["Nama"] != null)
                    dataGridView1.Columns["Nama"].Width = 150;
                if (dataGridView1.Columns["JenisKelamin"] != null)
                    dataGridView1.Columns["JenisKelamin"].Width = 80;
                if (dataGridView1.Columns["TanggalLahir"] != null)
                    dataGridView1.Columns["TanggalLahir"].Width = 120;
                if (dataGridView1.Columns["Alamat"] != null)
                    dataGridView1.Columns["Alamat"].Width = 150;
                if (dataGridView1.Columns["NamaProdi"] != null)
                    dataGridView1.Columns["NamaProdi"].Width = 150;
            }
        }

        private void HitungTotal()
        {
            try
            {
                int total = dbLogic.CountMhs();
                lblTotal.Text = "Total Mahasiswa : " + total;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearForm()
        {
            txtNIM.Clear();
            txtNama.Clear();
            cmbJK.SelectedIndex = -1;
            txtAlamat.Clear();
            cmbProdi.SelectedIndex = -1;
            dtpTanggalLahir.Value = DateTime.Now;

            if (pictureBoxFoto != null)
                pictureBoxFoto.Image = null;

            txtNIM.Focus();
            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private byte[] GetFotoBytes()
        {
            byte[] fotoBytes = null;

            if (pictureBoxFoto != null && pictureBoxFoto.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBoxFoto.Image.Save(ms, pictureBoxFoto.Image.RawFormat);
                    fotoBytes = ms.ToArray();
                }
            }

            return fotoBytes;
        }

        private void SetFormFromDataGridView()
        {
            if (dataGridView1.CurrentRow != null)
            {
                DataRowView row = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;

                txtNIM.Text = row["NIM"].ToString();
                txtNama.Text = row["Nama"].ToString();
                cmbJK.Text = row["JenisKelamin"].ToString();
                txtAlamat.Text = row["Alamat"].ToString();

                if (row["TanggalLahir"] != DBNull.Value)
                    dtpTanggalLahir.Value = Convert.ToDateTime(row["TanggalLahir"]);

                if (row["NamaProdi"] != DBNull.Value)
                    cmbProdi.Text = row["NamaProdi"].ToString();

                if (row["Foto"] != DBNull.Value && row["Foto"] != null)
                {
                    byte[] fotoBytes = (byte[])row["Foto"];
                    if (fotoBytes.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(fotoBytes))
                        {
                            pictureBoxFoto.Image = Image.FromStream(ms);
                        }
                    }
                }

                btnInsert.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        // ========================================
        // EVENT HANDLER
        // ========================================

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string connString = dbLogic.GetConnectionString();
                MessageBox.Show("Koneksi Berhasil!\n\nConnection String: " + connString,
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi Gagal: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearForm();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNIM.Text))
                {
                    MessageBox.Show("NIM harus diisi!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNIM.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtNama.Text))
                {
                    MessageBox.Show("Nama harus diisi!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNama.Focus();
                    return;
                }

                if (cmbJK.SelectedIndex == -1)
                {
                    MessageBox.Show("Jenis Kelamin harus dipilih!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbJK.Focus();
                    return;
                }

                if (cmbProdi.SelectedIndex == -1)
                {
                    MessageBox.Show("Program Studi harus dipilih!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbProdi.Focus();
                    return;
                }

                // ✅ PAKAI FOTO
                dbLogic.InsertMhs(
                    txtNIM.Text,
                    txtNama.Text,
                    txtAlamat.Text,
                    cmbJK.Text,
                    dtpTanggalLahir.Value,
                    cmbProdi.SelectedValue.ToString(),
                    GetFotoBytes());

                MessageBox.Show("Data berhasil ditambahkan!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                dbLogic.insertLog($"Menambah data mahasiswa NIM: {txtNIM.Text}");

                ClearForm();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNIM.Text))
                {
                    MessageBox.Show("Pilih data yang akan diupdate!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ PAKAI FOTO
                dbLogic.UpdateMhs(
                    txtNIM.Text,
                    txtNama.Text,
                    txtAlamat.Text,
                    cmbJK.Text,
                    dtpTanggalLahir.Value,
                    cmbProdi.SelectedValue.ToString(),
                    GetFotoBytes());

                MessageBox.Show("Data berhasil diperbarui!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                dbLogic.insertLog($"Mengupdate data mahasiswa NIM: {txtNIM.Text}");

                ClearForm();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNIM.Text))
            {
                MessageBox.Show("Pilih data yang akan dihapus!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(
                $"Yakin ingin menghapus data mahasiswa NIM: {txtNIM.Text}?",
                "Konfirmasi Hapus",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    dbLogic.DeleteMhs(txtNIM.Text);

                    MessageBox.Show("Data berhasil dihapus!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dbLogic.insertLog($"Menghapus data mahasiswa NIM: {txtNIM.Text}");

                    ClearForm();
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnResetData_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Yakin ingin mereset semua data? Data akan dikembalikan ke backup!",
                "Konfirmasi Reset",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    dbLogic.resetData();

                    MessageBox.Show("Data berhasil direset!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dbLogic.insertLog("Merreset data mahasiswa");

                    LoadData();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTestInjection_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNIM.Text))
            {
                MessageBox.Show("Masukkan NIM untuk test injection!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(
                $"Yakin ingin melakukan test injection pada NIM: {txtNIM.Text}?\nNama akan diubah menjadi 'HACKED'",
                "Konfirmasi Test Injection",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    dbLogic.testInject(txtNIM.Text);

                    MessageBox.Show("SQL Injection berhasil dijalankan!\nNama mahasiswa telah diubah menjadi 'HACKED'",
                        "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dbLogic.insertLog($"Melakukan test injection pada NIM: {txtNIM.Text}");

                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearForm();
        }

        private void btnRekapData_Click(object sender, EventArgs e)
        {
            RekapData frm = new RekapData();
            frm.Show();
            this.Hide();
        }

        // ==========================================



        // ==========================================
        // IMPORT DATABASE
        // ==========================================
        private void btnImportDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                dbLogic.ImportFromDatabase();

                MessageBox.Show(
                    "Data berhasil diimport dari database backup!",
                    "Sukses",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error Import Database : " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnUploadFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Pilih Foto Mahasiswa";
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                ofd.FilterIndex = 1;
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBoxFoto.Image = Image.FromFile(ofd.FileName);
                        pictureBoxFoto.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error upload foto: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClearFoto_Click(object sender, EventArgs e)
        {
            pictureBoxFoto.Image = null;
            pictureBoxFoto.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                SetFormFromDataGridView();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SetFormFromDataGridView();
            }
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {
            // Handle navigator refresh
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            btnDelete_Click(sender, e);
        }

        private void grpInput_Enter(object sender, EventArgs e)
        {

        }
        
        private void grpFoto_Enter(object sender, EventArgs e)
        {

        }

        private void grpButton_Enter(object sender, EventArgs e)
        {

        }
    }
}