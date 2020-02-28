using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Arkanoid.Entities
{
    public class EntityPad : EntityMoving
    {
        public EntityPad(double x, double y) : base(x, y)
        {
            this.Width = Constants.PadWidth;
            this.Height = Constants.PadHeight;

            LoadImage("Pad");
        }

        public override void Update(Game game)
        {
            if (game.KeyboardManager.IsPressed(Key.Left) && X > 0)
                X -= Constants.PadSpeed;
            else if (game.KeyboardManager.IsPressed(Key.Right) && X < (Constants.CanvasWidth - Constants.PadWidth))
                X += Constants.PadSpeed;
        }
    }
}
