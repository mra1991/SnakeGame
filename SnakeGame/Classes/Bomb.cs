using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeGame.Classes
{
    public class Bomb : Cell
    {
        private static Image image = Image.FromFile("Bomb.bmp");
        public Bomb()
        {

        }
        public override void Draw(Graphics g, int x, int y)
        {
            g.DrawImage(image, x * CellWidth, y * CellWidth);
        }
        public override void IfEaten(out bool isLethal, out int lengthEffect, out int moneyEffect)
        {
            isLethal = false;
            lengthEffect = -1;
            moneyEffect = 0;
        }

    }
}
