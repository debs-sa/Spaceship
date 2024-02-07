using System;
using System.Drawing;
using System.Windows.Forms;

namespace AsteroidDodger
{
    public class SpaceShip : Asset
    {
        public SpaceShip(Point center)
        {
            Center = center;
            rect = new Rectangle(center.X - 25, center.Y - 75, 50, 150);
        }

        public override void Draw(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Define colors
            Color rocketBodyColor = Color.Red;
            Color rocketTipColor = Color.Blue;
            Color rocketWindowColor = Color.Yellow;
            Color rocketFinsColor = Color.White;

            // Create pens and brushes
            Pen rocketPen = new Pen(Color.Black, 2);
            SolidBrush rocketBodyBrush = new SolidBrush(rocketBodyColor);
            SolidBrush rocketTipBrush = new SolidBrush(rocketTipColor);
            SolidBrush rocketWindowBrush = new SolidBrush(rocketWindowColor);
            SolidBrush rocketFinsBrush = new SolidBrush(rocketFinsColor);

            // Calculate the center of the rocket body
            int rocketCenterX = Center.X + 25; // Half of the rocket body's width
            int rocketCenterY = Center.Y + 75; // Half of the rocket body's height

            // Draw the rocket body
            Rectangle rocketBody = new Rectangle(Center.X, Center.Y, 50, 150);
            g.FillRectangle(rocketBodyBrush, rocketBody);
            g.DrawRectangle(rocketPen, rocketBody);


            // Draw the rocket tip
            Point[] rocketTip = new Point[] {
                new Point(rocketCenterX, rocketCenterY - 75),
                new Point(rocketCenterX + 25, rocketCenterY - 125),
                new Point(rocketCenterX - 25, rocketCenterY - 125)
            };
            g.FillPolygon(rocketTipBrush, rocketTip);
            g.DrawPolygon(rocketPen, rocketTip);

            // Draw the rocket fins
            g.FillRectangle(rocketFinsBrush, rocketCenterX - 25, rocketCenterY + 75, 10, 20);
            g.FillRectangle(rocketFinsBrush, rocketCenterX + 15, rocketCenterY + 75, 10, 20);
            g.DrawRectangle(rocketPen, rocketCenterX - 25, rocketCenterY + 75, 10, 20);
            g.DrawRectangle(rocketPen, rocketCenterX + 15, rocketCenterY + 75, 10, 20);

            // Draw the rocket windows
            g.FillEllipse(rocketWindowBrush, rocketCenterX - 10, rocketCenterY - 25, 20, 20);
            g.FillEllipse(rocketWindowBrush, rocketCenterX - 10, rocketCenterY + 5, 20, 20);
        }

        public override void Move(int X1, int X2, int Y1, int Y2)
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
    

