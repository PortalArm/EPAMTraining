namespace ComputerraLib
{
#pragma warning disable CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
#pragma warning disable CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
    public struct Point
#pragma warning restore CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
#pragma warning restore CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public static bool operator ==(Point p1, Point p2) => p1.X == p2.X && p1.Y == p2.Y;
        public static bool operator !=(Point p1, Point p2) => !(p1 == p2);

        public override string ToString() => $"{{{X}, {Y}}}";
        public static Point Unreachable { get; } = new Point(-1,-1); 
    }

}
