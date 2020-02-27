using System;
using System.Collections.Generic;
using System.Text;

namespace Arkanoid.Entities
{
    public class EntityBrickBlue : EntityBrick
    {
        public EntityBrickBlue(double x, double y) : base(x, y)
        {
            LoadImage("BrickBlue");
        }

        public override int Score => 1;
    }
}
