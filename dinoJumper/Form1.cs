using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dinoJumper
{
    public partial class Form1 : Form
    {
        Rectangle player1 = new Rectangle(120, 370, 20, 20);

        List<Spikes> spike = new List<Spikes>();
        List<Bird> bird = new List<Bird>();
        List<longSpike> lSpike = new List<longSpike>();
        List<tallSpike> tSpike = new List<tallSpike>();


         Random randGen = new Random();


        public static int player1Speed = 5;
        public static int GroundSpikes = 20;
        public static int Birds = 20;
        public static int longSpike = 15;
        public static int tallSpike = 15;

        public static bool wDown = false;
        public static bool sDown = false;
        public static bool upArrowDown = false;
        public static bool downArrowDown = false;
        public static bool rightArrowDown = false;
        public static bool leftArrowDown = false;

        public static SolidBrush whiteBrush = new SolidBrush(Color.White);
        public static SolidBrush greenBrush = new SolidBrush(Color.Green);


        public static List<Rectangle> rightSpike = new List<Rectangle>();






        public static string gameState = "waiting";


        public Form1()
        {
            InitializeComponent();
        }

        public void GameInitialize()
        {
            startLabl.Text = "";


            gameTimer.Enabled = true;
            gameState = "running";
            this.Focus();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;


                case Keys.Space:
                    if (gameState == "waiting" || gameState == "over" || gameState == "Win" || gameState == "lost")

                    {

                        GameInitialize();

                    }

                    break;

                case Keys.Escape:

                    if (gameState == "waiting" || gameState == "over" || gameState == "Win" || gameState == "lost")

                    {

                        Application.Exit();

                    }

                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (downArrowDown == true && player1.Y > 0)
            {
                player1.Y += player1Speed;
            }

            if (upArrowDown == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y -= player1Speed;
            }
            if (rightArrowDown == true && player1.Y > 0)
            {
                player1.X += player1Speed;
            }
            if (leftArrowDown == true && player1.X < this.Width - player1.Width)
            {
                player1.X -= player1Speed;
            }

            GroundSpikes--;
            Birds --;
            tallSpike--;
            longSpike--;

            if(Birds == 0)
            {
               bird.Add(new Bird(1500, randGen.Next(340, 340)));
                Birds = 250;
            }
             
            foreach (Bird birds in bird)
            {
                birds.Move();
            }

            if (tallSpike == 0)
            {
                tSpike.Add(new tallSpike(1500, randGen.Next(340, 340)));
                tallSpike = 300;
            }

            foreach (tallSpike tspike in tSpike)
            {
                tspike.Move();
            }


            if (GroundSpikes == 0)
            {
                spike.Add(new Spikes(this.Width, randGen.Next(360, 360)));
                GroundSpikes = 150;
                //lineSpeeds.Add(randGen.Next(2, 10));
            }

            foreach (Spikes spikes in spike)
            {
                spikes.Move();
            }

           Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Spikes spikes in spike)
            {
                e.Graphics.FillRectangle(whiteBrush, spikes.x, spikes.y, spikes.size, spikes.size);
            }
            e.Graphics.FillRectangle(greenBrush, player1);


            foreach (Bird birds in bird)
            {
                e.Graphics.FillRectangle(whiteBrush, birds.x, birds.y, birds.size, birds.size);
            }
            foreach (tallSpike tspike in tSpike)
            {
                e.Graphics.FillRectangle(whiteBrush, tspike.x, tspike.y, tspike.height, tspike.width);
            }


        }
    }
}
