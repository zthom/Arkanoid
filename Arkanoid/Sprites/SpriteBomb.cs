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
            Y += Constants.BombSpeed;

            if (Bottom >= Constants.CanvasHeight)
                Alive = false;
        }

        public override void OnCollision(Game game, Sprite sprite)
        {
            Alive = false;
        }
    }
}
