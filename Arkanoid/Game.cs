using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using Arkanoid.Entities;

namespace Arkanoid
{
    public class Game
    {
        public ObservableCollection<Entity> AllEntities { get; private set; } = new ObservableCollection<Entity>();
        public KeyboardManager KeyboardManager { get; private set; } = new KeyboardManager();

        public Game()
        {
            Random rand = new Random();

            for (int x = 0; x < Constants.CanvasWidth; x += Constants.BrickWidth)
            {
                for (int y = 100; y < 300; y += Constants.BrickHeight)
                {
                    int selected = rand.Next(20);

                    if (selected == 0)
                        AllEntities.Add(new EntityBrickBall(x, y));
                    else if (selected < 5)
                        AllEntities.Add(new EntityBrickRocket(x, y));
                    else if (selected < 10)
                        AllEntities.Add(new EntityBrickBlue(x, y));
                    else
                        AllEntities.Add(new EntityBrickGreen(x, y));
                }
            }

            AllEntities.Add(new EntityPad(250, 450));
        }

        public void OnTick()
        {
            foreach (var obj in AllEntities.OfType<EntityMoving>())
            {
                obj.Update(this);
            }

            foreach (var td in AllEntities.Where(x => !x.Alive).ToArray())
            {
                AllEntities.Remove(td);
            }
        }
    }
}
