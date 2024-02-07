using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace AsteroidDodger
{
    public abstract class Asset
    {
        public Point Center { get; set; }
        public Rectangle rect { get; set; }
        public int MoveX { get; set; } = 0;
        public int MoveY { get; set; }= 0;
        public abstract void Draw(PaintEventArgs e);
        public virtual void Move(int X1, int X2, int Y1, int Y2)
        {
            int newX = Center.X + MoveX;
            if (newX < X1)
            {
                newX = X1;
            }
            else if (newX > X2 - 100)
            {
                newX = X2 - 100;
            }

            int newY = Center.Y + MoveY;
            if (newY < Y1)
            {
                newY = Y1;
            }
            else if (newY > Y2 - 75)
            {
                newY = Y2 - 75;
            }
            Center = new Point(newX, newY);
        }
    }
}
