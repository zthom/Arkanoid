using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Arkanoid.Sprites;

namespace Arkanoid.Logic
{
    public class Game
    {
        public ObservableCollection<Sprite> AllEntities { get; private set; } = new ObservableCollection<Sprite>();
        public KeyboardManager KeyboardManager { get; private set; } = new KeyboardManager();
        public Counter Counter { get; private set; } = new Counter();

        public GameState GameState => GetGameState();

        public Game()
        {
            Init();
        }

        public void Init()
        {
            AllEntities.Clear();
            Counter.Init();

            Random rand = new Random();

            for (int x = 0; x < Constants.CanvasWidth; x += Constants.BrickWidth)
            {
                for (int y = 100; y < 300; y += Constants.BrickHeight)
                {
                    int selected = rand.Next(20);

                    if (selected == 0)
                        AddSprite(new SpriteBrickBall(x, y));
                    else if (selected < 5)
                        AddSprite(new SpriteBrickRocket(x, y));
                    else if (selected < 10)
                        AddSprite(new SpriteBrickBlue(x, y));
                    else
                        AddSprite(new SpriteBrickGreen(x, y));
                }
            }

            AddSprite(new SpritePad(250, 460));

            AddSprite(new SpriteUfo(0, 10));
        }

        public void KillUfo()
        {
            var ufo = AllEntities.OfType<SpriteUfo>().FirstOrDefault();

            if (ufo != null)
                AllEntities.Remove(ufo);
        }

        public void AddSprite(Sprite sprite)
        {
            AllEntities.Add(sprite);
        }

        public void OnTick()
        {
            if (GameState == GameState.Running)
            {
                SolveCollisions();
                UpdateSprites();
                RemoveDeadSprites();
            }

            Counter.UpdateGameState(GameState);
        }

        private void SolveCollisions()
        {
            foreach (var sprite in AllEntities.OfType<SpriteMoving>().ToArray())
            {
                var collision = AllEntities.Where(x => x != sprite).FirstOrDefault(x => sprite.IsCollision(x));

                if (collision != null)
                {
                    sprite.OnCollision(this, collision);

                    if (collision is SpriteMoving == false)
                        collision.OnCollision(this, sprite);
                }
            }
        }

        private void UpdateSprites()
        {
            foreach (var sprite in AllEntities.OfType<SpriteMoving>().ToArray())
            {
                sprite.Update(this);
            }
        }

        private void RemoveDeadSprites()
        {
            foreach (var td in AllEntities.Where(x => !x.Alive).ToArray())
            {
                AllEntities.Remove(td);
            }
        }

        private GameState GetGameState()
        {
            if (!AllEntities.OfType<SpriteBrick>().Any() && !AllEntities.OfType<SpriteUfo>().Any())
                return GameState.Victory;
            else if (Counter.BallCounter <= 0 && !AllEntities.OfType<SpriteBall>().Any())
                return GameState.Defeat;
            else if (!AllEntities.OfType<SpritePad>().Any())
                return GameState.Defeat;

            return GameState.Running;
        }
    }
}
