using System;
using System.Collections.Generic;
using System.Text;

namespace Arkanoid.Entities
{
    public class EntityPad : Entity
    {
        public EntityPad(double x, double y) : base(x, y)
        {
            this.Width = Constants.PadWidth;
            this.Height = Constants.PadHeight;

            LoadImage("Pad");
        }
    }
}
