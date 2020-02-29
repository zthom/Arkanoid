using Arkanoid.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Arkanoid.Sprites
{
    public class SpritePad : SpriteMoving
    {
        private bool CanRocket { get; set; }
        private bool CanBall { get; set; }

        public SpritePad(double x, double y) : base(x, y)
        {
            this.Width = Constants.PadWidth;
            this.Height = Constants.PadHeight;

            LoadImage("Pad");
        }

        public override void Update(Game game)
        {
            if (game.KeyboardManager.IsPressed(Key.Left) && X > 0)
                X -= Constants.PadSpeed;
            else if (game.KeyboardManager.IsPressed(Key.Right) && X < (Constants.CanvasWidth - Width))
                X += Constants.PadSpeed;

            if (game.KeyboardManager.IsPressed(Key.LeftCtrl) && CanRocket && game.Counter.Rockets > 0)
            {
                game.Counter.ModifyRockets(-1);
                game.AddSprite(new SpriteRocket(this.X + this.Width / 2 - Constants.RocketWidth / 2, this.Y - Constants.RocketHeight));
                CanRocket = false;
            }

            if (game.KeyboardManager.IsPressed(Key.Space) && CanBall && game.Counter.BallCounter > 0)
            {
                game.Counter.ModifyBalls(-1);
                game.AddSprite(new SpriteBall(this.X + this.Width / 2 - Constants.BallSize / 2, this.Y - Constants.BallSize));
                CanBall = false;
            }

            CanBall = !game.KeyboardManager.IsPressed(Key.Space) ? true : CanBall;
            CanRocket = !game.KeyboardManager.IsPressed(Key.LeftCtrl) ? true : CanRocket;
        }

        public override void OnCollision(Game game, Sprite sprite)
        {
            if (sprite is SpriteBubbleBall)
                game.Counter.ModifyBalls(1);
            else if (sprite is SpriteBubbleRocket)
                game.Counter.ModifyRockets(1);
        }
    }
}
