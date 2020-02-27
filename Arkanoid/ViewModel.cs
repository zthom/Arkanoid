using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Arkanoid
{
    public class ViewModel
    {
        public ObservableCollection<Entity> AllEntities { get; set; } = new ObservableCollection<Entity>();

        public ViewModel()
        {
            AllEntities.Add(new Entity { X = 10, Y = 20, Width = 100, Height = 25 });
        }
    }
}
