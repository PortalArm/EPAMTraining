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


            //Board board = new Board(20, 20);
            //List<Worker> workers = new List<Worker>();
            //int workersCount = 5;
            //for (int i = 0; i < workersCount; ++i)
            //    workers.Add(board.GenerateObject<Worker>());
            //GameObject.SetLogger((m, t) => { if (((MessageType.ObjectLog | MessageType.Placing)).HasFlag(t)) Console.WriteLine(m); });
            //board.Run(333, 32);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
