using System;
using System.Collections.Generic;
using System.Text;

namespace Arkanoid.Entities
{
    public abstract class EntityMoving : Entity
    {
        public EntityMoving(double x, double y) : base(x, y)
        {
        }

        public abstract void Update(Game game);
    }
}
