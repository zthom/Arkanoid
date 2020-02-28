using System;
using System.Collections.Generic;
using System.Text;

namespace Arkanoid.Entities
{
    public class EntityBall : EntityMoving
    {
        private double SpeedX { get; set; }
        private double SpeedY { get; set; }

        public EntityBall(double x, double y) : base(x, y)
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
        }
    }
}
