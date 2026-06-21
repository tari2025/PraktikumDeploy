using System;
using System.Windows.Forms;
using OfficeOpenXml;

namespace CRUDMahasiswaADO
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Set lisensi EPPlus
            ExcelPackage.License.SetNonCommercialPersonal("Nama Mahasiswa");
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Dashboard());
        }
    }
}