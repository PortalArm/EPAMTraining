using System;

namespace ComputerraLib
{
    public abstract class GameObject : IMoveable
    {
        public abstract bool IsAnimate { get; }
        public Point Position { get; protected set; }
        public static void SetLogger(Action<string> act) => Logger = act;

        public void Move(Point p) => Position = p;
        public virtual void Move(Direction dir)
        {
            switch (dir)
            {
                case Direction.Down:
                    Move(new Point(Position.X, Position.Y + 1));
                    return;
                case Direction.Up:
                    Move(new Point(Position.X, Position.Y - 1));
                    return;
                case Direction.Left:
                    Move(new Point(Position.X - 1, Position.Y));
                    return;
                case Direction.Right:
                    Move(new Point(Position.X + 1, Position.Y));
                    return;
            }
        }

        public static Action<string> Logger { get; private set; } = Console.WriteLine;

        protected GameObject(Point pos)
        {
            Position = pos;
        }

        public override string ToString() => GetType().Name;
    }

}
