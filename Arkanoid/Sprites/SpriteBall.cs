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
            // Moves ball
            X += SpeedX;
            Y += SpeedY;

            // Updates speed
            if (X < 0)
                SpeedX = Constants.BallSpeed;
            else if (X > (Constants.CanvasWidth - Width))
                SpeedX = -Constants.BallSpeed;

            if (Y < 0)
                SpeedY = Constants.BallSpeed;
            else if (Y > (Constants.CanvasHeight - Height))
                SpeedY = -Constants.BallSpeed;

            // If falls below, marks it to be removed
            if (Bottom >= Constants.CanvasHeight)
                Alive = false;
        }

        public override void OnCollision(Game game, Sprite sprite)
        {
            switch (sprite)
            {
                // Bounces from brick
                case SpriteBrick _:
                    if (this.X < sprite.X || this.Right > sprite.Right)
                        SpeedX *= -1;

                    if (this.Y < sprite.Bottom || this.Bottom > sprite.Y)
                        SpeedY *= -1;
                    break;
                // Bounces from pad, only up
                case SpritePad _:
                    if (this.X < sprite.X || this.Right > sprite.Right)
                        SpeedX *= -1;

                    SpeedY = -Constants.BallSpeed;
                    break;
                // Destroyed  by rocket and bomb
                case SpriteRocket _:
                case SpriteBomb _:
                    Alive = false;
                    break;
            }
        }
    }
}
