using System;
using System.Windows.Forms;
using KeyboardOS.Core;
using KeyboardOS.Operations;

namespace KeyboardOS
{
    static class Program
    {
        private static GlobalKeyboardHook _keyboardHook;
        private static SystemOperationsService _systemOperations;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _systemOperations = new SystemOperationsService();
            _keyboardHook = new GlobalKeyboardHook();
            _keyboardHook.KeyDown += OnKeyDown;

            Console.WriteLine("KeyboardOS is running. Press Ctrl+C to exit.");
            Application.Run(new ApplicationContext());
        }

        private static void OnKeyDown(object sender, KeyEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.LWin) != 0)
            {
                if (e.KeyCode == Keys.J)
                {
                    _systemOperations.OpenDownloadsFolder();
                    Console.WriteLine("Opening Downloads folder");
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    if ((Control.ModifierKeys & Keys.Shift) != 0)
                    {
                        _systemOperations.EmptyRecycleBin();
                        Console.WriteLine("Emptying Recycle Bin");
                    }
                    else
                    {
                        _systemOperations.OpenRecycleBin();
                        Console.WriteLine("Opening Recycle Bin");
                    }
                }
            }
        }
    }
}