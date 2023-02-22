using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeGame.Classes
{
    public class Money : Cell
    {
        private static Image image = Image.FromFile("Money.bmp");
        public Money()
        {

        }
        public override void Draw(Graphics g, int x, int y)
        {
            g.DrawImage(image, x * CellWidth, y * CellWidth);
        }
        public override void IfEaten(out bool isLethal, out int lengthEffect, out int moneyEffect)
        {
            isLethal = false;
            lengthEffect = 0;
            moneyEffect = +1;
        }

    }
}
