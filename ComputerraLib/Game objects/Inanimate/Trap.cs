namespace ComputerraLib
{
    public class Trap : GameObject
    {
        public override bool IsAnimate { get; } = false;
        public bool IsFatal { get; }
        public Trap(Point position, bool isFatal = false) : base(position)
        {
            IsFatal = isFatal;
        }
    }
}
