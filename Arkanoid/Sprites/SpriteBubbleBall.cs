using System;
using System.Collections.Generic;
using System.Text;

namespace Arkanoid.Sprites
{
    public class SpriteBubbleBall : SpriteBubble
    {
        public SpriteBubbleBall(double x, double y) : base(x, y)
        {
            LoadImage("BubbleBall");
        }
    }
}
