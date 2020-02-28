using System;
using System.Collections.Generic;
using System.Text;

namespace Arkanoid.Sprites
{
    public class SpriteBrickBall : SpriteBrick
    {
        public SpriteBrickBall(double x, double y) : base(x, y)
        {
            LoadImage("BrickBall");
        }

        public override int Score => 10;
    }
}
