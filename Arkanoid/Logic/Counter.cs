using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Arkanoid.Logic
{
    public class Counter : INotifyPropertyChanged
    {
        #region Properties
        private int ballCounter;
        public int BallCounter
        {
            get { return this.ballCounter; }
            protected set
            {
                if (this.ballCounter != value)
                {
                    this.ballCounter = value;
                    this.NotifyPropertyChanged(nameof(BallCounter));
                }
            }
        }

        private int score;
        public int Score
        {
            get { return this.score; }
            protected set
            {
                if (this.score != value)
                {
                    this.score = value;
                    this.NotifyPropertyChanged(nameof(Score));
                }
            }
        }

        private int rockets;
        public int Rockets
        {
            get { return this.rockets; }
            protected set
            {
                if (this.rockets != value)
                {
                    this.rockets = value;
                    this.NotifyPropertyChanged(nameof(Rockets));
                }
            }
        }

        private GameState gameState;
        public GameState GameState
        {
            get { return this.gameState; }
            protected set
            {
                if (this.gameState != value)
                {
                    this.gameState = value;
                    this.NotifyPropertyChanged(nameof(GameState));
                }
            }
        }
        #endregion

        #region Functions
        public Counter()
        {
            Init();
        }

        public void Init()
        {
            Rockets = 0;
            BallCounter = 10;
            Score = 0;
        }

        public void ModifyScore(int amount)
        {
            Score += amount;
        }

        public void ModifyBalls(int amount)
        {
            BallCounter += amount;
        }

        public void ModifyRockets(int amount)
        {
            Rockets += amount;
        }

        public void UpdateGameState(GameState newState)
        {
            GameState = newState;
        }
        #endregion

        #region Change Handler
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        #endregion
    }
}
