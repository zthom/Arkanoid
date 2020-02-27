using System;
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
            AllEntities.Add(new EntityBrickBlue(50, 50));
        }
    }
}
