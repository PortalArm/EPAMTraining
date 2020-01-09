﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ComputerraLib
{

    public class Board
    {
        public bool ExitThread { get; set; } = false;
        private Dictionary<GameObject, GameObject> talkedTo;
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
        private void SetObjAtPos(GameObject obj)
        {
            Field[obj.Position.Y, obj.Position.X] = obj;
            FreeCells -= 1;
        }

        private void MoveObj(GameObject obj, Direction dir)
        {
            Point objectPos = obj.Position;
            RemoveObjAtPos(objectPos); // FreeCells -> +1
            obj.Move(dir);
            SetObjAtPos(obj); // FreeCells -> -1
            //GameObject.Logger($"Moved {obj} from {objectPos} to {obj.Position}");
            //FreeCells diff = 0
        }
        private bool IsPosInBounds(Point pos) => pos.X >= 0 && pos.Y >= 0 && pos.X < Cols && pos.Y < Rows;
        private void AttemptMove(GameObject obj, Direction dir)
        {
            Point newPos = GetNewPos(obj, dir);
            if (!IsPosInBounds(newPos))
            {
                GameObject.Logger($"Can not move '{obj}' in {dir} direction (On the edge of the field).", MessageType.Error);
                return;
            }
            if (!(GetObjAtPos(newPos) is null))
                Interact(obj, GetObjAtPos(newPos));
            else
                MoveObj(obj, dir);
        }
        private Point GetNewPos(GameObject obj, Direction dir)
        {
            //Тупо, но работает
            //Так, только в одном месте прописана логика перемещения объектов (Класс GameObject)
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
            GameObject.Logger($"Interacting {sender} with {receiver}", MessageType.Interacting);
            
            if (!receiver.IsAnimate)
            {
                if(receiver is NullObject)
                    GameObject.Logger($"{sender} is staring at the wall.", MessageType.InteractingWithNullObject);
                else
                if (sender is IManagable && receiver is Work)
                {
                    (sender as IManagable).DoWork();
                    RemoveObjAtPos(receiver.Position);
                    GenerateObject<Work>();
                }
                else
                if (receiver is Trap && (receiver as Trap).IsFatal)
                {
                    GameObject.Logger($"{sender} encountered a trap and died.", MessageType.InteractingWithTrap);
                    RemoveObjAtPos(sender.Position);
                }
                return;
            }

            if (sender is Employee && receiver is Employee)
            {
                //Если sender поприветствовал receiver, receiver поприветствует sender в ответ,
                //но если в одном ходу receiver захочет опять поздороваться, это нужно учесть.
                if(talkedTo.TryGetValue(sender, out GameObject rec) && rec == receiver)
                    return;

                (sender as Employee).Talk(receiver as Employee);
                (receiver as Employee).Talk(sender as Employee);
                talkedTo[receiver] = sender;

            }

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
            int row, col;
            while (GetObjAtPos(row = _random.Next(Rows), col = _random.Next(Cols)) != null) ;
            obj.Move(new Point(col, row));
            SetObjAtPos(obj);
            GameObject.Logger($"{obj} placed on {obj.Position}", MessageType.Placing);
        }

        public event Action FieldUpdated;

        public void Run(int tickTimeMilliseconds, int tickCount = 16)
        {
            int tick = 0;
            talkedTo = new Dictionary<GameObject, GameObject>();
            List<GameObject> listToProcess = new List<GameObject>();
            do
            {
                talkedTo.Clear();
                listToProcess.Clear();
                for (int i = 0; i < Rows; ++i)
                    for (int j = 0; j < Cols; ++j)
                    {
                        GameObject currObject = GetObjAtPos(i, j);
                        if (currObject != null && currObject.IsAnimate)
                            listToProcess.Add(currObject);
                    }
                
                foreach (GameObject current in listToProcess)
                {
                    if (tick == tickCount / 2 && current is Customer)
                        (current as Customer).AddTasks(12);

                    AttemptMove(current, (Direction)_random.Next(4));
                }

                FieldUpdated?.Invoke();
                GameObject.Logger($"Iteration {tick}", MessageType.SimulationInfo);
                Thread.Sleep(tickTimeMilliseconds);
            }
            while (++tick < tickCount && !ExitThread);
            GameObject.Logger("Finished simulation", MessageType.SimulationInfo);
        }
        public T GenerateObjectAt<T>(int x,int y) where T : GameObject
        {
            Point pos = new Point(x, y);
            if (GetObjAtPos(pos) != null){

                GameObject.Logger($"Can not generate object at {pos}", MessageType.Error);
                return null;
            }
            T tmp = GenerateObject<T>(false);
            tmp.Move(pos);
            SetObjAtPos(tmp);
            return tmp;
        }
        public T GenerateObject<T>(bool addToField = true) where T : GameObject
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

            if(addToField)
                SpawnAtRandomPos(obj);
            
            return obj as T;
        }

    }
}
