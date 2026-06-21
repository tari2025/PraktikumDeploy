using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;



namespace CRUDMahasiswaADO
{
    partial class Dashboard
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartProdi = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblRekap = new System.Windows.Forms.Label();
            this.lblTahun = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnData = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dtpTanggalMasuk = new System.Windows.Forms.DateTimePicker();
            this.cmbTipe = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartProdi)).BeginInit();
            this.SuspendLayout();
            // 
            // chartProdi
            // 
            chartArea1.Name = "ChartArea1";
            this.chartProdi.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartProdi.Legends.Add(legend1);
            this.chartProdi.Location = new System.Drawing.Point(138, 89);
            this.chartProdi.Name = "chartProdi";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartProdi.Series.Add(series1);
            this.chartProdi.Size = new System.Drawing.Size(483, 300);
            this.chartProdi.TabIndex = 0;
            // 
            // lblRekap
            // 
            this.lblRekap.AutoSize = true;
            this.lblRekap.Location = new System.Drawing.Point(301, 9);
            this.lblRekap.Name = "lblRekap";
            this.lblRekap.Size = new System.Drawing.Size(178, 20);
            this.lblRekap.TabIndex = 1;
            this.lblRekap.Text = "Rekap Data Mahasiswa";
            // 
            // lblTahun
            // 
            this.lblTahun.AutoSize = true;
            this.lblTahun.Location = new System.Drawing.Point(45, 56);
            this.lblTahun.Name = "lblTahun";
            this.lblTahun.Size = new System.Drawing.Size(105, 20);
            this.lblTahun.TabIndex = 2;
            this.lblTahun.Text = "Tahun Masuk";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Red;
            this.btnReset.Location = new System.Drawing.Point(468, 39);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(116, 44);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnData
            // 
            this.btnData.BackColor = System.Drawing.Color.Yellow;
            this.btnData.Location = new System.Drawing.Point(648, 403);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(140, 35);
            this.btnData.TabIndex = 4;
            this.btnData.Text = "Data Mahasiswa";
            this.btnData.UseVisualStyleBackColor = false;
            this.btnData.Click += new System.EventHandler(this.btnDataMahasiswa_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.Chartreuse;
            this.btnLoad.Location = new System.Drawing.Point(368, 39);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(94, 44);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dtpTanggalMasuk
            // 
            this.dtpTanggalMasuk.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTanggalMasuk.Location = new System.Drawing.Point(152, 52);
            this.dtpTanggalMasuk.Name = "dtpTanggalMasuk";
            this.dtpTanggalMasuk.Size = new System.Drawing.Size(200, 26);
            this.dtpTanggalMasuk.TabIndex = 6;
            // 
            // cmbTipe
            // 
            this.cmbTipe.FormattingEnabled = true;
            this.cmbTipe.Location = new System.Drawing.Point(648, 39);
            this.cmbTipe.Name = "cmbTipe";
            this.cmbTipe.Size = new System.Drawing.Size(121, 28);
            this.cmbTipe.TabIndex = 7;
            this.cmbTipe.SelectedValueChanged += new System.EventHandler(this.cmbTipe_SelectedValueChanged);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbTipe);
            this.Controls.Add(this.dtpTanggalMasuk);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnData);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblTahun);
            this.Controls.Add(this.lblRekap);
            this.Controls.Add(this.chartProdi);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartProdi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartProdi;
        private System.Windows.Forms.Label lblRekap;
        private System.Windows.Forms.Label lblTahun;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnData;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DateTimePicker dtpTanggalMasuk;
        private System.Windows.Forms.ComboBox cmbTipe;
    }
}