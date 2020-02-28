using Arkanoid.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arkanoid
{
    public class ViewModel
    {
        public Game Game { get; private set; }
        public RelayCommand CmdCheatBalls { get; private set; }
        public RelayCommand CmdCheatRocket { get; private set; }

        public ViewModel()
        {
            Game = new Game();

            CmdCheatBalls = new RelayCommand((obj) => Game.Counter.CheatBalls());
            CmdCheatRocket = new RelayCommand((obj) => Game.Counter.CheatRockets());
        }
    }
}
