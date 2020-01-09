using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComputerraLib;

namespace ComputerraWF
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var setupForm = new SetupForm();
            if(setupForm.ShowDialog() == DialogResult.OK)
            {
                int[] pars = setupForm.OutputParameters;
                setupForm.Dispose();
                Application.Run(new MainForm(pars[0], pars[1], pars[2], pars[3], pars[4], pars[5], pars[6], pars[7], pars[8], pars[9], pars[10]));
            }
        }
    }
}
