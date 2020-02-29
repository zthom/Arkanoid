using System;
using System.Collections.Generic;
using System.Text;

namespace Arkanoid.Logic
{
    static class Constants
    {
        public static int CanvasWidth => 700;
        public static int CanvasHeight => 500;

        static int DefaultSize => 50;

        public static int BrickWidth => DefaultSize;
        public static int BrickHeight => DefaultSize / 2;

        public static int PadWidth => DefaultSize * 2;
        public static int PadHeight => DefaultSize / 2;

        public static int RocketWidth => DefaultSize / 2;
        public static int RocketHeight => DefaultSize * 2;

        public static int BallSize => DefaultSize / 2;
        public static int BubbleSize => DefaultSize / 2;

        public static double PadSpeed => 20;
        public static double BallSpeed => 10;
        public static double RocketSpeed => 10;
        public static double BubbleSpeed => 10;
    }
}
