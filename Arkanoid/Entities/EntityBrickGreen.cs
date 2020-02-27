using System;
using System.Collections.Generic;
using System.Text;

namespace Arkanoid.Entities
{
    public class EntityBrickGreen : EntityBrick
    {
        public EntityBrickGreen(double x, double y) : base(x, y)
        {
            LoadImage("BrickGreen");
        }

        public override int Score => 2;
    }
}
