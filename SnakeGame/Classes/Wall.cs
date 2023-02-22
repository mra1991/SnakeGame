using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeGame.Classes
{
    public class Wall : Cell
    {
        private static Image image = Image.FromFile("Wall.bmp");
        public Wall()
        {

        }
        public override void Draw(Graphics g, int x, int y)
        {
            g.DrawImage(image, x * CellWidth, y * CellWidth);
        }
        public override void IfEaten(out bool isLethal, out int lengthEffect, out int moneyEffect)
        {
            isLethal = true;
            lengthEffect = 0;
            moneyEffect = 0;
        }

    }
}
