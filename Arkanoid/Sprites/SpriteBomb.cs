using Arkanoid.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arkanoid.Sprites
{
    public class SpriteBomb : SpriteMoving
    {
        public SpriteBomb(double x, double y) : base(x, y)
        {
            this.Width = Constants.BombWidth;
            this.Height = Constants.BombHeight;

            LoadImage("Bomb");
        }

        public override void Update(Game game)
        {
            // Moves bomb
            Y += Constants.BombSpeed;

            // If falls below, marks it to be removed
            if (Bottom >= Constants.CanvasHeight)
                Alive = false;
        }

        public override void OnCollision(Game game, Sprite sprite)
        {
            Alive = false;
        }
    }
}
