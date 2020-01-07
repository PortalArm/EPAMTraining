namespace ComputerraLib
{

    public enum Direction { Up, Right, Down, Left }
    public interface IMoveable
    {
        
        void Move(Point p);
        void Move(Direction dir);
    }

}
