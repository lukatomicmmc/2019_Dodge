using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2019_Dodge
{
    public partial class FrmDoge : Form
    {
        Graphics g; //declare a graphics object called g
        // declare space for an array of 7 objects called planet 
        Planet[] planet = new Planet[7];
        Random yspeed = new Random();
        Spaceship spaceship = new Spaceship();
        bool left, right;
        int score, lives;
        int scorelvl = 1;
        string move;



        public FrmDoge()
        {
            InitializeComponent();
            for (int i = 0; i < 7; i++)
            {
                int x = 10 + (i * 75);
                planet[i] = new Planet(x);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Use the left and right arrow keys to move the spaceship. \n Don't get hit by the planets! \n Every planet that gets past scores a point. \n If a planet hits a spaceship a life is lost! \n \n Enter your Name press tab and enter the number of lives \n Click Start to begin", "Game Instructions");
            txtName.Focus();

        }

        private void PnlGame_Paint(object sender, PaintEventArgs e)
        {
            //get the graphics used to paint on the panel control
            g = e.Graphics;
            for (int i = 0; i < 7; i++)
            {
                // generate a random number from 5 to 20 and put it in rndmspeed
                int rndmspeed = yspeed.Next(1, 30);
                int speed = rndmspeed + 5 * scorelvl;
                planet[i].y += speed;
                
                //call the Planet class's drawPlanet method to draw the images
                planet[i].drawPlanet(g);
            }
            spaceship.drawSpaceship(g);


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmDoge_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { left = false; }
            if (e.KeyData == Keys.Right) { right = false; }

        }

        private void FrmDoge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { left = true; }
            if (e.KeyData == Keys.Right) { right = true; }

        }

        private void tmrShip_Tick(object sender, EventArgs e)
        {
            if (right) // if right arrow key pressed
            {
                move = "right";
                spaceship.moveSpaceship(move);
            }
            if (left) // if left arrow key pressed
            {
                move = "left";
                spaceship.moveSpaceship(move);
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void mnuStart_Click(object sender, EventArgs e)
        {
            score = 0;
            lblScore.Text = score.ToString();
            lblScoreLevel.Text = scorelvl.ToString();
            lives = int.Parse(txtLives.Text);// pass lives entered from textbox to lives variable
            tmrPlanet.Enabled = true;
            tmrShip.Enabled = true;

        }

        private void mnuStop_Click(object sender, EventArgs e)
        {
            tmrShip.Enabled = false;
            tmrPlanet.Enabled = false;

        }

        private void txtName_Click(object sender, EventArgs e)
        {

        }

        private void tmrPlanet_Tick(object sender, EventArgs e)
        {
            score = 0;
            for (int i = 0; i < 7; i++)
            {
                planet[i].movePlanet();
                if (spaceship.spaceRec.IntersectsWith(planet[i].planetRec))
                {
                    //reset planet[i] back to top of panel
                    planet[i].y = 30; // set  y value of planetRec
                    lives -= 1;// lose a life
                    txtLives.Text = lives.ToString();// display number of lives
                    checkLives();
                }

                score += planet[i].score;// get score from Planet class (in movePlanet method)
                lblScore.Text = score.ToString();// display score


                if (score > 49)
                {
                    score = 0;
                    scorelvl += 1;
                    lives += 1;
                }
                lblScoreLevel.Text = scorelvl.ToString();
            }
            PnlGame.Invalidate();//makes the paint event fire to redraw the panel
        }
        private void checkLives()
        {
            if (lives == 0)
            {
                tmrPlanet.Enabled = false;
                tmrShip.Enabled = false;
                MessageBox.Show("Game Over");

            }
        }

    }
}
