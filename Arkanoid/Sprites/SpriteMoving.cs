using Arkanoid.Logic;
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

        /// <summary>
        /// Moves sprites and updates speed and logic
        /// </summary>
        public abstract void Update(Game game);

        /// <summary>
        /// Checks if there is collision between two sprites
        /// </summary>
        /// <param name="sprite">Other sprite to check</param>
        /// <returns>Collided or not</returns>
        public bool IsCollision(Sprite sprite)
        {
            return this.X < sprite.Right &&
                sprite.X < this.Right &&
                this.Y < sprite.Bottom &&
                sprite.Y < this.Bottom;
        }
    }
}
