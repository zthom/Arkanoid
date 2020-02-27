﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Media.Imaging;
using Arkanoid.Entities;

namespace Arkanoid
{
    public class ViewModel
    {
        public ObservableCollection<Entity> AllEntities { get; set; } = new ObservableCollection<Entity>();

        public ViewModel()
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
        }
    }
}
