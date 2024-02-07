using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidDodger
{
    public partial class MainForm : Form
    {
        List<Asteroid> assests;
        SpaceShip ship;
        int collision = 0;
        int counter = 0;
        int score = 0;
        public MainForm()
        {
            InitializeComponent();
        }
        private void InitializeObjects()
        {
            int[] movement = { -5, -4, -3, -3, -2, -2, -1, -1 - 1, -1, -1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 4, 4, 5 };

            Random rand = new Random();
            assests = new List<Asteroid>();
            ship = new SpaceShip(new Point(550, 450));

            // You don't need to set a fixed number of asteroids.

            timerAsteroid.Interval = 15; // Adjust the interval based on your desired speed.

            int asteroidCount = 0;
            while (true) // This loop will generate asteroids continuously.
            {
                int x = rand.Next(100, 1100);
                int y = rand.Next(100, 500);
                int radius = rand.Next(20, 70);
                Asteroid asteroid = new Asteroid(new Point(x, y), radius);
                asteroid.MoveX = movement[rand.Next(0, movement.Length - 1)];
                asteroid.MoveY = movement[rand.Next(0, movement.Length - 1)];
                assests.Add(asteroid);
                asteroidCount++;

                if (asteroidCount >= 100) // You can change this number as needed.
                    break;
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            timerAsteroid.Interval= 15;
            timerAsteroid.Start();
            InitializeObjects();

            this.Size = new Size(1300, 900);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.BackColor = Color.Black;
            this.Paint += new PaintEventHandler(this.PaintObjects);
            DoubleBuffered = true;
        }

        private void PaintObjects(Object sender, PaintEventArgs e)
        {
               
            Rectangle rec = new Rectangle(100, 100, 1100, 700);
            e.Graphics.DrawRectangle(Pens.Beige, rec);

            Region clippingRegion = new Region(rec);
            e.Graphics.Clip= clippingRegion;


            ship.Draw(e);
            int assetIndex = assests.Count - 1;
            
            while (assetIndex > 0)
            {
                if (assests[assetIndex].Collision(ship))
                {
                    assests.RemoveAt(assetIndex);
                    collision++;
                }
                else
                {
                    assests[assetIndex].Draw(e);
                }
                assetIndex--;
            }

            e.Graphics.ResetClip();
            e.Graphics.DrawString("Score: " + score.ToString(), new Font("Arial", 30, FontStyle.Regular), Brushes.White, 100, 20     );
            e.Graphics.DrawString("Collision: " + collision.ToString(), new Font("Arial", 30, FontStyle.Italic), Brushes.LightGray, 700, 20);
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            ship.MoveX = 0;
            ship.MoveY = 0;
        }



        private void MainForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                ship.MoveX = -5;
            }
            if (e.KeyCode == Keys.Right)
            {
                ship.MoveX = 5;
            }
            if (e.KeyCode == Keys.Up)
            {
                ship.MoveY = -5;
            }
            if (e.KeyCode == Keys.Down)
            {
                ship.MoveY = 5; // Change -5 to 5 for the down arrow
            }
        }

        private void timerAsteroid_Tick(object sender, EventArgs e)
        {
            ship.Move(100, 1100, 100, 800);

            foreach(Asset a in assests)
            {
                a.Move(0, this.Size.Width, 0 ,this.Size.Height);
            }

            counter++;
            if(counter >= 60)
            {
                score++;
                counter= 0;
            }

            this.Refresh();
            
        }
    }
}
