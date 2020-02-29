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

            if (X < 0)
                SpeedX = Constants.BallSpeed;
            else if (X > (Constants.CanvasWidth - Width))
                SpeedX = -Constants.BallSpeed;

            if (Y < 0)
                SpeedY = Constants.BallSpeed;
            else if (Y > (Constants.CanvasHeight - Height))
                SpeedY = -Constants.BallSpeed;

            if (Bottom >= Constants.CanvasHeight)
                Alive = false;
        }

        public override void OnCollision(Game game, Sprite sprite)
        {
            if (sprite is SpriteBrick)
            {
                if (this.X < sprite.X || this.Right > sprite.Right)
                    SpeedX *= -1;

                if (this.Y < sprite.Bottom || this.Bottom > sprite.Y)
                    SpeedY *= -1;
            }
            else if (sprite is SpritePad)
            {
                if (this.X < sprite.X || this.Right > sprite.Right)
                    SpeedX *= -1;

                SpeedY = -Constants.BallSpeed;
            }
            else if (sprite is SpriteRocket)
            {
                Alive = false;
            }
        }
    }
}
