using Arkanoid.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arkanoid.Sprites
{
    public class SpriteRocket : SpriteMoving
    {
        public SpriteRocket(double x, double y) : base(x, y)
        {
            this.Width = Constants.RocketWidth;
            this.Height = Constants.RocketHeight;

            LoadImage("Rocket");
        }

        public override void Update(Game game)
        {
            Y -= Constants.RocketSpeed;

            if (Bottom < 0)
                Alive = false;
        }

        public override void OnCollision(Game game, Sprite sprite)
        {
            Alive = false;
        }
    }
}
