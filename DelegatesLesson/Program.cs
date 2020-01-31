using System;
using System.Windows.Forms;

namespace DelegatesLesson
{
    //internal delegate void Feedback(int value);
    internal sealed class DelegateIntro
    {
        internal delegate void Feedback(Int32 value);
        public static void Go()
        {
            StaticDelegateDemo();
        }

        private static void StaticDelegateDemo()
        {
            Console.WriteLine("----------Static delegate demo----------");
            Counter(1, 3, null);
            Counter(1, 3, new Feedback(FeedbackToConsole));
            Counter(1, 3, new Feedback(FeedbackToMsgBox));
            Console.WriteLine();
        }

        private static void Counter(int from, int to, Feedback p)
        {
            for (int val = from; val <= to; val++)
                p?.Invoke(val);
        }

        private static void FeedbackToMsgBox(int value)
        {
            MessageBox.Show("MsgBox = " + value);
        }

        private static void FeedbackToConsole(int value)
        {
            Console.WriteLine("ConsoleBox = " + value);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Account acc = new Account(5000);
            //acc.RegisterHandler(ShowMessage); 
            //acc.RegisterHandler(Console.WriteLine);
            //acc.Put(500);
            //acc.Withdraw(1200);
            //acc.Withdraw(int.MaxValue);
            DelegateIntro.Go();
            Console.ReadKey();
        }
        private static void ShowMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
