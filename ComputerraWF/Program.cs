using System;
using System.Collections.Generic;
using System.Linq;
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
            Board board = new Board(20, 20);
            //board.AddObject(new Worker(555,"worker1",true, new Point(2,2)));
            //board.AddObject(new Worker(555,"worker2",true, new Point(2,4)));
            //board.Run(200);
            List<Worker> workers = new List<Worker>();
            int workersCount = 5;
            for (int i = 0; i < workersCount; ++i)
                workers.Add(board.GenerateObject<Worker>());


            //Console.WriteLine(board.FreeCells);
            //BigBoss bb = new BigBoss(325326, "Big boss", true, new Point(5, 10));
            //bb.Say("hi");
            //Console.ReadLine();
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}
