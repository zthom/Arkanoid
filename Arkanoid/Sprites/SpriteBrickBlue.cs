using System;
using System.Collections.Generic;
using System.Text;

namespace Arkanoid.Sprites
{
    public class SpriteBrickBlue : SpriteBrick
    {
        public SpriteBrickBlue(double x, double y) : base(x, y)
        {
            LoadImage("BrickBlue");
        }

        public override int Score => 1;
    }
}
