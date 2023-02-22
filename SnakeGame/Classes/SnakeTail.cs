using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeGame.Classes
{
    public class SnakeTail : SnakePart
    {
        private static Image[] images = new Image[] {   Image.FromFile("Tail_Up.bmp") ,
                                                        Image.FromFile("Tail_Down.bmp"),
                                                        Image.FromFile("Tail_Left.bmp"),
                                                        Image.FromFile("Tail_Right.bmp"),
        };
        public SnakeTail(Direction d) : base(d)
        {

        }
        public void Turn(Direction d)
        {
            this.Dir = d;
        }
        public override void Draw(Graphics g, int x, int y)
        {
            switch (this.Dir)
            {
                case Direction.Up:
                    g.DrawImage(images[0], x * CellWidth, y * CellWidth);
                    break;
                case Direction.Down:
                    g.DrawImage(images[1], x * CellWidth, y * CellWidth);
                    break;
                case Direction.Left:
                    g.DrawImage(images[2], x * CellWidth, y * CellWidth);
                    break;
                case Direction.Right:
                    g.DrawImage(images[3], x * CellWidth, y * CellWidth);
                    break;
                default:
                    break;
            }

        }
    }
}
