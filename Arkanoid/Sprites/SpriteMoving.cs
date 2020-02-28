using System;
using System.Collections.Generic;
using System.Text;

namespace Arkanoid.Sprites
{
    public abstract class SpriteMoving : Sprite
    {
        public SpriteMoving(double x, double y) : base(x, y)
        {
        }

        public abstract void Update(Game game);

        public virtual void OnCollision(Sprite sprite) { }

        public bool IsCollision(Sprite sprite)
        {
            return this.X < sprite.Right &&
                sprite.X < this.Right &&
                this.Y < sprite.Bottom &&
                sprite.Y < this.Bottom;
        }
    }
}
