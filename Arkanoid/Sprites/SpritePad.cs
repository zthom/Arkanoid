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

            if (game.KeyboardManager.IsPressed(Key.LeftCtrl) && game.Counter.Rockets > 0 && !game.AllEntities.OfType<SpriteRocket>().Any())
            {
                game.Counter.ModifyRockets(-1);

                game.AddSprite(new SpriteRocket(this.X + this.Width / 2 - Constants.RocketWidth / 2, this.Y - Constants.RocketHeight));
            }

            if (game.KeyboardManager.IsPressed(Key.Space) && !game.AllEntities.OfType<SpriteBall>().Any())
            {
                game.AddSprite(new SpriteBall(this.X + this.Width / 2 - Constants.BallSize / 2, this.Y - Constants.BallSize));
            }
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
