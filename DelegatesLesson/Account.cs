using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Account
    {
        public delegate void AccountStateHandler(string message);
        AccountStateHandler _del;
        public void RegisterHandler(AccountStateHandler del) => _del += del;
        public void UnregisterHandler(AccountStateHandler del) => _del -= del;

        public int Sum { get; private set; }

        public Account(int sum)
        {
            Sum = sum;
        }
        public void Put(int sum) => Sum += sum;
        public void Withdraw(int sum)
        {
            if(_del != null)
            {
                if (sum <= Sum) { Sum -= sum; _del($"Сумма {sum} была снята со счета."); }
                else _del("Недостаточно денег на счету.");
            }
        }
    }
}
