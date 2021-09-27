using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstructionDecoder
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CPU c = new CPU();
            string x6ANDx7INx0 = c.DecodeInstruction(30221);
            string x6ORx7INx0 = c.DecodeInstruction(30222);
            Console.WriteLine(x6ORx7INx0);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
