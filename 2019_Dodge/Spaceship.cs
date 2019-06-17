
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _2019_Dodge
{
    class Spaceship
    {
        // declare fields to use in the class
        //yeet

        public int x, y, width, height;//variables for the rectangle
        public Image spaceship;//variable for the planet's image

        public Rectangle spaceRec;//variable for a rectangle to place our image in

        //Create a constructor (initialises the values of the fields)
        public Spaceship()
        {
            x = 200;
            y = 330;
            width = 40;
            height = 40;
            spaceship = Image.FromFile("alien1.png");
            spaceRec = new Rectangle(x, y, width, height);
        }
        //methods
        public void drawSpaceship(Graphics g)
        {

            g.DrawImage(spaceship, spaceRec);
        }
        public void moveSpaceship(string move)
        {
            spaceRec.Location = new Point(x, y);

            if (move == "right")
            {
                if (spaceRec.Location.X > 450) // is spaceship within 50 of right side
                {

                    x = 420;
                    spaceRec.Location = new Point(x, y);
                }
                else
                {
                    x += 20;
                    spaceRec.Location = new Point(x, y);
                }

            }

            if (move == "left")
            {
                if (spaceRec.Location.X < 10) // is spaceship within 10 of left side
                {

                    x = 40;
                    spaceRec.Location = new Point(x, y);
                }
                else
                {
                    x -= 20;
                    spaceRec.Location = new Point(x, y);
                }

            }


        }


    }
}
