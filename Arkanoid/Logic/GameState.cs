using System;
using System.Collections.Generic;
using System.Text;

namespace Arkanoid.Logic
{
    public enum GameState
    {
        /// <summary>
        /// Timer is updated, game in progress
        /// </summary>
        Running,

        /// <summary>
        /// Timer stopped, player won
        /// </summary>
        Victory,

        /// <summary>
        /// Timer stopped, player lost
        /// </summary>
        Defeat
    }
}
