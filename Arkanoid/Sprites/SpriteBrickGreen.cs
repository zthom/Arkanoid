using System;
using System.Collections.Generic;
using System.Text;

namespace Arkanoid.Sprites
{
    public class SpriteBrickGreen : SpriteBrick
    {
        public SpriteBrickGreen(double x, double y) : base(x, y)
        {
            LoadImage("BrickGreen");
        }

        public override int Score => 2;
    }
}
