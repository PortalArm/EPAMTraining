namespace ComputerraLib
{
    public class NullObject : GameObject
    {
        public NullObject(Point pos) : base(pos)
        {
        }
        public override bool IsAnimate { get; } = false;
    }

}
