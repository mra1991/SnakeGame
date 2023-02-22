using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SnakeGame.Classes;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        public static Snake snake = new Snake();
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!snake.IsDead)
            {
                snake.Advance();
                this.Invalidate();
                this.Text = "Snake -------------------------------------<< " + snake.ToString() + " >>---------------------------------------------";
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            snake.Draw(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1515, 820);
            this.Location = new Point(0, 0);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    snake.CurrentDirection = Direction.Up;
                    break;
                case Keys.Down:
                    snake.CurrentDirection = Direction.Down;
                    break;
                case Keys.Left:
                    snake.CurrentDirection = Direction.Left;
                    break;
                case Keys.Right:
                    snake.CurrentDirection = Direction.Right;
                    break;
                default:
                    break;
            }
        }
    }
}
