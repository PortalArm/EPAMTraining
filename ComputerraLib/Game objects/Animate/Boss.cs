﻿namespace ComputerraLib
{
    public class Boss : Employee, IManage, IManagable
    {
        public Boss(decimal salary, string name, bool mood, Point position) : base(salary, name, mood, position)
        {
        }

        public void DoWork()
        {
            Logger($"Increasing salary to me :) (Boss '{Name}')", MessageType.ObjectLog);
            Salary *= 1.1m;
            Logger($"Boss {Name}'s salary increased to {Salary} ", MessageType.ObjectLog);
        }

        public virtual void Manage(IManagable managable)
        {
            if (managable is Worker)
                (managable as Worker).DoWork();
        }

        public override void Talk(Employee employee)
        {
            string talkString = string.Empty;
            if (employee is Boss)
                talkString = $"{Name} says 'Hello!' to {employee.Name}";
            else
                talkString = $"{Name} says 'Greetings!' to {employee.Name}";
            Logger(talkString, MessageType.ObjectLog);

        }
    }

}