using System;
using System.Collections.Generic;
using System.Text;

namespace Arkanoid.Logic
{
    public static class Constants
    {
        public static int CanvasWidth => 700;
        public static int CanvasHeight => 500;

        private static int DefaultSize => 50;

        public static int BrickWidth => DefaultSize;
        public static int BrickHeight => DefaultSize / 2;

        public static int PadWidth => DefaultSize * 2;
        public static int PadHeight => DefaultSize / 2;

        public static int RocketWidth => DefaultSize / 2;
        public static int RocketHeight => DefaultSize * 2;

        public static int BallSize => DefaultSize / 2;
        public static int BubbleSize => DefaultSize / 2;

        public static int BombWidth => DefaultSize / 2;
        public static int BombHeight => DefaultSize / 4;

        public static int UfoWidth => DefaultSize * 2;
        public static int UfoHeight => DefaultSize;

        private static int DefaultSpeed => 10;

        public static double PadSpeed => DefaultSpeed * 2;
        public static double BallSpeed => DefaultSpeed;
        public static double RocketSpeed => DefaultSpeed;
        public static double BubbleSpeed => DefaultSpeed;
        public static double BombSpeed => DefaultSpeed;
        public static double UfoSpeed => DefaultSpeed / 2;

        public static int UfoBomb => 50;
    }
}
