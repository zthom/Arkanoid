using Arkanoid.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arkanoid.Sprites
{
    public abstract class SpriteBrick : Sprite
    {
        public SpriteBrick(double x, double y) : base(x, y)
        {
            this.Width = Constants.BrickWidth;
            this.Height = Constants.BrickHeight;
        }

        public abstract int Score { get; }

        public override void OnCollision(Game game, Sprite sprite)
        {
            if (sprite is SpriteBomb || sprite is SpriteRocket || sprite is SpriteBall)
                Alive = false;

            if (sprite is SpriteRocket || sprite is SpriteBall)
                game.Counter.ModifyScore(Score);
        }
    }
}
