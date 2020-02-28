using Arkanoid.Logic;
using System;
using System.Collections.Generic;
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
        }
    }
}
