using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;

namespace Arkanoid.Sprites
{
    public abstract class Sprite : INotifyPropertyChanged
    {
        #region Properties
        private double x;
        public double X
        {
            get { return this.x; }
            protected set
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
            protected set
            {
                if (this.y != value)
                {
                    this.y = value;
                    this.NotifyPropertyChanged(nameof(Y));
                }
            }
        }

        public double Width { get; protected set; }
        public double Height { get; protected set; }
        public bool Alive { get; protected set; } = true;
        public double Right => X + Width;
        public double Bottom => Y + Height;

        public BitmapImage ImgSource { get; private set; }
        #endregion

        #region Change Handler
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        #endregion

        #region Functions
        public Sprite(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        protected void LoadImage(string imgName)
        {
            string path = System.Environment.CurrentDirectory + @"\Images\" + imgName + ".png";
            ImgSource = new BitmapImage(new Uri(path, UriKind.Absolute));
        }
        #endregion
    }
}
