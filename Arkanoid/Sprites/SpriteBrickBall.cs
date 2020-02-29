using Arkanoid.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arkanoid.Sprites
{
    public class SpriteBrickBall : SpriteBrick
    {
        public SpriteBrickBall(double x, double y) : base(x, y)
        {
            LoadImage("BrickBall");
        }

        public override int Score => 10;

        public override void OnCollision(Game game, Sprite sprite)
        {
            base.OnCollision(game, sprite);

            // Generates bubble with ball
            if (sprite is SpriteBomb || sprite is SpriteRocket || sprite is SpriteBall)
                game.AddSprite(new SpriteBubbleBall(this.X + this.Width / 2 - Constants.BubbleSize / 2, this.Bottom + Constants.BubbleSize));
        }
    }
}
