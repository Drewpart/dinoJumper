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
        List<Border> borders = new List<Border>();

        Boolean jumping = false;

        Random randGen = new Random();

        public static int highscore = 0;
        public static int player1Speed = 5;
        public static int GroundSpikes = 20;
        public static int Birds = 20;
        public static int longSpike = 15;
        public static int tallSpike = 15;
        public static int borderLine = 15;
        public static int counter = 0;

        public static bool wDown = false;
        public static bool sDown = false;
        public static bool upArrowDown = false;
        public static bool downArrowDown = false;
        public static bool rightArrowDown = false;
        public static bool leftArrowDown = false;

        public static SolidBrush whiteBrush = new SolidBrush(Color.White);
        public static SolidBrush greenBrush = new SolidBrush(Color.Green);
        public static SolidBrush blueBrush = new SolidBrush(Color.Blue);


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
            highscore++;

            if (downArrowDown == true && player1.Y > 0)
            {
                player1.Y += player1Speed;
            }

            if (upArrowDown == true && jumping == false) // and jumping is false
            {
                //player1.Y -= player1Speed;
                jumping = true;
            }
            if (rightArrowDown == true && player1.Y > 0)
            {
                player1.X += player1Speed;
            }
            if (leftArrowDown == true && player1.X < this.Width - player1.Width)
            {
                player1.X -= player1Speed;
            }


            if (jumping == true)
            {
                if (counter < 12)
                {
                    player1.Y -= player1Speed;
                }
                else
                {
                    player1.Y += player1Speed;
                }
                counter++;

                if (counter == 24)
                {
                    counter = 0;
                    jumping = false;
                }
            }


            // if jumping is true
            // if counter less than 4 make player go up
            // else  make player go down
            // add 1 to the counter
            // if counter gets to 8 reset it back to 0 and make jummping false

            GroundSpikes--;
            Birds--;
            tallSpike--;
            longSpike--;

            highscoreLabel.Text = Convert.ToString(highscore);

            highscoreLabel.Text = $"{highscore}";

            if (longSpike == 0)
            {
                lSpike.Add(new longSpike(this.Width, randGen.Next(360, 360)));
                longSpike = randGen.Next(600, 700);
            }
            foreach (longSpike lspike in lSpike)
            {
                lspike.Move();
            }

            if (Birds == 0)
            {
                bird.Add(new Bird(this.Width, randGen.Next(320, 320)));
                Birds = randGen.Next(700, 750);
            }

            foreach (Bird birds in bird)
            {
                birds.Move();
            }

            if (tallSpike == 0)
            {
                tSpike.Add(new tallSpike(1500, randGen.Next(370, 370)));
                tallSpike = randGen.Next(500, 900);
            }

            foreach (tallSpike tspike in tSpike)
            {
                tspike.Move();
            }


            if (GroundSpikes == 0)
            {
                spike.Add(new Spikes(this.Width, randGen.Next(360, 360)));
                GroundSpikes = randGen.Next(40, 50);
                //lineSpeeds.Add(randGen.Next(2, 10));
            }

            foreach (Spikes spikes in spike)
            {
                spikes.Move();
            }

            if (borderLine == 0)
            {
                borders.Add(new Border(this.Width, randGen.Next(300, 300)));
                borderLine = 10;
                //lineSpeeds.Add(randGen.Next(2, 10));
            }

            foreach (Border borders in borders)
            {
                borders.Move();
            }

            foreach (Spikes spikes in spike)
            {
                Rectangle s = new Rectangle(spikes.x, spikes.y, spikes.size, spikes.size);

                if (player1.IntersectsWith(s))
                {
                    player1.X = 120;
                    player1.Y = 370;

                    counter = 0;
                    jumping = false;

                    gameState = "Lost";
                    startLabl.Text = "  Press Space        to Start";
                    highscore = 0;

                }
            }
            foreach (tallSpike tspike in tSpike)
            {
                Rectangle ts = new Rectangle(tspike.x, tspike.y, tspike.height, tspike.width);

                if (player1.IntersectsWith(ts))
                {
                    player1.X = 120;
                    player1.Y = 370;

                    counter = 0;
                    jumping = false;

                    gameState = "Lost";
                    startLabl.Text = "  Press Space        to Start";
                    highscore = 0;


                }
                foreach (Bird birds in bird)
                {
                    Rectangle b = new Rectangle(tspike.x, tspike.y, tspike.height, tspike.width);

                    if (player1.IntersectsWith(b))
                    {
                        player1.X = 120;
                        player1.Y = 370;

                        counter = 0;
                        jumping = false;

                        gameState = "Lost";
                        startLabl.Text = "  Press Space        to Start";
                        highscore = 0;



                    }
                    foreach (longSpike lspike in lSpike)
                    {
                        Rectangle ls = new Rectangle(tspike.x, tspike.y, tspike.height, tspike.width);

                        if (player1.IntersectsWith(ls))
                        {
                            player1.X = 120;
                            player1.Y = 370;

                            counter = 0;
                            jumping = false;

                            gameState = "Lost";
                            startLabl.Text = "  Press Space        to Start";

                            gameTimer.Enabled = false;

                            highscore = 0;

                        }
                        if (gameState == "Lost")
                        {
                            Form form = this.FindForm();
                            endScreen go = new endScreen();
                            form.Controls.Add(go);
                           // form.Controls.Remove(this);

                        }
                    }

                    Refresh();
                }
            }
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

            foreach(longSpike lspike in lSpike)

            {
                e.Graphics.FillRectangle(whiteBrush, lspike.x, lspike.y, lspike.height, lspike.width);

            }
            foreach(Border borders in borders)
                {
                e.Graphics.FillRectangle(blueBrush, borders.x, borders.y, borders.size, borders.size);
            }



        }
    }
}
