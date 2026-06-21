using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;
using System.Net;           
using System.Net.Sockets;

namespace CRUDMahasiswaADO
{
    public class DAL
    {
        private static readonly string connectionString =
            "Data Source=LAPTOP-6B5BO8RM\\SA;Initial Catalog=DBAkademikADO;Integrated Security=True";

        private SqlConnection conn;

        public DAL()
        {
            conn = new SqlConnection(connectionString);
            ExcelPackage.License.SetNonCommercialPersonal("Nama Mahasiswa");
        }

        public string GetConnectionString()
        {
            return connectionString;
        }

        private void OpenConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        private void CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        // ==========================================
        // COUNT MAHASISWA
        // ==========================================
        public int CountMhs()
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Mahasiswa", conn);
                return (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error CountMhs: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        // ==========================================
        // GET ALL MAHASISWA
        // ==========================================
        public DataTable GetMhs()
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_GetMahasiswa", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error GetMhs: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        // ==========================================
        // GET MAHASISWA BY NIM
        // ==========================================
        public DataTable GetMhsByNIM(string nim)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_GetMahasiswaByNIM", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pNIM", nim);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error GetMhsByNIM: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        // ==========================================
        // INSERT MAHASISWA
        // ==========================================
        public void InsertMhs(string nim, string nama, string alamat, string jenisKelamin,
            DateTime tanggalLahir, string kodeProdi, byte[] foto)
        {
            try
            {
                OpenConnection();

                SqlCommand cmd = new SqlCommand("sp_InsertMahasiswa", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@pNIM", nim);
                cmd.Parameters.AddWithValue("@pNama", nama);
                cmd.Parameters.AddWithValue("@pAlamat", alamat);
                cmd.Parameters.AddWithValue("@pJenisKelamin", jenisKelamin);
                cmd.Parameters.AddWithValue("@pTanggalLahir", tanggalLahir);
                cmd.Parameters.AddWithValue("@pKodeProdi", kodeProdi);

                SqlParameter fotoParam = new SqlParameter("@pFoto", SqlDbType.VarBinary);
                fotoParam.Value = (foto != null) ? (object)foto : DBNull.Value;
                cmd.Parameters.Add(fotoParam);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error InsertMhs: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        // ==========================================
        // UPDATE MAHASISWA
        // ==========================================
        public void UpdateMhs(string nim, string nama, string alamat, string jenisKelamin,
            DateTime tanggalLahir, string kodeProdi, byte[] foto)
        {
            try
            {
                OpenConnection();

                SqlCommand cmd = new SqlCommand("sp_UpdateMahasiswa", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@pNIM", nim);
                cmd.Parameters.AddWithValue("@pNama", nama);
                cmd.Parameters.AddWithValue("@pAlamat", alamat);
                cmd.Parameters.AddWithValue("@pJenisKelamin", jenisKelamin);
                cmd.Parameters.AddWithValue("@pTanggalLahir", tanggalLahir);
                cmd.Parameters.AddWithValue("@pKodeProdi", kodeProdi);

                SqlParameter fotoParam = new SqlParameter("@pFoto", SqlDbType.VarBinary);
                fotoParam.Value = (foto != null) ? (object)foto : DBNull.Value;
                cmd.Parameters.Add(fotoParam);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    throw new Exception("Data dengan NIM " + nim + " tidak ditemukan!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error UpdateMhs: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        // ==========================================
        // DELETE MAHASISWA
        // ==========================================
        public void DeleteMhs(string nim)
        {
            try
            {
                OpenConnection();

                SqlCommand cmd = new SqlCommand("sp_DeleteMahasiswa", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pNIM", nim);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    throw new Exception("Data dengan NIM " + nim + " tidak ditemukan!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error DeleteMhs: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        // ==========================================
        // RESET DATA
        // ==========================================
        public void ResetData()
        {
            try
            {
                OpenConnection();

                SqlCommand cmdCheck = new SqlCommand(
                    "SELECT COUNT(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[mahasiswa_backup]') AND type in (N'U')",
                    conn);
                int backupExists = (int)cmdCheck.ExecuteScalar();

                if (backupExists == 0)
                {
                    throw new Exception("Tabel mahasiswa_backup tidak ditemukan! Buat backup terlebih dahulu.");
                }

                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    SqlCommand cmdDelete = new SqlCommand("DELETE FROM Mahasiswa", conn, transaction);
                    cmdDelete.ExecuteNonQuery();

                    SqlCommand cmdInsert = new SqlCommand(@"
                        INSERT INTO Mahasiswa (NIM, Nama, JenisKelamin, TanggalLahir, Alamat, KodeProdi, TanggalDaftar, Foto)
                        SELECT NIM, Nama, JenisKelamin, TanggalLahir, Alamat, KodeProdi, TanggalDaftar, Foto
                        FROM mahasiswa_backup",
                        conn, transaction);
                    cmdInsert.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error reset data: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error ResetData: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        // ==========================================
        // IMPORT EXCEL
        // ==========================================
        public void ImportExcel(string filePath)
        {
            try
            {
                ExcelPackage.License.SetNonCommercialPersonal("Nama Mahasiswa");

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets[0];

                    if (worksheet.Dimension == null)
                    {
                        throw new Exception("File Excel kosong atau tidak valid!");
                    }

                    int rowCount = worksheet.Dimension.Rows;

                    OpenConnection();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        int successCount = 0;
                        int errorCount = 0;

                        for (int row = 2; row <= rowCount; row++)
                        {
                            try
                            {
                                string nim = worksheet.Cells[row, 1].Text?.Trim();
                                string nama = worksheet.Cells[row, 2].Text?.Trim();
                                string alamat = worksheet.Cells[row, 3].Text?.Trim();
                                string jk = worksheet.Cells[row, 4].Text?.Trim();
                                string tanggalLahir = worksheet.Cells[row, 5].Text?.Trim();
                                string kodeProdi = worksheet.Cells[row, 6].Text?.Trim();

                                if (string.IsNullOrEmpty(nim) || string.IsNullOrEmpty(nama))
                                {
                                    errorCount++;
                                    continue;
                                }

                                string checkQuery = "SELECT COUNT(*) FROM Mahasiswa WHERE NIM = @NIM";
                                SqlCommand cmdCheck = new SqlCommand(checkQuery, conn, transaction);
                                cmdCheck.Parameters.AddWithValue("@NIM", nim);
                                int exists = (int)cmdCheck.ExecuteScalar();

                                if (exists > 0)
                                {
                                    string updateQuery = @"
                                        UPDATE Mahasiswa 
                                        SET Nama = @Nama, 
                                            Alamat = @Alamat, 
                                            JenisKelamin = @JK, 
                                            TanggalLahir = @TglLahir, 
                                            KodeProdi = @KodeProdi
                                        WHERE NIM = @NIM";

                                    SqlCommand cmdUpdate = new SqlCommand(updateQuery, conn, transaction);
                                    cmdUpdate.Parameters.AddWithValue("@NIM", nim);
                                    cmdUpdate.Parameters.AddWithValue("@Nama", nama);
                                    cmdUpdate.Parameters.AddWithValue("@Alamat", alamat ?? "");
                                    cmdUpdate.Parameters.AddWithValue("@JK", string.IsNullOrEmpty(jk) ? "L" : jk);
                                    cmdUpdate.Parameters.AddWithValue("@TglLahir",
                                        DateTime.TryParse(tanggalLahir, out DateTime tgl) ? tgl : DateTime.Now);
                                    cmdUpdate.Parameters.AddWithValue("@KodeProdi", string.IsNullOrEmpty(kodeProdi) ? "IF01" : kodeProdi);

                                    cmdUpdate.ExecuteNonQuery();
                                }
                                else
                                {
                                    string insertQuery = @"
                                        INSERT INTO Mahasiswa (NIM, Nama, Alamat, JenisKelamin, TanggalLahir, KodeProdi, TanggalDaftar)
                                        VALUES (@NIM, @Nama, @Alamat, @JK, @TglLahir, @KodeProdi, GETDATE())";

                                    SqlCommand cmdInsert = new SqlCommand(insertQuery, conn, transaction);
                                    cmdInsert.Parameters.AddWithValue("@NIM", nim);
                                    cmdInsert.Parameters.AddWithValue("@Nama", nama);
                                    cmdInsert.Parameters.AddWithValue("@Alamat", alamat ?? "");
                                    cmdInsert.Parameters.AddWithValue("@JK", string.IsNullOrEmpty(jk) ? "L" : jk);
                                    cmdInsert.Parameters.AddWithValue("@TglLahir",
                                        DateTime.TryParse(tanggalLahir, out DateTime tgl) ? tgl : DateTime.Now);
                                    cmdInsert.Parameters.AddWithValue("@KodeProdi", string.IsNullOrEmpty(kodeProdi) ? "IF01" : kodeProdi);

                                    cmdInsert.ExecuteNonQuery();
                                }

                                successCount++;
                            }
                            catch (Exception ex)
                            {
                                errorCount++;
                                System.Diagnostics.Debug.WriteLine($"Error row {row}: {ex.Message}");
                            }
                        }

                        transaction.Commit();

                        if (errorCount > 0)
                        {
                            throw new Exception($"Import selesai! {successCount} data berhasil, {errorCount} data gagal.");
                        }
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Import Excel: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        // ==========================================
        // IMPORT FROM DATABASE BACKUP
        // ==========================================
        public void ImportFromDatabase()
        {
            try
            {
                OpenConnection();

                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string checkBackup = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'mahasiswa_backup'";
                    SqlCommand cmdCheck = new SqlCommand(checkBackup, conn, transaction);
                    int backupExists = (int)cmdCheck.ExecuteScalar();

                    if (backupExists == 0)
                    {
                        throw new Exception("Tabel mahasiswa_backup tidak ditemukan!");
                    }

                    SqlCommand cmdDelete = new SqlCommand("DELETE FROM Mahasiswa", conn, transaction);
                    cmdDelete.ExecuteNonQuery();

                    SqlCommand cmdInsert = new SqlCommand("INSERT INTO Mahasiswa SELECT * FROM mahasiswa_backup", conn, transaction);
                    cmdInsert.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Import Database: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        // ==========================================
        // TEST INJECTION
        // ==========================================
        public void TestInject(string nim)
        {
            try
            {
                OpenConnection();

                string query = "UPDATE Mahasiswa SET Nama='HACKED' WHERE NIM='" + nim + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error TestInject: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        // ==========================================
        // INSERT LOG
        // ==========================================
        public void InsertLog(string message)
        {
            try
            {
                OpenConnection();

                string createTable = @"
                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LogActivity]') AND type in (N'U'))
                    BEGIN
                        CREATE TABLE LogActivity (
                            LogID int IDENTITY(1,1) PRIMARY KEY,
                            Pesan varchar(500),
                            Tanggal datetime DEFAULT GETDATE()
                        );
                    END";

                SqlCommand cmdCreate = new SqlCommand(createTable, conn);
                cmdCreate.ExecuteNonQuery();

                string insertLog = "INSERT INTO LogActivity (Pesan) VALUES (@psn)";
                SqlCommand cmdInsert = new SqlCommand(insertLog, conn);
                cmdInsert.Parameters.AddWithValue("@psn", message);
                cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error InsertLog: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        // ==========================================
        // GET PRODI
        // ==========================================
        public DataTable GetProdi()
        {
            try
            {
                OpenConnection();

                SqlCommand cmd = new SqlCommand("SELECT KodeProdi, NamaProdi FROM ProgramStudi", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error GetProdi: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        // ==========================================
        // GET DATA REKAP
        // ==========================================
        public DataTable GetDataRekap(string prodi, DateTime tanggalMasuk)
        {
            try
            {
                OpenConnection();

                SqlCommand cmd = new SqlCommand("sp_Report", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@inProdi", prodi);
                cmd.Parameters.AddWithValue("@inTglMasuk", tanggalMasuk.Year.ToString());

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error GetDataRekap: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        // ==========================================
        // GET ALL DATA CHART
        // ==========================================
        public DataTable GetAllDataChart()
        {
            try
            {
                OpenConnection();

                SqlCommand cmd = new SqlCommand("sp_DashBoard", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error GetAllDataChart: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        // ==========================================
        // GET DATA CHART BY TAHUN
        // ==========================================
        public DataTable GetDataChartByTahun(DateTime tahun)
        {
            DataTable dt = new DataTable();

            try
            {
                OpenConnection();

                SqlCommand cmd = new SqlCommand("sp_DashBoardByTahun", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@inTglMsuk", tahun.Year);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Error GetDataChartByTahun: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return dt;
        }

        // ==========================================
        // METHOD KOMPATIBILITAS (HURUF KECIL)
        // ==========================================
        public void updateMhs(string nim, string nama, string alamat, string jenisKelamin,
            DateTime tanggalLahir, string kodeProdi, byte[] foto)
        {
            UpdateMhs(nim, nama, alamat, jenisKelamin, tanggalLahir, kodeProdi, foto);
        }

        public void deleteMhs(string nim)
        {
            DeleteMhs(nim);
        }

        public void resetData()
        {
            ResetData();
        }

        public void testInject(string nim)
        {
            TestInject(nim);
        }

        public void insertLog(string message)
        {
            InsertLog(message);
        }

        public DataTable getProdi()
        {
            return GetProdi();
        }

        public DataTable getDataRekap(string prodi, DateTime tanggalMasuk)
        {
            return GetDataRekap(prodi, tanggalMasuk);
        }

        public DataTable getAllDataChart()
        {
            try
            {
                OpenConnection();

                SqlCommand cmd = new SqlCommand(
                    @"SELECT p.NamaProdi, COUNT(m.NIM) AS JmlhMhs
                      FROM Prodi p
                      LEFT JOIN Mahasiswa m ON p.KodeProdi = m.KodeProdi
                      GROUP BY p.NamaProdi
                      ORDER BY p.NamaProdi", conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getAllDataChart: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataTable getDataChartBytahun(DateTime thnMasuk)
        {
            return GetDataChartByTahun(thnMasuk);
        }
    }
}