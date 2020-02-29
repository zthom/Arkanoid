using Arkanoid.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Arkanoid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Passes keyboard events to game
        /// </summary>
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Game game = ((ViewModel)DataContext).Game;
            game.KeyboardManager.KeyDown(e.Key);

            e.Handled = true;
        }

        /// <summary>
        /// Passes keyboard events to game
        /// </summary>
        private void Window_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            Game game = ((ViewModel)DataContext).Game;
            game.KeyboardManager.KeyUp(e.Key);
        }

        /// <summary>
        /// Starts game timer
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Game game = ((ViewModel)DataContext).Game;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = Constants.GameSpeed;
            timer.Tick += (s, e) => game.OnTick();
            timer.Start();
        }
    }
}
