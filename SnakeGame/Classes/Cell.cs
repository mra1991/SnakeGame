using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeGame.Classes
{
    public class Cell
    {
        protected const int CellWidth = 20;
        public Cell()
        {

        }
        public virtual void Draw(Graphics g, int x, int y)
        {

        }
        public virtual void IfEaten(out bool isLethal, out int lengthEffect, out int moneyEffect)
        {
            isLethal = false;
            lengthEffect = 0;
            moneyEffect = 0;
        }
    }
}
