using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeGame.Classes
{
    public class SnakeBody : SnakePart
    {
        private static Image image = Image.FromFile("Body.bmp");
        public SnakeBody(Direction d) : base(d)
        {

        }
        public override void Draw(Graphics g, int x, int y)
        {
            g.DrawImage(image, x * CellWidth, y * CellWidth);
        }
    }
}
