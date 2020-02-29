using Arkanoid.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arkanoid.Sprites
{
    public class SpriteUfo : SpriteMoving
    {
        private double Speed { get; set; }
        private Random Rand { get; set; }

        public SpriteUfo(double x, double y) : base(x, y)
        {
            this.Width = Constants.UfoWidth;
            this.Height = Constants.UfoHeight;

            this.Speed = Constants.UfoSpeed;
            this.Rand = new Random();

            LoadImage("Ufo");
        }

        public override void Update(Game game)
        {
            // Movves UFO
            X += Speed;

            // Bouncing from sides
            if (X < 0)
                Speed = Constants.UfoSpeed;
            else if (X > (Constants.CanvasWidth - Width))
                Speed = -Constants.UfoSpeed;

            // Drops bomb
            if (Rand.Next(Constants.UfoBomb) == 0)
            {
                game.AddSprite(new SpriteBomb(this.X + this.Width / 2 - Constants.BombWidth / 2, this.Bottom + Constants.BombHeight));
            }
        }

        public override void OnCollision(Game game, Sprite sprite)
        {
            Alive = false;
        }
    }
}
