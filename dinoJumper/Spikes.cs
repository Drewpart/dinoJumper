using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dinoJumper
{
    internal class Spikes
    {

        public int size = 12;
        public int xSpeed = 8;
        public int x, y;

        public Spikes(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public void Move()
        {
            x -= xSpeed;

            //check if ball has reached right or left edge
            //if (x > screenSize.Width - size || x < 0)
            //{
            //    xSpeed *= -1; ;
            //}

        }
    }
}
