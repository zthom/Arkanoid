using System;
using System.Collections.Generic;
using System.Text;

namespace Arkanoid.Sprites
{
    public class SpriteBrickRocket : SpriteBrick
    {
        public SpriteBrickRocket(double x, double y) : base(x, y)
        {
            LoadImage("BrickRocket");
        }

        public override int Score => 3;
    }
}
