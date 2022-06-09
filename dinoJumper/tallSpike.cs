using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dinoJumper
{
    internal class tallSpike
    {
        public int height = 12;
        public int width = 30;
        public int xSpeed = 7;
        public int x, y;

        public tallSpike(int _x, int _y)
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
