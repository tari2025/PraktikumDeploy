using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System;
using OfficeOpenXml;
using System.IO;

namespace PrakMahasiswaADO
{
    public class MahasiswaData
    {
        public string Nama { get; set; }
        public string JenisKelamin { get; set; }
        public string Alamat { get; set; }
        public string NamaProdi { get; set; }
        public DateTime TanggalDaftar { get; set; }
    }
}
namespace CRUDMahasiswaADO
{


    partial class dsMahasiswa
    {
        partial class MahasiswaDataTable
        {
        }
    }
}
