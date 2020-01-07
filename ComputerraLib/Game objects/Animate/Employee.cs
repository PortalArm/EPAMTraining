namespace ComputerraLib
{
    public abstract class Employee : GameObject
    {
        protected Employee(decimal salary, string name, bool mood, Point position) : base(position)
        {
            Salary = salary;
            Name = name;
            Mood = mood;
        }

        public decimal Salary { get; set; }
        public string Name { get; set; }
        public bool Mood { get; set; }
        public override bool IsAnimate { get; } = true;
        public void Say(string whatToSay) => Logger($"Name: {Name}, Role: {GetType()}, says: '{whatToSay}'", MessageType.ObjectLog);
        public abstract void Talk(Employee employee);

        public override string ToString() => $"{base.ToString()} {Name}";
    }

}
