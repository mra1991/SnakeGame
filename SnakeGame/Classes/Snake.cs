using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeGame.Classes
{
    public class Snake
    {
        private const int GRID_WIDTH = 75, GRID_HEIGHT = 39;
        private Cell[,] theGrid = new Cell[GRID_WIDTH, GRID_HEIGHT];
        private SnakeHead head;
        private SnakeTail tail;
        private LinkedList<SnakeBody> body;
        private Point headPosition = new Point(10, 10), tailPosition = new Point(6, 10);
        private int cash = 0;
        public Direction CurrentDirection { get => this.head.Dir; set => this.head.Turn(value); }
        public bool IsDead { get; private set; }
        public int Length { get => body.Count; }
        
        public Snake()
        {

            this.head = new SnakeHead(Direction.Right);
            this.tail = new SnakeTail(Direction.Right);
            this.body = new LinkedList<SnakeBody>();
            for (int i = 0; i < 3; i++)
            {              
                this.body.AddLast(new SnakeBody(Direction.Right));
            }
            this.IsDead = false;
            this.InitializeGrid();
        }
        private void InitializeGrid()
        {
            for (int i = 0; i < GRID_WIDTH; i++)
            {
                this.theGrid[i, 0] = new Wall();
                this.theGrid[i, GRID_HEIGHT - 1] = new Wall();
            }
            for (int i = 1; i < GRID_HEIGHT - 1; i++)
            {
                this.theGrid[0, i] = new Wall();
                this.theGrid[GRID_WIDTH - 1, i] = new Wall();
            }
            DrawSnake();
            GenerateRandom(15, 10, 25, 35);
        }
        private void DrawSnake()
        {
            Point currentPoint = new Point(this.tailPosition.X, this.tailPosition.Y);
            this.theGrid[currentPoint.X, currentPoint.Y] = this.tail;
            PointManipulator.MovePoint(ref currentPoint, this.tail.Dir);
            foreach (var i in this.body)
            {
                this.theGrid[currentPoint.X, currentPoint.Y] = i;
                PointManipulator.MovePoint(ref currentPoint, i.Dir);
            }
            this.theGrid[currentPoint.X, currentPoint.Y] = this.head;
        }
        private void GenerateRandom(int bomb,int food,int money,int wall)
        {
            Point randomPoint = PointManipulator.GenerateRandomPoint(GRID_WIDTH, GRID_HEIGHT);
            for (int i = 0; i < bomb; i++)
            {
                while (this.theGrid[randomPoint.X, randomPoint.Y] != null)
                {
                    randomPoint = PointManipulator.GenerateRandomPoint(GRID_WIDTH, GRID_HEIGHT);
                }
                this.theGrid[randomPoint.X, randomPoint.Y] = new Bomb();
            }
            for (int i = 0; i < food; i++)
            {
                while (this.theGrid[randomPoint.X, randomPoint.Y] != null)
                {
                    randomPoint = PointManipulator.GenerateRandomPoint(GRID_WIDTH, GRID_HEIGHT);
                }
                this.theGrid[randomPoint.X, randomPoint.Y] = new Food();
            }
            for (int i = 0; i < money; i++)
            {
                while (this.theGrid[randomPoint.X, randomPoint.Y] != null)
                {
                    randomPoint = PointManipulator.GenerateRandomPoint(GRID_WIDTH, GRID_HEIGHT);
                }
                this.theGrid[randomPoint.X, randomPoint.Y] = new Money();
            }
            for (int i = 0; i < wall; i++)
            {
                while (this.theGrid[randomPoint.X, randomPoint.Y] != null)
                {
                    randomPoint = PointManipulator.GenerateRandomPoint(GRID_WIDTH, GRID_HEIGHT);
                }
                this.theGrid[randomPoint.X, randomPoint.Y] = new Wall();
            }
        }
        public void Advance()
        {
            Point nextPoint = new Point(this.headPosition.X, this.headPosition.Y);
            PointManipulator.MovePoint(ref nextPoint, this.CurrentDirection);
            bool isLethal = false;
            int moneyEffect = 0, lengthEffect = 0;
            if (this.theGrid[nextPoint.X, nextPoint.Y] != null)
                this.theGrid[nextPoint.X, nextPoint.Y].IfEaten(out isLethal, out lengthEffect, out moneyEffect);
            if (isLethal)
            {
                this.IsDead = true;
            }
            else
            {
                this.cash += moneyEffect;
                this.theGrid[nextPoint.X, nextPoint.Y] = this.head;
                this.body.AddLast(new SnakeBody(CurrentDirection));
                this.theGrid[headPosition.X, headPosition.Y] = this.body.Last.Value;
                this.headPosition = nextPoint;
                switch (lengthEffect)
                {
                    case +1:
                        break;
                    case 0:
                        this.Shrink();
                        break;
                    case -1:
                        this.Shrink();
                        this.Shrink();
                        break;
                    default:
                        break;
                }
                if (lengthEffect == +1)
                {
                    GenerateRandom(0, 1, moneyEffect, 0);
                }
                else if (lengthEffect == -1)
                {
                    GenerateRandom(1, 0, moneyEffect, 0);
                }
            }
        }
        public void Shrink()
        {
            if (this.Length > 0)
            {
                this.theGrid[tailPosition.X, tailPosition.Y] = null;
                PointManipulator.MovePoint(ref this.tailPosition, this.tail.Dir);
                this.tail.Turn(this.body.First.Value.Dir);
                this.body.RemoveFirst();
                this.theGrid[tailPosition.X, tailPosition.Y] = this.tail;
            }
            else
            {
                this.IsDead = true;
            }
        }

        public void Draw(Graphics g)
        {
            for (int i = 0; i < GRID_WIDTH; i++)
            {
                for (int j = 0; j < GRID_HEIGHT; j++)
                {
                    if (this.theGrid[i, j] != null)
                        this.theGrid[i, j].Draw(g, i, j);
                }
            }
        }
        public override string ToString()
        {
            return ("Length = " + this.Length + "   |   Cash = $" + this.cash);
        }
        public string Credits()
        {
            return "Snake by Mohammadreza Abolhassani";
        }

    }
}
