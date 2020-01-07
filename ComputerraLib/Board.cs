using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ComputerraLib
{

    public class Board
    {
        private int _tick;
        public bool ExitThread { get; set; } = false;
        private const int _dayTickCount = 30;
        private readonly Random _random = new Random();

        public GameObject[,] Field { get; set; }
        public int Rows { get => Field.GetLength(0); }
        public int Cols { get => Field.GetLength(1); }
        public int FreeCells { get; private set; }

        public Board(int rows, int cols)
        {

            //Наверно, можно обойтись одним объектом для стен, т.к. с ними ничего нельзя сделать
            GameObject nullObject = new NullObject(Point.Unreachable);

            Field = new GameObject[rows, cols];
            for (int i = 0; i < rows; ++i)
            {
                Field[i, 0] = nullObject;//new NullObject();
                Field[i, Cols - 1] = nullObject;// new NullObject();
            }
            for (int i = 0; i < cols; ++i)
            {
                Field[0, i] = nullObject;//new NullObject();
                Field[Rows - 1, i] = nullObject;//new NullObject();
            }
            FreeCells = rows * cols - (rows * 2 + cols * 2 - 4);

        }


        private GameObject GetObjAtPos(int row, int col) => Field[row, col];
        private GameObject GetObjAtPos(Point pos) => GetObjAtPos(pos.Y, pos.X);
        private void SetObjAtPos(GameObject obj, Point pos)
        {
            Field[pos.Y, pos.X] = obj;
            FreeCells -= 1;
        }

        //public void AddObject(GameObject obj)
        //{
        //    if (FreeCells < 0)
        //        throw new InvalidOperationException("Out of cells.");

        //    if (!(GetObjAtPos(obj.Position) is null))
        //        throw new InvalidOperationException($"Cell {obj.Position} is occupied.");

        //    GameObject.Logger($"{obj} placed on {obj.Position}");
        //    SetObjAtPos(obj, obj.Position);

        //    //FreeCells -= 1;
        //}

        //public void AddObjectRange(IEnumerable<GameObject> objects)
        //{
        //    foreach (GameObject obj in objects)
        //        AddObject(obj);
        //}


        private void MoveObj(GameObject obj, Direction dir)
        {
            Point objectPos = obj.Position;
            RemoveObjAtPos(objectPos); // FreeCells -> +1
            obj.Move(dir);
            SetObjAtPos(obj, obj.Position); // FreeCells -> -1
            //GameObject.Logger($"Moved {obj} from {objectPos} to {obj.Position}");
            //FreeCells diff = 0
        }
        private bool IsPosInBounds(Point pos) => pos.X >= 0 && pos.Y >= 0 && pos.X < Cols && pos.Y < Rows;
        private bool AttemptMove(GameObject obj, Direction dir)
        {
            Point newPos = GetNewPos(obj, dir);
            if (!IsPosInBounds(newPos))
            {
                GameObject.Logger($"Can not move '{obj}' in {dir} direction (On the edge of the field).", MessageType.Error);
                return false;
            }
            if (!(GetObjAtPos(newPos) is null))
                Interact(obj, GetObjAtPos(newPos));
            else
                MoveObj(obj, dir);

            return true;

        }

        private Point GetNewPos(GameObject obj, Direction dir)
        {
            //Тупо, но работает
            Point oldPos = obj.Position;
            obj.Move(dir);
            Point newPos = obj.Position;
            obj.Move(oldPos);
            return newPos;
        }
        private void RemoveObjAtPos(int row, int col)
        {
            Field[row, col] = null;
            FreeCells += 1;
        }

        private void RemoveObjAtPos(Point pos) => RemoveObjAtPos(pos.Y, pos.X);
        private void Interact(GameObject sender, GameObject receiver)
        {
            //sender - [BigBoss, Boss, Customer, Worker]
            //receiver - [All]
            //sender -> Trap (done)
            //sender(IManagable [Boss, Worker]) -> Work (done)
            //sender(IManage [BigBoss, Customer]) -> 
            GameObject.Logger($"Interacting {sender} with {receiver}", MessageType.Interacting);
            
            if (!receiver.IsAnimate)
            {
                if(receiver is NullObject)
                    GameObject.Logger($"{sender} is staring at the wall.", MessageType.ObjectLog);
                else
                if (sender is IManagable && receiver is Work)
                {
                    (sender as IManagable).DoWork();
                    RemoveObjAtPos(receiver.Position);
                    GenerateObject<Work>();
                    //SpawnAtRandomPos(new Work(Point.Unreachable));
                }
                else
                if (receiver is Trap && (receiver as Trap).IsFatal)
                {
                    GameObject.Logger($"{sender} encountered a trap and died.", MessageType.ObjectLog);
                    RemoveObjAtPos(sender.Position);
                }
                return;
            }

            if (sender is Employee && receiver is Employee)
                (sender as Employee).Talk(receiver as Employee);

            if (sender is IManage && receiver is IManagable)
                (sender as IManage).Manage(receiver as IManagable);

        }

        public void SpawnAtRandomPos(GameObject obj)
        {
            if (FreeCells == 0)
            {
                GameObject.Logger($"Can not spawn more objects.", MessageType.Error);
                return;
            }
            //Поиск свободной ячейки
            int row = _random.Next(Rows),
                col = _random.Next(Cols);
            while (GetObjAtPos(row = _random.Next(Rows), col = _random.Next(Cols)) != null) ;
            Point newPos = new Point(col, row);
            obj.Move(newPos);
            SetObjAtPos(obj, newPos);
            GameObject.Logger($"{obj} placed on {obj.Position}", MessageType.Placing);
        }

        public event Action FieldUpdated;

        public void Run(int tickTimeMilliseconds, int dayCount = 16)
        {
            
            int dtc = dayCount;
            do
            {
                List<GameObject> listToProcess = new List<GameObject>();
                for (int i = 0; i < Rows; ++i)
                    for (int j = 0; j < Cols; ++j)
                    {
                        GameObject currObject = GetObjAtPos(i, j);
                        if (currObject != null && currObject.IsAnimate)
                            listToProcess.Add(currObject);
                    }

                foreach (GameObject current in listToProcess)
                {
                    if (_tick == dtc / 2 && current is Customer)
                        (current as Customer).AddTasks(12);

                    AttemptMove(current, (Direction)_random.Next(4));
                }
                FieldUpdated?.Invoke();
                Thread.Sleep(tickTimeMilliseconds);
            }
            while (++_tick < dtc && !ExitThread);
            //while (++_tick < _dayTickCount);
        }
        public T GenerateObject<T>() where T : GameObject
        {
            if (FreeCells <= 0)
            {
                GameObject.Logger("Can not generate more objects.", MessageType.Error);
                return null;
            }

            GameObject obj = null;
            if (typeof(T) == typeof(Worker))
                obj = new Worker(CtorValuesUtil.GetRandomSalary(), CtorValuesUtil.GetRandomName(), CtorValuesUtil.GetRandomMood(), Point.Unreachable);
            
            if (typeof(T) == typeof(BigBoss))
                obj = new BigBoss(CtorValuesUtil.GetRandomSalary(), CtorValuesUtil.GetRandomName(), CtorValuesUtil.GetRandomMood(), Point.Unreachable);
            else
            if (typeof(T) == typeof(Boss))
                obj = new Boss(CtorValuesUtil.GetRandomSalary(), CtorValuesUtil.GetRandomName(), CtorValuesUtil.GetRandomMood(), Point.Unreachable);

            if (typeof(T) == typeof(Customer))
                obj = new Customer(this, CtorValuesUtil.GetRandomName(), CtorValuesUtil.GetRandomMood(), Point.Unreachable);

            if (typeof(T) == typeof(Trap))
                obj = new Trap(Point.Unreachable, true);
            if (typeof(T) == typeof(Work))
                obj = new Work(Point.Unreachable);

            if (typeof(T) == typeof(NullObject))
                obj = new NullObject(Point.Unreachable);

            SpawnAtRandomPos(obj);
            
            return obj as T;
        }

    }
}
