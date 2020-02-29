using Arkanoid.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arkanoid.Sprites
{
    public class SpriteBall : SpriteMoving
    {
        private double SpeedX { get; set; }
        private double SpeedY { get; set; }

        public SpriteBall(double x, double y) : base(x, y)
        {
            this.Width = Constants.BallSize;
            this.Height = Constants.BallSize;

            this.SpeedX = Constants.BallSpeed;
            this.SpeedY = -Constants.BallSpeed;

            LoadImage("Ball");
        }

        public override void Update(Game game)
        {
            X += SpeedX;
            Y += SpeedY;

            if (X < 0 || X > (Constants.CanvasWidth - Width))
                SpeedX *= -1;

            if (Y < 0 || Y > (Constants.CanvasHeight - Height))
                SpeedY *= -1;

            if (Bottom > Constants.CanvasHeight)
                Alive = false;
        }

        public override void OnCollision(Game game, Sprite sprite)
        {
            if (sprite is SpritePad || sprite is SpriteBrick)
            {
                if (this.X < sprite.X || this.Right > sprite.Right)
                    SpeedX *= -1;

                if (this.Y < sprite.Bottom || this.Bottom > sprite.Y)
                    SpeedY *= -1;
            }
            else if (sprite is SpriteRocket)
            {
                Alive = false;
            }
        }
    }
}
