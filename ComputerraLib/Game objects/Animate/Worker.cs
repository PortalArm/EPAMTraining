using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerraLib
{
    public class Worker : Employee, IManagable
    {
        public Worker(decimal salary, string name, bool mood, Point position) : base(salary, name, mood, position)
        {
        }

        public override void Talk(Employee employee)
        {
            string talkString = string.Empty;
            if (employee is Worker)
                talkString = $"{Name} says 'Hello!' to {employee.Name}";
            else
                talkString = $"{Name} says 'Greetings!' to {employee.Name}";
            Logger(talkString, MessageType.ObjectLog);
        }
        public void DoWork()
        {
            Logger($"Worker '{Name}' is working in the mine.", MessageType.ObjectLog);
        }
    }

}
