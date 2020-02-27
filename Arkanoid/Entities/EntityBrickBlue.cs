using System;
using System.Collections.Generic;
using System.Text;

namespace Arkanoid.Entities
{
    public class EntityBrickBlue : EntityBrick
    {
        public EntityBrickBlue(double x, double y)
        {
            this.X = x;
            this.Y = y;
            this.Width = 200;
            this.Height = 100;

            LoadImage("BrickBlue");
        }
    }
}
