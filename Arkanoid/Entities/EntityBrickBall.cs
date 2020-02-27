using System;
using System.Collections.Generic;
using System.Text;

namespace Arkanoid.Entities
{
    public class EntityBrickBall : EntityBrick
    {
        public EntityBrickBall(double x, double y) : base(x, y)
        {
            LoadImage("BrickBall");
        }

        public override int Score => 10;
    }
}
