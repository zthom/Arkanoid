using System;
using System.Collections.Generic;
using System.Text;

namespace Arkanoid.Entities
{
    public class EntityBrickRocket : EntityBrick
    {
        public EntityBrickRocket(double x, double y) : base(x, y)
        {
            LoadImage("BrickRocket");
        }

        public override int Score => 3;
    }
}
