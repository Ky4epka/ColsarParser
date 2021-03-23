using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColsarParser
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool created;
            Mutex context_locker = new Mutex(false, ProgramSettings.PARSER_EXECUTABLE_FILE, out created);

            if (!created)
            {
                context_locker.Dispose();
                MessageBox.Show("Программа уже запущена.");
                return;
            }
            context_locker.WaitOne();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fmMain(args));
            context_locker.ReleaseMutex();
            context_locker.Dispose();
        }
    }
}
