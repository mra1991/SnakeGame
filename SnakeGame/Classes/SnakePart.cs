using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeGame.Classes
{
    public class SnakePart : Cell
    {
        protected SnakePart(Direction d)
        {
            this.Dir = d;
        }

        public Direction Dir { get; protected set; }

        public override void IfEaten(out bool isLethal, out int lengthEffect, out int moneyEffect)
        {
            isLethal = true;
            lengthEffect = 0;
            moneyEffect = 0;
        }

    }
}
