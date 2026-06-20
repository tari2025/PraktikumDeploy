using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CRUDMahasiswaADO
{
    partial class FormMahasiswa
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblNIM = new System.Windows.Forms.Label();
            this.lblNama = new System.Windows.Forms.Label();
            this.lblJK = new System.Windows.Forms.Label();
            this.lblTanggalLahir = new System.Windows.Forms.Label();
            this.lblAlamat = new System.Windows.Forms.Label();
            this.lblProdi = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtNIM = new System.Windows.Forms.TextBox();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.cmbJK = new System.Windows.Forms.ComboBox();
            this.cmbProdi = new System.Windows.Forms.ComboBox();
            this.dtpTanggalLahir = new System.Windows.Forms.DateTimePicker();
            this.pictureBoxFoto = new System.Windows.Forms.PictureBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnResetData = new System.Windows.Forms.Button();
            this.btnTestInjection = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRekap = new System.Windows.Forms.Button();
            this.btnUploadFoto = new System.Windows.Forms.Button();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.grpButton = new System.Windows.Forms.GroupBox();
            this.btnImportDatabase = new System.Windows.Forms.Button();
            this.btnImportExcel = new System.Windows.Forms.Button();
            this.grpFoto = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).BeginInit();
            this.grpInput.SuspendLayout();
            this.grpButton.SuspendLayout();
            this.grpFoto.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 385);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(1140, 308);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1176, 31);
            this.bindingNavigator1.TabIndex = 1;
            this.bindingNavigator1.Text = "bindingNavigator1";
            this.bindingNavigator1.RefreshItems += new System.EventHandler(this.bindingNavigator1_RefreshItems);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(54, 26);
            this.bindingNavigatorCountItem.Text = "of {0}";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(34, 26);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(34, 26);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(34, 26);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(148, 31);
            this.bindingNavigatorPositionItem.Text = "0";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(34, 26);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(34, 26);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // lblNIM
            // 
            this.lblNIM.AutoSize = true;
            this.lblNIM.Location = new System.Drawing.Point(30, 46);
            this.lblNIM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNIM.Name = "lblNIM";
            this.lblNIM.Size = new System.Drawing.Size(42, 20);
            this.lblNIM.TabIndex = 2;
            this.lblNIM.Text = "NIM:";
            // 
            // lblNama
            // 
            this.lblNama.AutoSize = true;
            this.lblNama.Location = new System.Drawing.Point(30, 92);
            this.lblNama.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNama.Name = "lblNama";
            this.lblNama.Size = new System.Drawing.Size(55, 20);
            this.lblNama.TabIndex = 3;
            this.lblNama.Text = "Nama:";
            // 
            // lblJK
            // 
            this.lblJK.AutoSize = true;
            this.lblJK.Location = new System.Drawing.Point(30, 138);
            this.lblJK.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblJK.Name = "lblJK";
            this.lblJK.Size = new System.Drawing.Size(110, 20);
            this.lblJK.TabIndex = 4;
            this.lblJK.Text = "Jenis Kelamin:";
            // 
            // lblTanggalLahir
            // 
            this.lblTanggalLahir.AutoSize = true;
            this.lblTanggalLahir.Location = new System.Drawing.Point(30, 185);
            this.lblTanggalLahir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTanggalLahir.Name = "lblTanggalLahir";
            this.lblTanggalLahir.Size = new System.Drawing.Size(109, 20);
            this.lblTanggalLahir.TabIndex = 5;
            this.lblTanggalLahir.Text = "Tanggal Lahir:";
            // 
            // lblAlamat
            // 
            this.lblAlamat.AutoSize = true;
            this.lblAlamat.Location = new System.Drawing.Point(30, 231);
            this.lblAlamat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAlamat.Name = "lblAlamat";
            this.lblAlamat.Size = new System.Drawing.Size(63, 20);
            this.lblAlamat.TabIndex = 6;
            this.lblAlamat.Text = "Alamat:";
            // 
            // lblProdi
            // 
            this.lblProdi.AutoSize = true;
            this.lblProdi.Location = new System.Drawing.Point(30, 277);
            this.lblProdi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProdi.Name = "lblProdi";
            this.lblProdi.Size = new System.Drawing.Size(95, 20);
            this.lblProdi.TabIndex = 7;
            this.lblProdi.Text = "Nama Prodi:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(18, 708);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(144, 20);
            this.lblTotal.TabIndex = 9;
            this.lblTotal.Text = "Total Mahasiswa: 0";
            // 
            // txtNIM
            // 
            this.txtNIM.Location = new System.Drawing.Point(180, 42);
            this.txtNIM.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNIM.Name = "txtNIM";
            this.txtNIM.Size = new System.Drawing.Size(223, 26);
            this.txtNIM.TabIndex = 10;
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(180, 88);
            this.txtNama.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(298, 26);
            this.txtNama.TabIndex = 11;
            // 
            // txtAlamat
            // 
            this.txtAlamat.Location = new System.Drawing.Point(180, 226);
            this.txtAlamat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(298, 26);
            this.txtAlamat.TabIndex = 12;
            // 
            // cmbJK
            // 
            this.cmbJK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJK.Items.AddRange(new object[] {
            "L",
            "P"});
            this.cmbJK.Location = new System.Drawing.Point(180, 134);
            this.cmbJK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbJK.Name = "cmbJK";
            this.cmbJK.Size = new System.Drawing.Size(73, 28);
            this.cmbJK.TabIndex = 13;
            // 
            // cmbProdi
            // 
            this.cmbProdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProdi.Location = new System.Drawing.Point(180, 272);
            this.cmbProdi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbProdi.Name = "cmbProdi";
            this.cmbProdi.Size = new System.Drawing.Size(298, 28);
            this.cmbProdi.TabIndex = 14;
            // 
            // dtpTanggalLahir
            // 
            this.dtpTanggalLahir.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTanggalLahir.Location = new System.Drawing.Point(180, 180);
            this.dtpTanggalLahir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpTanggalLahir.Name = "dtpTanggalLahir";
            this.dtpTanggalLahir.Size = new System.Drawing.Size(223, 26);
            this.dtpTanggalLahir.TabIndex = 15;
            // 
            // pictureBoxFoto
            // 
            this.pictureBoxFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxFoto.Location = new System.Drawing.Point(30, 62);
            this.pictureBoxFoto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBoxFoto.Name = "pictureBoxFoto";
            this.pictureBoxFoto.Size = new System.Drawing.Size(179, 184);
            this.pictureBoxFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxFoto.TabIndex = 16;
            this.pictureBoxFoto.TabStop = false;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnConnect.Location = new System.Drawing.Point(15, 31);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(135, 46);
            this.btnConnect.TabIndex = 17;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLoad.Location = new System.Drawing.Point(165, 31);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(135, 46);
            this.btnLoad.TabIndex = 18;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(15, 92);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(135, 46);
            this.btnInsert.TabIndex = 19;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(165, 92);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(135, 46);
            this.btnUpdate.TabIndex = 20;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(15, 205);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(135, 46);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnResetData
            // 
            this.btnResetData.Location = new System.Drawing.Point(15, 154);
            this.btnResetData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnResetData.Name = "btnResetData";
            this.btnResetData.Size = new System.Drawing.Size(135, 46);
            this.btnResetData.TabIndex = 22;
            this.btnResetData.Text = "Reset Data";
            this.btnResetData.UseVisualStyleBackColor = true;
            this.btnResetData.Click += new System.EventHandler(this.btnResetData_Click);
            // 
            // btnTestInjection
            // 
            this.btnTestInjection.Location = new System.Drawing.Point(165, 154);
            this.btnTestInjection.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTestInjection.Name = "btnTestInjection";
            this.btnTestInjection.Size = new System.Drawing.Size(135, 46);
            this.btnTestInjection.TabIndex = 23;
            this.btnTestInjection.Text = "Test Injection";
            this.btnTestInjection.UseVisualStyleBackColor = true;
            this.btnTestInjection.Click += new System.EventHandler(this.btnTestInjection_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(158, 210);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(135, 46);
            this.btnRefresh.TabIndex = 24;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnRekap
            // 
            this.btnRekap.Location = new System.Drawing.Point(465, 31);
            this.btnRekap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRekap.Name = "btnRekap";
            this.btnRekap.Size = new System.Drawing.Size(135, 46);
            this.btnRekap.TabIndex = 25;
            this.btnRekap.Text = "Rekap";
            this.btnRekap.UseVisualStyleBackColor = true;
            this.btnRekap.Click += new System.EventHandler(this.btnRekap_Click);
            // 
            // btnUploadFoto
            // 
            this.btnUploadFoto.Location = new System.Drawing.Point(30, 262);
            this.btnUploadFoto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUploadFoto.Name = "btnUploadFoto";
            this.btnUploadFoto.Size = new System.Drawing.Size(120, 38);
            this.btnUploadFoto.TabIndex = 26;
            this.btnUploadFoto.Text = "Upload Foto";
            this.btnUploadFoto.UseVisualStyleBackColor = true;
            this.btnUploadFoto.Click += new System.EventHandler(this.btnUploadFoto_Click);
            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.lblNIM);
            this.grpInput.Controls.Add(this.txtNIM);
            this.grpInput.Controls.Add(this.lblNama);
            this.grpInput.Controls.Add(this.txtNama);
            this.grpInput.Controls.Add(this.lblJK);
            this.grpInput.Controls.Add(this.cmbJK);
            this.grpInput.Controls.Add(this.lblTanggalLahir);
            this.grpInput.Controls.Add(this.dtpTanggalLahir);
            this.grpInput.Controls.Add(this.lblAlamat);
            this.grpInput.Controls.Add(this.txtAlamat);
            this.grpInput.Controls.Add(this.lblProdi);
            this.grpInput.Controls.Add(this.cmbProdi);
            this.grpInput.Location = new System.Drawing.Point(18, 46);
            this.grpInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpInput.Name = "grpInput";
            this.grpInput.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpInput.Size = new System.Drawing.Size(525, 323);
            this.grpInput.TabIndex = 28;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Data Mahasiswa";
            // 
            // grpButton
            // 
            this.grpButton.Controls.Add(this.btnImportDatabase);
            this.grpButton.Controls.Add(this.btnImportExcel);
            this.grpButton.Controls.Add(this.btnConnect);
            this.grpButton.Controls.Add(this.btnLoad);
            this.grpButton.Controls.Add(this.btnInsert);
            this.grpButton.Controls.Add(this.btnUpdate);
            this.grpButton.Controls.Add(this.btnDelete);
            this.grpButton.Controls.Add(this.btnResetData);
            this.grpButton.Controls.Add(this.btnTestInjection);
            this.grpButton.Controls.Add(this.btnRefresh);
            this.grpButton.Controls.Add(this.btnRekap);
            this.grpButton.Location = new System.Drawing.Point(810, 46);
            this.grpButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpButton.Name = "grpButton";
            this.grpButton.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpButton.Size = new System.Drawing.Size(345, 323);
            this.grpButton.TabIndex = 30;
            this.grpButton.TabStop = false;
            this.grpButton.Text = "Aksi";
            // 
            // btnImportDatabase
            // 
            this.btnImportDatabase.Location = new System.Drawing.Point(158, 266);
            this.btnImportDatabase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnImportDatabase.Name = "btnImportDatabase";
            this.btnImportDatabase.Size = new System.Drawing.Size(142, 57);
            this.btnImportDatabase.TabIndex = 27;
            this.btnImportDatabase.Text = "Import To Database";
            this.btnImportDatabase.UseVisualStyleBackColor = true;
            this.btnImportDatabase.Click += new System.EventHandler(this.btnImportDatabase_Click);
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.btnImportExcel.Location = new System.Drawing.Point(15, 261);
            this.btnImportExcel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(135, 68);
            this.btnImportExcel.TabIndex = 26;
            this.btnImportExcel.Text = "Import From Excel";
            this.btnImportExcel.UseVisualStyleBackColor = true;
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // grpFoto
            // 
            this.grpFoto.Controls.Add(this.pictureBoxFoto);
            this.grpFoto.Controls.Add(this.btnUploadFoto);
            this.grpFoto.Location = new System.Drawing.Point(555, 46);
            this.grpFoto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpFoto.Name = "grpFoto";
            this.grpFoto.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpFoto.Size = new System.Drawing.Size(240, 323);
            this.grpFoto.TabIndex = 29;
            this.grpFoto.TabStop = false;
            this.grpFoto.Text = "Foto";
            // 
            // FormMahasiswa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 754);
            this.Controls.Add(this.grpButton);
            this.Controls.Add(this.grpFoto);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.bindingNavigator1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMahasiswa";
            this.Text = "Form Mahasiswa";
            this.Load += new System.EventHandler(this.FormMahasiswa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).EndInit();
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.grpButton.ResumeLayout(false);
            this.grpFoto.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // ==========================================
        // Deklarasi Komponen
        // ==========================================
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;

        private System.Windows.Forms.Label lblNIM;
        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.Label lblJK;
        private System.Windows.Forms.Label lblTanggalLahir;
        private System.Windows.Forms.Label lblAlamat;
        private System.Windows.Forms.Label lblProdi;
        private System.Windows.Forms.Label lblTotal;

        private System.Windows.Forms.TextBox txtNIM;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtAlamat;

        private System.Windows.Forms.ComboBox cmbJK;
        private System.Windows.Forms.ComboBox cmbProdi;

        private System.Windows.Forms.DateTimePicker dtpTanggalLahir;

        private System.Windows.Forms.PictureBox pictureBoxFoto;

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnResetData;
        private System.Windows.Forms.Button btnTestInjection;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnRekap;
        private System.Windows.Forms.Button btnUploadFoto;

        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.GroupBox grpFoto;
        private System.Windows.Forms.GroupBox grpButton;
        private System.Windows.Forms.Button btnImportDatabase;
        private System.Windows.Forms.Button btnImportExcel;

    }
}