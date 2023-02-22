using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeGame.Classes
{
    public enum Direction { Up, Down, Left, Right };
    public static class PointManipulator
    {
        private static Random random = new Random();
        public static void MovePoint(ref Point p,Direction d)
        {
            switch (d)
            {
                case Direction.Up:
                    p.Y--;
                    break;
                case Direction.Down:
                    p.Y++;
                    break;
                case Direction.Left:
                    p.X--;
                    break;
                case Direction.Right:
                    p.X++;
                    break;
                default:
                    break;
            }
        }
        public static Point GenerateRandomPoint(int width,int height)
        {
            return new Point(random.Next(1, width - 1), random.Next(1, height - 1));
        }
    }
}
