using _3_TVDongNVHieuDXDuongNKHungDVKhaiLHDuc.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_TVDongNVHieuDXDuongNKHungDVKhaiLHDuc
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fm_DangNhap_NVHieu());
        }
    }
}
