namespace ComputerraLib
{
    public class BigBoss : Boss, IManage
    {
        public BigBoss(decimal salary, string name, bool mood, Point position) : base(salary, name, mood, position)
        {
        }

        public override void Manage(IManagable managable)
        {
            if (managable is Boss)
                (managable as Boss).DoWork();
        }

        public override void Talk(Employee employee)
        {
            string talkString;
            if (employee is BigBoss)
                talkString = $"{Name} says 'Hello!' to {employee.Name}";
            else
                talkString = $"{Name} says 'Greetings!' to {employee.Name}";
            Logger(talkString);
        }
    }

}
