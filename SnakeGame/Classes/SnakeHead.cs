using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeGame.Classes
{
public class SnakeHead : SnakePart
    {
        private static Image[] images = new Image[] {   Image.FromFile("Head_CloseMouth_FacingUp.bmp") ,
                                                        Image.FromFile("Head_CloseMouth_FacingDown.bmp"),
                                                        Image.FromFile("Head_CloseMouth_FacingLeft.bmp"),
                                                        Image.FromFile("Head_CloseMouth_FacingRight.bmp"),
                                                        Image.FromFile("Head_HalfOpenMouth_FacingUp.bmp"),
                                                        Image.FromFile("Head_HalfOpenMouth_FacingDown.bmp"),
                                                        Image.FromFile("Head_HalfOpenMouth_FacingLeft.bmp"),
                                                        Image.FromFile("Head_HalfOpenMouth_FacingRight.bmp"),
                                                        Image.FromFile("Head_OpenMouth_FacingUp.bmp"),
                                                        Image.FromFile("Head_OpenMouth_FacingDown.bmp"),
                                                        Image.FromFile("Head_OpenMouth_FacingLeft.bmp"),
                                                        Image.FromFile("Head_OpenMouth_FacingRight.bmp"),
        };
        private int mouthState = 0;
        public SnakeHead(Direction d) : base(d)
        {

        }
        public void Turn(Direction d)
        {
            this.Dir = d;
        }
        public override void Draw(Graphics g, int x, int y)
        {
            mouthState++;
            mouthState %= 3;
            switch (mouthState)
            {
                case 0:
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
                    break;
                case 1:
                    switch (this.Dir)
                    {
                        case Direction.Up:
                            g.DrawImage(images[4], x * CellWidth, y * CellWidth);
                            break;
                        case Direction.Down:
                            g.DrawImage(images[5], x * CellWidth, y * CellWidth);
                            break;
                        case Direction.Left:
                            g.DrawImage(images[6], x * CellWidth, y * CellWidth);
                            break;
                        case Direction.Right:
                            g.DrawImage(images[7], x * CellWidth, y * CellWidth);
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
                    switch (this.Dir)
                    {
                        case Direction.Up:
                            g.DrawImage(images[8], x * CellWidth, y * CellWidth);
                            break;
                        case Direction.Down:
                            g.DrawImage(images[9], x * CellWidth, y * CellWidth);
                            break;
                        case Direction.Left:
                            g.DrawImage(images[10], x * CellWidth, y * CellWidth);
                            break;
                        case Direction.Right:
                            g.DrawImage(images[11], x * CellWidth, y * CellWidth);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

        }
    }
}
