using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Media.Imaging;

namespace Arkanoid
{
    public class Entity : INotifyPropertyChanged
    {
        #region Properties
        private double x;
        public double X
        {
            get { return this.x; }
            set
            {
                if (this.x != value)
                {
                    this.x = value;
                    this.NotifyPropertyChanged(nameof(X));
                }
            }
        }

        private double y;
        public double Y
        {
            get { return this.y; }
            set
            {
                if (this.y != value)
                {
                    this.y = value;
                    this.NotifyPropertyChanged(nameof(Y));
                }
            }
        }

        public double Width { get; set; }
        public double Height { get; set; }

        public BitmapImage ImgSource { get; set; }
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
