using System;

namespace ComputerraLib
{
    public class Work : GameObject
    {
        public Work(Point pos) : base(pos)
        {
        }
        public override bool IsAnimate { get; } = false;
        public override void Move(Direction dir) => throw new InvalidOperationException();
    }
}
