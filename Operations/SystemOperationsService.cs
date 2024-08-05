using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace KeyboardOS.Operations
{
    public class SystemOperationsService
    {
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern int SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, uint dwFlags);

        public void OpenDownloadsFolder()
        {
            string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            Process.Start("explorer.exe", downloadsPath);
        }

        public void OpenRecycleBin()
        {
            Process.Start("explorer.exe", "::{645FF040-5081-101B-9F08-00AA002F954E}");
        }

        public void EmptyRecycleBin()
        {
            SHEmptyRecycleBin(IntPtr.Zero, null, 0);
        }
    }
}