namespace ComputerraLib
{
    public class Customer : GameObject, IManage
    {
        private readonly Board _board; 
        public Customer(Board board, string name, bool mood, Point position) : base(position)
        {
            _board = board;
            Name = name;
            Mood = mood;
        }
        public string Name { get; set; }
        public bool Mood { get; set; }
        public override bool IsAnimate { get; } = true;

        public void Manage(IManagable managable)
        {
            if (managable is Worker)
            {
                Logger($"{Name} forced {(managable as Worker).Name} to do following:");
                (managable as Worker).DoWork();
            }

        }

        public void AddTasks(int count)
        {
            if (count > _board.FreeCells)
            {
                Logger($"{Name} can't add {count} objects on field.");
                return;
            }
            for (int i = 0; i < count; ++i)
                _board.SpawnAtRandomPos(new Work(Point.Unreachable));

        }

        public void Talk(Employee employee)
        {
            string talkString = string.Empty;
            if (employee is BigBoss)
                talkString = $"{Name} says 'Hello!' to {employee.Name}";
            else
                talkString = $"{Name} says 'Greetings!' to {employee.Name}";
            Logger(talkString);
        }
        public override string ToString() => $"{base.ToString()} {Name}";
    }

}
