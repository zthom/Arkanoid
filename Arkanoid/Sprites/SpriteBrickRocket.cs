using Arkanoid.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arkanoid.Sprites
{
    public class SpriteBrickRocket : SpriteBrick
    {
        public SpriteBrickRocket(double x, double y) : base(x, y)
        {
            LoadImage("BrickRocket");
        }

        public override int Score => 3;

        public override void OnCollision(Game game, Sprite sprite)
        {
            base.OnCollision(game, sprite);

            if (sprite is SpriteBomb || sprite is SpriteRocket || sprite is SpriteBall)
                game.AddSprite(new SpriteBubbleRocket(this.X + this.Width / 2 - Constants.BubbleSize / 2, this.Bottom + Constants.BubbleSize));
        }
    }
}
