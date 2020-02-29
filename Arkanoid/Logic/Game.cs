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
    /// <summary>
    /// Main logic for all objects in game
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Collections of all game objects
        /// </summary>
        public ObservableCollection<Sprite> AllSprites { get; private set; } = new ObservableCollection<Sprite>();

        /// <summary>
        /// State of keyboard keys
        /// </summary>
        public KeyboardManager KeyboardManager { get; private set; } = new KeyboardManager();

        /// <summary>
        /// Game score, balls and rockets
        /// </summary>
        public Counter Counter { get; private set; } = new Counter();

        /// <summary>
        /// Actual game state
        /// </summary>
        public GameState GameState => GetGameState();

        public Game()
        {
            Init();
        }

        /// <summary>
        /// (Re)sets game objects and counter
        /// </summary>
        public void Init()
        {
            AllSprites.Clear();
            Counter.Init();

            Random rand = new Random();

            // Generates random bricks
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

            // Pad and ufo
            AddSprite(new SpritePad(250, 460));
            AddSprite(new SpriteUfo(0, 10));
        }

        public void KillUfo()
        {
            var ufo = AllSprites.OfType<SpriteUfo>().FirstOrDefault();

            if (ufo != null)
                AllSprites.Remove(ufo);
        }

        public void AddSprite(Sprite sprite)
        {
            AllSprites.Add(sprite);
        }

        public void OnTick()
        {
            // If game is not won or lost
            if (GameState == GameState.Running)
            {
                SolveCollisions();
                UpdateSprites();
                RemoveDeadSprites();
            }

            // Game state is edited also in View
            Counter.UpdateGameState(GameState);
        }

        private void SolveCollisions()
        {
            foreach (var sprite in AllSprites.OfType<SpriteMoving>().ToArray())
            {
                var collision = AllSprites.Where(x => x != sprite).FirstOrDefault(x => sprite.IsCollision(x));

                if (collision != null)
                {
                    sprite.OnCollision(this, collision);

                    // Moving sprites generates their own collision, so collision is not triggered twice
                    if (collision is SpriteMoving == false)
                        collision.OnCollision(this, sprite);
                }
            }
        }

        private void UpdateSprites()
        {
            foreach (var sprite in AllSprites.OfType<SpriteMoving>().ToArray())
            {
                sprite.Update(this);
            }
        }

        private void RemoveDeadSprites()
        {
            foreach (var td in AllSprites.Where(x => !x.Alive).ToArray())
            {
                AllSprites.Remove(td);
            }
        }

        /// <summary>
        /// Victory - no UFOs and bricks
        /// Defeat - no balls or pad destroyed by bomb
        /// </summary>
        /// <returns></returns>
        private GameState GetGameState()
        {
            if (!AllSprites.OfType<SpriteBrick>().Any() && !AllSprites.OfType<SpriteUfo>().Any())
                return GameState.Victory;
            else if (Counter.BallCounter <= 0 && !AllSprites.OfType<SpriteBall>().Any())
                return GameState.Defeat;
            else if (!AllSprites.OfType<SpritePad>().Any())
                return GameState.Defeat;

            return GameState.Running;
        }
    }
}
