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
            // Moves rocket
            Y -= Constants.RocketSpeed;

            // If flies over screen, marks it to be removed
            if (Y < 0)
                Alive = false;
        }

        public override void OnCollision(Game game, Sprite sprite)
        {
            // Destroyed by everything except other rocket, to prevent destruction by fast rocket launching
            if (sprite is SpriteRocket == false)
                Alive = false;
        }
    }
}
