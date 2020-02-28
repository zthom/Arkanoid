﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Arkanoid
{
    static class Constants
    {
        public static int CanvasWidth => 500;
        public static int CanvasHeight => 500;

        static int DefaultSize => 50;

        public static int BrickWidth => DefaultSize;
        public static int BrickHeight => DefaultSize / 2;

        public static int PadWidth => DefaultSize * 2;
        public static int PadHeight => DefaultSize / 2;
    }
}
