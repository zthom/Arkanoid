using System;
using System.Collections.Generic;
using System.Text;

namespace Arkanoid.Entities
{
    public abstract class EntityBrick : Entity
    {
        public EntityBrick(double x, double y) : base(x, y)
        {
            this.Width = Constants.BrickWidth;
            this.Height = Constants.BrickHeight;
        }

        public abstract int Score { get; }
    }
}
