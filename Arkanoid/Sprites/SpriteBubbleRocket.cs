using System;
using System.Collections.Generic;
using System.Text;

namespace Arkanoid.Sprites
{
    public class SpriteBubbleRocket : SpriteBubble
    {
        public SpriteBubbleRocket(double x, double y) : base(x, y)
        {
            LoadImage("BubbleRocket");
        }
    }
}
