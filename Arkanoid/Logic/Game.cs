using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using Arkanoid.Sprites;

namespace Arkanoid.Logic
{
    public class Game
    {
        public ObservableCollection<Sprite> AllEntities { get; private set; } = new ObservableCollection<Sprite>();
        public KeyboardManager KeyboardManager { get; private set; } = new KeyboardManager();
        public Counter Counter { get; private set; } = new Counter();

        public Game()
        {
            Random rand = new Random();

            for (int x = 0; x < Constants.CanvasWidth; x += Constants.BrickWidth)
            {
                for (int y = 100; y < 300; y += Constants.BrickHeight)
                {
                    int selected = rand.Next(20);

                    if (selected == 0)
                        AllEntities.Add(new SpriteBrickBall(x, y));
                    else if (selected < 5)
                        AllEntities.Add(new SpriteBrickRocket(x, y));
                    else if (selected < 10)
                        AllEntities.Add(new SpriteBrickBlue(x, y));
                    else
                        AllEntities.Add(new SpriteBrickGreen(x, y));
                }
            }

            AllEntities.Add(new SpritePad(250, 450));
            AllEntities.Add(new SpriteBall(250, 400));
        }

        public void OnTick()
        {
            foreach (var sprite in AllEntities.OfType<SpriteMoving>())
            {
                var collision = AllEntities.Where(x => x != sprite).FirstOrDefault(x => sprite.IsCollision(x));

                if (collision != null)
                {
                    sprite.OnCollision(this, collision);

                    if (collision is SpriteMoving == false)
                        collision.OnCollision(this, sprite);
                }

                sprite.Update(this);
            }

            foreach (var td in AllEntities.Where(x => !x.Alive).ToArray())
            {
                AllEntities.Remove(td);
            }
        }
    }
}
