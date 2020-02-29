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
        public RelayCommand CmdCheatRockets { get; private set; }
        public RelayCommand CmdRestart { get; private set; }

        public ViewModel()
        {
            Game = new Game();

            CmdCheatBalls = new RelayCommand((obj) => Game.Counter.ModifyBalls(100));
            CmdCheatRockets = new RelayCommand((obj) => Game.Counter.ModifyRockets(100));
            CmdRestart = new RelayCommand((obj) => Game.Init());
        }
    }
}
