using Arkanoid.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arkanoid.Sprites
{
    public abstract class SpriteBubble : SpriteMoving
    {
        public SpriteBubble(double x, double y) : base(x, y)
        {
            this.Width = Constants.BubbleSize;
            this.Height = Constants.BubbleSize;
        }

        public override void Update(Game game)
        {
            Y += Constants.BubbleSpeed;

            if (Bottom > Constants.CanvasHeight)
                Alive = false;
        }

        public override void OnCollision(Game game, Sprite sprite)
        {
            if (sprite is SpriteRocket || sprite is SpritePad)
                Alive = false;
        }
    }
}
