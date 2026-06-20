namespace CRUDMahasiswaADO
{
    partial class RekapData
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblRekap = new System.Windows.Forms.Label();
            this.lblProdi = new System.Windows.Forms.Label();
            this.lblTahunMasuk = new System.Windows.Forms.Label();
            this.cmbProdi = new System.Windows.Forms.ComboBox();
            this.dtpTanggalMasuk = new System.Windows.Forms.DateTimePicker();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnCetak = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRekap
            // 
            this.lblRekap.AutoSize = true;
            this.lblRekap.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblRekap.Location = new System.Drawing.Point(250, 30);
            this.lblRekap.Name = "lblRekap";
            this.lblRekap.Size = new System.Drawing.Size(374, 37);
            this.lblRekap.TabIndex = 0;
            this.lblRekap.Text = "Rekap Data Mahasiswa";
            // 
            // lblProdi
            // 
            this.lblProdi.AutoSize = true;
            this.lblProdi.Location = new System.Drawing.Point(50, 100);
            this.lblProdi.Name = "lblProdi";
            this.lblProdi.Size = new System.Drawing.Size(45, 20);
            this.lblProdi.TabIndex = 1;
            this.lblProdi.Text = "Prodi";
            // 
            // lblTahunMasuk
            // 
            this.lblTahunMasuk.AutoSize = true;
            this.lblTahunMasuk.Location = new System.Drawing.Point(50, 150);
            this.lblTahunMasuk.Name = "lblTahunMasuk";
            this.lblTahunMasuk.Size = new System.Drawing.Size(105, 20);
            this.lblTahunMasuk.TabIndex = 2;
            this.lblTahunMasuk.Text = "Tahun Masuk";
            // 
            // cmbProdi
            // 
            this.cmbProdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProdi.FormattingEnabled = true;
            this.cmbProdi.Location = new System.Drawing.Point(170, 97);
            this.cmbProdi.Name = "cmbProdi";
            this.cmbProdi.Size = new System.Drawing.Size(250, 28);
            this.cmbProdi.TabIndex = 3;
            // 
            // dtpTanggalMasuk
            // 
            this.dtpTanggalMasuk.CustomFormat = "yyyy";
            this.dtpTanggalMasuk.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTanggalMasuk.Location = new System.Drawing.Point(170, 145);
            this.dtpTanggalMasuk.Name = "dtpTanggalMasuk";
            this.dtpTanggalMasuk.ShowUpDown = true;
            this.dtpTanggalMasuk.Size = new System.Drawing.Size(250, 26);
            this.dtpTanggalMasuk.TabIndex = 4;
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.LightBlue;
            this.btnLoad.Location = new System.Drawing.Point(470, 97);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(120, 35);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(50, 200);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(700, 200);
            this.dataGridView1.TabIndex = 6;
            // 
            // btnCetak
            // 
            this.btnCetak.BackColor = System.Drawing.Color.LightGreen;
            this.btnCetak.Location = new System.Drawing.Point(650, 420);
            this.btnCetak.Name = "btnCetak";
            this.btnCetak.Size = new System.Drawing.Size(100, 35);
            this.btnCetak.TabIndex = 7;
            this.btnCetak.Text = "Cetak";
            this.btnCetak.UseVisualStyleBackColor = false;
            this.btnCetak.Click += new System.EventHandler(this.btnCetak_Click);
            // 
            // RekapData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.btnCetak);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dtpTanggalMasuk);
            this.Controls.Add(this.cmbProdi);
            this.Controls.Add(this.lblTahunMasuk);
            this.Controls.Add(this.lblProdi);
            this.Controls.Add(this.lblRekap);
            this.Name = "RekapData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rekap Data Mahasiswa";
            this.Load += new System.EventHandler(this.RekapData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Deklarasi semua kontrol
        private System.Windows.Forms.Label lblRekap;
        private System.Windows.Forms.Label lblProdi;
        private System.Windows.Forms.Label lblTahunMasuk;
        private System.Windows.Forms.ComboBox cmbProdi;
        private System.Windows.Forms.DateTimePicker dtpTanggalMasuk;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCetak;
    }
}